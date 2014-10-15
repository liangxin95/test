/*
 * Created by Ranorex
 * User: Administrator
 * Date: 3/11/2014
 * Time: 9:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Globalization.Framework;

namespace ITBM
{
	/// <summary>
	/// Description of Config.
	/// </summary>
	public class Config
	{
        //ConfigFile cf = new ConfigFile(@".\config.ini");
		//-dm=thin --acceptAllEulas --powerOn --prop:varoot-password=vmware123 --name=vcac_lx z:\VMware-vCAC-Appliance-6.1.0.0-1648823_OVF10.ova "vi://root:vmware@10.117.4.215/Mike's Datacenter/host/10.117.6.127/Resources/lx"
		#region  VC
		public static string VCUsername = ConfigFile.ReadValue("vCenter","VCUsername");
		public static string VCPassword = ConfigFile.ReadValue("vCenter","VCPassword");
		public static string VCIP = ConfigFile.ReadValue("vCenter","VCIP");
		//public static string VCName = ConfigFile.ReadValue("vCenter","VCName");
		//public static string ESXiIP = ConfigFile.ReadValue("vCenter","ESXiIP");
		//public static string ResourcePool = ConfigFile.ReadValue("vCenter","ResourcePool");
		public static string DatastoreName = ConfigFile.ReadValue("vCenter","DatastoreName");
		public static string DatastoreParam = "--datastore=";
		public static string Getway = ConfigFile.ReadValue("vCenter","Getway");
		public static string moref = ConfigFile.ReadValue("vCenter","moref");
		//public static string VMLocation = "\"vi://" + VCUsername + ":" + VCPassword + "@" + VCIP + "/" + VCName + "/host/" + ESXiIP + "/Resources/" + ResourcePool + "\"";
		public static string VMLocation ="\"vi://" + VCUsername +":"+ VCPassword +"@"+ VCIP + "?moref=" + moref;
		public static string BuildPath = ConfigFile.ReadValue("Path","BuildPath");
		#endregion
		
		#region VCAC
		public static string DomainName = ConfigFile.ReadValue("DeployINfo","DomainName");
		//public static string VCACName = ConfigFile.ReadValue("VCAC","VCACName");
		public static string VCACHostName = ConfigFile.ReadValue("DeployINfo","VCACHostName")+"."+DomainName;
		public static string VCACIP = ConfigFile.ReadValue("DeployINfo","VCACIP");
		public static string VCACOVFName = ConfigFile.ReadValue("DeployINfo","VCACOVFName");
		//public static string VCACNameParam = "--name=";
		public static string VCACHostNameParam = "--prop:vami.hostname=";
		public static string VCACIPParm = "--prop:vami.ip0.VMware_vCAC_Appliance=";
		public static string VCACParam = ConfigFile.ReadValue("VCAC","VCACParam")+Getway+" "+DatastoreParam+DatastoreName+" "+ VCACHostNameParam+VCACHostName +" "+VCACIPParm + VCACIP;
		public static string VCAC = VCACParam +" "+ BuildPath + VCACOVFName + " " + VMLocation;
		//public static string VCAC = @"-dm=thin --acceptAllEulas --powerOn --prop:varoot-password=vmware123 --name=vcac_lx z:\VMware-vCAC-Appliance-6.1.0.0-1648823_OVF10.ova ""vi://root:vmware@10.117.4.215/Mike's Datacenter/host/10.117.6.127/Resources/lx""";
		//-dm=thin --acceptAllEulas --powerOn --prop:itfm_root_password=vmware123 --prop:itfm_currency="USD - US Dollar" --name=ITBM_lx z:\ITBM-Standard-1.1.0.0-1633825_OVF10.ova "vi://root:vmware@10.117.4.215/Mike's Datacenter/host/10.117.6.127/Resources/lx"
		#endregion
		
		#region SSO
		//public static string SSOName = ConfigFile.ReadValue("SSO","SSOName");
		public static string SSOHostName = ConfigFile.ReadValue("DeployINfo","SSOHostName")+"."+DomainName;
		public static string SSOIP = ConfigFile.ReadValue("DeployINfo","SSOIP");
		public static string SSOOVFName = ConfigFile.ReadValue("DeployINfo","SSOOVFName");
		//public static string SSONameParam = "--name=";
		public static string SSOHostNameParam = "--prop:vami.hostname=";
		public static string SSOIPParm = "--prop:vami.ip0.VMware_Identity_Appliance=";
		public static string SSOParam = ConfigFile.ReadValue("SSO","SSOParam")+Getway+" "+DatastoreParam+DatastoreName+" "+ SSOHostNameParam+SSOHostName +" "+SSOIPParm + SSOIP;
		public static string SSO = SSOParam +" " + BuildPath + SSOOVFName + " " +  VMLocation;
		//public static string SSO = @"-dm=thin --acceptAllEulas --powerOn --prop:varoot-password=vmware123 --name=SSO_lx z:\VMware-Identity-Appliance-2.0.1.0-1545089_OVF10.ova ""vi://root:vmware@10.117.4.215/Mike's Datacenter/host/10.117.6.127/Resources/lx""";
		//plink -pw vmware123 root@10.117.4.28 exit<t.txt
		public static string PlinkParam1 = "-pw @WSX3edc root@";
		//plink -pw vmware123 -m s.txt root@10.117.4.28
		public static string PlinkParam2 = "-pw @WSX3edc -m s.txt root@";
		#endregion
		
		#region Config web 
		public static string Organisation = ConfigFile.ReadValue("UI","Organisation");
		public static string OrganisationalUnit = ConfigFile.ReadValue("UI","OrganisationalUnit");
		public static string CountryCode = ConfigFile.ReadValue("UI","CountryCode");
		public static string Licensing = ConfigFile.ReadValue("UI","Licensing");
		public static bool DepolyVcac = false; 
		public static bool DepolySSO = false;
		public static bool DepolyITBM = false;
		public static bool ConfigSSLSSO = false;
		public static string TenantName = ConfigFile.ReadValue("UI","TenantName");
		public static string TenantDescription = ConfigFile.ReadValue("UI","TenantDescription");
		public static string TenantURLName = ConfigFile.ReadValue("UI","TenantURLName");
		public static string TenantContactEmail = ConfigFile.ReadValue("UI","TenantContactEmail");
		public static string IdentityStoreName = ConfigFile.ReadValue("UI","IdentityStoreName");
		public static string IdentityStoreURL = ConfigFile.ReadValue("UI","IdentityStoreURL");
		public static string IdentityStoreDomain = ConfigFile.ReadValue("UI","IdentityStoreDomain");
		public static string IdentityStoreLoginUserDN = ConfigFile.ReadValue("UI","IdentityStoreLoginUserDN");
		public static string IdentityStorePassword = ConfigFile.ReadValue("UI","IdentityStorePassword");
		public static string IdentityStoreGroupSearchBaseDN = ConfigFile.ReadValue("UI","IdentityStoreGroupSearchBaseDN");
		public static string AdministratorsUserName1 = ConfigFile.ReadValue("UI","AdministratorsUserName1");
		public static string MyTenantLicense = ConfigFile.ReadValue("UI","MyTenantLicense");
		public static string MyTenantVCName = ConfigFile.ReadValue("UI","MyTenantVCName");
		#endregion
		
		# region Map NetworkPath
		public static string ReallyBuildPath = ConfigFile.ReadValue("Map NetworkPath","ReallyBuildPath");
		public static string UserName = ConfigFile.ReadValue("Map NetworkPath","UserName");
		public static string Password = ConfigFile.ReadValue("Map NetworkPath","Password");	
		#endregion
		
		#region Issa Install
		public static string VcacFQDN = Config.VCACHostName;
		public static string VcacPort = "5480";
		public static string VcacUrl = "https://"+ VcacFQDN +":"+VcacPort;
		public static string VcacUser = "root";
		public static string VcacPassword = "@WSX3edc";
		//public static string DomainAdmin = "vcmen\\administrator";
        //public static string DomainAdminPassword = "123456";
        //public static string DomainAdminPasswordKeystring = "123456";
		//public static string loginUser = @"vcmen\woo鷗Œé停B逍Üßàù01";
		
		public static string CustomInstall = ConfigFile.ReadValue("Iaas","CustomInstall");
        public static string loginUserPassword = ConfigFile.ReadValue("Iaas","loginUserPassword");
        public static string DEMWorkerName = ConfigFile.ReadValue("Iaas","DEMWorkerName");
        //public static string DEMWorkerName = "DEM-鷗Œé停B逍Üßàù";
        public static string DEMOrchestratorName = ConfigFile.ReadValue("Iaas","DEMOrchestratorName");
        //public static string DEMOrchestratorName = "DEO-鷗Œé停B逍Üßàù";
        public static string VsphereAgentName = ConfigFile.ReadValue("Iaas","VsphereAgentName");
        public static string EndpointName = ConfigFile.ReadValue("Iaas","EndpointName");
        public static string ServiceName = ConfigFile.ReadValue("Iaas","ServiceName");
        public static string CustomInstallFolderName = ConfigFile.ReadValue("Iaas","CustomInstallFolderName");
        public static string DatabaseName = ConfigFile.ReadValue("Iaas","DatabaseName");
        public static string WebSiteName = ConfigFile.ReadValue("Iaas","WebSiteName");
		public static string FolderOrder1 = ConfigFile.ReadValue("Iaas","FolderOrder1");
        public static string FolderOrder2 = ConfigFile.ReadValue("Iaas","FolderOrder2");
        public static string DatabaseInstanceName = ConfigFile.ReadValue("Iaas","DatabaseInstanceName");
        #endregion
		
        public static bool Is2012Server = Environment.OSVersion.ToString().Equals("Microsoft Windows NT 6.2.9200.0");
	}
}
