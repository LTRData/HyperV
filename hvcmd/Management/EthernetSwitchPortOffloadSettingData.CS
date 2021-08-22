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
    // En EarlyBound-klass genererades för WMI-klassen.Msvm_EthernetSwitchPortOffloadSettingData
    [System.CodeDom.Compiler.GeneratedCode("mgmtclassgen", "")]
    public class EthernetSwitchPortOffloadSettingData : System.ComponentModel.Component {
        
        // En privat egenskap som ska innehålla WMI-namnområdet där klassen finns.
        public const string CreatedWmiNamespace = "root\\virtualization\\v2";
        
        // En privat egenskap som ska innehålla namnet på den WMI-klass som skapade den här klassen.
        public const string CreatedClassName = "Msvm_EthernetSwitchPortOffloadSettingData";
        
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
        public EthernetSwitchPortOffloadSettingData() {
            this.InitializeObject(null, null, null);
        }
        
        public EthernetSwitchPortOffloadSettingData(string keyInstanceID) {
            this.InitializeObject(null, new System.Management.ManagementPath(EthernetSwitchPortOffloadSettingData.ConstructPath(keyInstanceID)), null);
        }
        
        public EthernetSwitchPortOffloadSettingData(System.Management.ManagementScope mgmtScope, string keyInstanceID) {
            this.InitializeObject(((System.Management.ManagementScope)(mgmtScope)), new System.Management.ManagementPath(EthernetSwitchPortOffloadSettingData.ConstructPath(keyInstanceID)), null);
        }
        
        public EthernetSwitchPortOffloadSettingData(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(null, path, getOptions);
        }
        
        public EthernetSwitchPortOffloadSettingData(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
            this.InitializeObject(mgmtScope, path, null);
        }
        
        public EthernetSwitchPortOffloadSettingData(System.Management.ManagementPath path) {
            this.InitializeObject(null, path, null);
        }
        
        public EthernetSwitchPortOffloadSettingData(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(mgmtScope, path, getOptions);
        }
        
        public EthernetSwitchPortOffloadSettingData(System.Management.ManagementObject theObject) {
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
        
        public EthernetSwitchPortOffloadSettingData(System.Management.ManagementBaseObject theObject) {
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
        public string Caption {
            get {
                return ((string)(curObj["Caption"]));
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
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string InstanceID {
            get {
                return ((string)(curObj["InstanceID"]));
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsIOVInterruptModerationNull {
            get {
                if ((curObj["IOVInterruptModeration"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The interrupt moderation value for I/O virtualization (IOV) offloading.The defaul" +
            "t is Adaptive")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public IOVInterruptModerationValues IOVInterruptModeration {
            get {
                if ((curObj["IOVInterruptModeration"] == null)) {
                    return ((IOVInterruptModerationValues)(System.Convert.ToInt32(301)));
                }
                return ((IOVInterruptModerationValues)(System.Convert.ToInt32(curObj["IOVInterruptModeration"])));
            }
            set {
                if ((IOVInterruptModerationValues.NULL_ENUM_VALUE == value)) {
                    curObj["IOVInterruptModeration"] = null;
                }
                else {
                    curObj["IOVInterruptModeration"] = value;
                }
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsIOVOffloadWeightNull {
            get {
                if ((curObj["IOVOffloadWeight"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The weight assigned to this port for I/O virtualization (IOV) offloading. The wei" +
            "ght isthe relative importance when assigning IOV resources. Setting the IOVOfflo" +
            "adWeight property to 0 disables IOV offloading on the port. The default is 0.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint IOVOffloadWeight {
            get {
                if ((curObj["IOVOffloadWeight"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["IOVOffloadWeight"]));
            }
            set {
                curObj["IOVOffloadWeight"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsIOVQueuePairsRequestedNull {
            get {
                if ((curObj["IOVQueuePairsRequested"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The number of queue pairs requested for this port for I/O virtualization (IOV) of" +
            "floading.The default is 1.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint IOVQueuePairsRequested {
            get {
                if ((curObj["IOVQueuePairsRequested"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["IOVQueuePairsRequested"]));
            }
            set {
                curObj["IOVQueuePairsRequested"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsIPSecOffloadLimitNull {
            get {
                if ((curObj["IPSecOffloadLimit"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The maximum number of SA offload slot allowed from the port.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint IPSecOffloadLimit {
            get {
                if ((curObj["IPSecOffloadLimit"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["IPSecOffloadLimit"]));
            }
            set {
                curObj["IPSecOffloadLimit"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPacketDirectModerationCountNull {
            get {
                if ((curObj["PacketDirectModerationCount"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The interrupt moderation count value for Packet Direct (PD).The default is 0.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint PacketDirectModerationCount {
            get {
                if ((curObj["PacketDirectModerationCount"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["PacketDirectModerationCount"]));
            }
            set {
                curObj["PacketDirectModerationCount"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPacketDirectModerationIntervalNull {
            get {
                if ((curObj["PacketDirectModerationInterval"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The interrupt moderation interval value for Packet Direct (PD).The default is 0.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint PacketDirectModerationInterval {
            get {
                if ((curObj["PacketDirectModerationInterval"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["PacketDirectModerationInterval"]));
            }
            set {
                curObj["PacketDirectModerationInterval"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPacketDirectNumProcsNull {
            get {
                if ((curObj["PacketDirectNumProcs"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The number of processors used by the host for processing packets sent from this p" +
            "ort in Packet Direct mode. The default is 1.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint PacketDirectNumProcs {
            get {
                if ((curObj["PacketDirectNumProcs"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["PacketDirectNumProcs"]));
            }
            set {
                curObj["PacketDirectNumProcs"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsVmmqEnabledNull {
            get {
                if ((curObj["VmmqEnabled"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Enable VMMQ offload if supported by hardware.The default is true.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool VmmqEnabled {
            get {
                if ((curObj["VmmqEnabled"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["VmmqEnabled"]));
            }
            set {
                curObj["VmmqEnabled"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsVmmqQueuePairsNull {
            get {
                if ((curObj["VmmqQueuePairs"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The number of queues to allocate when VRSS is enabled.The default is 16.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint VmmqQueuePairs {
            get {
                if ((curObj["VmmqQueuePairs"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["VmmqQueuePairs"]));
            }
            set {
                curObj["VmmqQueuePairs"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsVMQOffloadWeightNull {
            get {
                if ((curObj["VMQOffloadWeight"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The weight assigned to this port for virtual machine queue (VMQ) offloading. The " +
            "weight is the relative importance when assigning VMQ resources. Setting the VMQO" +
            "ffloadWeight property to 0 disables VMQ on the port. The default is 100.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint VMQOffloadWeight {
            get {
                if ((curObj["VMQOffloadWeight"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["VMQOffloadWeight"]));
            }
            set {
                curObj["VMQOffloadWeight"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsVrssEnabledNull {
            get {
                if ((curObj["VrssEnabled"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Enable VRSS.The default is true.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool VrssEnabled {
            get {
                if ((curObj["VrssEnabled"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["VrssEnabled"]));
            }
            set {
                curObj["VrssEnabled"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsVrssExcludePrimaryProcessorNull {
            get {
                if ((curObj["VrssExcludePrimaryProcessor"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Whether to exclude primary VMQ processor from the VRSS indirection table when VRS" +
            "S is enabled.The default is false.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool VrssExcludePrimaryProcessor {
            get {
                if ((curObj["VrssExcludePrimaryProcessor"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["VrssExcludePrimaryProcessor"]));
            }
            set {
                curObj["VrssExcludePrimaryProcessor"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsVrssIndependentHostSpreadingNull {
            get {
                if ((curObj["VrssIndependentHostSpreading"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Whether to always do host-side VRSS when VRSS is enabled, regardless of RSS setti" +
            "ng of the virtual NIC.The default is false.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool VrssIndependentHostSpreading {
            get {
                if ((curObj["VrssIndependentHostSpreading"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["VrssIndependentHostSpreading"]));
            }
            set {
                curObj["VrssIndependentHostSpreading"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsVrssMinQueuePairsNull {
            get {
                if ((curObj["VrssMinQueuePairs"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The minimum number of queues to allocate when VRSS is enabled.The default is 1.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint VrssMinQueuePairs {
            get {
                if ((curObj["VrssMinQueuePairs"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["VrssMinQueuePairs"]));
            }
            set {
                curObj["VrssMinQueuePairs"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsVrssQueueSchedulingModeNull {
            get {
                if ((curObj["VrssQueueSchedulingMode"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The queue scheduling mode to use when VRSS is enabled.The default is static sched" +
            "uling.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint VrssQueueSchedulingMode {
            get {
                if ((curObj["VrssQueueSchedulingMode"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["VrssQueueSchedulingMode"]));
            }
            set {
                curObj["VrssQueueSchedulingMode"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsVrssVmbusChannelAffinityPolicyNull {
            get {
                if ((curObj["VrssVmbusChannelAffinityPolicy"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The vmbus channel affinity policy to use when VRSS is enabled.The default is stro" +
            "ng.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint VrssVmbusChannelAffinityPolicy {
            get {
                if ((curObj["VrssVmbusChannelAffinityPolicy"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["VrssVmbusChannelAffinityPolicy"]));
            }
            set {
                curObj["VrssVmbusChannelAffinityPolicy"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
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
        
        private bool ShouldSerializeIOVInterruptModeration() {
            if ((this.IsIOVInterruptModerationNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetIOVInterruptModeration() {
            curObj["IOVInterruptModeration"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeIOVOffloadWeight() {
            if ((this.IsIOVOffloadWeightNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetIOVOffloadWeight() {
            curObj["IOVOffloadWeight"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeIOVQueuePairsRequested() {
            if ((this.IsIOVQueuePairsRequestedNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetIOVQueuePairsRequested() {
            curObj["IOVQueuePairsRequested"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeIPSecOffloadLimit() {
            if ((this.IsIPSecOffloadLimitNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetIPSecOffloadLimit() {
            curObj["IPSecOffloadLimit"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializePacketDirectModerationCount() {
            if ((this.IsPacketDirectModerationCountNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetPacketDirectModerationCount() {
            curObj["PacketDirectModerationCount"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializePacketDirectModerationInterval() {
            if ((this.IsPacketDirectModerationIntervalNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetPacketDirectModerationInterval() {
            curObj["PacketDirectModerationInterval"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializePacketDirectNumProcs() {
            if ((this.IsPacketDirectNumProcsNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetPacketDirectNumProcs() {
            curObj["PacketDirectNumProcs"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeVmmqEnabled() {
            if ((this.IsVmmqEnabledNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetVmmqEnabled() {
            curObj["VmmqEnabled"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeVmmqQueuePairs() {
            if ((this.IsVmmqQueuePairsNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetVmmqQueuePairs() {
            curObj["VmmqQueuePairs"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeVMQOffloadWeight() {
            if ((this.IsVMQOffloadWeightNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetVMQOffloadWeight() {
            curObj["VMQOffloadWeight"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeVrssEnabled() {
            if ((this.IsVrssEnabledNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetVrssEnabled() {
            curObj["VrssEnabled"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeVrssExcludePrimaryProcessor() {
            if ((this.IsVrssExcludePrimaryProcessorNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetVrssExcludePrimaryProcessor() {
            curObj["VrssExcludePrimaryProcessor"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeVrssIndependentHostSpreading() {
            if ((this.IsVrssIndependentHostSpreadingNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetVrssIndependentHostSpreading() {
            curObj["VrssIndependentHostSpreading"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeVrssMinQueuePairs() {
            if ((this.IsVrssMinQueuePairsNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetVrssMinQueuePairs() {
            curObj["VrssMinQueuePairs"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeVrssQueueSchedulingMode() {
            if ((this.IsVrssQueueSchedulingModeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetVrssQueueSchedulingMode() {
            curObj["VrssQueueSchedulingMode"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeVrssVmbusChannelAffinityPolicy() {
            if ((this.IsVrssVmbusChannelAffinityPolicyNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetVrssVmbusChannelAffinityPolicy() {
            curObj["VrssVmbusChannelAffinityPolicy"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
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
            string strPath = "root\\virtualization\\v2:Msvm_EthernetSwitchPortOffloadSettingData";
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
        public static EthernetSwitchPortOffloadSettingDataCollection GetInstances() {
            return GetInstances(null, null, null);
        }
        
        public static EthernetSwitchPortOffloadSettingDataCollection GetInstances(string condition) {
            return GetInstances(null, condition, null);
        }
        
        public static EthernetSwitchPortOffloadSettingDataCollection GetInstances(string[] selectedProperties) {
            return GetInstances(null, null, selectedProperties);
        }
        
        public static EthernetSwitchPortOffloadSettingDataCollection GetInstances(string condition, string[] selectedProperties) {
            return GetInstances(null, condition, selectedProperties);
        }
        
        public static EthernetSwitchPortOffloadSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
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
            pathObj.ClassName = "Msvm_EthernetSwitchPortOffloadSettingData";
            pathObj.NamespacePath = "root\\virtualization\\v2";
            System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
            if ((enumOptions == null)) {
                enumOptions = new System.Management.EnumerationOptions();
                enumOptions.EnsureLocatable = true;
            }
            return new EthernetSwitchPortOffloadSettingDataCollection(clsObject.GetInstances(enumOptions));
        }
        
        public static EthernetSwitchPortOffloadSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
            return GetInstances(mgmtScope, condition, null);
        }
        
        public static EthernetSwitchPortOffloadSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string[] selectedProperties) {
            return GetInstances(mgmtScope, null, selectedProperties);
        }
        
        public static EthernetSwitchPortOffloadSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, string[] selectedProperties) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\virtualization\\v2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("Msvm_EthernetSwitchPortOffloadSettingData", condition, selectedProperties));
            System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
            ObjectSearcher.Options = enumOptions;
            return new EthernetSwitchPortOffloadSettingDataCollection(ObjectSearcher.Get());
        }
        
        [Browsable(true)]
        public static EthernetSwitchPortOffloadSettingData CreateInstance() {
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
            return new EthernetSwitchPortOffloadSettingData(tmpMgmtClass.CreateInstance());
        }
        
        [Browsable(true)]
        public void Delete() {
            PrivateLateBoundObject.Delete();
        }
        
        public enum IOVInterruptModerationValues {
            
            Default = 0,
            
            Adaptive = 1,
            
            Off = 2,
            
            Low = 100,
            
            Medium = 200,
            
            High = 300,
            
            NULL_ENUM_VALUE = 301,
        }
        
        // Implementering av uppräknare för klassens uppräkningsinstanser.
        public class EthernetSwitchPortOffloadSettingDataCollection : object, ICollection {
            
            private ManagementObjectCollection privColObj;
            
            public EthernetSwitchPortOffloadSettingDataCollection(ManagementObjectCollection objCollection) {
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
                    array.SetValue(new EthernetSwitchPortOffloadSettingData(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
                }
            }
            
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return new EthernetSwitchPortOffloadSettingDataEnumerator(privColObj.GetEnumerator());
            }
            
            public class EthernetSwitchPortOffloadSettingDataEnumerator : object, System.Collections.IEnumerator {
                
                private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
                
                public EthernetSwitchPortOffloadSettingDataEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                    privObjEnum = objEnum;
                }
                
                public virtual object Current {
                    get {
                        return new EthernetSwitchPortOffloadSettingData(((System.Management.ManagementObject)(privObjEnum.Current)));
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
