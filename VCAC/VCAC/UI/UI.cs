/*
 * Created by Ranorex
 * User: vanceinfo
 * Date: 2012/5/7
 * Time: 15:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Ranorex;
using Ranorex.Core;
using ITBM;

namespace ITBM.UI
{
	/// <summary>
	/// Description of UIObject.
	/// </summary>
	public class UI
	{
		
		public class vcac {
			public static WebDocument VcacDomRootUI {get{return LC.VCAC.VcacDomRoot;}}
			public static WebElement UserNameUI {get{return LC.VCAC.UserName;}}
			public static WebElement PasswordUI {get{return LC.VCAC.Password;}}
			public static WebElement IaasInstallUI {get{return LC.VCAC.IaasInstall;}}
			public static WebElement IaasInstallerUI {get{return LC.VCAC.IaasInstaller;}}
			public static WebDocument xPathRoot5480UI {get{return LC.VCAC.xPathRoot5480;}}
			public static WebDocument ssoxPathRoot5480UI {get{return LC.VCAC.ssoxPathRoot5480;}}
			public static WebElement xPathLoadingIconUI {get{return LC.VCAC.xPathLoadingIcon;}}
			public static WebElement webElmUserNameUI {get{return LC.VCAC.webElmUserName;}}
			public static WebElement webElmPasswordUI {get{return LC.VCAC.webElmPassword;}}
			public static WebElement ssowebElmUserNameUI {get{return LC.VCAC.ssowebElmUserName;}}
			public static WebElement ssowebElmPasswordUI {get{return LC.VCAC.ssowebElmPassword;}}
			public static WebElement webElmVcacSetingsUI {get{return LC.VCAC.webElmVcacSetings;}}
			public static WebElement webElmSystem  {get {return LC.VCAC.webElmSystem;}} 
		    public static WebElement webElmTimeZone	{get {return LC.VCAC.webElmTimeZone;}} 
		    public static WebElement webElmSystemTimeZone{get {return LC.VCAC.webElmSystemTimeZone;}} 
		    public static WebElement webElmAsiashanghaiItem	{get {return LC.VCAC.webElmAsiashanghaiItem;}} 
		    public static WebElement webElmTimeZone_SaveSettingsButton {get {return LC.VCAC.webElmTimeZone_SaveSettingsButton;}} 
		    public static WebElement webElmTimeZone_SaveSettingsSaved {get {return LC.VCAC.webElmTimeZone_SaveSettingsSaved;}} 
		    public static WebElement ssowebElmSystem  {get {return LC.VCAC.ssowebElmSystem;}} 
		    public static WebElement ssowebElmTimeZone	{get {return LC.VCAC.ssowebElmTimeZone;}} 
		    public static WebElement ssowebElmSystemTimeZone	{get {return LC.VCAC.ssowebElmSystemTimeZone;}} 
		    public static WebElement ssowebElmAsiashanghaiItem	{get {return LC.VCAC.ssowebElmAsiashanghaiItem;}} 
		    public static WebElement ssowebElmTimeZone_SaveSettingsButton {get {return LC.VCAC.ssowebElmTimeZone_SaveSettingsButton;}} 
		    public static WebElement ssowebElmTimeZone_SaveSettingsSaved {get {return LC.VCAC.ssowebElmTimeZone_SaveSettingsSaved;}} 
		   	public static WebElement ssowebElmTimeZone_ssoLogout {get {return LC.VCAC.ssowebElmTimeZone_ssoLogout;}} 
		    public static WebElement webElmVcacHostNameUI {get{return LC.VCAC.webElmVcacHostName;}}
		    public static WebElement webElmSaveSettingsUI {get{return LC.VCAC.webElmSaveSettings;}}
		    public static WebElement webElmSSLUI {get{return LC.VCAC.webElmSSL;}}
		    public static WebElement webElmChooseActionUI {get{return LC.VCAC.webElmChooseAction;}}
		    public static WebElement webElmGenerateSelfSignedCertificateUI {get{return LC.VCAC.webElmGenerateSelfSignedCertificate;}}
		    public static WebElement webElmCommonNameUI {get{return LC.VCAC.webElmCommonName;}}
		    public static WebElement webElmOrganizationUI {get{return LC.VCAC.webElmOrganization;}}
		    public static WebElement webElmOrganizationalUnitUI {get{return LC.VCAC.webElmOrganizationalUnit;}}
		    public static WebElement webElmCountryCodeUI {get{return LC.VCAC.webElmCountryCode;}}
		    public static WebElement webElmReplaceCertificateUI {get{return LC.VCAC.webElmReplaceCertificate;}}
		    public static WebElement webElmHostAndPortUI {get{return LC.VCAC.webElmHostAndPort;}}
		    public static WebElement webElmAdminUserUI {get{return LC.VCAC.webElmAdminUser;}}
		    public static WebElement webElmAdminPasswordUI {get{return LC.VCAC.webElmAdminPassword;}}
		    public static WebElement webElmSSOUI {get{return LC.VCAC.webElmSSO;}}
		    public static WebElement webElmSaveSettings1UI {get{return LC.VCAC.webElmSaveSettings1;}}
		    public static WebElement safeUI {get{return LC.VCAC.safe;}}
		    public static WebElement webElmLicensingUI {get{return LC.VCAC.webElmLicensing;}}
		    public static WebElement webElmNewLicenseKeyUI {get{return LC.VCAC.webElmNewLicenseKey;}}
		    public static WebElement webElmSubmitKeyUI {get{return LC.VCAC.webElmSubmitKey;}}
		    public static WebElement webElmAddTenantUI{get{return LC.VCAC.webElmAddTenant;}}
		    public static WebElement webElmNameUI{get{return LC.VCAC.webElmName;}}
		    public static WebElement webElmDescriptionUI{get{return LC.VCAC.webElmDescription;}}
		   public static WebElement webElmURLNameUI{get{return LC.VCAC.webElmURLName;}}
		   public static WebElement webElmContactEmailUI{get{return LC.VCAC.webElmContactEmail;}}
		   public static WebElement webElmSubmitAndNextUI{get{return LC.VCAC.webElmSubmitAndNext;}}
		   public static WebElement webElmAddIdentityStoresUI{get{return LC.VCAC.webElmAddIdentityStores;}}
		   public static WebElement webElmName_AISUI{get{return LC.VCAC.webElmName_AIS;}}
		   public static WebElement webElmType_AISUI{get{return LC.VCAC.webElmType_AIS;}}
		   public static WebElement webElmOpenLDAP_AISUI{get{return LC.VCAC.webElmOpenLDAP_AIS;}}
		   public static WebElement webElmURL_AISUI{get{return LC.VCAC.webElmURL_AIS;}}
		   public static WebElement webElmDomain_AISUI{get{return LC.VCAC.webElmDomain_AIS;}}
		   public static WebElement webElmLoginUserDN_AISUI{get{return LC.VCAC.webElmLoginUserDN_AIS;}}
		   public static WebElement webElmPassword_AISUI{get{return LC.VCAC.webElmPassword_AIS;}}
		   public static WebElement webElmGroupSearchBaseDN_AISUI{get{return LC.VCAC.webElmGroupSearchBaseDN_AIS;}}
		   public static WebElement webElmAdd_AISUI{get{return LC.VCAC.webElmAdd_AIS;}}
		   public static WebElement webElmNext_AISUI{get{return LC.VCAC.webElmNext_AIS;}}
		   public static WebElement webElmSearch_ADMUI{get{return LC.VCAC.webElmSearch_ADM;}}
		   public static WebElement webElmPopup1_ADMUI{get{return LC.VCAC.webElmPopup1_ADM;}}
		   public static WebElement webElmPopup2_ADMUI{get{return LC.VCAC.webElmPopup2_ADM;}}
		   public static WebElement webElmAdd_ADMUI{get{return LC.VCAC.webElmAdd_ADM;}}
		   
		   public static WebElement webElmSearch_Iaas_ADMUI{get{return LC.VCAC.webElmSearch_Iaas_ADM;}}
		   public static WebElement webElmPopup1_Iaas_ADMUI{get{return LC.VCAC.webElmPopup1_Iaas_ADM;}}
		   
		   public static WebElement webElmAdministration_MyTUI{get{return LC.VCAC.webElmAdministration_MyT;}}
		   public static WebElement webElmUsers_MyTUI {get{return LC.VCAC.webElmUsers_MyT;}}
		   public static WebElement webElmSearch_MyTUI {get{return LC.VCAC.webElmSearch_MyT;}}
		   public static WebElement webElmSearchIcon_MyTUI {get{return LC.VCAC.webElmSearchIcon_MyT;}}
		   public static WebElement webElmAdminUserLink_MyTUI {get{return LC.VCAC.webElmAdminUserLink_MyT;}}
		   public static InputTag inpTagApprovalAdministrator_MyTUI {get{return LC.VCAC.inpTagApprovalAdministrator_MyT;}}
		   public static InputTag inpTagBusinessManagementAdministrator_MyTUI {get{return LC.VCAC.inpTagBusinessManagementAdministrator_MyT;}}
		   public static InputTag inpTagBusinessManagementReadonlyUser_MyTUI {get{return LC.VCAC.inpTagBusinessManagementReadonlyUser_MyT;}}
		   public static InputTag inpTagServiceArchitect_MyTUI {get{return LC.VCAC.inpTagServiceArchitect_MyT;}}
		   public static InputTag inpTagTenantAdministrator_MyTUI {get{return LC.VCAC.inpTagTenantAdministrator_MyT;}}
		   public static WebElement webElmUpdate_MyTUI {get{return LC.VCAC.webElmUpdate_MyT;}}
		   public static WebElement webElmAdminUserLink1_MyTUI {get{return LC.VCAC.webElmAdminUserLink1_MyT;}}
		   public static WebElement webElmBusinessManagement_MyTUI {get{return LC.VCAC.webElmBusinessManagement_MyT;}}
		   public static WebElement webElmLicense_MyTUI {get{return LC.VCAC.webElmLicense_MyT;}}
		   public static WebElement webElmSave_MyTUI {get{return LC.VCAC.webElmSave_MyT;}}
		   public static WebElement webElmAdministration1_MyTUI {get{return LC.VCAC.webElmAdministration1_MyT;}}
		   public static WebElement webElmBusinessManagement1_MyTUI {get{return LC.VCAC.webElmBusinessManagement1_MyT;}}
		   
		   #region  click
		   public static WebElement webMvc1{get {return LC.VCAC.webMvc1;}}
		   public static WebElement webMvc2{get {return LC.VCAC.webMvc2;}}
		   #endregion
		   
		   
		   public static WebElement webElmAddVcServer_MyTUI {get{return LC.VCAC.webElmAddVcServer_MyT;}}
		   public static WebElement webElmName3_MyTUI {get{return LC.VCAC.webElmName3_MyT;}}
		   public static WebElement webElmVcenterServer3_MyTUI {get{return LC.VCAC.webElmVcenterServer3_MyT;}}
		   public static WebElement webElmUserName3_MyTUI {get{return LC.VCAC.webElmUserName3_MyT;}}
		   public static WebElement webElmPassword3_MyTUI {get{return LC.VCAC.webElmPassword3_MyT;}}
		   public static WebElement webElmSave3_MyTUI {get{return LC.VCAC.webElmSave3_MyT;}}
		   public static WebElement webElmInstall_MyTUI {get{return LC.VCAC.webElmInstall_MyT;}}
		   public static WebElement webElmLicenseOkUI {get{return LC.VCAC.webElmLicenseOk;}}
		}
		
		public class sso {
			public static WebDocument ssoRootUI {get{return LC.SSO.ssoRoot;}}
			public static WebElement webElmUserName1UI {get{return LC.SSO.webElmUserName1;}}
			public static WebElement webElmPassword1UI{get{return LC.SSO.webElmPassword1;}}
			public static WebElement webElmUserName1_MyTUI{get{return LC.SSO.webElmUserName1_MyT;}}
			public static WebElement webElmPassword1_MyTUI{get{return LC.SSO.webElmPassword1_MyT;}}
		}
		
		public class Iaas {
		public static Button RunButtonUI {get{return LC.Iaas.RunButton;}}
		public static Button NextButtonUI {get{return LC.Iaas.NextButton;}}
		public static CheckBox AcceptLicenseUI{get{return LC.Iaas.AcceptLicense;}}
		public static Text UserNameUI {get{return LC.Iaas.UserName;}}
		public static Text PasswordUI {get{return LC.Iaas.Password;}}
		public static RadioButton CompleteInstallUI {get{return LC.Iaas.CompleteInstall;}}
		public static Button ByPassUI {get{return LC.Iaas.ByPass;}}
		public static Text Password1UI {get{return LC.Iaas.Password1;}}
		public static Text ConformUI {get{return LC.Iaas.Conform;}}
		public static Text PassphraseUI {get{return LC.Iaas.Passphrase;}}
		public static Text Conform1UI {get{return LC.Iaas.Conform1;}}
		public static Text DEMWorkerNameUI {get{return LC.Iaas.DEMWorkerName;}}
		public static Text DEMOrchestratorNameUI {get{return LC.Iaas.DEMOrchestratorName;}}
		public static Text VsphereAgentNameUI {get{return LC.Iaas.VsphereAgentName;}}
		public static Text EndpointNameUI {get{return LC.Iaas.EndpointName;}}
		public static Button LoadUI {get{return LC.Iaas.Load;}}
		public static Text SSODefaultTenantUI {get{return LC.Iaas.SSODefaultTenant;}}
		public static Button DownloadUI {get{return LC.Iaas.Download;}}
		public static Text CertificateUI {get{return LC.Iaas.Certificate;}}
		public static CheckBox AcceptCertificateUI {get{return LC.Iaas.AcceptCertificate;}}
		public static Link ViewCertificateUI {get{return LC.Iaas.ViewCertificate;}}
		public static Button InstallCertificateUI {get{return LC.Iaas.InstallCertificate;}}
		public static Button NextButton1UI {get{return LC.Iaas.NextButton1;}}
		public static RadioButton FollowingStoreUI {get{return LC.Iaas.FollowingStore;}}
		public static Button BrowseUI {get{return LC.Iaas.Browse;}}
		public static TreeItem TrustRootCertificateAuthoritiesUI {get{return LC.Iaas.TrustRootCertificateAuthorities;}}
		public static Button OKButtonUI {get{return LC.Iaas.OKButton;}}
		public static Button FinishUI {get{return LC.Iaas.Finish;}}
		public static Button YesButtonUI {get{return LC.Iaas.YesButton;}}
		public static Button OKButton1UI {get{return LC.Iaas.OKButton1;}}
		public static Text UserName1UI {get{return LC.Iaas.UserName1;}}
		public static Text Password2UI {get{return LC.Iaas.Password2;}}
		public static Text Conform2UI {get{return LC.Iaas.Conform2;}}
		public static Link TestLink1UI {get{return LC.Iaas.TestLink1;}}
		public static Text PassedStringUI {get{return LC.Iaas.PassedString;}}
		public static Link TestLink2UI {get{return LC.Iaas.TestLink2;}}
		public static Text PassedString1UI {get{return LC.Iaas.PassedString1;}}
		public static Button InstallUI {get{return LC.Iaas.Install;}}
		public static Button NextButton2UI {get{return LC.Iaas.NextButton2;}}
		public static CheckBox GuideMeUI {get{return LC.Iaas.GuideMe;}}
		public static Button YesButton1UI {get{return LC.Iaas.YesButton1;}}
		public static Button YesButton2UI {get{return LC.Iaas.YesButton2;}}
		
		public static RadioButton CustomInstallUI {get{return LC.Iaas.CustomInstall;}}
		public static RadioButton IaaSServerUI {get{return LC.Iaas.IaaSServer;}}
		public static Button ChangeFolderUI {get{return LC.Iaas.ChangeFolder;}}
		public static TreeItem ComputerNodeUI {get{return LC.Iaas.ComputerNode;}}
		public static TreeItem LocalDiskCNodeUI {get{return LC.Iaas.LocalDiskCNode;}}
		public static Button MakeNewFolderUI {get{return LC.Iaas.MakeNewFolder;}}
		public static Button OkButton2UI {get{return LC.Iaas.OkButton2;}}
		public static TabPage DatabaseTabUI {get{return LC.Iaas.DatabaseTab;}}
		public static Text DatabaseInstanceUI {get{return LC.Iaas.DatabaseInstance;}}
		public static Text DatabaseNameUI {get{return LC.Iaas.DatabaseName;}}
		public static TabPage AdministrationModelManagerWebSiteTabUI {get{return LC.Iaas.AdministrationModelManagerWebSiteTab;}}
		public static ComboBox AvailableWebsitesUI {get{return LC.Iaas.AvailableWebsites;}}
		public static ListItem UsedWebSiteUI {get{return LC.Iaas.UsedWebSite;}}
		public static ComboBox AvailableCertificatesUI {get{return LC.Iaas.AvailableCertificates;}}
		public static ListItem UsedCertificateUI {get{return LC.Iaas.UsedCertificate;}}
		public static TabPage ModelManagerDataUI {get{return LC.Iaas.ModelManagerData;}}
		public static Text ServerUI {get{return LC.Iaas.Server;}}
		public static Button Load1UI {get{return LC.Iaas.Load1;}}
		public static Text SSODefaultTenant1UI {get{return LC.Iaas.SSODefaultTenant1;}}
		public static Button Download1UI {get{return LC.Iaas.Download1;}}
		public static Text Certificate1UI {get{return LC.Iaas.Certificate1;}}
		public static CheckBox AcceptCertificate1UI {get{return LC.Iaas.AcceptCertificate1;}}
		public static Text UserName2UI {get{return LC.Iaas.UserName2;}}
		public static Text Password3UI {get{return LC.Iaas.Password3;}}
		public static Text Conform3UI {get{return LC.Iaas.Conform3;}}
		public static Text IaaSServer1UI {get{return LC.Iaas.IaaSServer1;}}
		public static Link TestLink3UI {get{return LC.Iaas.TestLink3;}}
		public static Text PassedString2UI {get{return LC.Iaas.PassedString2;}}
		public static Link TestLink4UI {get{return LC.Iaas.TestLink4;}}
		public static Text PassedString3UI {get{return LC.Iaas.PassedString3;}}
		public static TabPage ManagerServiceTabUI {get{return LC.Iaas.ManagerServiceTab;}}
		public static CheckBox vCloudAutomationCenterServerUI {get{return LC.Iaas.vCloudAutomationCenterServer;}}
		public static Text Password5UI {get{return LC.Iaas.Password5;}}
		public static Text Conform5UI {get{return LC.Iaas.Conform5;}}
		public static Text Passphrase1UI {get{return LC.Iaas.Passphrase1;}}
		public static Text Conform6UI {get{return LC.Iaas.Conform6;}}
		public static TreeItem CustomFolderNodeUI {get{return LC.Iaas.CustomFolderNode;}}
		
		
		
		public static RadioButton DistributedExecutionManagersUI {get{return LC.Iaas.DistributedExecutionManagers;}}
		public static Text Password4UI {get{return LC.Iaas.Password4;}}
		public static Text Conform4UI {get{return LC.Iaas.Conform4;}}
		public static Text DEMNameUI {get{return LC.Iaas.DEMName;}}
		public static Text DEMDescriptionUI {get{return LC.Iaas.DEMDescription;}}
		public static Text ManagerServiceHostNameUI {get{return LC.Iaas.ManagerServiceHostName;}}
		public static Link TestLink5UI {get{return LC.Iaas.TestLink5;}}
		public static Text PassedString4UI {get{return LC.Iaas.PassedString4;}}
		public static Link TestLink6UI {get{return LC.Iaas.TestLink6;}}
		public static Text PassedString5UI {get{return LC.Iaas.PassedString5;}}
		public static Button AddUI {get{return LC.Iaas.Add;}}
		public static ComboBox DEMRoleUI {get{return LC.Iaas.DEMRole;}}
		public static ListItem OrchestratorUI {get{return LC.Iaas.Orchestrator;}}
		public static RadioButton ProxyAgentsUI {get{return LC.Iaas.ProxyAgents;}}
		public static ComboBox AgentTypeUI {get{return LC.Iaas.AgentType;}}
		public static ListItem VsphereUI {get{return LC.Iaas.Vsphere;}}
		public static Text AgentNameUI {get{return LC.Iaas.AgentName;}}
		public static Text ManagerServiceHostName1UI {get{return LC.Iaas.ManagerServiceHostName1;}}
		public static Link TestLink7UI {get{return LC.Iaas.TestLink7;}}
		public static Text PassedString6UI {get{return LC.Iaas.PassedString6;}}
		public static Link TestLink8UI {get{return LC.Iaas.TestLink8;}}
		public static Text PassedString7UI {get{return LC.Iaas.PassedString7;}}
		public static Text EndpointUI {get{return LC.Iaas.Endpoint;}}
		public static Button Add1UI {get{return LC.Iaas.Add1;}}
		
		public static Button ConformReplaceFolderUI {get{return LC.Iaas.ConformReplaceFolder;}}
	}
		
		public class ConfigFireforx{
	    	public static Form OptionDialogForm {get{return LC.ConfigFireforx.OptionDialogForm;}}
	    	public static ListItem AdvancedListItem {get{return LC.ConfigFireforx.AdvancedListItem;}}
	    	public static TabPage UpdatePageTab {get{return LC.ConfigFireforx.UpdatePageTab;}}
	    	public static RadioButton NeverUpdateRadioButton {get{return LC.ConfigFireforx.NeverUpdateRadioButton;}}
	    	public static Button OKButton {get{return LC.ConfigFireforx.OKButton;}}
	    }
		
	}
}
