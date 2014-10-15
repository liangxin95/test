/*
 * Created by Ranorex
 * User: woo01
 * Date: 7/23/2014
 * Time: 6:43 PM
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
    /// Description of CustomInstall.
    /// </summary>
    [TestModule("5608368B-0DF0-4DF4-9985-0B2D9272A5E9", ModuleType.UserCode, 1)]
    public class CustomInstall : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CustomInstall()
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
            RxPath.DefaultSearchTimeout=30000;
            if (!Config.CustomInstall.Equals("Yes"))
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
			
			string[] lines2 = { 
				@"ren """  + setupFilename + @".exe"" """ + setupFilename + @".exe.bak""",
				@"type """ + setupFilename + @".exe.bak"">""" + setupFilename + @".exe""",
				@"del """ + path + "\\" + setupFilename + @".exe.bak"""//,@"pause"
				};
			System.IO.File.WriteAllLines("temp.bat", lines2);
			Process.Start("temp.bat");
			Delay.Seconds(10);
			Process.Start(path + "\\" + setupFilename + ".exe");
			
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
			
            UI.UI.Iaas.CustomInstallUI.Click();
            UI.UI.Iaas.IaaSServerUI.Click();
            UI.UI.Iaas.ChangeFolderUI.Click();
            if( Config.Is2012Server )
            {
				Delay.Seconds(3);
            	Keyboard.Press("{shift down}{tab}{shift up}");
            	Keyboard.Press("{shift down}{tab}{shift up}");
            	Delay.Seconds(1);
				Keyboard.Press("{down " + Config.FolderOrder1 + "}");
				Delay.Seconds(1);
            	Keyboard.Press("{right}");
				Delay.Seconds(1);
            	Keyboard.Press("{down " + Config.FolderOrder2 + "}");
				Delay.Seconds(1);
            	UI.UI.Iaas.MakeNewFolderUI.Click();
            	Delay.Seconds(1);
            	Solution.text22Adapter(Config.CustomInstallFolderName,Host.Local);
            	UI.UI.Iaas.OkButton2UI.Click();
            	if(GUIUtility.WaitForExist(LC.Iaas.ConformReplaceFolder,3000)) 
            	{
            		UI.UI.Iaas.ConformReplaceFolderUI.Click();
            		UI.UI.Iaas.OkButton2UI.Click();
            	}
            } else {
	            UI.UI.Iaas.ComputerNodeUI.Click();
	            UI.UI.Iaas.LocalDiskCNodeUI.Click();
	            UI.UI.Iaas.MakeNewFolderUI.Click();
	            Delay.Seconds(1);
	            Solution.text22Adapter(Config.CustomInstallFolderName,Host.Local);
	            UI.UI.Iaas.OkButton2UI.Click();
            }
            UI.UI.Iaas.NextButtonUI.Click();
            
            if(!UI.UI.Iaas.vCloudAutomationCenterServerUI.Checked) {
            	UI.UI.Iaas.vCloudAutomationCenterServerUI.Click();
            	Keyboard.Press("{Space}");
            }
            UI.UI.Iaas.DatabaseTabUI.Click();
            if(String.IsNullOrEmpty(Config.DatabaseInstanceName)){
            	Solution.text22Adapter(Environment.MachineName + "." + Config.DomainName,UI.UI.Iaas.DatabaseInstanceUI);
            }else{
            	Solution.text22Adapter(Config.DatabaseInstanceName,UI.UI.Iaas.DatabaseInstanceUI);
            }
            Solution.text22Adapter(Config.DatabaseName,UI.UI.Iaas.DatabaseNameUI);
            UI.UI.Iaas.AdministrationModelManagerWebSiteTabUI.Click();
            UI.UI.Iaas.AvailableWebsitesUI.Click();
            UI.UI.Iaas.UsedWebSiteUI.Click();
            UI.UI.Iaas.AvailableCertificatesUI.Click();
            UI.UI.Iaas.UsedCertificateUI.Click();
            UI.UI.Iaas.ModelManagerDataUI.Click();
            Solution.text22Adapter(Config.VcacFQDN, UI.UI.Iaas.ServerUI);
            UI.UI.Iaas.Load1UI.Click();
            GUIUtility.WaitForExist(LC.Iaas.SSODefaultTenant1,60000);
            UI.UI.Iaas.Download1UI.Click();
            GUIUtility.WaitForExist(LC.Iaas.Certificate1,60000);
            UI.UI.Iaas.AcceptCertificate1UI.Click();
            Solution.text22Adapter("administrator@vsphere.local",UI.UI.Iaas.UserName2UI);
            Solution.text22Adapter("vmware",UI.UI.Iaas.Password3UI);
            Solution.text22Adapter("vmware",UI.UI.Iaas.Conform3UI);
            Solution.text22Adapter(Environment.MachineName + "." + Config.DomainName,UI.UI.Iaas.IaaSServer1UI);
            UI.UI.Iaas.TestLink3UI.Click();
            if(!GUIUtility.WaitForExist(LC.Iaas.PassedString2,60000)){throw new System.Exception("Failed to test the SSO Administrator Credentials.");}
            UI.UI.Iaas.TestLink4UI.Click();
            if(!GUIUtility.WaitForExist(LC.Iaas.PassedString3,10000)){throw new System.Exception("Failed to test the IaaS server.");}
            UI.UI.Iaas.ManagerServiceTabUI.Click();
            UI.UI.Iaas.NextButtonUI.Click();
            GUIUtility.WaitForExist(LC.Iaas.ByPass,30000);
            if (UI.UI.Iaas.ByPassUI.Enabled || !UI.UI.Iaas.NextButtonUI.Enabled){ throw new SystemException("Failed prerequesement check!");}
            UI.UI.Iaas.NextButtonUI.Click();
            Solution.text22Adapter(Config.loginUserPassword,UI.UI.Iaas.Password5UI);
			Solution.text22Adapter(Config.loginUserPassword,UI.UI.Iaas.Conform5UI);
			Solution.text22Adapter(Config.loginUserPassword,UI.UI.Iaas.Passphrase1UI);
			Solution.text22Adapter(Config.loginUserPassword,UI.UI.Iaas.Conform6UI);
            UI.UI.Iaas.NextButtonUI.Click();
            if(GUIUtility.WaitForExist(LC.Iaas.YesButton1,5000)){
				UI.UI.Iaas.YesButton1UI.Click();
				Delay.Seconds(1);
			}
			if(GUIUtility.WaitForExist(LC.Iaas.YesButton2,5000)){
				UI.UI.Iaas.YesButton2UI.Click();
				Delay.Seconds(1);
			}
            UI.UI.Iaas.InstallUI.Click();
            if(!GUIUtility.WaitForExist(LC.Iaas.NextButton2,1800000)){throw new System.Exception("IaaS server installation timeout.");}
			
            UI.UI.Iaas.NextButton2UI.Click();
			GUIUtility.WaitForExist(LC.Iaas.GuideMe,30000);
            UI.UI.Iaas.GuideMeUI.Click();
			UI.UI.Iaas.InstallUI.Click();
            if(!SystemUtil.WaitforServiceStatus(Config.ServiceName,ServiceControllerStatus.Running,60000))
   			{
    			if(!SystemUtil.StartService(Config.ServiceName,60000)){throw new System.Exception("The service " + Config.ServiceName + " is not started.");}
   			}
   			Delay.Seconds(5);
   			string[] lines3 = { 
				@"del %temp% /q /s /f"//,				@"pause"
                };
                
   			System.IO.File.WriteAllLines("temp.bat", lines3);
			Process.Start("temp.bat");
			Delay.Seconds(5);
			
   			Process.Start(path + "\\" + setupFilename + ".exe");
			Delay.Seconds(3);
            
			Keyboard.Press("{enter}");
			UI.UI.Iaas.NextButtonUI.Click();
			Delay.Seconds(3);
			UI.UI.Iaas.AcceptLicenseUI.Click();
			Delay.Seconds(3);
			UI.UI.Iaas.NextButtonUI.Click();
			Solution.text22Adapter(Config.VcacUser,UI.UI.Iaas.UserNameUI);
			Solution.text22Adapter(Config.VcacPassword,UI.UI.Iaas.PasswordUI);
			Delay.Seconds(3);
			UI.UI.Iaas.NextButtonUI.Click();
			GUIUtility.WaitForExist(LC.Iaas.CustomInstall,40000);
			UI.UI.Iaas.CustomInstallUI.Click();
            UI.UI.Iaas.DistributedExecutionManagersUI.Click();
            UI.UI.Iaas.ChangeFolderUI.Click();
            if(Config.Is2012Server)
            {
				Delay.Seconds(3);
            	Keyboard.Press("{shift down}{tab}{shift up}");
            	Keyboard.Press("{shift down}{tab}{shift up}");
            	Delay.Seconds(1);
				Keyboard.Press("{down " + Config.FolderOrder1 + "}");
				Delay.Seconds(1);
            	Keyboard.Press("{right}");
				Delay.Seconds(1);
            	Keyboard.Press("{down " + Config.FolderOrder2 + "}");
				Delay.Seconds(1);
            	UI.UI.Iaas.MakeNewFolderUI.Click();
            	Delay.Seconds(1);
            	Solution.text22Adapter(Config.CustomInstallFolderName,Host.Local);
            	UI.UI.Iaas.OkButton2UI.Click();
            	if(GUIUtility.WaitForExist(LC.Iaas.ConformReplaceFolder,3000)) 
            	{
            		UI.UI.Iaas.ConformReplaceFolderUI.Click();
            		UI.UI.Iaas.OkButton2UI.Click();
            	}
            } else {
	            UI.UI.Iaas.ComputerNodeUI.Click();
	            UI.UI.Iaas.LocalDiskCNodeUI.Click();
	            UI.UI.Iaas.CustomFolderNodeUI.Click();
				UI.UI.Iaas.OkButton2UI.Click();
            }
            UI.UI.Iaas.NextButtonUI.Click();
            Delay.Seconds(2);
            UI.UI.Iaas.NextButtonUI.Click();
            Solution.text22Adapter(Config.loginUserPassword,UI.UI.Iaas.Password4UI);
            Solution.text22Adapter(Config.loginUserPassword,UI.UI.Iaas.Conform4UI);
            UI.UI.Iaas.NextButtonUI.Click();
            Solution.text22Adapter(Config.DEMWorkerName,UI.UI.Iaas.DEMNameUI);
            Solution.text22Adapter(Config.DEMWorkerName,UI.UI.Iaas.DEMDescriptionUI);
            Solution.text22Adapter(Environment.MachineName + "." + Config.DomainName,UI.UI.Iaas.ManagerServiceHostNameUI);
            UI.UI.Iaas.TestLink5UI.Click();
            if(!GUIUtility.WaitForExist(LC.Iaas.PassedString4,60000)){throw new System.Exception("Failed to test the Manager Service Host Name.");}
            UI.UI.Iaas.TestLink6UI.Click();
            if(!GUIUtility.WaitForExist(LC.Iaas.PassedString5,60000)){throw new System.Exception("Failed to test the Model Manager Web Service Host name.");}
            UI.UI.Iaas.AddUI.Click();
            UI.UI.Iaas.DEMRoleUI.Click();
            UI.UI.Iaas.OrchestratorUI.Click();
            Solution.text22Adapter(Config.DEMOrchestratorName,UI.UI.Iaas.DEMNameUI);
            Solution.text22Adapter(Config.DEMOrchestratorName,UI.UI.Iaas.DEMDescriptionUI);
            Solution.text22Adapter(Environment.MachineName + "." + Config.DomainName,UI.UI.Iaas.ManagerServiceHostNameUI);
            UI.UI.Iaas.TestLink5UI.Click();
            if(!GUIUtility.WaitForExist(LC.Iaas.PassedString4,60000)){throw new System.Exception("Failed to test the Manager Service Host Name.");}
            UI.UI.Iaas.TestLink6UI.Click();
            if(!GUIUtility.WaitForExist(LC.Iaas.PassedString5,60000)){throw new System.Exception("Failed to test the Model Manager Web Service Host name.");}
            UI.UI.Iaas.AddUI.Click();
            UI.UI.Iaas.NextButtonUI.Click();
			GUIUtility.WaitForExist(LC.Iaas.GuideMe,30000);
            UI.UI.Iaas.InstallUI.Click();
            if(!GUIUtility.WaitForExist(LC.Iaas.NextButton2,600000)){throw new System.Exception("IaaS server installation timeout.");}
            Delay.Seconds(5);
            UI.UI.Iaas.NextButton2UI.Click();
            UI.UI.Iaas.InstallUI.Click();
            string[] lines4 = { 
				@"del %temp% /q /s /f"//,				@"pause"
                };
            System.IO.File.WriteAllLines("temp.bat", lines4);
			Process.Start("temp.bat");
			Delay.Seconds(5);
			
   			Process.Start(path + "\\" + setupFilename + ".exe");
			Delay.Seconds(3);
            
			Keyboard.Press("{enter}");
            UI.UI.Iaas.NextButtonUI.Click();
			Delay.Seconds(3);
			UI.UI.Iaas.AcceptLicenseUI.Click();
			Delay.Seconds(3);
			UI.UI.Iaas.NextButtonUI.Click();
			Solution.text22Adapter(Config.VcacUser,UI.UI.Iaas.UserNameUI);
			Solution.text22Adapter(Config.VcacPassword,UI.UI.Iaas.PasswordUI);
			Delay.Seconds(3);
			UI.UI.Iaas.NextButtonUI.Click();
			GUIUtility.WaitForExist(LC.Iaas.CustomInstall,40000);
			UI.UI.Iaas.CustomInstallUI.Click();
            UI.UI.Iaas.ProxyAgentsUI.Click();
            UI.UI.Iaas.ChangeFolderUI.Click();
            if( Config.Is2012Server)
            {
				Delay.Seconds(3);
            	Keyboard.Press("{shift down}{tab}{shift up}");
            	Keyboard.Press("{shift down}{tab}{shift up}");
            	Delay.Seconds(1);
				Keyboard.Press("{down " + Config.FolderOrder1 + "}");
				Delay.Seconds(1);
            	Keyboard.Press("{right}");
				Delay.Seconds(1);
            	Keyboard.Press("{down " + Config.FolderOrder2 + "}");
				Delay.Seconds(1);
            	UI.UI.Iaas.MakeNewFolderUI.Click();
            	Delay.Seconds(1);
            	Solution.text22Adapter(Config.CustomInstallFolderName,Host.Local);
            	UI.UI.Iaas.OkButton2UI.Click();
            	if(GUIUtility.WaitForExist(LC.Iaas.ConformReplaceFolder,3000)) 
            	{
            		UI.UI.Iaas.ConformReplaceFolderUI.Click();
            		UI.UI.Iaas.OkButton2UI.Click();
            	}
            } else {
	            UI.UI.Iaas.ComputerNodeUI.Click();
	            UI.UI.Iaas.LocalDiskCNodeUI.Click();
	            UI.UI.Iaas.CustomFolderNodeUI.Click();
				UI.UI.Iaas.OkButton2UI.Click();
            }
            UI.UI.Iaas.NextButtonUI.Click();
            Solution.text22Adapter(Config.loginUserPassword,UI.UI.Iaas.Password4UI);
            Solution.text22Adapter(Config.loginUserPassword,UI.UI.Iaas.Conform4UI);
            UI.UI.Iaas.NextButtonUI.Click();
            UI.UI.Iaas.AgentTypeUI.Click();
            UI.UI.Iaas.VsphereUI.Click();
            Solution.text22Adapter(Config.VsphereAgentName,UI.UI.Iaas.AgentNameUI);
            Solution.text22Adapter(Environment.MachineName + "." + Config.DomainName,UI.UI.Iaas.ManagerServiceHostName1UI);
            UI.UI.Iaas.TestLink7UI.Click();
            if(!GUIUtility.WaitForExist(LC.Iaas.PassedString6,60000)){throw new System.Exception("Failed to test the Manager Service Host Name.");}
            UI.UI.Iaas.TestLink8UI.Click();
            if(!GUIUtility.WaitForExist(LC.Iaas.PassedString7,60000)){throw new System.Exception("Failed to test the Model Manager Web Service Host name.");}
            Solution.text22Adapter(Config.EndpointName,UI.UI.Iaas.EndpointUI);
            UI.UI.Iaas.Add1UI.Click();
            UI.UI.Iaas.NextButtonUI.Click();
            UI.UI.Iaas.InstallUI.Click();
            if(!GUIUtility.WaitForExist(LC.Iaas.NextButton2,120000)){throw new System.Exception("IaaS server installation timeout.");}
            Delay.Seconds(5);
            UI.UI.Iaas.NextButton2UI.Click();
			GUIUtility.WaitForExist(LC.Iaas.GuideMe,30000);
            UI.UI.Iaas.InstallUI.Click();
            string[] lines5 = { 
				@"del %temp% /q /s /f"//,				@"pause"
                };
            System.IO.File.WriteAllLines("temp.bat", lines5);
			Process.Start("temp.bat");
			Delay.Seconds(5);
        }
    }
}
