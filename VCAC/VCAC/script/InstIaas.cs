/*
 * Created by Ranorex
 * User: jingkun
 * Date: 2014/7/8
 * Time: 10:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using ITBM.UI;
using Globalization.Framework;
using System.ServiceProcess;

namespace ITBM.script
{
    /// <summary>
    /// Description of InstIaas.
    /// </summary>
    [TestModule("0B0C616E-3F13-44A9-8F04-9C8D94542641", ModuleType.UserCode, 1)]
    public class InstIaas : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InstIaas()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            if (Config.CustomInstall.Equals("Yes"))
            {
            	Report.Info("The CustomInstall value in the config.ini is " + Config.CustomInstall + ", so skip this module.");
            	return;
            }
            
			string[] lines1 = { 
				@"netsh firewall set opmode DISABLE"//,@"pause"
				};
			System.IO.File.WriteAllLines("temp.bat", lines1);
			Process.Start("temp.bat");
			Delay.Seconds(3);
            
            Host.Local.KillBrowser("firefox");
            Process.Start("cfirefox.bat");
            Host.Local.OpenBrowser(Config.VcacUrl,"firefox","",true,true);
            Solution.allowFirefoxAccess();
            Solution.text22Adapter(Config.VcacUser,UI.UI.vcac.UserNameUI);
            Solution.text22Adapter(Config.VcacPassword,UI.UI.vcac.PasswordUI);
            UI.UI.vcac.PasswordUI.PressKeys("{Enter}");
            Solution.waitforIEComplete(UI.UI.vcac.VcacDomRootUI);
            Delay.Seconds(15);
            UI.UI.vcac.IaasInstallUI.Click();
            string path = Directory.GetCurrentDirectory();
            Delay.Seconds(3);
            UI.UI.vcac.IaasInstallerUI.Click(WinForms.MouseButtons.Right);
            MenuItem m = "/contextmenu//menuitem[5]";
            m.Click();
            Delay.Seconds(10);
            Keyboard.Press("{CONTROL down}{akey}{CONTROL up}");
            Keyboard.Press("{CONTROL down}{ckey}{CONTROL up}");
            string setupFilename = Solution.Clip2text();
            string[] ff = {path+"\\"+setupFilename+".exe", path+"\\"+setupFilename+".exe.Config",path+"\\"+setupFilename+".exe.bak"};
            foreach ( string f in ff){
            	if(File.Exists(f)){
            		File.Delete(f);
            	}
            }
            Delay.Seconds(2);
            Solution.text2Clip(path + "\\" + setupFilename);
            Delay.Seconds(2);
            Keyboard.Press("{CONTROL down}{vkey}{CONTROL up}");
            Keyboard.Press("{enter}");
            Delay.Seconds(10);
                       
			/*
			string path=@"C:\VCAC_Deploy_0619 - Copy\VcacInst\bin\Debug";
			string setupFilename=@"setup__vcac-lx.vcmen.com@5480";
			*/
			Host.Local.KillBrowser("firefox");
			Process.Start("cfirefox.bat");
			
			string[] lines = { 
				@"ren """  + setupFilename + @".exe"" """ + setupFilename + @".exe.bak""",
				@"type """ + setupFilename + @".exe.bak"">""" + setupFilename + @".exe""",
				@"del """ + path + "\\" + setupFilename + @".exe.bak"""//,@"pause"
				};
			System.IO.File.WriteAllLines("temp.bat", lines);
			Process.Start("temp.bat");
			Delay.Seconds(10);
			Process.Start(path + "\\" + setupFilename + ".exe");
			
			GUIUtility.WaitForExist(LC.Iaas.NextButton,30000);
			UI.UI.Iaas.NextButtonUI.Click();
			Delay.Seconds(3);
			UI.UI.Iaas.AcceptLicenseUI.Click();
			Delay.Seconds(3);
			UI.UI.Iaas.NextButtonUI.Click();
			Solution.text22Adapter(Config.VcacUser,UI.UI.Iaas.UserNameUI);
			Solution.text22Adapter(Config.VcacPassword,UI.UI.Iaas.PasswordUI);
			Delay.Seconds(3);
			UI.UI.Iaas.NextButtonUI.Click();
			GUIUtility.WaitForExist(LC.Iaas.CompleteInstall,40000);
			UI.UI.Iaas.CompleteInstallUI.Click();
			Delay.Seconds(3);
			UI.UI.Iaas.NextButtonUI.Click();
			Delay.Seconds(15);
			if (UI.UI.Iaas.ByPassUI.Enabled || !UI.UI.Iaas.NextButtonUI.Enabled){ throw new SystemException("Failed prerequesement check!");}
			Delay.Seconds(3);
			UI.UI.Iaas.NextButtonUI.Click();
			Delay.Seconds(3);
			Solution.text22Adapter(Config.loginUserPassword,UI.UI.Iaas.Password1UI);
			Solution.text22Adapter(Config.loginUserPassword,UI.UI.Iaas.ConformUI);
			Solution.text22Adapter(Config.loginUserPassword,UI.UI.Iaas.PassphraseUI);
			Solution.text22Adapter(Config.loginUserPassword,UI.UI.Iaas.Conform1UI);
			UI.UI.Iaas.NextButtonUI.Click();
			Delay.Seconds(3);
			if(GUIUtility.WaitForExist(LC.Iaas.YesButton1,5000)){
				UI.UI.Iaas.YesButton1UI.Click();
				Delay.Seconds(1);
			}
			if(GUIUtility.WaitForExist(LC.Iaas.YesButton2,5000)){
				UI.UI.Iaas.YesButton2UI.Click();
				Delay.Seconds(1);
			}
			Solution.text22Adapter(Config.DEMWorkerName,UI.UI.Iaas.DEMWorkerNameUI);
			Solution.text22Adapter(Config.DEMOrchestratorName,UI.UI.Iaas.DEMOrchestratorNameUI);
			Solution.text22Adapter(Config.VsphereAgentName,UI.UI.Iaas.VsphereAgentNameUI);
			Solution.text22Adapter(Config.EndpointName,UI.UI.Iaas.EndpointNameUI);
			UI.UI.Iaas.NextButtonUI.Click();
			Delay.Seconds(3);
			UI.UI.Iaas.LoadUI.Click();
			GUIUtility.WaitForExist(LC.Iaas.SSODefaultTenant,60000);
			UI.UI.Iaas.DownloadUI.Click();
			GUIUtility.WaitForExist(LC.Iaas.Certificate,60000);
			UI.UI.Iaas.AcceptCertificateUI.Click();
			UI.UI.Iaas.ViewCertificateUI.Click();
			GUIUtility.WaitForExist(LC.Iaas.InstallCertificate,60000);
			UI.UI.Iaas.InstallCertificateUI.Click();
			GUIUtility.WaitForExist(LC.Iaas.NextButton1,30000);
			UI.UI.Iaas.NextButton1UI.Click();
			Delay.Seconds(2);
			UI.UI.Iaas.FollowingStoreUI.Click();
			UI.UI.Iaas.BrowseUI.Click();
			Delay.Seconds(3);
			UI.UI.Iaas.TrustRootCertificateAuthoritiesUI.Click();
			UI.UI.Iaas.OKButtonUI.Click();
			UI.UI.Iaas.NextButton1UI.Click();
			UI.UI.Iaas.FinishUI.Click();
			
