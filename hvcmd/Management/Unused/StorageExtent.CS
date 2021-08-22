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
    // En EarlyBound-klass genererades för WMI-klassen.CIM_StorageExtent
    public class StorageExtent : System.ComponentModel.Component {
        
        // En privat egenskap som ska innehålla WMI-namnområdet där klassen finns.
        private static string CreatedWmiNamespace = "root\\virtualization\\v2";
        
        // En privat egenskap som ska innehålla namnet på den WMI-klass som skapade den här klassen.
        private static string CreatedClassName = "CIM_StorageExtent";
        
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
        public StorageExtent() {
            this.InitializeObject(null, null, null);
        }
        
        public StorageExtent(string keyCreationClassName, string keyDeviceID, string keySystemCreationClassName, string keySystemName) {
            this.InitializeObject(null, new System.Management.ManagementPath(StorageExtent.ConstructPath(keyCreationClassName, keyDeviceID, keySystemCreationClassName, keySystemName)), null);
        }
        
        public StorageExtent(System.Management.ManagementScope mgmtScope, string keyCreationClassName, string keyDeviceID, string keySystemCreationClassName, string keySystemName) {
            this.InitializeObject(((System.Management.ManagementScope)(mgmtScope)), new System.Management.ManagementPath(StorageExtent.ConstructPath(keyCreationClassName, keyDeviceID, keySystemCreationClassName, keySystemName)), null);
        }
        
        public StorageExtent(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(null, path, getOptions);
        }
        
        public StorageExtent(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
            this.InitializeObject(mgmtScope, path, null);
        }
        
        public StorageExtent(System.Management.ManagementPath path) {
            this.InitializeObject(null, path, null);
        }
        
        public StorageExtent(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(mgmtScope, path, getOptions);
        }
        
        public StorageExtent(System.Management.ManagementObject theObject) {
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
        
        public StorageExtent(System.Management.ManagementBaseObject theObject) {
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
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAccessNull {
            get {
                if ((curObj["Access"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Access describes whether the media is readable (value=1), writeable (value=2), or" +
            " both (value=3). \"Unknown\" (0) and \"Write Once\" (4) can also be defined.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public AccessValues Access {
            get {
                if ((curObj["Access"] == null)) {
                    return ((AccessValues)(System.Convert.ToInt32(5)));
                }
                return ((AccessValues)(System.Convert.ToInt32(curObj["Access"])));
            }
            set {
                if ((AccessValues.NULL_ENUM_VALUE == value)) {
                    curObj["Access"] = null;
                }
                else {
                    curObj["Access"] = value;
                }
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ushort[] AdditionalAvailability {
            get {
                return ((ushort[])(curObj["AdditionalAvailability"]));
            }
            set {
                curObj["AdditionalAvailability"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAvailabilityNull {
            get {
                if ((curObj["Availability"] == null)) {
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
        public ushort Availability {
            get {
                if ((curObj["Availability"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["Availability"]));
            }
            set {
                curObj["Availability"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ushort[] AvailableRequestedStates {
            get {
                return ((ushort[])(curObj["AvailableRequestedStates"]));
            }
            set {
                curObj["AvailableRequestedStates"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsBlockSizeNull {
            get {
                if ((curObj["BlockSize"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Size in bytes of the blocks which form this StorageExtent. If variable block size, then the maximum block size in bytes should be specified. If the block size is unknown or if a block concept is not valid (for example, for AggregateExtents, Memory or LogicalDisks), enter a 1.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ulong BlockSize {
            get {
                if ((curObj["BlockSize"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["BlockSize"]));
            }
            set {
                curObj["BlockSize"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Caption {
            get {
                return ((string)(curObj["Caption"]));
            }
            set {
                curObj["Caption"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCommunicationStatusNull {
            get {
                if ((curObj["CommunicationStatus"] == null)) {
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
        public ushort CommunicationStatus {
            get {
                if ((curObj["CommunicationStatus"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["CommunicationStatus"]));
            }
            set {
                curObj["CommunicationStatus"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsConsumableBlocksNull {
            get {
                if ((curObj["ConsumableBlocks"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The maximum number of blocks, of size BlockSize, which are available for consumption when layering StorageExtents using the BasedOn association. This property only has meaning when this StorageExtent is an Antecedent reference in a BasedOn relationship. For example, a StorageExtent could be composed of 120 blocks. However, the Extent itself may use 20 blocks for redundancy data. If another StorageExtent is BasedOn this Extent, only 100 blocks would be available to it. This information ('100 blocks is available for consumption') is indicated in the ConsumableBlocks property.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ulong ConsumableBlocks {
            get {
                if ((curObj["ConsumableBlocks"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["ConsumableBlocks"]));
            }
            set {
                curObj["ConsumableBlocks"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CreationClassName {
            get {
                return ((string)(curObj["CreationClassName"]));
            }
            set {
                curObj["CreationClassName"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDataOrganizationNull {
            get {
                if ((curObj["DataOrganization"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Type of data organization used.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public DataOrganizationValues DataOrganization {
            get {
                if ((curObj["DataOrganization"] == null)) {
                    return ((DataOrganizationValues)(System.Convert.ToInt32(5)));
                }
                return ((DataOrganizationValues)(System.Convert.ToInt32(curObj["DataOrganization"])));
            }
            set {
                if ((DataOrganizationValues.NULL_ENUM_VALUE == value)) {
                    curObj["DataOrganization"] = null;
                }
                else {
                    curObj["DataOrganization"] = value;
                }
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDataRedundancyNull {
            get {
                if ((curObj["DataRedundancy"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Number of complete copies of data currently maintained.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort DataRedundancy {
            get {
                if ((curObj["DataRedundancy"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["DataRedundancy"]));
            }
            set {
                curObj["DataRedundancy"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDeltaReservationNull {
            get {
                if ((curObj["DeltaReservation"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Current value for Delta reservation. This is a percentage that specifies the amou" +
            "nt of space that should be reserved in a replica for caching changes.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public byte DeltaReservation {
            get {
                if ((curObj["DeltaReservation"] == null)) {
                    return System.Convert.ToByte(0);
                }
                return ((byte)(curObj["DeltaReservation"]));
            }
            set {
                curObj["DeltaReservation"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description {
            get {
                return ((string)(curObj["Description"]));
            }
            set {
                curObj["Description"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDetailedStatusNull {
            get {
                if ((curObj["DetailedStatus"] == null)) {
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
        public ushort DetailedStatus {
            get {
                if ((curObj["DetailedStatus"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["DetailedStatus"]));
            }
            set {
                curObj["DetailedStatus"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DeviceID {
            get {
                return ((string)(curObj["DeviceID"]));
            }
            set {
                curObj["DeviceID"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ElementName {
            get {
                return ((string)(curObj["ElementName"]));
            }
            set {
                curObj["ElementName"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEnabledDefaultNull {
            get {
                if ((curObj["EnabledDefault"] == null)) {
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
        public ushort EnabledDefault {
            get {
                if ((curObj["EnabledDefault"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["EnabledDefault"]));
            }
            set {
                curObj["EnabledDefault"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEnabledStateNull {
            get {
                if ((curObj["EnabledState"] == null)) {
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
        public ushort EnabledState {
            get {
                if ((curObj["EnabledState"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["EnabledState"]));
            }
            set {
                curObj["EnabledState"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsErrorClearedNull {
            get {
                if ((curObj["ErrorCleared"] == null)) {
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
        public bool ErrorCleared {
            get {
                if ((curObj["ErrorCleared"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["ErrorCleared"]));
            }
            set {
                curObj["ErrorCleared"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ErrorDescription {
            get {
                return ((string)(curObj["ErrorDescription"]));
            }
            set {
                curObj["ErrorDescription"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("ErrorMethodology is a free-form string describing the type of error detection and" +
            " correction supported by this StorageExtent.")]
        public string ErrorMethodology {
            get {
                return ((string)(curObj["ErrorMethodology"]));
            }
            set {
                curObj["ErrorMethodology"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"StorageExtents have additional status information beyond that captured in the OperationalStatus and other properties, inherited from ManagedSystemElement. This additional information (for example, ""Protection Disabled"", value=9) is captured in the ExtentStatus property. 
'In-Band Access Granted' says that access to data on an extent is granted to some consumer and is only valid when 'Exported' is also set. It is set as a side effect of PrivilegeManagementService.ChangeAccess or equivalent interfaces. 
'Imported' indicates that the extent is used in the current system, but known to be managed by some other system. For example, a server imports volumes from a disk array. 
'Exported' indicates the extent is meant to be used by some comsumer. A disk array's logical units are exported. 
Intermediate composite extents may be neither imported nor exported.")]
        public ushort[] ExtentStatus {
            get {
                return ((ushort[])(curObj["ExtentStatus"]));
            }
            set {
                curObj["ExtentStatus"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsHealthStateNull {
            get {
                if ((curObj["HealthState"] == null)) {
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
        public ushort HealthState {
            get {
                if ((curObj["HealthState"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["HealthState"]));
            }
            set {
                curObj["HealthState"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] IdentifyingDescriptions {
            get {
                return ((string[])(curObj["IdentifyingDescriptions"]));
            }
            set {
                curObj["IdentifyingDescriptions"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsInstallDateNull {
            get {
                if ((curObj["InstallDate"] == null)) {
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
        public System.DateTime InstallDate {
            get {
                if ((curObj["InstallDate"] != null)) {
                    return ToDateTime(((string)(curObj["InstallDate"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
            set {
                curObj["InstallDate"] = ToDmtfDateTime(((System.DateTime)(value)));
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string InstanceID {
            get {
                return ((string)(curObj["InstanceID"]));
            }
            set {
                curObj["InstanceID"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsIsBasedOnUnderlyingRedundancyNull {
            get {
                if ((curObj["IsBasedOnUnderlyingRedundancy"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("True indicates that the underlying StorageExtent(s) participate in a StorageRedun" +
            "dancyGroup.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool IsBasedOnUnderlyingRedundancy {
            get {
                if ((curObj["IsBasedOnUnderlyingRedundancy"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["IsBasedOnUnderlyingRedundancy"]));
            }
            set {
                curObj["IsBasedOnUnderlyingRedundancy"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLastErrorCodeNull {
            get {
                if ((curObj["LastErrorCode"] == null)) {
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
        public uint LastErrorCode {
            get {
                if ((curObj["LastErrorCode"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["LastErrorCode"]));
            }
            set {
                curObj["LastErrorCode"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMaxQuiesceTimeNull {
            get {
                if ((curObj["MaxQuiesceTime"] == null)) {
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
        public ulong MaxQuiesceTime {
            get {
                if ((curObj["MaxQuiesceTime"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["MaxQuiesceTime"]));
            }
            set {
                curObj["MaxQuiesceTime"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A unique identifier for the Extent.")]
        public string Name {
            get {
                return ((string)(curObj["Name"]));
            }
            set {
                curObj["Name"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNameFormatNull {
            get {
                if ((curObj["NameFormat"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The list here applies to all StorageExtent subclasses. Please look at the Descrip" +
            "tion in each subclass for guidelines on the approriate values for that subclass." +
            " Note that any of these formats could apply to a CompositeExtent. \n\nNote - this " +
            "property originally touched on two concepts that are now separated into this pro" +
            "perty and NameNamespace. Values 2,3,4,5,6, and 8 are retained for backwards comp" +
            "atibility but are deprecated in lieu of the corresponding values in CIM_StorageE" +
            "xtent.NameNamespace. \n\nFor example, the preferred source for SCSI virtual (RAID)" +
            " disk names is from Inquiry VPD page 83 response, type 3 identifiers. These will" +
            " have NameFormat set to \'NAA\' and NameNamespace to \'VPD83Type3\'. \n\nFormat of the" +
            " Name property. Values for extents representing SCSI volumes are (per SCSI SPC-3" +
            "): \n2 = VPD Page 83, NAA IEEE Registered Extended (VPD83NAA6) \n(DEPRECATED) \n3 =" +
            " VPD Page 83, NAA IEEE Registered (VPD83NAA5) \n(DEPRECATED) \n4 = VPD Page 83, (V" +
            "PD83Type2) (DEPRECATED) \n5 = VPD Page 83, \nT10 Vendor Identification (VPD83Type1" +
            ") (DEPRECATED) \n6 = VPD Page 83, Vendor Specific (VPD83Type0) (DEPRECATED) \n7 = " +
            "Serial Number/Vendor/Model (SNVM) SNVM is 3 strings representing the vendor name" +
            ", product name within the vendor namespace, and the serial number within the mod" +
            "el namespace. Strings are delimited with a \'+\'. Spaces may be included and are s" +
            "ignificant. The serial number is the text representation of the serial number in" +
            " hexadecimal upper case. This represents the vendor and model ID from SCSI Inqui" +
            "ry data; the vendor field MUST be 8 characters wide and the product field MUST b" +
            "e 16 characters wide. For example, \n\'ACME____+SUPER DISK______+124437458\' (_ is " +
            "a space character) \n8 = Node WWN (for single LUN/controller) (NodeWWN) \n(DEPRECA" +
            "TED) \n9 = NAA as a generic format. See \nhttp://standards.ieee.org/regauth/oui/tu" +
            "torials/fibrecomp_id.html. Formatted as 16 or 32 unseparated uppercase hex chara" +
            "cters (2 per binary byte). For example \'21000020372D3C73\' \n10 = EUI as a generic" +
            " format (EUI64) See \nhttp://standards.ieee.org/regauth/oui/tutorials/EUI64.html." +
            " \nFormatted as 16 unseparated uppercase hex characters (2 per binary byte) \n11 =" +
            " T10 vendor identifier format as returned by SCSI Inquiry VPD page 83, identifie" +
            "r type 1. See T10 SPC-3 specification. This is the 8-byte ASCII vendor ID from t" +
            "he T10 registry followed by a vendor specific ASCII identifier; spaces are permi" +
            "tted. For non SCSI volumes, \'SNVM\' may be the most appropriate choice. 12 = OS D" +
            "evice Name (for LogicalDisks). See LogicalDisk Name description for details.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public NameFormatValues NameFormat {
            get {
                if ((curObj["NameFormat"] == null)) {
                    return ((NameFormatValues)(System.Convert.ToInt32(13)));
                }
                return ((NameFormatValues)(System.Convert.ToInt32(curObj["NameFormat"])));
            }
            set {
                if ((NameFormatValues.NULL_ENUM_VALUE == value)) {
                    curObj["NameFormat"] = null;
                }
                else {
                    curObj["NameFormat"] = value;
                }
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNameNamespaceNull {
            get {
                if ((curObj["NameNamespace"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The preferred source SCSI for volume names is SCSI VPD Page 83 responses. Page 83 returns a list of identifiers for various device elements. The metadata for each identifier includes an Association field, identifiers with association of 0 apply to volumes. Page 83 supports several namespaces specified in the Type field in the identifier metadata. See SCSI SPC-3 specification. 
2 = VPD Page 83, Type 3 NAA (NameFormat SHOULD be NAA) 
3 = VPD Page 83, Type 2 EUI64 (NameFormat EUI) 
4 = VPD Page 83, Type 1 T10 Vendor Identification 
(NameFormat T10) 
Less preferred volume namespaces from other interfaces: 
5 = VPD page 80, Serial number (NameFormat SHOULD be Other) 
6 = FC NodeWWN (NameFormat SHOULD be NAA or EUI) 
7 = Serial Number/Vendor/Model (NameFormat SHOULD be SNVM) 
The preferred namespace for LogigicalDisk names is platform specific device namespace; see LogigicalDIsk Description. 
8 = OS Device Namespace.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public NameNamespaceValues NameNamespace {
            get {
                if ((curObj["NameNamespace"] == null)) {
                    return ((NameNamespaceValues)(System.Convert.ToInt32(9)));
                }
                return ((NameNamespaceValues)(System.Convert.ToInt32(curObj["NameNamespace"])));
            }
            set {
                if ((NameNamespaceValues.NULL_ENUM_VALUE == value)) {
                    curObj["NameNamespace"] = null;
                }
                else {
                    curObj["NameNamespace"] = value;
                }
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNoSinglePointOfFailureNull {
            get {
                if ((curObj["NoSinglePointOfFailure"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Indicates whether or not there exists no single point of failure.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool NoSinglePointOfFailure {
            get {
                if ((curObj["NoSinglePointOfFailure"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["NoSinglePointOfFailure"]));
            }
            set {
                curObj["NoSinglePointOfFailure"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNumberOfBlocksNull {
            get {
                if ((curObj["NumberOfBlocks"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Total number of logically contiguous blocks, of size Block Size, which form this " +
            "Extent. The total size of the Extent can be calculated by multiplying BlockSize " +
            "by NumberOfBlocks. If the BlockSize is 1, this property is the total size of the" +
            " Extent.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ulong NumberOfBlocks {
            get {
                if ((curObj["NumberOfBlocks"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["NumberOfBlocks"]));
            }
            set {
                curObj["NumberOfBlocks"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsOperatingStatusNull {
            get {
                if ((curObj["OperatingStatus"] == null)) {
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
        public ushort OperatingStatus {
            get {
                if ((curObj["OperatingStatus"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["OperatingStatus"]));
            }
            set {
                curObj["OperatingStatus"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ushort[] OperationalStatus {
            get {
                return ((ushort[])(curObj["OperationalStatus"]));
            }
            set {
                curObj["OperationalStatus"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OtherEnabledState {
            get {
                return ((string)(curObj["OtherEnabledState"]));
            }
            set {
                curObj["OtherEnabledState"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] OtherIdentifyingInfo {
            get {
                return ((string[])(curObj["OtherIdentifyingInfo"]));
            }
            set {
                curObj["OtherIdentifyingInfo"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A string describing the format of the Name property when NameFormat includes the " +
            "value 1, \"Other\".")]
        public string OtherNameFormat {
            get {
                return ((string)(curObj["OtherNameFormat"]));
            }
            set {
                curObj["OtherNameFormat"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A string describing the namespace of the Name property when NameNamespace include" +
            "s the value 1, \"Other\".")]
        public string OtherNameNamespace {
            get {
                return ((string)(curObj["OtherNameNamespace"]));
            }
            set {
                curObj["OtherNameNamespace"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPackageRedundancyNull {
            get {
                if ((curObj["PackageRedundancy"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("How many physical packages can currently fail without data loss. For example, in " +
            "the storage domain, this might be disk spindles.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort PackageRedundancy {
            get {
                if ((curObj["PackageRedundancy"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["PackageRedundancy"]));
            }
            set {
                curObj["PackageRedundancy"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ushort[] PowerManagementCapabilities {
            get {
                return ((ushort[])(curObj["PowerManagementCapabilities"]));
            }
            set {
                curObj["PowerManagementCapabilities"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPowerManagementSupportedNull {
            get {
                if ((curObj["PowerManagementSupported"] == null)) {
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
        public bool PowerManagementSupported {
            get {
                if ((curObj["PowerManagementSupported"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["PowerManagementSupported"]));
            }
            set {
                curObj["PowerManagementSupported"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPowerOnHoursNull {
            get {
                if ((curObj["PowerOnHours"] == null)) {
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
        public ulong PowerOnHours {
            get {
                if ((curObj["PowerOnHours"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["PowerOnHours"]));
            }
            set {
                curObj["PowerOnHours"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPrimaryStatusNull {
            get {
                if ((curObj["PrimaryStatus"] == null)) {
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
        public ushort PrimaryStatus {
            get {
                if ((curObj["PrimaryStatus"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["PrimaryStatus"]));
            }
            set {
                curObj["PrimaryStatus"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPrimordialNull {
            get {
                if ((curObj["Primordial"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"If true, ""Primordial"" indicates that the containing System does not have the ability to create or delete this operational element. This is important because StorageExtents are assembled into higher-level abstractions using the BasedOn association. Although the higher-level abstractions can be created and deleted, the most basic, (i.e. primordial), hardware-based storage entities cannot. They are physically realized as part of the System, or are actually managed by some other System and imported as if they were physically realized. In other words, a Primordial StorageExtent exists in, but is not created by its System and conversely a non-Primordial StorageExtent is created in the context of its System. For StorageVolumes, this property will generally be false. One use of this property is to enable algorithms that aggregate StorageExtent.ConsumableSpace across all, StorageExtents but that also want to distinquish the space that underlies Primordial StoragePools. Since implementations are not required to surface all Component StorageExtents of a StoragePool, this information is not accessible in any other way.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool Primordial {
            get {
                if ((curObj["Primordial"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["Primordial"]));
            }
            set {
                curObj["Primordial"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A free form string describing the media and/or its use.")]
        public string Purpose {
            get {
                return ((string)(curObj["Purpose"]));
            }
            set {
                curObj["Purpose"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsRequestedStateNull {
            get {
                if ((curObj["RequestedState"] == null)) {
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
        public ushort RequestedState {
            get {
                if ((curObj["RequestedState"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["RequestedState"]));
            }
            set {
                curObj["RequestedState"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSequentialAccessNull {
            get {
                if ((curObj["SequentialAccess"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Boolean set to TRUE if the Storage is sequentially accessed by a MediaAccessDevic" +
            "e. A TapePartition is an example of a sequentially accessed StorageExtent. Stora" +
            "geVolumes, Disk Partitions and LogicalDisks represent randomly accessed Extents." +
            "")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool SequentialAccess {
            get {
                if ((curObj["SequentialAccess"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["SequentialAccess"]));
            }
            set {
                curObj["SequentialAccess"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Status {
            get {
                return ((string)(curObj["Status"]));
            }
            set {
                curObj["Status"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] StatusDescriptions {
            get {
                return ((string[])(curObj["StatusDescriptions"]));
            }
            set {
                curObj["StatusDescriptions"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsStatusInfoNull {
            get {
                if ((curObj["StatusInfo"] == null)) {
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
        public ushort StatusInfo {
            get {
                if ((curObj["StatusInfo"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["StatusInfo"]));
            }
            set {
                curObj["StatusInfo"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SystemCreationClassName {
            get {
                return ((string)(curObj["SystemCreationClassName"]));
            }
            set {
                curObj["SystemCreationClassName"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SystemName {
            get {
                return ((string)(curObj["SystemName"]));
            }
            set {
                curObj["SystemName"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsTimeOfLastStateChangeNull {
            get {
                if ((curObj["TimeOfLastStateChange"] == null)) {
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
        public System.DateTime TimeOfLastStateChange {
            get {
                if ((curObj["TimeOfLastStateChange"] != null)) {
                    return ToDateTime(((string)(curObj["TimeOfLastStateChange"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
            set {
                curObj["TimeOfLastStateChange"] = ToDmtfDateTime(((System.DateTime)(value)));
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsTotalPowerOnHoursNull {
            get {
                if ((curObj["TotalPowerOnHours"] == null)) {
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
        public ulong TotalPowerOnHours {
            get {
                if ((curObj["TotalPowerOnHours"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["TotalPowerOnHours"]));
            }
            set {
                curObj["TotalPowerOnHours"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsTransitioningToStateNull {
            get {
                if ((curObj["TransitioningToState"] == null)) {
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
        public ushort TransitioningToState {
            get {
                if ((curObj["TransitioningToState"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["TransitioningToState"]));
            }
            set {
                curObj["TransitioningToState"] = value;
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
        
        private bool ShouldSerializeAccess() {
            if ((this.IsAccessNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetAccess() {
            curObj["Access"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetAdditionalAvailability() {
            curObj["AdditionalAvailability"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeAvailability() {
            if ((this.IsAvailabilityNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetAvailability() {
            curObj["Availability"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetAvailableRequestedStates() {
            curObj["AvailableRequestedStates"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeBlockSize() {
            if ((this.IsBlockSizeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetBlockSize() {
            curObj["BlockSize"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetCaption() {
            curObj["Caption"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeCommunicationStatus() {
            if ((this.IsCommunicationStatusNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetCommunicationStatus() {
            curObj["CommunicationStatus"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeConsumableBlocks() {
            if ((this.IsConsumableBlocksNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetConsumableBlocks() {
            curObj["ConsumableBlocks"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeDataOrganization() {
            if ((this.IsDataOrganizationNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetDataOrganization() {
            curObj["DataOrganization"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeDataRedundancy() {
            if ((this.IsDataRedundancyNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetDataRedundancy() {
            curObj["DataRedundancy"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeDeltaReservation() {
            if ((this.IsDeltaReservationNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetDeltaReservation() {
            curObj["DeltaReservation"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetDescription() {
            curObj["Description"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeDetailedStatus() {
            if ((this.IsDetailedStatusNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetDetailedStatus() {
            curObj["DetailedStatus"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetElementName() {
            curObj["ElementName"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeEnabledDefault() {
            if ((this.IsEnabledDefaultNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetEnabledDefault() {
            curObj["EnabledDefault"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeEnabledState() {
            if ((this.IsEnabledStateNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetEnabledState() {
            curObj["EnabledState"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeErrorCleared() {
            if ((this.IsErrorClearedNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetErrorCleared() {
            curObj["ErrorCleared"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetErrorDescription() {
            curObj["ErrorDescription"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetErrorMethodology() {
            curObj["ErrorMethodology"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetExtentStatus() {
            curObj["ExtentStatus"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeHealthState() {
            if ((this.IsHealthStateNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetHealthState() {
            curObj["HealthState"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetIdentifyingDescriptions() {
            curObj["IdentifyingDescriptions"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
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
        
        private bool ShouldSerializeInstallDate() {
            if ((this.IsInstallDateNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetInstallDate() {
            curObj["InstallDate"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetInstanceID() {
            curObj["InstanceID"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeIsBasedOnUnderlyingRedundancy() {
            if ((this.IsIsBasedOnUnderlyingRedundancyNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetIsBasedOnUnderlyingRedundancy() {
            curObj["IsBasedOnUnderlyingRedundancy"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeLastErrorCode() {
            if ((this.IsLastErrorCodeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetLastErrorCode() {
            curObj["LastErrorCode"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeMaxQuiesceTime() {
            if ((this.IsMaxQuiesceTimeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetMaxQuiesceTime() {
            curObj["MaxQuiesceTime"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetName() {
            curObj["Name"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeNameFormat() {
            if ((this.IsNameFormatNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetNameFormat() {
            curObj["NameFormat"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeNameNamespace() {
            if ((this.IsNameNamespaceNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetNameNamespace() {
            curObj["NameNamespace"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeNoSinglePointOfFailure() {
            if ((this.IsNoSinglePointOfFailureNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetNoSinglePointOfFailure() {
            curObj["NoSinglePointOfFailure"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeNumberOfBlocks() {
            if ((this.IsNumberOfBlocksNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetNumberOfBlocks() {
            curObj["NumberOfBlocks"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeOperatingStatus() {
            if ((this.IsOperatingStatusNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetOperatingStatus() {
            curObj["OperatingStatus"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOperationalStatus() {
            curObj["OperationalStatus"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherEnabledState() {
            curObj["OtherEnabledState"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherIdentifyingInfo() {
            curObj["OtherIdentifyingInfo"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherNameFormat() {
            curObj["OtherNameFormat"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherNameNamespace() {
            curObj["OtherNameNamespace"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializePackageRedundancy() {
            if ((this.IsPackageRedundancyNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetPackageRedundancy() {
            curObj["PackageRedundancy"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetPowerManagementCapabilities() {
            curObj["PowerManagementCapabilities"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializePowerManagementSupported() {
            if ((this.IsPowerManagementSupportedNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetPowerManagementSupported() {
            curObj["PowerManagementSupported"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializePowerOnHours() {
            if ((this.IsPowerOnHoursNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetPowerOnHours() {
            curObj["PowerOnHours"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializePrimaryStatus() {
            if ((this.IsPrimaryStatusNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetPrimaryStatus() {
            curObj["PrimaryStatus"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializePrimordial() {
            if ((this.IsPrimordialNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetPrimordial() {
            curObj["Primordial"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetPurpose() {
            curObj["Purpose"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeRequestedState() {
            if ((this.IsRequestedStateNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetRequestedState() {
            curObj["RequestedState"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeSequentialAccess() {
            if ((this.IsSequentialAccessNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetSequentialAccess() {
            curObj["SequentialAccess"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetStatus() {
            curObj["Status"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetStatusDescriptions() {
            curObj["StatusDescriptions"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeStatusInfo() {
            if ((this.IsStatusInfoNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetStatusInfo() {
            curObj["StatusInfo"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeTimeOfLastStateChange() {
            if ((this.IsTimeOfLastStateChangeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetTimeOfLastStateChange() {
            curObj["TimeOfLastStateChange"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeTotalPowerOnHours() {
            if ((this.IsTotalPowerOnHoursNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetTotalPowerOnHours() {
            curObj["TotalPowerOnHours"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeTransitioningToState() {
            if ((this.IsTransitioningToStateNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetTransitioningToState() {
            curObj["TransitioningToState"] = null;
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
        
        private static string ConstructPath(string keyCreationClassName, string keyDeviceID, string keySystemCreationClassName, string keySystemName) {
            string strPath = "root\\virtualization\\v2:CIM_StorageExtent";
            strPath = string.Concat(strPath, string.Concat(".CreationClassName=", string.Concat("\"", string.Concat(keyCreationClassName, "\""))));
            strPath = string.Concat(strPath, string.Concat(",DeviceID=", string.Concat("\"", string.Concat(keyDeviceID, "\""))));
            strPath = string.Concat(strPath, string.Concat(",SystemCreationClassName=", string.Concat("\"", string.Concat(keySystemCreationClassName, "\""))));
            strPath = string.Concat(strPath, string.Concat(",SystemName=", string.Concat("\"", string.Concat(keySystemName, "\""))));
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
        public static StorageExtentCollection GetInstances() {
            return GetInstances(null, null, null);
        }
        
        public static StorageExtentCollection GetInstances(string condition) {
            return GetInstances(null, condition, null);
        }
        
        public static StorageExtentCollection GetInstances(string[] selectedProperties) {
            return GetInstances(null, null, selectedProperties);
        }
        
        public static StorageExtentCollection GetInstances(string condition, string[] selectedProperties) {
            return GetInstances(null, condition, selectedProperties);
        }
        
        public static StorageExtentCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
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
            pathObj.ClassName = "CIM_StorageExtent";
            pathObj.NamespacePath = "root\\virtualization\\v2";
            System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
            if ((enumOptions == null)) {
                enumOptions = new System.Management.EnumerationOptions();
                enumOptions.EnsureLocatable = true;
            }
            return new StorageExtentCollection(clsObject.GetInstances(enumOptions));
        }
        
        public static StorageExtentCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
            return GetInstances(mgmtScope, condition, null);
        }
        
        public static StorageExtentCollection GetInstances(System.Management.ManagementScope mgmtScope, string[] selectedProperties) {
            return GetInstances(mgmtScope, null, selectedProperties);
        }
        
        public static StorageExtentCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, string[] selectedProperties) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\virtualization\\v2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("CIM_StorageExtent", condition, selectedProperties));
            System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
            ObjectSearcher.Options = enumOptions;
            return new StorageExtentCollection(ObjectSearcher.Get());
        }
        
        [Browsable(true)]
        public static StorageExtent CreateInstance() {
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
            return new StorageExtent(tmpMgmtClass.CreateInstance());
        }
        
        [Browsable(true)]
        public void Delete() {
            PrivateLateBoundObject.Delete();
        }
        
        public uint EnableDevice(bool Enabled) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("EnableDevice");
                inParams["Enabled"] = ((bool)(Enabled));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("EnableDevice", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint OnlineDevice(bool Online) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("OnlineDevice");
                inParams["Online"] = ((bool)(Online));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("OnlineDevice", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint QuiesceDevice(bool Quiesce) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("QuiesceDevice");
                inParams["Quiesce"] = ((bool)(Quiesce));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("QuiesceDevice", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint RequestStateChange(ushort RequestedState, System.DateTime TimeoutPeriod, out System.Management.ManagementPath Job) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("RequestStateChange");
                inParams["RequestedState"] = ((ushort)(RequestedState));
                inParams["TimeoutPeriod"] = ToDmtfDateTime(((System.DateTime)(TimeoutPeriod)));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("RequestStateChange", inParams, null);
                Job = null;
                if ((outParams.Properties["Job"] != null)) {
                    Job = new System.Management.ManagementPath(outParams.Properties["Job"].ToString());
                }
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                Job = null;
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint Reset() {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("Reset", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint RestoreProperties() {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("RestoreProperties", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint SaveProperties() {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SaveProperties", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public uint SetPowerState(ushort PowerState, System.DateTime Time) {
            if ((isEmbedded == false)) {
                System.Management.ManagementBaseObject inParams = null;
                inParams = PrivateLateBoundObject.GetMethodParameters("SetPowerState");
                inParams["PowerState"] = ((ushort)(PowerState));
                inParams["Time"] = ToDmtfDateTime(((System.DateTime)(Time)));
                System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("SetPowerState", inParams, null);
                return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
            }
            else {
                return System.Convert.ToUInt32(0);
            }
        }
        
        public enum AccessValues {
            
            Unknown0 = 0,
            
            Readable = 1,
            
            Writeable = 2,
            
            Read_Write_Supported = 3,
            
            Write_Once = 4,
            
            NULL_ENUM_VALUE = 5,
        }
        
        public enum DataOrganizationValues {
            
            Other0 = 0,
            
            Unknown0 = 1,
            
            Fixed_Block = 2,
            
            Variable_Block = 3,
            
            Count_Key_Data = 4,
            
            NULL_ENUM_VALUE = 5,
        }
        
        public enum NameFormatValues {
            
            Unknown0 = 0,
            
            Other0 = 1,
            
            VPD83NAA6 = 2,
            
            VPD83NAA5 = 3,
            
            VPD83Type2 = 4,
            
            VPD83Type1 = 5,
            
            VPD83Type0 = 6,
            
            SNVM = 7,
            
            NodeWWN = 8,
            
            NAA = 9,
            
            EUI64 = 10,
            
            T10VID = 11,
            
            OS_Device_Name = 12,
            
            NULL_ENUM_VALUE = 13,
        }
        
        public enum NameNamespaceValues {
            
            Unknown0 = 0,
            
            Other0 = 1,
            
            VPD83Type3 = 2,
            
            VPD83Type2 = 3,
            
            VPD83Type1 = 4,
            
            VPD80 = 5,
            
            NodeWWN = 6,
            
            SNVM = 7,
            
            OS_Device_Namespace = 8,
            
            NULL_ENUM_VALUE = 9,
        }
        
        // Implementering av uppräknare för klassens uppräkningsinstanser.
        public class StorageExtentCollection : object, ICollection {
            
            private ManagementObjectCollection privColObj;
            
            public StorageExtentCollection(ManagementObjectCollection objCollection) {
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
                    array.SetValue(new StorageExtent(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
                }
            }
            
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return new StorageExtentEnumerator(privColObj.GetEnumerator());
            }
            
            public class StorageExtentEnumerator : object, System.Collections.IEnumerator {
                
                private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
                
                public StorageExtentEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                    privObjEnum = objEnum;
                }
                
                public virtual object Current {
                    get {
                        return new StorageExtent(((System.Management.ManagementObject)(privObjEnum.Current)));
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
