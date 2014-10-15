/*
 * Created by Ranorex
 * User: Administrator
 * Date: 5/29/2014
 * Time: 9:00 PM
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
    
    [TestModule("1FF8DDAC-DB09-453C-B042-0ED79EBE9BFF", ModuleType.UserCode, 1)]
    public class VCACTenent : ITestModule
    {
        void ITestModule.Run()
        {
        	Element elm;
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            string VCACHostName = Config.VCACHostName;
			string VCACIP = Config.VCACIP;
	
			#region  添加 ldap
			Delay.Seconds(1);
            Host.Local.OpenBrowser("https://"+VCACHostName+"/vcac","firefox","",true,true);
            Delay.Seconds(2);
			Solution.allowFirefoxAccess();
			Delay.Seconds(3);
			Solution.allowFirefoxAccess();
			Delay.Seconds(5);
			Solution.text22Adapter("administrator@vsphere.local",UI.UI.sso.webElmUserName1UI);
			Solution.text22Adapter(Config.VCPassword,UI.UI.sso.webElmPassword1UI);
			Delay.Seconds(1);
			UI.UI.sso.webElmPassword1UI.PressKeys("{ENTER}");
			Delay.Seconds(1);
			Solution.waitforIEComplete(UI.UI.sso.ssoRootUI);
			Delay.Seconds(1);
			Host.Local.TryFindSingle(UI.LC.VCAC.vspherelocal,600000,out elm);
			Delay.Seconds(1);
			UI.UI.vcac.webElmAddTenantUI.Click();
			Solution.text22Adapter(Config.TenantName,UI.UI.vcac.webElmNameUI);
			Solution.text22Adapter(Config.TenantDescription,UI.UI.vcac.webElmDescriptionUI);
			Solution.text22Adapter(Config.TenantURLName,UI.UI.vcac.webElmURLNameUI);
			Solution.text22Adapter(Config.TenantContactEmail,UI.UI.vcac.webElmContactEmailUI);
			Delay.Seconds(1);
			UI.UI.vcac.webElmSubmitAndNextUI.Click();
			Solution.waitforElmDisappear(UI.LC.VCAC.wiatone,30000);
			Delay.Seconds(2);
			UI.UI.vcac.webElmAddIdentityStoresUI.Click();
			Delay.Seconds(1);
			Solution.text22Adapter(Config.IdentityStoreName,UI.UI.vcac.webElmName_AISUI);
			Host.Local.TryFindSingle(UI.LC.VCAC.webElmType_AIS,600000,out elm);
			UI.UI.vcac.webElmType_AISUI.Click();
			Host.Local.TryFindSingle(UI.LC.VCAC.webElmOpenLDAP_AIS,600000,out elm);
			UI.UI.vcac.webElmOpenLDAP_AISUI.Click();
			Solution.text22Adapter(Config.IdentityStoreURL,UI.UI.vcac.webElmURL_AISUI);
			Solution.text22Adapter(Config.IdentityStoreDomain,UI.UI.vcac.webElmDomain_AISUI);
			Solution.text22Adapter(Config.IdentityStoreLoginUserDN,UI.UI.vcac.webElmLoginUserDN_AISUI);
			Solution.text22Adapter(Config.IdentityStorePassword,UI.UI.vcac.webElmPassword_AISUI);
			Solution.text22Adapter(Config.IdentityStoreGroupSearchBaseDN,UI.UI.vcac.webElmGroupSearchBaseDN_AISUI);
			Delay.Seconds(1);
			UI.UI.vcac.webElmAdd_AISUI.Click();
			Host.Local.TryFindSingle(UI.LC.VCAC.waittwo,30000,out elm);
			UI.UI.vcac.webElmNext_AISUI.Click();
			Delay.Seconds(1);
			Solution.text22Adapter(Config.AdministratorsUserName1,UI.UI.vcac.webElmSearch_ADMUI);
			Delay.Seconds(1);
			UI.UI.vcac.webElmSearch_ADMUI.PressKeys("{enter}");
			Host.Local.TryFindSingle(UI.LC.VCAC.webElmPopup1_ADM,30000,out elm);
			UI.UI.vcac.webElmPopup1_ADMUI.Click();
			Delay.Seconds(1);
			Solution.text22Adapter(Config.AdministratorsUserName1,UI.UI.vcac.webElmSearch_Iaas_ADMUI);
			Delay.Seconds(1);
			UI.UI.vcac.webElmSearch_Iaas_ADMUI.PressKeys("{enter}");
			Host.Local.TryFindSingle(UI.LC.VCAC.webElmPopup1_Iaas_ADM,30000,out elm);
			UI.UI.vcac.webElmPopup1_Iaas_ADMUI.Click();
			Delay.Seconds(1);
			UI.UI.vcac.webElmAdd_ADMUI.Click();
			Delay.Seconds(1);
			Host.Local.TryFindSingle(UI.LC.VCAC.waitthree, 20000,out elm);
			Delay.Seconds(1);
			Host.Local.PressKeys("{ALT down}{F4}{ALT up}");
			Delay.Seconds(3);
			#endregion
        }
    }
}

