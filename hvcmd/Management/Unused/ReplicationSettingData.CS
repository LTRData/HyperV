namespace LTR.HyperV.Management.ROOT.virtualization.v2 {
    using System;
    using System.ComponentModel;
    using System.Management;
    using System.Collections;
    using System.Globalization;
    
    
    // Funktionerna ShouldSerialize<PropertyName> är funktioner som används av Egenskapsgranskning i VS för att kontrollera om en viss egenskap måste serialiseras. Dessa funktioner läggs till för alla ValueType-egenskaper (egenskaper av typen Int32, BOOL m.fl. som inte kan anges till Null). Dessa funktioner använder funktionen Is<PropertyName>Null. Funktionerna används också vid implementering av TypeConverter när NULL-värde kontrolleras för egenskapen, så att ett tomt värde kan visas i Egenskapsgranskning om Dra och släpp används i Visual Studio.
    // Funktionerna Is<PropertyName>Null() används för att kontrollera om en egenskap är NULL.
    // Funktionerna Reset<PropertyName> läggs till för Read/Write-egenskaper som kan ha värdet NULL. Dessa funktioner används i Egenskapsgranskning i VS-designer för att ange en egenskap till NULL.
    // Varje egenskap som läggs till i klassen för WMI-egenskaper har angivna attribut som definierar dess beteende i Visual Studio-designer, och vilken TypeConverter som ska användas.
    // Konverteringsfunktionerna ToDateTime och ToDmtfDateTime för datum och tid läggs till för klassen så att DMTF-datum/tid kan konverteras till System.DateTime och tvärt om.
    // En EarlyBound-klass genererades för WMI-klassen.Msvm_ReplicationSettingData
    public class ReplicationSettingData : System.ComponentModel.Component {
        
        // En privat egenskap som ska innehålla WMI-namnområdet där klassen finns.
        private static string CreatedWmiNamespace = "root\\virtualization\\v2";
        
        // En privat egenskap som ska innehålla namnet på den WMI-klass som skapade den här klassen.
        private static string CreatedClassName = "Msvm_ReplicationSettingData";
        
        // En privat medlemsvariabel som ska innehålla ManagementScope som används i olika metoder.
        private static System.Management.ManagementScope statMgmtScope = null;
        
        private ManagementSystemProperties PrivateSystemProperties;
        
        // Ett underliggande lateBound WMI-objekt.
        private System.Management.ManagementObject PrivateLateBoundObject;
        
        // En medlemsvariabel som lagrar klassens automatiskt aktiverade beteende.
        private bool AutoCommitProp;
        
        // En privat variabel som ska innehålla de inbäddade egenskaper som representerar instansen.
        private System.Management.ManagementBaseObject embeddedObj;
        
        // Det aktuella WMI-objekt som används
        private System.Management.ManagementBaseObject curObj;
        
        // En flagga som indikerar om instansen är ett inbäddat objekt.
        private bool isEmbedded;
        
        // Nedan visas olika överlagringar för konstruktörer som initierar en instans för klassen med ett WMI-objekt.
        public ReplicationSettingData() {
            this.InitializeObject(null, null, null);
        }
        
        public ReplicationSettingData(string keyInstanceID) {
            this.InitializeObject(null, new System.Management.ManagementPath(ReplicationSettingData.ConstructPath(keyInstanceID)), null);
        }
        
        public ReplicationSettingData(System.Management.ManagementScope mgmtScope, string keyInstanceID) {
            this.InitializeObject(((System.Management.ManagementScope)(mgmtScope)), new System.Management.ManagementPath(ReplicationSettingData.ConstructPath(keyInstanceID)), null);
        }
        
        public ReplicationSettingData(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(null, path, getOptions);
        }
        
        public ReplicationSettingData(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
            this.InitializeObject(mgmtScope, path, null);
        }
        
        public ReplicationSettingData(System.Management.ManagementPath path) {
            this.InitializeObject(null, path, null);
        }
        
        public ReplicationSettingData(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(mgmtScope, path, getOptions);
        }
        
        public ReplicationSettingData(System.Management.ManagementObject theObject) {
            Initialize();
            if ((CheckIfProperClass(theObject) == true)) {
                PrivateLateBoundObject = theObject;
                PrivateSystemProperties = new ManagementSystemProperties(PrivateLateBoundObject);
                curObj = PrivateLateBoundObject;
            }
            else {
                throw new System.ArgumentException("Klassnamnet matchar inte.");
            }
        }
        
        public ReplicationSettingData(System.Management.ManagementBaseObject theObject) {
            Initialize();
            if ((CheckIfProperClass(theObject) == true)) {
                embeddedObj = theObject;
                PrivateSystemProperties = new ManagementSystemProperties(theObject);
                curObj = embeddedObj;
                isEmbedded = true;
            }
            else {
                throw new System.ArgumentException("Klassnamnet matchar inte.");
            }
        }
        
        // En egenskap som returnerar WMI-klassens namnområde.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OriginatingNamespace {
            get {
                return "root\\virtualization\\v2";
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ManagementClassName {
            get {
                string strRet = CreatedClassName;
                if ((curObj != null)) {
                    if ((curObj.ClassPath != null)) {
                        strRet = ((string)(curObj["__CLASS"]));
                        if (((strRet == null) 
                                    || (strRet == string.Empty))) {
                            strRet = CreatedClassName;
                        }
                    }
                }
                return strRet;
            }
        }
        
        // Egenskaper som pekar till ett inbäddat objekt för att hämta WMI-objektets systemegenskaper.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ManagementSystemProperties SystemProperties {
            get {
                return PrivateSystemProperties;
            }
        }
        
        // En egenskap som returnerar det underliggande lateBound-objektet.
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Management.ManagementBaseObject LateBoundObject {
            get {
                return curObj;
            }
        }
        
        // Objektets ManagementScope.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Management.ManagementScope Scope {
            get {
                if ((isEmbedded == false)) {
                    return PrivateLateBoundObject.Scope;
                }
                else {
                    return null;
                }
            }
            set {
                if ((isEmbedded == false)) {
                    PrivateLateBoundObject.Scope = value;
                }
            }
        }
        
        // Egenskap som visar aktiverat beteende för WMI-objektet. Om detta är True sparas WMI-objektet automatiskt efter varje egenskapsändring (d.v.s. Put() anropas efter en egenskapsändring).
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AutoCommit {
            get {
                return AutoCommitProp;
            }
            set {
                AutoCommitProp = value;
            }
        }
        
        // ManagementPath för det underliggande WMI-objektet.
        [Browsable(true)]
        public System.Management.ManagementPath Path {
            get {
                if ((isEmbedded == false)) {
                    return PrivateLateBoundObject.Path;
                }
                else {
                    return null;
                }
            }
            set {
                if ((isEmbedded == false)) {
                    if ((CheckIfProperClass(null, value, null) != true)) {
                        throw new System.ArgumentException("Klassnamnet matchar inte.");
                    }
                    PrivateLateBoundObject.Path = value;
                }
            }
        }
        
        // En offentlig och statisk områdesegenskap som används i olika metoder.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static System.Management.ManagementScope StaticScope {
            get {
                return statMgmtScope;
            }
            set {
                statMgmtScope = value;
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Additional replication settings which can be used by endpoint provider.")]
        public string AdditionalSettings {
            get {
                return ((string)(curObj["AdditionalSettings"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsApplicationConsistentSnapshotIntervalNull {
            get {
                if ((curObj["ApplicationConsistentSnapshotInterval"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Time interval between application consistent snapshots, specified in unit of hour" +
            "s. Valid range is from 1 hour to 12 hours in step of 1 hour.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort ApplicationConsistentSnapshotInterval {
            get {
                if ((curObj["ApplicationConsistentSnapshotInterval"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["ApplicationConsistentSnapshotInterval"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAuthenticationTypeNull {
            get {
                if ((curObj["AuthenticationType"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Define authentication mode used to connect to recovery server.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public AuthenticationTypeValues AuthenticationType {
            get {
                if ((curObj["AuthenticationType"] == null)) {
                    return ((AuthenticationTypeValues)(System.Convert.ToInt32(0)));
                }
                return ((AuthenticationTypeValues)(System.Convert.ToInt32(curObj["AuthenticationType"])));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAutomaticRecoveryActionNull {
            get {
                if ((curObj["AutomaticRecoveryAction"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort AutomaticRecoveryAction {
            get {
                if ((curObj["AutomaticRecoveryAction"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["AutomaticRecoveryAction"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAutomaticShutdownActionNull {
            get {
                if ((curObj["AutomaticShutdownAction"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort AutomaticShutdownAction {
            get {
                if ((curObj["AutomaticShutdownAction"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["AutomaticShutdownAction"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAutomaticStartupActionNull {
            get {
                if ((curObj["AutomaticStartupAction"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort AutomaticStartupAction {
            get {
                if ((curObj["AutomaticStartupAction"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["AutomaticStartupAction"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAutomaticStartupActionDelayNull {
            get {
                if ((curObj["AutomaticStartupActionDelay"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public System.DateTime AutomaticStartupActionDelay {
            get {
                if ((curObj["AutomaticStartupActionDelay"] != null)) {
                    return ToDateTime(((string)(curObj["AutomaticStartupActionDelay"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAutomaticStartupActionSequenceNumberNull {
            get {
                if ((curObj["AutomaticStartupActionSequenceNumber"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort AutomaticStartupActionSequenceNumber {
            get {
                if ((curObj["AutomaticStartupActionSequenceNumber"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["AutomaticStartupActionSequenceNumber"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAutoResynchronizeEnabledNull {
            get {
                if ((curObj["AutoResynchronizeEnabled"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Automatically trigger resynchronize operation on replication errors due to power " +
            "and hardware failures. Default value is TRUE.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool AutoResynchronizeEnabled {
            get {
                if ((curObj["AutoResynchronizeEnabled"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["AutoResynchronizeEnabled"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAutoResynchronizeIntervalEndNull {
            get {
                if ((curObj["AutoResynchronizeIntervalEnd"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Automatically trigger resynchronize operation on replication errors due to power and hardware failures when they occur before the time specified by this parameter and AutoResynchronizeEnabled is TRUE.
Specify the datetime using time elements only. Default value is 0600 hours local time.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public System.DateTime AutoResynchronizeIntervalEnd {
            get {
                if ((curObj["AutoResynchronizeIntervalEnd"] != null)) {
                    return ToDateTime(((string)(curObj["AutoResynchronizeIntervalEnd"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAutoResynchronizeIntervalStartNull {
            get {
                if ((curObj["AutoResynchronizeIntervalStart"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Automatically trigger resynchronize operation on replication errors due to power and hardware failures when they occur after the time specified by this parameter and AutoResynchronizeEnabled is TRUE.
Specify the datetime using time elements only. Default value is 1830 hours local time.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public System.DateTime AutoResynchronizeIntervalStart {
            get {
                if ((curObj["AutoResynchronizeIntervalStart"] != null)) {
                    return ToDateTime(((string)(curObj["AutoResynchronizeIntervalStart"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsBypassProxyServerNull {
            get {
                if ((curObj["BypassProxyServer"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Bypass proxy server while connectng it to recovery server.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool BypassProxyServer {
            get {
                if ((curObj["BypassProxyServer"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["BypassProxyServer"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Caption {
            get {
                return ((string)(curObj["Caption"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Certificate thumbprint to use when AuthenticationType is certificate based author" +
            "ization.")]
        public string CertificateThumbPrint {
            get {
                return ((string)(curObj["CertificateThumbPrint"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCompressionEnabledNull {
            get {
                if ((curObj["CompressionEnabled"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Enable compression of replication data while sending it to recovery server.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool CompressionEnabled {
            get {
                if ((curObj["CompressionEnabled"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["CompressionEnabled"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ConfigurationDataRoot {
            get {
                return ((string)(curObj["ConfigurationDataRoot"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ConfigurationFile {
            get {
                return ((string)(curObj["ConfigurationFile"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ConfigurationID {
            get {
                return ((string)(curObj["ConfigurationID"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCreationTimeNull {
            get {
                if ((curObj["CreationTime"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public System.DateTime CreationTime {
            get {
                if ((curObj["CreationTime"] != null)) {
                    return ToDateTime(((string)(curObj["CreationTime"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description {
            get {
                return ((string)(curObj["Description"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ElementName {
            get {
                return ((string)(curObj["ElementName"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEnableWriteOrderPreservationAcrossDisksNull {
            get {
                if ((curObj["EnableWriteOrderPreservationAcrossDisks"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Enabling this property ensures all replicating virtual hard disks for the virtual" +
            " machine are replicated to the same point in time. This ensures replication hono" +
            "rs the write-order of the applications in the virtual machine.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool EnableWriteOrderPreservationAcrossDisks {
            get {
                if ((curObj["EnableWriteOrderPreservationAcrossDisks"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["EnableWriteOrderPreservationAcrossDisks"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The list of VHD attached to the ComputerSystem that will be replicated by the Fai" +
            "lover Replication Engine. This is an array of strings each containing an the Ins" +
            "tanceID of the resource allocation setting data (RASD) of the VHD.")]
        public string[] IncludedDisks {
            get {
                return ((string[])(curObj["IncludedDisks"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string InstanceID {
            get {
                return ((string)(curObj["InstanceID"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LogDataRoot {
            get {
                return ((string)(curObj["LogDataRoot"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] Notes {
            get {
                return ((string[])(curObj["Notes"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Name of connection point, in case of primary cluster this is the broker CAP name " +
            "and in case of standalone primary server this is the host system name.")]
        public string PrimaryConnectionPoint {
            get {
                return ((string)(curObj["PrimaryConnectionPoint"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("FQDN of primary host system which is hosting the virtual machine.")]
        public string PrimaryHostSystem {
            get {
                return ((string)(curObj["PrimaryHostSystem"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Name of connection point, in case of recovery cluster this is the broker CAP name" +
            " and in case of standalone recovery server this is the host system name. In case" +
            " of external provider, this represents the connection point specific to the prov" +
            "ider.")]
        public string RecoveryConnectionPoint {
            get {
                return ((string)(curObj["RecoveryConnectionPoint"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RecoveryFile {
            get {
                return ((string)(curObj["RecoveryFile"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsRecoveryHistoryNull {
            get {
                if ((curObj["RecoveryHistory"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Maximum number of recovery snapshots stored at the recovery server.\nValid range i" +
            "s from 0 to 16 for the Hyper-V to Hyper-V replication. In case of external provi" +
            "der, range is as supported by the endpoint provider.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort RecoveryHistory {
            get {
                if ((curObj["RecoveryHistory"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["RecoveryHistory"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("FQDN of recovery host system which is hosting the virtual machine.")]
        public string RecoveryHostSystem {
            get {
                return ((string)(curObj["RecoveryHostSystem"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsRecoveryServerPortNumberNull {
            get {
                if ((curObj["RecoveryServerPortNumber"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Recovery server port number to use when making secure connection for replication." +
            "")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort RecoveryServerPortNumber {
            get {
                if ((curObj["RecoveryServerPortNumber"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["RecoveryServerPortNumber"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsReplicateHostKvpItemsNull {
            get {
                if ((curObj["ReplicateHostKvpItems"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Enable or disable of host-only Msvm_KvpExchangeDataItem from primary virtual mach" +
            "ine to recovery virtual machine. Default value is TRUE.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool ReplicateHostKvpItems {
            get {
                if ((curObj["ReplicateHostKvpItems"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["ReplicateHostKvpItems"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsReplicationIntervalNull {
            get {
                if ((curObj["ReplicationInterval"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Replication Interval of a replication relationship in seconds.\nValid values are 3" +
            "0, 300, 900.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort ReplicationInterval {
            get {
                if ((curObj["ReplicationInterval"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["ReplicationInterval"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Path to instance of class Msvm_ReplicationProvider that identifies the replicatio" +
            "n provider endpoint.")]
        public string ReplicationProvider {
            get {
                return ((string)(curObj["ReplicationProvider"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Root Certificate thumbprint of the certificate in use  when AuthenticationType is" +
            " certificate based authorization.")]
        public string RootCertificateThumbPrint {
            get {
                return ((string)(curObj["RootCertificateThumbPrint"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SnapshotDataRoot {
            get {
                return ((string)(curObj["SnapshotDataRoot"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SuspendDataRoot {
            get {
                return ((string)(curObj["SuspendDataRoot"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SwapFileDataRoot {
            get {
                return ((string)(curObj["SwapFileDataRoot"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string VirtualSystemIdentifier {
            get {
                return ((string)(curObj["VirtualSystemIdentifier"]));
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string VirtualSystemType {
            get {
                return ((string)(curObj["VirtualSystemType"]));
            }
        }
        
        private bool CheckIfProperClass(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions OptionsParam) {
            if (((path != null) 
                        && (string.Compare(path.ClassName, this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0))) {
                return true;
            }
            else {
                return CheckIfProperClass(new System.Management.ManagementObject(mgmtScope, path, OptionsParam));
            }
        }
        
        private bool CheckIfProperClass(System.Management.ManagementBaseObject theObj) {
            if (((theObj != null) 
                        && (string.Compare(((string)(theObj["__CLASS"])), this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0))) {
                return true;
            }
            else {
                System.Array parentClasses = ((System.Array)(theObj["__DERIVATION"]));
                if ((parentClasses != null)) {
                    int count = 0;
                    for (count = 0; (count < parentClasses.Length); count = (count + 1)) {
                        if ((string.Compare(((string)(parentClasses.GetValue(count))), this.ManagementClassName, true, System.Globalization.CultureInfo.InvariantCulture) == 0)) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        private bool ShouldSerializeApplicationConsistentSnapshotInterval() {
            if ((this.IsApplicationConsistentSnapshotIntervalNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeAuthenticationType() {
            if ((this.IsAuthenticationTypeNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeAutomaticRecoveryAction() {
            if ((this.IsAutomaticRecoveryActionNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeAutomaticShutdownAction() {
            if ((this.IsAutomaticShutdownActionNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeAutomaticStartupAction() {
            if ((this.IsAutomaticStartupActionNull == false)) {
                return true;
            }
            return false;
        }
        
        // Konverterar ett givet datum/tid med DMTF-format till System.DateTime-objekt.
        static System.DateTime ToDateTime(string dmtfDate) {
            System.DateTime initializer = System.DateTime.MinValue;
            int year = initializer.Year;
            int month = initializer.Month;
            int day = initializer.Day;
            int hour = initializer.Hour;
            int minute = initializer.Minute;
            int second = initializer.Second;
            long ticks = 0;
            string dmtf = dmtfDate;
            System.DateTime datetime = System.DateTime.MinValue;
            string tempString = string.Empty;
            if ((dmtf == null)) {
                throw new System.ArgumentOutOfRangeException();
            }
            if ((dmtf.Length == 0)) {
                throw new System.ArgumentOutOfRangeException();
            }
            if ((dmtf.Length != 25)) {
                throw new System.ArgumentOutOfRangeException();
            }
            try {
                tempString = dmtf.Substring(0, 4);
                if (("****" != tempString)) {
                    year = int.Parse(tempString);
                }
                tempString = dmtf.Substring(4, 2);
                if (("**" != tempString)) {
                    month = int.Parse(tempString);
                }
                tempString = dmtf.Substring(6, 2);
                if (("**" != tempString)) {
                    day = int.Parse(tempString);
                }
                tempString = dmtf.Substring(8, 2);
                if (("**" != tempString)) {
                    hour = int.Parse(tempString);
                }
                tempString = dmtf.Substring(10, 2);
                if (("**" != tempString)) {
                    minute = int.Parse(tempString);
                }
                tempString = dmtf.Substring(12, 2);
                if (("**" != tempString)) {
                    second = int.Parse(tempString);
                }
                tempString = dmtf.Substring(15, 6);
                if (("******" != tempString)) {
                    ticks = (long.Parse(tempString) * ((long)((System.TimeSpan.TicksPerMillisecond / 1000))));
                }
                if (((((((((year < 0) 
                            || (month < 0)) 
                            || (day < 0)) 
                            || (hour < 0)) 
                            || (minute < 0)) 
                            || (minute < 0)) 
                            || (second < 0)) 
                            || (ticks < 0))) {
                    throw new System.ArgumentOutOfRangeException();
                }
            }
            catch (System.Exception e) {
                throw new System.ArgumentOutOfRangeException(null, e.Message);
            }
            datetime = new System.DateTime(year, month, day, hour, minute, second, 0);
            datetime = datetime.AddTicks(ticks);
            System.TimeSpan tickOffset = System.TimeZone.CurrentTimeZone.GetUtcOffset(datetime);
            int UTCOffset = 0;
            int OffsetToBeAdjusted = 0;
            long OffsetMins = ((long)((tickOffset.Ticks / System.TimeSpan.TicksPerMinute)));
            tempString = dmtf.Substring(22, 3);
            if ((tempString != "******")) {
                tempString = dmtf.Substring(21, 4);
                try {
                    UTCOffset = int.Parse(tempString);
                }
                catch (System.Exception e) {
                    throw new System.ArgumentOutOfRangeException(null, e.Message);
                }
                OffsetToBeAdjusted = ((int)((OffsetMins - UTCOffset)));
                datetime = datetime.AddMinutes(((double)(OffsetToBeAdjusted)));
            }
            return datetime;
        }
        
        // Konverterar ett givet System.DateTime-objekt till DMTF-datum/tid.
        static string ToDmtfDateTime(System.DateTime date) {
            string utcString = string.Empty;
            System.TimeSpan tickOffset = System.TimeZone.CurrentTimeZone.GetUtcOffset(date);
            long OffsetMins = ((long)((tickOffset.Ticks / System.TimeSpan.TicksPerMinute)));
            if ((System.Math.Abs(OffsetMins) > 999)) {
                date = date.ToUniversalTime();
                utcString = "+000";
            }
            else {
                if ((tickOffset.Ticks >= 0)) {
                    utcString = string.Concat("+", ((long)((tickOffset.Ticks / System.TimeSpan.TicksPerMinute))).ToString().PadLeft(3, '0'));
                }
                else {
                    string strTemp = ((long)(OffsetMins)).ToString();
                    utcString = string.Concat("-", strTemp.Substring(1, (strTemp.Length - 1)).PadLeft(3, '0'));
                }
            }
            string dmtfDateTime = ((int)(date.Year)).ToString().PadLeft(4, '0');
            dmtfDateTime = string.Concat(dmtfDateTime, ((int)(date.Month)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ((int)(date.Day)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ((int)(date.Hour)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ((int)(date.Minute)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ((int)(date.Second)).ToString().PadLeft(2, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, ".");
            System.DateTime dtTemp = new System.DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, 0);
            long microsec = ((long)((((date.Ticks - dtTemp.Ticks) 
                        * 1000) 
                        / System.TimeSpan.TicksPerMillisecond)));
            string strMicrosec = ((long)(microsec)).ToString();
            if ((strMicrosec.Length > 6)) {
                strMicrosec = strMicrosec.Substring(0, 6);
            }
            dmtfDateTime = string.Concat(dmtfDateTime, strMicrosec.PadLeft(6, '0'));
            dmtfDateTime = string.Concat(dmtfDateTime, utcString);
            return dmtfDateTime;
        }
        
        private bool ShouldSerializeAutomaticStartupActionDelay() {
            if ((this.IsAutomaticStartupActionDelayNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeAutomaticStartupActionSequenceNumber() {
            if ((this.IsAutomaticStartupActionSequenceNumberNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeAutoResynchronizeEnabled() {
            if ((this.IsAutoResynchronizeEnabledNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeAutoResynchronizeIntervalEnd() {
            if ((this.IsAutoResynchronizeIntervalEndNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeAutoResynchronizeIntervalStart() {
            if ((this.IsAutoResynchronizeIntervalStartNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeBypassProxyServer() {
            if ((this.IsBypassProxyServerNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeCompressionEnabled() {
            if ((this.IsCompressionEnabledNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeCreationTime() {
            if ((this.IsCreationTimeNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeEnableWriteOrderPreservationAcrossDisks() {
            if ((this.IsEnableWriteOrderPreservationAcrossDisksNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeRecoveryHistory() {
            if ((this.IsRecoveryHistoryNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeRecoveryServerPortNumber() {
            if ((this.IsRecoveryServerPortNumberNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeReplicateHostKvpItems() {
            if ((this.IsReplicateHostKvpItemsNull == false)) {
                return true;
            }
            return false;
        }
        
        private bool ShouldSerializeReplicationInterval() {
            if ((this.IsReplicationIntervalNull == false)) {
                return true;
            }
            return false;
        }
        
        [Browsable(true)]
        public void CommitObject() {
            if ((isEmbedded == false)) {
                PrivateLateBoundObject.Put();
            }
        }
        
        [Browsable(true)]
        public void CommitObject(System.Management.PutOptions putOptions) {
            if ((isEmbedded == false)) {
                PrivateLateBoundObject.Put(putOptions);
            }
        }
        
        private void Initialize() {
            AutoCommitProp = true;
            isEmbedded = false;
        }
        
        private static string ConstructPath(string keyInstanceID) {
            string strPath = "root\\virtualization\\v2:Msvm_ReplicationSettingData";
            strPath = string.Concat(strPath, string.Concat(".InstanceID=", string.Concat("\"", string.Concat(keyInstanceID, "\""))));
            return strPath;
        }
        
        private void InitializeObject(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            Initialize();
            if ((path != null)) {
                if ((CheckIfProperClass(mgmtScope, path, getOptions) != true)) {
                    throw new System.ArgumentException("Klassnamnet matchar inte.");
                }
            }
            PrivateLateBoundObject = new System.Management.ManagementObject(mgmtScope, path, getOptions);
            PrivateSystemProperties = new ManagementSystemProperties(PrivateLateBoundObject);
            curObj = PrivateLateBoundObject;
        }
        
        // Olika överlagringar av hjälp om GetInstances() i WMI-klassens uppräkningsinstanser.
        public static ReplicationSettingDataCollection GetInstances() {
            return GetInstances(null, null, null);
        }
        
        public static ReplicationSettingDataCollection GetInstances(string condition) {
            return GetInstances(null, condition, null);
        }
        
        public static ReplicationSettingDataCollection GetInstances(string[] selectedProperties) {
            return GetInstances(null, null, selectedProperties);
        }
        
        public static ReplicationSettingDataCollection GetInstances(string condition, string[] selectedProperties) {
            return GetInstances(null, condition, selectedProperties);
        }
        
        public static ReplicationSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\virtualization\\v2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementPath pathObj = new System.Management.ManagementPath();
            pathObj.ClassName = "Msvm_ReplicationSettingData";
            pathObj.NamespacePath = "root\\virtualization\\v2";
            System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
            if ((enumOptions == null)) {
                enumOptions = new System.Management.EnumerationOptions();
                enumOptions.EnsureLocatable = true;
            }
            return new ReplicationSettingDataCollection(clsObject.GetInstances(enumOptions));
        }
        
        public static ReplicationSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
            return GetInstances(mgmtScope, condition, null);
        }
        
        public static ReplicationSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string[] selectedProperties) {
            return GetInstances(mgmtScope, null, selectedProperties);
        }
        
        public static ReplicationSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, string[] selectedProperties) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\virtualization\\v2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("Msvm_ReplicationSettingData", condition, selectedProperties));
            System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
            ObjectSearcher.Options = enumOptions;
            return new ReplicationSettingDataCollection(ObjectSearcher.Get());
        }
        
        [Browsable(true)]
        public static ReplicationSettingData CreateInstance() {
            System.Management.ManagementScope mgmtScope = null;
            if ((statMgmtScope == null)) {
                mgmtScope = new System.Management.ManagementScope();
                mgmtScope.Path.NamespacePath = CreatedWmiNamespace;
            }
            else {
                mgmtScope = statMgmtScope;
            }
            System.Management.ManagementPath mgmtPath = new System.Management.ManagementPath(CreatedClassName);
            System.Management.ManagementClass tmpMgmtClass = new System.Management.ManagementClass(mgmtScope, mgmtPath, null);
            return new ReplicationSettingData(tmpMgmtClass.CreateInstance());
        }
        
        [Browsable(true)]
        public void Delete() {
            PrivateLateBoundObject.Delete();
        }
        
        public enum AuthenticationTypeValues {
            
            Kerberos_authentication = 1,
            
            Certificate_based_authentication = 2,
            
            NULL_ENUM_VALUE = 0,
        }
        
        // Implementering av uppräknare för klassens uppräkningsinstanser.
        public class ReplicationSettingDataCollection : object, ICollection {
            
            private ManagementObjectCollection privColObj;
            
            public ReplicationSettingDataCollection(ManagementObjectCollection objCollection) {
                privColObj = objCollection;
            }
            
            public virtual int Count {
                get {
                    return privColObj.Count;
                }
            }
            
            public virtual bool IsSynchronized {
                get {
                    return privColObj.IsSynchronized;
                }
            }
            
            public virtual object SyncRoot {
                get {
                    return this;
                }
            }
            
            public virtual void CopyTo(System.Array array, int index) {
                privColObj.CopyTo(array, index);
                int nCtr;
                for (nCtr = 0; (nCtr < array.Length); nCtr = (nCtr + 1)) {
                    array.SetValue(new ReplicationSettingData(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
                }
            }
            
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return new ReplicationSettingDataEnumerator(privColObj.GetEnumerator());
            }
            
            public class ReplicationSettingDataEnumerator : object, System.Collections.IEnumerator {
                
                private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
                
                public ReplicationSettingDataEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                    privObjEnum = objEnum;
                }
                
                public virtual object Current {
                    get {
                        return new ReplicationSettingData(((System.Management.ManagementObject)(privObjEnum.Current)));
                    }
                }
                
                public virtual bool MoveNext() {
                    return privObjEnum.MoveNext();
                }
                
                public virtual void Reset() {
                    privObjEnum.Reset();
                }
            }
        }
        
        // TypeConverter som hanterar Null-värden för ValueType-egenskaper
        public class WMIValueTypeConverter : TypeConverter {
            
            private TypeConverter baseConverter;
            
            private System.Type baseType;
            
            public WMIValueTypeConverter(System.Type inBaseType) {
                baseConverter = TypeDescriptor.GetConverter(inBaseType);
                baseType = inBaseType;
            }
            
            public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type srcType) {
                return baseConverter.CanConvertFrom(context, srcType);
            }
            
            public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Type destinationType) {
                return baseConverter.CanConvertTo(context, destinationType);
            }
            
            public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) {
                return baseConverter.ConvertFrom(context, culture, value);
            }
            
            public override object CreateInstance(System.ComponentModel.ITypeDescriptorContext context, System.Collections.IDictionary dictionary) {
                return baseConverter.CreateInstance(context, dictionary);
            }
            
            public override bool GetCreateInstanceSupported(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetCreateInstanceSupported(context);
            }
            
            public override PropertyDescriptorCollection GetProperties(System.ComponentModel.ITypeDescriptorContext context, object value, System.Attribute[] attributeVar) {
                return baseConverter.GetProperties(context, value, attributeVar);
            }
            
            public override bool GetPropertiesSupported(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetPropertiesSupported(context);
            }
            
            public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetStandardValues(context);
            }
            
            public override bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetStandardValuesExclusive(context);
            }
            
            public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context) {
                return baseConverter.GetStandardValuesSupported(context);
            }
            
            public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType) {
                if ((baseType.BaseType == typeof(System.Enum))) {
                    if ((value.GetType() == destinationType)) {
                        return value;
                    }
                    if ((((value == null) 
                                && (context != null)) 
                                && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
                        return  "NULL_ENUM_VALUE" ;
                    }
                    return baseConverter.ConvertTo(context, culture, value, destinationType);
                }
                if (((baseType == typeof(bool)) 
                            && (baseType.BaseType == typeof(System.ValueType)))) {
                    if ((((value == null) 
                                && (context != null)) 
                                && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
                        return "";
                    }
                    return baseConverter.ConvertTo(context, culture, value, destinationType);
                }
                if (((context != null) 
                            && (context.PropertyDescriptor.ShouldSerializeValue(context.Instance) == false))) {
                    return "";
                }
                return baseConverter.ConvertTo(context, culture, value, destinationType);
            }
        }
        
        // En inbäddad klass som representerar WMI-systemegenskaper.
        [TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
        public class ManagementSystemProperties {
            
            private System.Management.ManagementBaseObject PrivateLateBoundObject;
            
            public ManagementSystemProperties(System.Management.ManagementBaseObject ManagedObject) {
                PrivateLateBoundObject = ManagedObject;
            }
            
            [Browsable(true)]
            public int GENUS {
                get {
                    return ((int)(PrivateLateBoundObject["__GENUS"]));
                }
            }
            
            [Browsable(true)]
            public string CLASS {
                get {
                    return ((string)(PrivateLateBoundObject["__CLASS"]));
                }
            }
            
            [Browsable(true)]
            public string SUPERCLASS {
                get {
                    return ((string)(PrivateLateBoundObject["__SUPERCLASS"]));
                }
            }
            
            [Browsable(true)]
            public string DYNASTY {
                get {
                    return ((string)(PrivateLateBoundObject["__DYNASTY"]));
                }
            }
            
            [Browsable(true)]
            public string RELPATH {
                get {
                    return ((string)(PrivateLateBoundObject["__RELPATH"]));
                }
            }
            
            [Browsable(true)]
            public int PROPERTY_COUNT {
                get {
                    return ((int)(PrivateLateBoundObject["__PROPERTY_COUNT"]));
                }
            }
            
            [Browsable(true)]
            public string[] DERIVATION {
                get {
                    return ((string[])(PrivateLateBoundObject["__DERIVATION"]));
                }
            }
            
            [Browsable(true)]
            public string SERVER {
                get {
                    return ((string)(PrivateLateBoundObject["__SERVER"]));
                }
            }
            
            [Browsable(true)]
            public string NAMESPACE {
                get {
                    return ((string)(PrivateLateBoundObject["__NAMESPACE"]));
                }
            }
            
            [Browsable(true)]
            public string PATH {
                get {
                    return ((string)(PrivateLateBoundObject["__PATH"]));
                }
            }
        }
    }
}