//			GUIUtility.WaitForExist(LC.Iaas.YesButton,30000);
//			Iaas.YesButtonUI.Click();
			Delay.Seconds(40);
			Host.Local.Click();
			Keyboard.Press("{left}");
			Keyboard.Press("{enter}");
			
			UI.UI.Iaas.OKButton1UI.Click();
			UI.UI.Iaas.OKButtonUI.Click();
			Solution.text22Adapter("administrator@vsphere.local",UI.UI.Iaas.UserName1UI);
			Solution.text22Adapter("vmware",UI.UI.Iaas.Password2UI);
			Solution.text22Adapter("vmware",UI.UI.Iaas.Conform2UI);
			UI.UI.Iaas.TestLink1UI.Click();
			if(!GUIUtility.WaitForExist(LC.Iaas.PassedString,60000)){throw new System.Exception("Failed to test the SSO Administrator Credentials.");}
			UI.UI.Iaas.TestLink2UI.Click();
			if(!GUIUtility.WaitForExist(LC.Iaas.PassedString,10000)){throw new System.Exception("Failed to test the IaaS server.");}
			UI.UI.Iaas.NextButtonUI.Click();
			Delay.Seconds(10);
			UI.UI.Iaas.InstallUI.Click();
			if(!GUIUtility.WaitForExist(LC.Iaas.NextButton2,3600000)){throw new System.Exception("IaaS server installation timeout.");}
			UI.UI.Iaas.NextButton2UI.Click();
			UI.UI.Iaas.GuideMeUI.Click();
			UI.UI.Iaas.InstallUI.Click();
			//if(!SystemUtil.WaitforServiceStatus(Config.ServiceName,ServiceControllerStatus.Running,600000)){throw new System.Exception("The service " + Config.ServiceName + " is not started.");}
			if(!SystemUtil.WaitforServiceStatus(Config.ServiceName,ServiceControllerStatus.Running,60000))
   			{
    			if(!SystemUtil.StartService(Config.ServiceName,60000)){throw new System.Exception("The service " + Config.ServiceName + " is not started.");}
   			}
        }
    }
}
