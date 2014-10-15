/*
 * Created by Ranorex
 * User: Administrator
 * Date: 5/5/2014
 * Time: 7:23 PM
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

namespace ITBM.UI
{
   
    public class LC 
    {
    
        public LC()
        {
           
        }
        public class VCAC
		{
			public static string VCACHostName {
				get {
					//return Config.VCACIP;
					//return "pek2-office-05-dhcp74.eng.vmware.com";
					return Config.VCACHostName;
				}
			}
        	
        	public static string VCACIP{
        		get{
        			
        			return Config.VCACIP;
        		}
        		
        	}
        	
			public static string urlRoot {
				get {
					//return "https://"+Config.VCACIP+":5480";
					return "https://"+Config.VCACIP+":5480";
				}
			}
        	
        	public static string ssourlRoot {
				get {
					//return "https://"+Config.VCACIP+":5480";
					return "https://"+Config.SSOIP+":5480";
				}
			}
        	
        	#region 配置vcac_sso
        	public static string xPathRoot5480 {get {return  "/dom[@domain='"+Config.VCACIP+":5480']";}} 
        	public static string ssoxPathRoot5480 {get {return  "/dom[@domain='"+Config.SSOIP+":5480']";}} 
			public static string xPathLoadingIcon  {get { return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//div[@class='vami-banner-loading']";}} 
			public static string ssoxPathLoadingIcon  {get { return  "/dom[@domain='"+Config.SSOIP+":5480']"+"//div[@class='vami-banner-loading']";}} 
		    public static string webElmUserName  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//input[@type='text']";}} 
		    public static string webElmPassword  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//input[@type='password']";}} 
		    
		    public static string ssowebElmUserName  {get {return  "/dom[@domain='"+Config.SSOIP+":5480']"+"//input[@type='text']";}} 
		    public static string ssowebElmPassword  {get {return  "/dom[@domain='"+Config.SSOIP+":5480']"+"//input[@type='password']";}} 
		    
		    
		    public static string webElmVcacSetings  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//td[3]//div[@class='vami-navpanel-tab']";}} 
		    
		    
		    public static string webElmSystem  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']/"+".//div[@innertext='System']";}} 
		    public static string webElmTimeZone	{get {return  "/dom[@domain='"+Config.VCACIP+":5480']/"+".//div[@innertext='Time Zone']";}}
		    public static string webElmSystemTimeZone	{get {return "/dom[@domain='"+Config.VCACIP+":5480']/"+"/select[#'vami-debug-system-timezone-timezonelist']";}}
		    public static string webElmAsiashanghaiItem	{get {return "/dom[@domain='"+Config.VCACIP+":5480']/"+"//select[#'vami-debug-system-timezone-timezonelist']/option[#'vami-debug-system-timezone-timezonelist-item265']";}}
		    public static string webElmTimeZone_SaveSettingsButton {get {return "/dom[@domain='"+Config.VCACIP+":5480']/"+".//button[@innertext='Save Settings']";}}
		    public static string webElmTimeZone_SaveSettingsSaved {get {return "/dom[@domain='"+Config.VCACIP+":5480']/"+".//div[@innertext='Timezone settings saved.']";}}
		    
		    
		    public static string ssowebElmSystem  {get {return  "/dom[@domain='"+Config.SSOIP+":5480']/"+".//div[@innertext='System']";}} 
		    public static string ssowebElmTimeZone	{get {return  "/dom[@domain='"+Config.SSOIP+":5480']/"+".//div[@innertext='Time Zone']";}}
		    public static string ssowebElmSystemTimeZone	{get {return "/dom[@domain='"+Config.SSOIP+":5480']/"+"/select[#'vami-debug-system-timezone-timezonelist']";}}
		    public static string ssowebElmAsiashanghaiItem	{get {return "/dom[@domain='"+Config.SSOIP+":5480']/"+"//select[#'vami-debug-system-timezone-timezonelist']/option[#'vami-debug-system-timezone-timezonelist-item265']";}}
		    public static string ssowebElmTimeZone_SaveSettingsButton {get {return "/dom[@domain='"+Config.SSOIP+":5480']/"+".//button[@innertext='Save Settings']";}}
		    public static string ssowebElmTimeZone_SaveSettingsSaved {get {return "/dom[@domain='"+Config.SSOIP+":5480']/"+".//div[@innertext='Timezone settings saved.']";}}
		   	public static string ssowebElmTimeZone_ssoLogout {get {return "/dom[@domain='"+Config.SSOIP+":5480']/"+".//a[@innertext='Logout user ']";}}
		   
		    
		    
		 //	public static string webElmVcacHostName  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//table[#'cafe.host']//input[@type='text']";}} 
		    public static string webElmVcacHostName  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//input[@type='text']";}}
		    public static string webElmSaveSettings  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//button[@innertext='Save Settings']";}} 
		    
		    public static string webElmSSL {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//div[#'SSL']";}} 
		    
		    
		    public static string webElmChooseAction  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//table[#'ssl.action']//select";}} 
		    public static string webElmGenerateSelfSignedCertificate  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//table[#'ssl.action']//select/option[2]";}} 
		    public static string webElmCommonName  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//table[#'ssl.commonName']//input[@type='text']";}} 
		    public static string webElmOrganization {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//table[#'ssl.organization']//input[@type='text']";}} 
		    public static string webElmOrganizationalUnit  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//table[#'ssl.organizationalUnit']//input[@type='text']";}} 
		    public static string webElmCountryCode  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//table[#'ssl.country']//input[@type='text']";}} 
		    public static string webElmReplaceCertificate  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//button[@innertext='Replace Certificate']";}} 
		    public static string webElmHostAndPort  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//table[#'sso.host']//input[@type='text']";}} 
		    public static string webElmAdminUser  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//table[#'sso.admin']//input[@type='text']";}} 
		    public static string webElmAdminPassword  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//table[#'sso.password']//input[@type='password']";}} 
		    public static string webElmSSO  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//div[#'SSO']";}} 
		    
		    public static string webElmSaveSettings1{get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//button[@innertext='Save Settings']";}} 
		    
		    public static string safe {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//table[@class='vami-fieldpanel-fields']//div[@class='vami-form-ok' and @innertext!=@null]";}} 
		    public static string License {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//div[@class='vami-form-error']";}} 
		    
		    
		    
		    public static string webElmLicensing {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//div[#'Licensing']";}} 
		    public static string webElmNewLicenseKey  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//input[@type='text']";}} 
		    public static string webElmSubmitKey  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//iframe[@name='frame-cafe']//button[@innertext='Submit Key']";}} 
		    public static string webElmLicenseOk  {get {return  "/dom[@domain='"+Config.VCACIP+":5480']"+"//div[@class='vami-form-ok']";}} 
		    #endregion
		    
		    
		    #region  配置 tenant 。。
		    public static string xPathRoot{ get { return "/dom[@domain='"+VCACHostName+"']";}}
		    public static string vspherelocal { get { return "/dom[@domain='"+VCACHostName+"']"+"//tr[#'vsphere.local']";}}
		   
		    public static string webElmAddTenant { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[#'command0']";}}
		    
		    public static string webElmName { get { return "/dom[@domain='"+VCACHostName+"']" + "//input[#'TENANT_NAME_FIELD']";}}
		    public static string webElmDescription { get { return "/dom[@domain='"+VCACHostName+"']" + "//textarea[#'TENANT_DESCRIPTION_FIELD']";}}
		    public static string webElmURLName { get { return "/dom[@domain='"+VCACHostName+"']" + "//input[#'TENANT_URL_NAME_FIELD']";}}
		    public static string webElmContactEmail { get { return "/dom[@domain='"+VCACHostName+"']" + "//input[#'TENANT_EMAIL_FIELD']";}}
		    public static string webElmSubmitAndNext { get { return "/dom[@domain='"+VCACHostName+"']" + "//button[#'submitPageAndNext']";}}
		    public static string wiatone{ get { return "/dom[@domain='"+VCACHostName+"']"+"//div[@class='gwt-DialogBox']//img[@src='https://" + VCACHostName + "/vcac/shell/clear.cache.gif' and @visible=True]";}}
		    public static string webElmAddIdentityStores { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[#'command0']/";}}
		    public static string webElmName_AIS { get { return "/dom[@domain='"+VCACHostName+"']" + "//input[#'TENANT_ID_STORE_NAME_FIELD']";}}
		    public static string webElmType_AIS { get { return "/dom[@domain='"+VCACHostName+"']" + "//table[#'TENANT_ID_STORE_TYPE_FIELD']//tr/td";}}
		    public static string webElmOpenLDAP_AIS { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[@innertext='Active Directory']";}}
	    	
		    public static string webElmURL_AIS { get { return "/dom[@domain='"+VCACHostName+"']" + "//input[#'TENANT_ID_STORE_URL_FIELD']";}}
		    public static string webElmDomain_AIS { get { return "/dom[@domain='"+VCACHostName+"']" + "//input[#'TENANT_ID_STORE_DOMAIN_FIELD']";}}
		    public static string webElmLoginUserDN_AIS { get { return "/dom[@domain='"+VCACHostName+"']" + "//input[#'TENANT_ID_STORE_USER_NAME_DN_FIELD']";}}
		    public static string webElmPassword_AIS { get { return "/dom[@domain='"+VCACHostName+"']" + "//input[#'TENANT_ID_STORE_PASSWORD_FIELD']";}}
		    public static string webElmGroupSearchBaseDN_AIS { get { return "/dom[@domain='"+VCACHostName+"']" + "//input[#'TENANT_ID_STORE_GROUP_BASE_DN_FIELD']";}}
		    public static string webElmAdd_AIS { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[@class='gwt-DialogBox']//button[#'submit']";}}
		    public static string waittwo{ get { return "/dom[@domain='"+VCACHostName+"']" + "//table[#'TENANT_ID_STORE_LIST_TABLE']//a[@title='" + Config.IdentityStoreName + "']/b[@innertext='" + Config.IdentityStoreName + "']";}}
		    public static string webElmNext_AIS { get { return "/dom[@domain='"+VCACHostName+"']" + "//button[#'next']";}}
		    public static string webElmSearch_ADM { get { return "/dom[@domain='"+VCACHostName+"']" + "//table[#'TENANT_TENANT_ADMIN_SELECTOR']//input";}}
		    public static string webElmPopup1_ADM { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[@class='suggestPopupMiddleCenterInner suggestPopupContent' and @visible='true']//tr[1]";}}
		    public static string webElmPopup2_ADM { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[@class='suggestPopupMiddleCenterInner suggestPopupContent']//tr[1]";}}
		    public static string webElmAdd_ADM { get { return "/dom[@domain='"+VCACHostName+"']" + "//button[#'submit']";}}
		    public static string waitthree { get { return "/dom[@domain='"+VCACHostName+"']" + "//table[#'TENANT_LIST_TABLE']//a[@title='" + Config.TenantName + "']/b[@innertext='" + Config.TenantName + "' and @visible='True']";}}
		    public static string waitFour{ get { return "/dom[@domain='"+VCACHostName+"']" + "//div[#'shellTabBar']";}}
		    public static string waitFive{ get { return "/dom[@domain='"+VCACHostName+"']" + "//div[#'vcac.administration']";}}
		    
		    public static string webElmSearch_Iaas_ADM { get { return "/dom[@domain='"+VCACHostName+"']" + "//table[#'TENANT_IAAS_ADMIN_SELECTOR']//input";}}
		    public static string webElmPopup1_Iaas_ADM { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[@class='suggestPopupMiddleCenterInner suggestPopupContent' and @visible='true']//tr[1]";}}
		    
		    public static string webElmAdministration_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[#'vcac.administration']";}}
		    public static string webElmUsers_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[#'vcac.administration.tenant.users']";}}
		    public static string webElmSearch_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//input[#'TENANT_USERS_LIST_TABLE_TABLEVIEW_SEARCH_TEXTBOX']";}}
		    public static string webElmSearchIcon_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//img[#'TENANT_USERS_LIST_TABLE_TABLEVIEW_SEARCH_IMG_SEARCH_OR_CLEAR']";}}
		    public static string webElmAdminUserLink_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//tr[#'"+Config.AdministratorsUserName1+"@"+Config.IdentityStoreDomain+"']//span[@title='"+Config.AdministratorsUserName1+"@"+Config.IdentityStoreDomain+"']";}}
		    public static string waitSix{ get { return "/dom[@domain='"+VCACHostName+"']" + "//table[#'TENANT_GROUPS_LIST_TABLE']//div[@class='gwt-Label GKDDAIOBAOD']";}}
		    
		    public static string inpTagApprovalAdministrator_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[@class='listBoxEx']//tr[1]//input";}}
		    public static string inpTagBusinessManagementAdministrator_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[@class='listBoxEx']//tr[2]//input";}}
		    public static string inpTagBusinessManagementReadonlyUser_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[@class='listBoxEx']//tr[3]//input";}}
		    public static string inpTagServiceArchitect_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[@class='listBoxEx']//tr[4]//input";}}
		    public static string inpTagTenantAdministrator_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[@class='listBoxEx']//tr[5]//input";}}
		    public static string webElmUpdate_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//button[#'submit']";}}
		    public static string webElmAdminUserLink1_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//tr[#'"+Config.AdministratorsUserName1+"']//span[@title='"+Config.AdministratorsUserName1+"']";}}
		    public static string waitSeven{ get { return "/dom[@domain='"+VCACHostName+"']" + "//div[#'vcbm.csp.places.home']";}}
		    
		    
		    public static string webElmBusinessManagement_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[#'vcbm.csp.places.home']";}}
		    public static string waitEight{ get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe//div[#'dialogue-1011']";}}
		    public static string webElmLicense_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe//input[#'licenseKey']";}}
		    public static string webElmSave_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe//div[#'add-license']//button";}}
		    public static string webElmAdministration1_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[#'vcac.administration']";}}
		    public static string webElmBusinessManagement1_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//div[#'vcbm.csp.places.administration']";}}
		/*  public static string waitNine{ get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'manageVCServers-']//button";}}
		    public static string webElmAddVcServer_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'manageVCServers-']//button";}}
		   	
		    public static string webElmName3_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'dynamicForm-']//table[1]//input";}}
		    public static string webElmVcenterServer3_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'dynamicForm-']//table[2]//input";}}
		    public static string webElmUserName3_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'dynamicForm-']//table[3]//input";}}
		    public static string webElmPassword3_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'dynamicForm-']//table[4]//input";}}
		    public static string webElmSave3_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'dynamicForm-']//button[@id~'dialogueSaveBtn-']";}}
		    public static string webElmInstall_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'threeButtonWindow-']//button[@id~'dialogueSaveBtn']";}}
		*/	
		
	
		    public static string webMvc1 { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//img[#'tool-1233-toolEl']";}}
		    public static string webMvc2{ get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//img[#'tool-1240-toolEl']";}}
//		    
//			
//		    public static string waitNine{ get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_2']//img[#'tool-1233-toolEl']";}}
		     
//		    public static string waitNine{ get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_2']//div[@id~'manageVCServers-']//button";}}
		    public static string webElmAddVcServer_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'manageVCServers-']//button";}} 		
		    public static string webElmName3_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'dynamicForm-']//table[1]//input";}}
		    public static string webElmVcenterServer3_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'dynamicForm-']//table[2]//input";}}
		    public static string webElmUserName3_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'dynamicForm-']//table[3]//input";}}
		    public static string webElmPassword3_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'dynamicForm-']//table[4]//input";}}
		    public static string webElmSave3_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'dynamicForm-']//button[@id~'dialogueSaveBtn-']";}}
		    public static string webElmInstall_MyT { get { return "/dom[@domain='"+VCACHostName+"']" + "//iframe[@id='__gadget_3']//div[@id~'threeButtonWindow-']//button[@id~'dialogueSaveBtn']";}}
	
        #endregion
        
        	#region
        	public static string VcacDomRoot = "/dom[@domain='"+ Config.VcacFQDN + ":" + Config.VcacPort+"']";
	   		public static string UserName {get {return  VcacDomRoot + "//input[@type='text']";}}
	   		public static string Password {get {return  VcacDomRoot + "//input[@type='password']";}}
	   		public static string IaasInstall {get {return  VcacDomRoot + "//table[@class='vami-navpanel']//td[6]";}}
	   		public static string IaasInstaller {get {return  VcacDomRoot + "//a[@href~'setup']";}}
        	#endregion

        }
			
		public class SSO
		{
			public static string SSOHostName {
				get {
					return Config.SSOHostName;
					//return "pek2-office-04-dhcp224.eng.vmware.com";
				}
			}
			public static string ssoRoot {
				get {
					return  "/dom[@domain='" + Config.VCACHostName + "']";
				}
			}
			public static string webElmUserName1 {get { return "/dom[@domain='" + Config.SSOHostName + ":7444" + "']"+"//input[#'username']";}}
			public static string webElmPassword1 {get { return "/dom[@domain='" + Config.SSOHostName + ":7444" + "']"+"//input[#'password']";}}
			public static string webElmUserName1_MyT  {get { return "/dom[@domain='" + Config.SSOHostName + ":7444" + "']"+"//input[#'username']";}}
			public static string webElmPassword1_MyT  {get { return "/dom[@domain='" + Config.SSOHostName + ":7444" + "']"+"//input[#'password']";}}	
		}
		
	    public class Iaas
        {
        	public static string RunButton = "/form[@class='#32770']/button[@controlid='4426']";
        	public static string IaasFormRoot = "/form[@controlname='VcacSuiteConfigMainForm']";
        	public static string NextButton {get {return  IaasFormRoot + "//button[@controlname='BtnNext']";}}
        	public static string AcceptLicense {get {return  IaasFormRoot + "//checkbox[@controlname='licenseAgreementCheckBox']";}}
        	public static string UserName {get {return  IaasFormRoot + "//text[@controlname='vcacApplianceUserNameTextBox']";}}
        	public static string Password {get {return  IaasFormRoot + "//text[@controlname='vcacApplianceUserNamePasswordTextBox']";}}
        	public static string CompleteInstall {get {return  IaasFormRoot + "//radiobutton[@controlname='completeInstallTypeRadioButton']";}}
        	public static string ByPass {get {return  IaasFormRoot + "//button[@controlname='butPreReqCheckerByPass']";}}
        	public static string Password1 {get {return  IaasFormRoot + "//text[@controlname='ciPassword']";}}
        	public static string Conform {get {return  IaasFormRoot + "//text[@controlname='ciConfirmPassword']";}}
        	public static string Passphrase {get {return  IaasFormRoot + "//text[@controlname='ciPassPhrase']";}}
        	public static string Conform1 {get {return  IaasFormRoot + "//text[@controlname='ciConfirmPassPhrase']";}}
        	public static string DEMWorkerName {get {return  IaasFormRoot + "//text[@controlname='completeInstallDemWorkerNameTextBox']";}}
        	public static string DEMOrchestratorName {get {return  IaasFormRoot + "//text[@controlname='completeInstallDemOrchestratorNameTextBox']";}}
        	public static string VsphereAgentName {get {return  IaasFormRoot + "//text[@controlname='completeInstallvSphereAgentNameTextBox']";}}
        	public static string EndpointName {get {return  IaasFormRoot + "//text[@controlname='completeInstallvSphereAgentEndpointNameTextBox']";}}
        	public static string Load {get {return  IaasFormRoot + "//button[@controlname='DefaultTenantButton']";}}
        	public static string SSODefaultTenant {get {return  IaasFormRoot + "//text[@text='vsphere.local']";}}
        	public static string Download {get {return  IaasFormRoot + "//button[@controlname='ViewCertificateBtn']";}}
        	public static string Certificate {get {return  IaasFormRoot + "//text[@controlname='SecurityCertificateTextBox']/text[@Text~'CN=']";}}
        	public static string AcceptCertificate {get {return  IaasFormRoot + "//checkbox[@controlname='componentRegistryApproveCertificateCheckbox']";}}
        	public static string ViewCertificate {get {return  IaasFormRoot + "//container[@controlname='groupComponentRegistry']//link";}}
        	public static string InstallCertificate {get {return "/form[@class='#32770']/container[@class='#32770']/button[controlid='101']";}}
        	public static string NextButton1 {get {return"/form[@enabled='True']/button[@controlid='12324']";}}
        	public static string FollowingStore {get {return"/form[@enabled='True']//radiobutton[@controlid='1012']";}}
        	public static string Browse {get {return"/form[@enabled='True']//button[@controlid='1000' and @enabled='True']";}}
        	public static string TrustRootCertificateAuthorities {get {return"/form[@enabled='True' and @active='True']//treeitem[2]";}}
        	public static string OKButton {get {return"/form[@enabled='True']/button[@controlid='1']";}}
        	public static string Finish {get {return"/form[@enabled='True']/button[@controlid='12325']";}}
        	public static string YesButton {get {return"/form[@enabled='True']/button[@controlid='6']";}}
        	public static string OKButton1 {get {return"/form[@enabled='True']/button[@visible='True']";}}
        	public static string UserName1 {get {return IaasFormRoot + "//text[@controlname='ssoCredentialsUserNameTextBox']";}}
        	public static string Password2 {get {return IaasFormRoot + "//text[@controlname='ssoCredentialsPasswordTextBox']";}}
        	public static string Conform2 {get {return IaasFormRoot + "//text[@controlname='ssoCredentialsConfirmPasswordTextBox']";}}
        	public static string TestLink1 {get {return IaasFormRoot + "//link[@controlname='ssoCredentialsLinkLabel']";}}
        	public static string PassedString {get {return IaasFormRoot + "//text[@controlname='SsoCredentialsLabel' and @visible='True' and ForeColor='Color [Green]']";}}
        	public static string TestLink2 {get {return IaasFormRoot + "//link[@controlname='IaaSServerTestLinkLabel']";}}
        	public static string PassedString1 {get {return IaasFormRoot + "//text[@controlname='IaaSServerTestStatusLabel' and @visible='True' and ForeColor='Color [Green]']";}}
        	public static string Install {get {return  IaasFormRoot + "//button[@controlname='BtnNext']";}}
        	public static string NextButton2 {get {return  IaasFormRoot + "//button[@controlname='BtnNext' and @enabled='True']";}}
        	public static string GuideMe {get {return  IaasFormRoot + "//checkbox[@controlname='launchConfigWizardCheckBox']";}}
        	public static string YesButton1 {get {return  "/form[@enabled='True']/button[@controlid='6']";}}
        	public static string YesButton2 {get {return  "/form[@enabled='True']/button[@controlid='6']";}}
        	
        	public static string CustomInstall {get {return  IaasFormRoot + "//radiobutton[@controlname='customInstallTypeRadioButton']";}}
        	public static string IaaSServer {get {return  IaasFormRoot + "//radiobutton[@controlname='customInstallIaaSSelectionRadioButton']";}}
        	public static string ChangeFolder {get {return  IaasFormRoot + "//button[@controlname='customInstallLocationChangeButton']";}}
        	public static string ComputerNode {get {return  "/form[@class='#32770' and @active='True']//treeitem[3]";}}
        	public static string LocalDiskCNode {get {return  "/form[@class='#32770' and @active='True']//treeitem[@text~'\\(C:\\)$']";}}
        	public static string MakeNewFolder {get {return  "/form[@class='#32770' and @active='True']//button[@controlid='14150']";}}
        	public static string OkButton2 {get {return  "/form[@class='#32770' and @active='True']//button[@controlid='1']";}}
        	public static string DatabaseTab {get {return  IaasFormRoot + "//TabPageList[@controlname='customInstallVcacFeatureTabControl']//tabpage[@index='0'and @accessiblerole='PageTab']";}}
        	public static string DatabaseInstance {get {return  IaasFormRoot + "//combobox[@controlname='customInstallDatabaseInstanceComboBox']/text";}}
        	public static string DatabaseName {get {return  IaasFormRoot + "//text[@controlname='customInstallDatabaseNameTextBox']/text";}}
        	public static string AdministrationModelManagerWebSiteTab {get {return  IaasFormRoot + "//TabPageList[@controlname='customInstallVcacFeatureTabControl']//tabpage[@index='1'and @accessiblerole='PageTab']";}}
        	public static string AvailableWebsites {get {return  IaasFormRoot + "//combobox[@controlname='customInstallInternetInformationServiceAvailableSiteComboBox']";}}
        	public static string UsedWebSite {get {return  "/list/listitem[@text='" + Config.WebSiteName + "']";}}
        	public static string AvailableCertificates {get {return IaasFormRoot + "//combobox[@controlname='customInstallInternetInformationServiceAvailableCertificateComboBox']";}}
        	public static string UsedCertificate {get {return "/list[@controlid='1000']/listitem[@text~'^(?i:" + Environment.MachineName + "." + Config.DomainName + ")$']";}}
        	public static string ModelManagerData {get {return IaasFormRoot + "//TabPageList[@controlname='customInstallVcacFeatureTabControl']//tabpage[@index='2'and @accessiblerole='PageTab']";}}
        	public static string Server {get {return IaasFormRoot + "//text[@controlname='customInstallModelManagerDataComponentRegistryServerTextBox']/text";}}
        	public static string Load1 {get {return IaasFormRoot + "//button[@controlname='customInstallModelManagerDataComponentRegistryDefaultTenantTextBoxButton']";}}
        	public static string SSODefaultTenant1 {get {return IaasFormRoot + "//text[@controlname='customInstallModelManagerDataComponentRegistryDefaultTenantTextBox']/text[@text='vsphere.local']";}}
        	public static string Download1 {get {return IaasFormRoot + "//button[@controlname='MMDataViewCertificateBtn']";}}
        	public static string Certificate1 {get {return IaasFormRoot + "//text[@controlname='MMDataSecurityCertificateTextBox']/text[@text~'^CN=']";}}
        	public static string AcceptCertificate1 {get {return IaasFormRoot + "//checkbox[@controlname='customInstallModelManagerDataAcceptCertificateCheckBox']";}}
        	public static string UserName2 {get {return IaasFormRoot + "//text[@controlname='customInstallModelManagerDataSSOUserNameTextBox']/text";}}
        	public static string Password3 {get {return IaasFormRoot + "//text[@controlname='customInstallModelManagerDataSSOPasswordTextBox']/text";}}
        	public static string Conform3 {get {return IaasFormRoot + "//text[@controlname='customInstallModelManagerDataSSOPasswordConfirmTextBox']/text";}}
        	public static string IaaSServer1 {get {return IaasFormRoot + "//text[@controlname='customInstallModelManagerDataIaaSServerTextBox']/text";}}
        	public static string TestLink3 {get {return IaasFormRoot + "//link[@controlname='MMDataSSOCredentialsLinkLabel']";}}
        	public static string PassedString2 {get {return IaasFormRoot + "//text[@controlname='MMDataSSOCredentialsLabel' and @visible='True' and ForeColor='Color [Green]']";}}
        	public static string TestLink4 {get {return IaasFormRoot + "//link[@controlname='CustomInstallIaaSServerTestLinkLabel']";}}
        	public static string PassedString3 {get {return IaasFormRoot + "//text[@controlname='CustomInstallIaaSServerTestStatusLabel' and @visible='True' and ForeColor='Color [Green]']";}}
        	public static string vCloudAutomationCenterServer {get {return IaasFormRoot + "//tree[@controlname='customInstallFeatureSelectionTreeView']/tree/checkbox";}}
        	public static string ManagerServiceTab {get {return  IaasFormRoot + "//TabPageList[@controlname='customInstallVcacFeatureTabControl']//tabpage[@index='3'and @accessiblerole='PageTab']";}}
        	public static string Password5 {get {return  IaasFormRoot + "//text[@controlname='customServiceAccountPasswordTextBox']";}}
        	public static string Conform5 {get {return  IaasFormRoot + "//text[@controlname='customServiceAccountPasswordConfirmTextBox']";}}
        	public static string Passphrase1 {get {return  IaasFormRoot + "//text[@controlname='customSecurityPassphraseTextBox']";}}
        	public static string Conform6 {get {return  IaasFormRoot + "//text[@controlname='customSecurityPassphraseConfirmTextBox']";}}
        	public static string CustomFolderNode {get {return  "/form[@class='#32770' and @active='True']//treeitem[@text='" + Config.CustomInstallFolderName + "']";}}
        	
        	
        	public static string DistributedExecutionManagers {get {return  IaasFormRoot + "//radiobutton[@controlname='customInstallDemSelectionRadioButton']";}}
        	public static string Password4 {get {return  IaasFormRoot + "//text[@controlname='customServiceAccountPasswordTextBox']/text";}}
        	public static string Conform4 {get {return  IaasFormRoot + "//text[@controlname='customServiceAccountPasswordConfirmTextBox']/text";}}
        	public static string DEMName {get {return  IaasFormRoot + "//text[@controlname='customDemInstallInstanceNameTextBox']/text";}}
        	public static string DEMDescription {get {return  IaasFormRoot + "//text[@controlname='customDemInstallInstanceDescriptionTextBox']/text";}}
        	public static string ManagerServiceHostName {get {return  IaasFormRoot + "//text[@controlname='customDemInstallManagerServiceHostNameTextBox']/text";}}
        	public static string TestLink5 {get {return  IaasFormRoot + "//link[@controlname='customDemInstallTestManagerServiceHostNameLinkLabel']";}}
        	public static string PassedString4 {get {return  IaasFormRoot + "//text[@controlname='customDemInstallTestManagerServiceHostResultLabel' and @visible='True' and ForeColor='Color [Green]']";}}
        	public static string TestLink6 {get {return  IaasFormRoot + "//link[@controlname='customDemInstallTestMMWebHostLinkLabel']";}}
        	public static string PassedString5 {get {return  IaasFormRoot + "//text[@controlname='customDemInstallTestMMWebHostResultLabel' and @visible='True' and ForeColor='Color [Green]']";}}
        	public static string Add {get {return  IaasFormRoot + "//button[@controlname='customDemInstallAddNewDemButton']";}}
        	public static string DEMRole {get {return  IaasFormRoot + "//combobox[@controlname='customDemInstallRoleComboBox']";}}
        	public static string Orchestrator {get {return  "/list[@controlid='1000']/listitem[@index='1']";}}
        	
        	
        	
        	public static string ProxyAgents {get {return  IaasFormRoot + "//radiobutton[@controlname='customInstallProxyAgentSelectionRadioButton']";}}
        	public static string AgentType {get {return  IaasFormRoot + "//combobox[@controlname='customProxyAgentInstallAgentTypeComboBox']";}}
        	public static string Vsphere {get {return  "/list[@controlid='1000']/listitem[@index='6']";}}
        	public static string AgentName {get {return  IaasFormRoot + "//text[@controlname='customProxyAgentInstallAgentNameTextBox']";}}
        	public static string ManagerServiceHostName1 {get {return  IaasFormRoot + "//text[@controlname='customProxyAgentInstallManagerServiceHostNameTextBox']/text";}}
        	public static string TestLink7 {get {return  IaasFormRoot + "//link[@controlname='customProxyAgentInstallTestManagerServiceHostNameLinkLabel']";}}
        	public static string PassedString6 {get {return  IaasFormRoot + "//text[@controlname='customProxyAgentInstallTestManagerServiceHostResultLabel' and @visible='True' and ForeColor='Color [Green]']";}}
        	public static string TestLink8 {get {return  IaasFormRoot + "//link[@controlname='customProxyAgentInstallTestMMWebHostLinkLabel']";}}
        	public static string PassedString7 {get {return  IaasFormRoot + "//text[@controlname='customProxyAgentInstallTestMMWebHostResultLabel' and @visible='True' and ForeColor='Color [Green]']";}}
        	public static string Endpoint {get {return  IaasFormRoot + "//text[@controlname='customProxyAgentInstallVsphereEndpointTextBox']";}}
        	public static string Add1 {get {return  IaasFormRoot + "//button[@controlname='customProxyAgentInstallAddNewAgentButton']";}}
        	
        	
        	
        	public static string ConformReplaceFolder {get {return  "/form[@class='#32770' and @active='True']/button[@controlid='6']";}}
        	
        	
        } 
	    
	    public class ConfigFireforx{
	    	public static string OptionDialogForm = "/form[@accessiblestate='Moveable, Focusable']/";
	    	public static string AdvancedListItem = OptionDialogForm + ".//list[@accessiblerole='List']/listitem[8]";
	    	public static string UpdatePageTab = OptionDialogForm + ".//tabpage[4]";
	    	public static string NeverUpdateRadioButton = OptionDialogForm + ".//radiobutton[3]";
	    	public static string OKButton = OptionDialogForm + ".//button[@accessiblerole='PushButton' and @accessiblestate='Default, Focusable']";
	    }
    }
}
