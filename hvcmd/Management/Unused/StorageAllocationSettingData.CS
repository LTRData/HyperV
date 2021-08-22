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
    // En EarlyBound-klass genererades för WMI-klassen.CIM_StorageAllocationSettingData
    public class StorageAllocationSettingData : System.ComponentModel.Component {
        
        // En privat egenskap som ska innehålla WMI-namnområdet där klassen finns.
        private static string CreatedWmiNamespace = "root\\virtualization\\v2";
        
        // En privat egenskap som ska innehålla namnet på den WMI-klass som skapade den här klassen.
        private static string CreatedClassName = "CIM_StorageAllocationSettingData";
        
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
        public StorageAllocationSettingData() {
            this.InitializeObject(null, null, null);
        }
        
        public StorageAllocationSettingData(string keyInstanceID) {
            this.InitializeObject(null, new System.Management.ManagementPath(StorageAllocationSettingData.ConstructPath(keyInstanceID)), null);
        }
        
        public StorageAllocationSettingData(System.Management.ManagementScope mgmtScope, string keyInstanceID) {
            this.InitializeObject(((System.Management.ManagementScope)(mgmtScope)), new System.Management.ManagementPath(StorageAllocationSettingData.ConstructPath(keyInstanceID)), null);
        }
        
        public StorageAllocationSettingData(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(null, path, getOptions);
        }
        
        public StorageAllocationSettingData(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
            this.InitializeObject(mgmtScope, path, null);
        }
        
        public StorageAllocationSettingData(System.Management.ManagementPath path) {
            this.InitializeObject(null, path, null);
        }
        
        public StorageAllocationSettingData(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(mgmtScope, path, getOptions);
        }
        
        public StorageAllocationSettingData(System.Management.ManagementObject theObject) {
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
        
        public StorageAllocationSettingData(System.Management.ManagementBaseObject theObject) {
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
        [Description(@"Access describes whether the allocated storage extent is 1 (readable), 2 (writeable), or 3 (both).
NOTE: This property is a copy of the CIM_StorageExtent.Access property, except deprecated values. See the description of the CIM_StorageExtent.Access property for details.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort Access {
            get {
                if ((curObj["Access"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["Access"]));
            }
            set {
                curObj["Access"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Address {
            get {
                return ((string)(curObj["Address"]));
            }
            set {
                curObj["Address"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AddressOnParent {
            get {
                return ((string)(curObj["AddressOnParent"]));
            }
            set {
                curObj["AddressOnParent"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AllocationUnits {
            get {
                return ((string)(curObj["AllocationUnits"]));
            }
            set {
                curObj["AllocationUnits"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAutomaticAllocationNull {
            get {
                if ((curObj["AutomaticAllocation"] == null)) {
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
        public bool AutomaticAllocation {
            get {
                if ((curObj["AutomaticAllocation"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["AutomaticAllocation"]));
            }
            set {
                curObj["AutomaticAllocation"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAutomaticDeallocationNull {
            get {
                if ((curObj["AutomaticDeallocation"] == null)) {
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
        public bool AutomaticDeallocation {
            get {
                if ((curObj["AutomaticDeallocation"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["AutomaticDeallocation"]));
            }
            set {
                curObj["AutomaticDeallocation"] = value;
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
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] Connection {
            get {
                return ((string[])(curObj["Connection"]));
            }
            set {
                curObj["Connection"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsConsumerVisibilityNull {
            get {
                if ((curObj["ConsumerVisibility"] == null)) {
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
        public ushort ConsumerVisibility {
            get {
                if ((curObj["ConsumerVisibility"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["ConsumerVisibility"]));
            }
            set {
                curObj["ConsumerVisibility"] = value;
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
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A unique identifier for the host extent. The identified host extent is used for t" +
            "he storage resource allocation.\nNOTE: This property is a copy of the CIM_Storage" +
            "Extent.Name property. See the description of CIM_StorageExtent.Name property for" +
            " details.")]
        public string HostExtentName {
            get {
                return ((string)(curObj["HostExtentName"]));
            }
            set {
                curObj["HostExtentName"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsHostExtentNameFormatNull {
            get {
                if ((curObj["HostExtentNameFormat"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The HostExtentNameFormat property identifies the format that is used for the valu" +
            "e of the HostExtentName property.\nNOTE: This property is a copy of the CIM_Stora" +
            "geExtent.NameFormat property, excluding deprecated values. See the description o" +
            "f CIM_StorageExtent.NameFormat class for details.\n7 = Serial Number/Vendor/Model" +
            " (SNVM) SNVM is 3 strings representing the vendor name, product name within the " +
            "vendor namespace, and the serial number within the model namespace. Strings are " +
            "delimited with a \'+\'. Spaces may be included and are significant. The serial num" +
            "ber is the text representation of the serial number in hexadecimal upper case. T" +
            "his represents the vendor and model ID from SCSI Inquiry data; the vendor field " +
            "MUST be 8 characters wide and the product field MUST be 16 characters wide. For " +
            "example, \n\'ACME____+SUPER DISK______+124437458\' (_ is a space character) \n9 = NA" +
            "A as a generic format. See \nhttp://standards.ieee.org/regauth/oui/tutorials/fibr" +
            "ecomp_id.html. Formatted as 16 or 32 unseparated uppercase hex characters (2 per" +
            " binary byte). For example \'21000020372D3C73\' \n10 = EUI as a generic format (EUI" +
            "64) See \nhttp://standards.ieee.org/regauth/oui/tutorials/EUI64.html. \nFormatted " +
            "as 16 unseparated uppercase hex characters (2 per binary byte) \n11 = T10 vendor " +
            "identifier format as returned by SCSI Inquiry VPD page 83, identifier type 1. Se" +
            "e T10 SPC-3 specification. This is the 8-byte ASCII vendor ID from the T10 regis" +
            "try followed by a vendor specific ASCII identifier; spaces are permitted. For no" +
            "n SCSI volumes, \'SNVM\' may be the most appropriate choice. 12 = OS Device Name (" +
            "for LogicalDisks). See LogicalDisk Name description for details.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort HostExtentNameFormat {
            get {
                if ((curObj["HostExtentNameFormat"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["HostExtentNameFormat"]));
            }
            set {
                curObj["HostExtentNameFormat"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsHostExtentNameNamespaceNull {
            get {
                if ((curObj["HostExtentNameNamespace"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"If the host extent is a SCSI volume, then the preferred source for SCSI volume names is SCSI VPD Page 83 responses.
NOTE: This property is a copy of the CIM_StorageExtent.NameNamespace property. See the description of CIM_StorageExtent.NameNamespace class for details.
Page 83 returns a list of identifiers for various device elements. The metadata for each identifier includes an Association field, identifiers with association of 0 apply to volumes. Page 83 supports several namespaces specified in the Type field in the identifier metadata. See SCSI SPC-3 specification. 
2 = VPD Page 83, Type 3 NAA (NameFormat SHOULD be NAA) 
3 = VPD Page 83, Type 2 EUI64 (NameFormat EUI) 
4 = VPD Page 83, Type 1 T10 Vendor Identification 
(NameFormat T10) 
Less preferred volume namespaces from other interfaces: 
5 = VPD page 80, Serial number (NameFormat SHOULD be Other) 
6 = FC NodeWWN (NameFormat SHOULD be NAA or EUI) 
7 = Serial Number/Vendor/Model (NameFormat SHOULD be SNVM) cThe preferred namespace for LogigicalDisk names is platform specific device namespace; see LogigicalDIsk Description. 
8 = OS Device Namespace.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort HostExtentNameNamespace {
            get {
                if ((curObj["HostExtentNameNamespace"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["HostExtentNameNamespace"]));
            }
            set {
                curObj["HostExtentNameNamespace"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsHostExtentStartingAddressNull {
            get {
                if ((curObj["HostExtentStartingAddress"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The HostExtentStartingAddress property identifies the starting address on the host storage extent identified by the value of the HostExtentName property that is used for the allocation of the virtual storage extent.
A value of NULL indicates that there is no direct mapping of the virtual storage extent onto the referenced host storage extent.
NOTE: This property is a copy of the CIM_BasedOn.StartingAddess property. See the description of CIM_BasedOn association for details.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ulong HostExtentStartingAddress {
            get {
                if ((curObj["HostExtentStartingAddress"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["HostExtentStartingAddress"]));
            }
            set {
                curObj["HostExtentStartingAddress"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] HostResource {
            get {
                return ((string[])(curObj["HostResource"]));
            }
            set {
                curObj["HostResource"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsHostResourceBlockSizeNull {
            get {
                if ((curObj["HostResourceBlockSize"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Size in bytes of the blocks that are allocated at the host as the result of this storage resource allocation or storage resource allocation request. If the block size is variable, then the maximum block size in bytes should be specified. If the block size is unknown or if a block concept does not apply, then the value 1 shall be used.
NOTE: This property is a copy of the CIM_StorageExtent.BlockSize property. See the description of the CIM_StorageExtent.BlockSize property for details.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ulong HostResourceBlockSize {
            get {
                if ((curObj["HostResourceBlockSize"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["HostResourceBlockSize"]));
            }
            set {
                curObj["HostResourceBlockSize"] = value;
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
        public bool IsLimitNull {
            get {
                if ((curObj["Limit"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The maximum amount of blocks that will be granted for this storage resource allocation at the host. The blocksize is specified by the value of the HostResourceBlockSize property.Usually the value this property would reflect a maximum size for the allocated host extent that matches the size of the virtual storage extent presented to the consumer. A value less than that would indicate a situation where a sparsely populated virtual storage extent is expected, where the fill rate is limited by the value of the Limit property.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ulong Limit {
            get {
                if ((curObj["Limit"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["Limit"]));
            }
            set {
                curObj["Limit"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMappingBehaviorNull {
            get {
                if ((curObj["MappingBehavior"] == null)) {
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
        public ushort MappingBehavior {
            get {
                if ((curObj["MappingBehavior"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["MappingBehavior"]));
            }
            set {
                curObj["MappingBehavior"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A string describing the format of the HostExtentName property if the value of the" +
            " HostExtentNameFormat property is 1 (Other).")]
        public string OtherHostExtentNameFormat {
            get {
                return ((string)(curObj["OtherHostExtentNameFormat"]));
            }
            set {
                curObj["OtherHostExtentNameFormat"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A string describing the namespace of the HostExtentName property if the value of " +
            "the HostExtentNameNamespace matches 1 (Other).")]
        public string OtherHostExtentNameNamespace {
            get {
                return ((string)(curObj["OtherHostExtentNameNamespace"]));
            }
            set {
                curObj["OtherHostExtentNameNamespace"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OtherResourceType {
            get {
                return ((string)(curObj["OtherResourceType"]));
            }
            set {
                curObj["OtherResourceType"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Parent {
            get {
                return ((string)(curObj["Parent"]));
            }
            set {
                curObj["Parent"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PoolID {
            get {
                return ((string)(curObj["PoolID"]));
            }
            set {
                curObj["PoolID"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsReservationNull {
            get {
                if ((curObj["Reservation"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The amount of blocks that are guaranteed to be available for this storage resourc" +
            "e allocation at the host. The blocksize is specified by the value of the HostRes" +
            "ourceBlockSize property.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ulong Reservation {
            get {
                if ((curObj["Reservation"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["Reservation"]));
            }
            set {
                curObj["Reservation"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResourceSubType {
            get {
                return ((string)(curObj["ResourceSubType"]));
            }
            set {
                curObj["ResourceSubType"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsResourceTypeNull {
            get {
                if ((curObj["ResourceType"] == null)) {
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
        public ushort ResourceType {
            get {
                if ((curObj["ResourceType"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["ResourceType"]));
            }
            set {
                curObj["ResourceType"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsVirtualQuantityNull {
            get {
                if ((curObj["VirtualQuantity"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Number of blocks that are presented to the consumer. The blocksize is specified b" +
            "y the value of the VirtualResourceBlockSize property.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ulong VirtualQuantity {
            get {
                if ((curObj["VirtualQuantity"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["VirtualQuantity"]));
            }
            set {
                curObj["VirtualQuantity"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"This property specifies the units used by the VirtualQuantity property. The value shall match ""count(fixed size block)"" | ""byte"".
The default value ""count(fixed size block)"" assumes that the implementation knows a fixed block size and conveys the block size through the value of the VirtualResourceBlockSize property. However, if the VirtualResourceBlockSize property has a value ""1"", this indicates an unknown or variable block size; in this case the value of the VirtualQuantityUnit property should be set to ""byte"", such that the value of the VirtualQuantity property is measured directly in byte.
NOTE: The IsPUnit qualifier already formally restricts the value of this property to be a unit as specified in DMTF DSP0004:2.5.0, Annex C; in addition, the normative text in the description of this property above further constrains the value to match ""byte"" | ""count(fixed size block)"".")]
        public string VirtualQuantityUnits {
            get {
                return ((string)(curObj["VirtualQuantityUnits"]));
            }
            set {
                curObj["VirtualQuantityUnits"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsVirtualResourceBlockSizeNull {
            get {
                if ((curObj["VirtualResourceBlockSize"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Size in bytes of the blocks that are presented to the consumer as the result of this storage resource allocation or storage resource allocation request. If the block size is variable, then the maximum block size in bytes should be specified. If the block size is unknown or if a block concept does not apply, then the value 1 shall be used.
NOTE: The use of 1 (and not 0) to indicate that the blocksize is unknown still allows the use of the VirtualQuantity property to convey the size in blocks of size 1).
NOTE: This property is a copy of the CIM_StorageExtent.BlockSize property. See the description of the CIM_StorageExtent.BlockSize property for details.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ulong VirtualResourceBlockSize {
            get {
                if ((curObj["VirtualResourceBlockSize"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["VirtualResourceBlockSize"]));
            }
            set {
                curObj["VirtualResourceBlockSize"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsWeightNull {
            get {
                if ((curObj["Weight"] == null)) {
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
        public uint Weight {
            get {
                if ((curObj["Weight"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["Weight"]));
            }
            set {
                curObj["Weight"] = value;
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
        
        private void ResetAddress() {
            curObj["Address"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetAddressOnParent() {
            curObj["AddressOnParent"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetAllocationUnits() {
            curObj["AllocationUnits"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeAutomaticAllocation() {
            if ((this.IsAutomaticAllocationNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetAutomaticAllocation() {
            curObj["AutomaticAllocation"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeAutomaticDeallocation() {
            if ((this.IsAutomaticDeallocationNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetAutomaticDeallocation() {
            curObj["AutomaticDeallocation"] = null;
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
        
        private void ResetConnection() {
            curObj["Connection"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeConsumerVisibility() {
            if ((this.IsConsumerVisibilityNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetConsumerVisibility() {
            curObj["ConsumerVisibility"] = null;
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
        
        private void ResetElementName() {
            curObj["ElementName"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetHostExtentName() {
            curObj["HostExtentName"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeHostExtentNameFormat() {
            if ((this.IsHostExtentNameFormatNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetHostExtentNameFormat() {
            curObj["HostExtentNameFormat"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeHostExtentNameNamespace() {
            if ((this.IsHostExtentNameNamespaceNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetHostExtentNameNamespace() {
            curObj["HostExtentNameNamespace"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeHostExtentStartingAddress() {
            if ((this.IsHostExtentStartingAddressNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetHostExtentStartingAddress() {
            curObj["HostExtentStartingAddress"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetHostResource() {
            curObj["HostResource"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeHostResourceBlockSize() {
            if ((this.IsHostResourceBlockSizeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetHostResourceBlockSize() {
            curObj["HostResourceBlockSize"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeLimit() {
            if ((this.IsLimitNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetLimit() {
            curObj["Limit"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeMappingBehavior() {
            if ((this.IsMappingBehaviorNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetMappingBehavior() {
            curObj["MappingBehavior"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherHostExtentNameFormat() {
            curObj["OtherHostExtentNameFormat"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherHostExtentNameNamespace() {
            curObj["OtherHostExtentNameNamespace"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherResourceType() {
            curObj["OtherResourceType"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetParent() {
            curObj["Parent"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetPoolID() {
            curObj["PoolID"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeReservation() {
            if ((this.IsReservationNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetReservation() {
            curObj["Reservation"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetResourceSubType() {
            curObj["ResourceSubType"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeResourceType() {
            if ((this.IsResourceTypeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetResourceType() {
            curObj["ResourceType"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeVirtualQuantity() {
            if ((this.IsVirtualQuantityNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetVirtualQuantity() {
            curObj["VirtualQuantity"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetVirtualQuantityUnits() {
            curObj["VirtualQuantityUnits"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeVirtualResourceBlockSize() {
            if ((this.IsVirtualResourceBlockSizeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetVirtualResourceBlockSize() {
            curObj["VirtualResourceBlockSize"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeWeight() {
            if ((this.IsWeightNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetWeight() {
            curObj["Weight"] = null;
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
            string strPath = "root\\virtualization\\v2:CIM_StorageAllocationSettingData";
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
        public static StorageAllocationSettingDataCollection GetInstances() {
            return GetInstances(null, null, null);
        }
        
        public static StorageAllocationSettingDataCollection GetInstances(string condition) {
            return GetInstances(null, condition, null);
        }
        
        public static StorageAllocationSettingDataCollection GetInstances(string[] selectedProperties) {
            return GetInstances(null, null, selectedProperties);
        }
        
        public static StorageAllocationSettingDataCollection GetInstances(string condition, string[] selectedProperties) {
            return GetInstances(null, condition, selectedProperties);
        }
        
        public static StorageAllocationSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
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
            pathObj.ClassName = "CIM_StorageAllocationSettingData";
            pathObj.NamespacePath = "root\\virtualization\\v2";
            System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
            if ((enumOptions == null)) {
                enumOptions = new System.Management.EnumerationOptions();
                enumOptions.EnsureLocatable = true;
            }
            return new StorageAllocationSettingDataCollection(clsObject.GetInstances(enumOptions));
        }
        
        public static StorageAllocationSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
            return GetInstances(mgmtScope, condition, null);
        }
        
        public static StorageAllocationSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string[] selectedProperties) {
            return GetInstances(mgmtScope, null, selectedProperties);
        }
        
        public static StorageAllocationSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, string[] selectedProperties) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\virtualization\\v2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("CIM_StorageAllocationSettingData", condition, selectedProperties));
            System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
            ObjectSearcher.Options = enumOptions;
            return new StorageAllocationSettingDataCollection(ObjectSearcher.Get());
        }
        
        [Browsable(true)]
        public static StorageAllocationSettingData CreateInstance() {
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
            return new StorageAllocationSettingData(tmpMgmtClass.CreateInstance());
        }
        
        [Browsable(true)]
        public void Delete() {
            PrivateLateBoundObject.Delete();
        }
        
        // Implementering av uppräknare för klassens uppräkningsinstanser.
        public class StorageAllocationSettingDataCollection : object, ICollection {
            
            private ManagementObjectCollection privColObj;
            
            public StorageAllocationSettingDataCollection(ManagementObjectCollection objCollection) {
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
                    array.SetValue(new StorageAllocationSettingData(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
                }
            }
            
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return new StorageAllocationSettingDataEnumerator(privColObj.GetEnumerator());
            }
            
            public class StorageAllocationSettingDataEnumerator : object, System.Collections.IEnumerator {
                
                private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
                
                public StorageAllocationSettingDataEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                    privObjEnum = objEnum;
                }
                
                public virtual object Current {
                    get {
                        return new StorageAllocationSettingData(((System.Management.ManagementObject)(privObjEnum.Current)));
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
