/*
 * Created by Ranorex
 * User: Administrator
 * Date: 5/6/2014
 * Time: 7:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Globalization.Framework;
using ITBM.UI;

namespace ITBM
{
    /// <summary>
    /// Description of VCAC_SSO.
    /// </summary>
    [TestModule("B664AB9F-0168-4138-8D53-E628254B7EA2", ModuleType.UserCode, 1)]
    public class VCAC_SSO : ITestModule
    {	
    	deleDeploy deleVcac,deleSso;
    	IAsyncResult irs1,irs2;
    	
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            Element elm;
  			
            Solution.configff();
            
            //前期操作：把ova文件所在的路径自动映射成本地的磁盘
            #region auto Map the network path
            string MapPath=Config.ReallyBuildPath;    
            Report.Info("MapPath="+MapPath);     
			if(System.IO.Directory.Exists(Config.BuildPath)){
            	Report.Info(Config.BuildPath+" is exist,Start to delete the Network Path");
            	SystemCmd delcmd = new SystemCmd("net","use" +" "+Config.BuildPath+" "+"/D");
				int delresult = delcmd.Execute();
				if(delresult !=0){
						Report.Info("Delete "+Config.BuildPath +" failed.");
						throw new Exception("Delete "+Config.BuildPath +" failed.");	
				}else{
						Report.Info("Delete "+Config.BuildPath +" successfully.");
				}
            }
			Report.Info("Start to map the Network Path");	
			SystemCmd mapcmd = new SystemCmd("net","use" +" "+Config.BuildPath+" "+MapPath+ " " +Config.Password+" /USER:"+Config.UserName); 
			int mapresult = mapcmd.Execute();
			if(mapresult !=0){
				Report.Info("map failed");
				throw new Exception("The "+MapPath+" is not mapped to "+Config.BuildPath+" successfully!!!,please check it.");	
			}else{
				Report.Info("The "+MapPath+" is mapped to "+Config.BuildPath+" successfully!!!");
			}
	
            if(!(System.IO.File.Exists(MapPath+@"\"+Config.VCACOVFName)&&System.IO.File.Exists(MapPath+@"\"+Config.SSOOVFName))){
            		throw new Exception("Can not find the files:\"" + Config.VCACOVFName +"\""+" and \""+ Config.SSOOVFName+"\" in"+ MapPath+". Please check it.");
			}else{
				Report.Info("Find the files:\"" + Config.VCACOVFName +"\""+" and \""+ Config.SSOOVFName+"\" in "+"\"" +MapPath+"\""+".");
			}
			Delay.Seconds(5);
			#endregion
			
			string VCAC = Config.VCACParam +" "+ Config.BuildPath+@"\"+Config.VCACOVFName + " " + Config.VMLocation;
			string SSO = Config.SSOParam +" " + Config.BuildPath+@"\"+Config.SSOOVFName + " " +  Config.VMLocation;
			
            //第一步，配置vm虚拟机，并启动。
			# region Deploy Vcac +  SSO	
		    if(Config.DepolyVcac){
		    	deleVcac = new deleDeploy(AutoDeploy.startDeploy);
			 	irs1 = deleVcac.BeginInvoke(VCAC,null,null);
		    }

		    if(Config.DepolySSO){
		    	deleSso = new deleDeploy(AutoDeploy.startDeploy);
				irs2 = deleSso.BeginInvoke(SSO,null,null);
		    }

		    string vcacExitCode = "EndDeploy", ssoExitCode = "EndDeploy";
		    if(Config.DepolyVcac){
		    	vcacExitCode = deleVcac.EndInvoke(irs1);
		    }
		    if(Config.DepolySSO){
		    	ssoExitCode = deleSso.EndInvoke(irs2);
		    }

		    if(vcacExitCode != "EndDeploy" || ssoExitCode !="EndDeploy" ){
		    	
		    	Console.WriteLine("部署没有完成");
		    }
		    if(Config.DepolyVcac|Config.DepolySSO){
		    	Delay.Seconds(180);
		    }	
			# endregion
			
			//第二步，根据 预设的虚拟机名 以及 VC 信息 去判断VM是否完全启动，并获取 HostName 和 IP
			#region	 Collect  vcac + SSO hsotname & static ip
			string VCACHostName = Config.VCACHostName;
			string VCACIP = Config.VCACIP;
			string SSOHostName = Config.SSOHostName;
			string SSOIP = Config.SSOIP;
			#endregion
			
			//第三步，根据获取到的VM IP，去操作Plink 实现对VM 命令行的配置
			# region Config SSL and SSO
			//Delay.Seconds(120);
			if (Config.DepolyVcac | Config.DepolySSO | Config.ConfigSSLSSO) {
				int configSSO1ExitCode = DeployOvaTool.plinkMethod(Config.PlinkParam1 + SSOIP + " exit","y");
				if( configSSO1ExitCode!= 0 ){
					throw new System.Exception("The exit code for command " + Config.PlinkParam1 + SSOIP + " exit\" return "+ configSSO1ExitCode.ToString() + "." );
				}
				string[] lines = { @"echo $'\r' >> /etc/hosts",
					@"echo """ + VCACIP + " " + VCACHostName + "\"" + " >> /etc/hosts",
					@"/usr/lib/vmware-identity-va-mgmt/firstboot/vmware-identity-va-firstboot.sh --domain vsphere.local --password " + Config.VCPassword,
					@"echo ""$(hostname)"" > /etc/vmware-identity/hostname.txt"};
				System.IO.File.WriteAllLines(@"s.txt", lines);
				int configSSO2ExitCode = DeployOvaTool.plinkMethod(Config.PlinkParam2 + SSOIP);
				if(configSSO2ExitCode != 0 ){
					throw new System.Exception("The exit code for command " + Config.PlinkParam2 + SSOIP + "\" return "+ configSSO2ExitCode.ToString() + "." );
				}  
			  # endregion	
			  
			//第四步，根据获取到的HostName ，实现对5480端口的 URL进行配置
			#region Deploy on URL
				//change sso time zone
				Delay.Seconds(1);
				Host.Local.OpenBrowser(UI.LC.VCAC.ssourlRoot,"firefox","",true,true);
				Delay.Seconds(1);
				Solution.allowFirefoxAccess();
				Delay.Seconds(2);
				Solution.text22Adapter("root",UI.UI.vcac.ssowebElmUserNameUI);
				Delay.Seconds(2);
				Solution.text22Adapter("@WSX3edc",UI.UI.vcac.ssowebElmPasswordUI);
				Delay.Seconds(1);
				UI.UI.vcac.ssowebElmPasswordUI.PressKeys("{Enter}");
				Delay.Seconds(1);
				Solution.waitforIEComplete(UI.UI.vcac.ssoxPathRoot5480UI);
				Delay.Seconds(1);
				Solution.waitforElmDisappear(UI.LC.VCAC.xPathLoadingIcon,3000);
				Delay.Seconds(2);			
				UI.UI.vcac.ssowebElmSystem.Click();
				Delay.Seconds(1);
				Solution.waitforIEComplete(UI.UI.vcac.ssoxPathRoot5480UI);
				Delay.Seconds(1);
				UI.UI.vcac.ssowebElmTimeZone.Click();
				Delay.Seconds(1);
				Solution.waitforIEComplete(UI.UI.vcac.ssoxPathRoot5480UI);
				Delay.Seconds(1);
				UI.UI.vcac.ssowebElmSystemTimeZone.Click();
				Solution.waitforIEComplete(UI.UI.vcac.ssoxPathRoot5480UI);
				UI.UI.vcac.ssoxPathRoot5480UI.PressKeys("{home}");
				UI.UI.vcac.ssoxPathRoot5480UI.PressKeys("{pagedown 14}");
				Delay.Seconds(1);
				UI.UI.vcac.ssowebElmAsiashanghaiItem.Click();
				Solution.waitforIEComplete(UI.UI.vcac.ssoxPathRoot5480UI);
				Delay.Seconds(1);
				UI.UI.vcac.ssowebElmTimeZone_SaveSettingsButton.Click();
				Host.Local.TryFindSingle(UI.LC.VCAC.ssowebElmTimeZone_SaveSettingsSaved,60000,out elm);
				Delay.Seconds(2);
				UI.UI.vcac.ssowebElmTimeZone_ssoLogout.Click();
				Solution.waitforIEComplete(UI.UI.vcac.ssoxPathRoot5480UI);
				Host.Local.TryFindSingle(UI.LC.VCAC.ssowebElmUserName,60000,out elm);
				Delay.Seconds(1);
				Host.Local.KillBrowser("firefox");	
							
				Delay.Seconds(5);
				Host.Local.OpenBrowser(UI.LC.VCAC.urlRoot,"firefox","",true,true);
				Delay.Seconds(1);
				Solution.allowFirefoxAccess();
				Delay.Seconds(2);
				Solution.text22Adapter("root",UI.UI.vcac.webElmUserNameUI);
				Delay.Seconds(2);
				Solution.text22Adapter("@WSX3edc",UI.UI.vcac.webElmPasswordUI);
				Delay.Seconds(1);
				UI.UI.vcac.webElmPasswordUI.PressKeys("{Enter}");
				Delay.Seconds(1);
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				Delay.Seconds(1);
				Solution.waitforElmDisappear(UI.LC.VCAC.xPathLoadingIcon,3000);
				Delay.Seconds(2);			
				UI.UI.vcac.webElmSystem.Click();
				Delay.Seconds(1);
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				Delay.Seconds(1);
				UI.UI.vcac.webElmTimeZone.Click();
				Delay.Seconds(1);
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				Delay.Seconds(1);
				UI.UI.vcac.webElmSystemTimeZone.Click();
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				UI.UI.vcac.xPathRoot5480UI.PressKeys("{home}");
				UI.UI.vcac.xPathRoot5480UI.PressKeys("{pagedown 14}");
				Delay.Seconds(1);
				UI.UI.vcac.webElmAsiashanghaiItem.Click();
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				Delay.Seconds(1);
				UI.UI.vcac.webElmTimeZone_SaveSettingsButton.Click();
				Host.Local.TryFindSingle(UI.LC.VCAC.webElmTimeZone_SaveSettingsSaved,60000,out elm);
				Delay.Seconds(2);
				UI.UI.vcac.webElmVcacSetingsUI.Click();
				Delay.Seconds(1);
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				Delay.Seconds(2);
				Solution.text22Adapter(VCACHostName,UI.UI.vcac.webElmVcacHostNameUI);
				Delay.Seconds(2);
				UI.UI.vcac.webElmSaveSettingsUI.Click();
				Delay.Seconds(1);
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				Delay.Seconds(1);
				Solution.waitforElmDisappear(UI.LC.VCAC.xPathLoadingIcon,3000);
				Delay.Seconds(2);
				UI.UI.vcac.webElmSSLUI.Click();
				Delay.Seconds(1);
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				Delay.Seconds(1);
				Solution.waitforElmDisappear(UI.LC.VCAC.xPathLoadingIcon,3000);
				Delay.Seconds(5);
				UI.UI.vcac.webElmChooseActionUI.Click();
				Delay.Seconds(2);
				UI.UI.vcac.webElmGenerateSelfSignedCertificateUI.Click();
				Delay.Seconds(1);
				Solution.text22Adapter(VCACHostName,UI.UI.vcac.webElmCommonNameUI);
				Solution.text22Adapter(Config.Organisation,UI.UI.vcac.webElmOrganizationUI);
				Solution.text22Adapter(Config.OrganisationalUnit,UI.UI.vcac.webElmOrganizationalUnitUI);
				Solution.text22Adapter(Config.CountryCode,UI.UI.vcac.webElmCountryCodeUI);
				Delay.Seconds(2);
				UI.UI.vcac.webElmReplaceCertificateUI.Click();
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				Solution.waitforElmDisappear(UI.LC.VCAC.xPathLoadingIcon,3000);
				Delay.Seconds(2);
				UI.UI.vcac.webElmSSOUI.Click();
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				Solution.waitforElmDisappear(UI.LC.VCAC.xPathLoadingIcon,3000);
				Solution.text22Adapter(SSOHostName+":7444",UI.UI.vcac.webElmHostAndPortUI);
				Solution.text22Adapter("administrator@vsphere.local",UI.UI.vcac.webElmAdminUserUI);
				//Solution.text22Adapter("vmware",UI.UI.vcac.webElmAdminPasswordUI);
				Solution.text22Adapter(Config.VCPassword,UI.UI.vcac.webElmAdminPasswordUI);
				Delay.Seconds(2);
				UI.UI.vcac.webElmSaveSettings1UI.Click();
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				Delay.Seconds(15);
				UI.UI.vcac.xPathRoot5480UI.PressKeys("{ENTER}");
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				Host.Local.TryFindSingle(UI.LC.VCAC.safe,3600000,out elm);
				Delay.Seconds(2);
				UI.UI.vcac.webElmLicensingUI.Click();
				Delay.Seconds(1);
				Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
				Solution.waitforElmDisappear(UI.LC.VCAC.xPathLoadingIcon,3000);
				Host.Local.TryFindSingle(UI.LC.VCAC.License,3600000,out elm);
				Delay.Seconds(1);
				bool LicenseIsOk = false;
				while (!LicenseIsOk) {
					Solution.text22Adapter(Config.Licensing,UI.UI.vcac.webElmNewLicenseKeyUI);
					Delay.Seconds(2);
					UI.UI.vcac.webElmSubmitKeyUI.Click();
					Delay.Seconds(1);
					Solution.waitforIEComplete(UI.UI.vcac.xPathRoot5480UI);
					Solution.waitforElmDisappear(UI.LC.VCAC.xPathLoadingIcon,60000);
					LicenseIsOk = GUIUtility.WaitForExist(UI.LC.VCAC.webElmLicenseOk,10000);
				}
				Host.Local.KillBrowser("firefox");	
			}
			# endregion
			
        }
       
    }
    
    
    public delegate  string deleDeploy (string s);
    public class AutoDeploy
    {
    	public static string startDeploy(string s){
    		DeployOvaTool  DeployOT = new DeployOvaTool(s);
    		return "EndDeploy";
    	}
    }
}

 

    
    


