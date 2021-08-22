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
    // En EarlyBound-klass genererades för WMI-klassen.Msvm_VirtualSystemExportSettingData
    public class VirtualSystemExportSettingData : System.ComponentModel.Component {
        
        // En privat egenskap som ska innehålla WMI-namnområdet där klassen finns.
        private static string CreatedWmiNamespace = "root\\virtualization\\v2";
        
        // En privat egenskap som ska innehålla namnet på den WMI-klass som skapade den här klassen.
        private static string CreatedClassName = "Msvm_VirtualSystemExportSettingData";
        
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
        public VirtualSystemExportSettingData() {
            this.InitializeObject(null, null, null);
        }
        
        public VirtualSystemExportSettingData(string keyInstanceID) {
            this.InitializeObject(null, new System.Management.ManagementPath(VirtualSystemExportSettingData.ConstructPath(keyInstanceID)), null);
        }
        
        public VirtualSystemExportSettingData(System.Management.ManagementScope mgmtScope, string keyInstanceID) {
            this.InitializeObject(((System.Management.ManagementScope)(mgmtScope)), new System.Management.ManagementPath(VirtualSystemExportSettingData.ConstructPath(keyInstanceID)), null);
        }
        
        public VirtualSystemExportSettingData(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(null, path, getOptions);
        }
        
        public VirtualSystemExportSettingData(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
            this.InitializeObject(mgmtScope, path, null);
        }
        
        public VirtualSystemExportSettingData(System.Management.ManagementPath path) {
            this.InitializeObject(null, path, null);
        }
        
        public VirtualSystemExportSettingData(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(mgmtScope, path, getOptions);
        }
        
        public VirtualSystemExportSettingData(System.Management.ManagementObject theObject) {
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
        
        public VirtualSystemExportSettingData(System.Management.ManagementBaseObject theObject) {
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
        public bool IsBackupIntentNull {
            get {
                if ((curObj["BackupIntent"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Indicates the intent on how the exported backup sets would be used
BackupIntentPreserveChain = All exported full and differential backup sets would be preserved as they are.
BackupIntentMerge = The exported full and differential backup sets would be merged to synthesize full backup sets.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public BackupIntentValues BackupIntent {
            get {
                if ((curObj["BackupIntent"] == null)) {
                    return ((BackupIntentValues)(System.Convert.ToInt32(2)));
                }
                return ((BackupIntentValues)(System.Convert.ToInt32(curObj["BackupIntent"])));
            }
            set {
                if ((BackupIntentValues.NULL_ENUM_VALUE == value)) {
                    curObj["BackupIntent"] = null;
                }
                else {
                    curObj["BackupIntent"] = value;
                }
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
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCaptureLiveStateNull {
            get {
                if ((curObj["CaptureLiveState"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Indicates what state to capture if the target of the export is a running VM.
CaptureCrashConsistentState = No saved state files will be exported for the running VM, placing it in a crash consistent state.
CaptureSavedState = Saved state files for the running VM will be exported along with the VM configuration.
CaptureAppConsistentState = Application-consistent state of the runningVM will be exported.
")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public CaptureLiveStateValues CaptureLiveState {
            get {
                if ((curObj["CaptureLiveState"] == null)) {
                    return ((CaptureLiveStateValues)(System.Convert.ToInt32(3)));
                }
                return ((CaptureLiveStateValues)(System.Convert.ToInt32(curObj["CaptureLiveState"])));
            }
            set {
                if ((CaptureLiveStateValues.NULL_ENUM_VALUE == value)) {
                    curObj["CaptureLiveState"] = null;
                }
                else {
                    curObj["CaptureLiveState"] = value;
                }
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCopySnapshotConfigurationNull {
            get {
                if ((curObj["CopySnapshotConfiguration"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Indicates what snapshots are to be exported with the VM.
ExportAllSnapshots = All snapshots will be exported with the VM.
ExportNoSnapshots = No snapshots will be exported with the VM.
ExportOneSnapshot = The snapshots identified by the SnapshotVirtualSystem property will be exported with the VM. The CopyVmStorage and CopyVmRuntimeInformation properties are ignored and storage and runtime information is exported with the VM and any VHD differencing disks will be merged into a new VHD.
ExportOneSnapshotForBackup = The snapshot identified by the SnapshotVirtualSystem property will be exported for the purpose of backing up the VM. The exported configuration will use ID of the VM.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public CopySnapshotConfigurationValues CopySnapshotConfiguration {
            get {
                if ((curObj["CopySnapshotConfiguration"] == null)) {
                    return ((CopySnapshotConfigurationValues)(System.Convert.ToInt32(4)));
                }
                return ((CopySnapshotConfigurationValues)(System.Convert.ToInt32(curObj["CopySnapshotConfiguration"])));
            }
            set {
                if ((CopySnapshotConfigurationValues.NULL_ENUM_VALUE == value)) {
                    curObj["CopySnapshotConfiguration"] = null;
                }
                else {
                    curObj["CopySnapshotConfiguration"] = value;
                }
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCopyVmRuntimeInformationNull {
            get {
                if ((curObj["CopyVmRuntimeInformation"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Indicates whether the VM runtime information will be copied when the VM is export" +
            "ed.\nIf TRUE, the VM runtime information will be copied.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool CopyVmRuntimeInformation {
            get {
                if ((curObj["CopyVmRuntimeInformation"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["CopyVmRuntimeInformation"]));
            }
            set {
                curObj["CopyVmRuntimeInformation"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCopyVmStorageNull {
            get {
                if ((curObj["CopyVmStorage"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Indicates whether the VM storage will be copied when the VM is exported.\nIf TRUE," +
            " the VM storage will be copied.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool CopyVmStorage {
            get {
                if ((curObj["CopyVmStorage"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["CopyVmStorage"]));
            }
            set {
                curObj["CopyVmStorage"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCreateVmExportSubdirectoryNull {
            get {
                if ((curObj["CreateVmExportSubdirectory"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Indicates whether a subdirectory with the name of the VM will be created when the" +
            " VM is exported.\nIf TRUE, a subdirectory will be created.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool CreateVmExportSubdirectory {
            get {
                if ((curObj["CreateVmExportSubdirectory"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["CreateVmExportSubdirectory"]));
            }
            set {
                curObj["CreateVmExportSubdirectory"] = value;
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
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Base for differential export. This is either path to a Msvm_VirtualSystemReferencePoint instance that represents the reference point or path to a Msvm_VirtualSystemSettingData instance that represents the snapshot to be used as a base for differential export. If the CopySnapshotConfiguration property is not set to 3(ExportOneSnapshotForBackup), this property is ignored.")]
        public string DifferentialBackupBase {
            get {
                return ((string)(curObj["DifferentialBackupBase"]));
            }
            set {
                curObj["DifferentialBackupBase"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDisableDifferentialOfIgnoredStorageNull {
            get {
                if ((curObj["DisableDifferentialOfIgnoredStorage"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Indicates whether differencing disks will be created or not for storage ignored d" +
            "uring export. By default this is set to false, which means that differencing dis" +
            "ks are created for the storage that is not going to be copied over to the export" +
            " destination.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool DisableDifferentialOfIgnoredStorage {
            get {
                if ((curObj["DisableDifferentialOfIgnoredStorage"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["DisableDifferentialOfIgnoredStorage"]));
            }
            set {
                curObj["DisableDifferentialOfIgnoredStorage"] = value;
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
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Array of Msvm_StorageAllocationSettingData (RASD) instance IDs that represent the virtual hard disks that are requested to be excluded from the export operation. If at least one of the supplied IDs is not a valid attached virtual hard disk, the operation will fail.
The virtual hard disks referenced by this property may be from the VM and/or from any of its snapshots. Exclusion of virtual hard disks is not supported when property CopySnapshotConfiguration is set to  0(ExportAllSnapshots).
Note that the RASD instance ID for virtual hard disks represents the location they are attached to, and excluding through this ID excludes all virtual hard disks attached in that location throughout the virtual machine's snapshot tree, regardless of them really being a valid virtual hard disk chain.")]
        public string[] ExcludedVirtualHardDisks {
            get {
                return ((string[])(curObj["ExcludedVirtualHardDisks"]));
            }
            set {
                curObj["ExcludedVirtualHardDisks"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsExportForLiveMigrationNull {
            get {
                if ((curObj["ExportForLiveMigration"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Indicates whether the exported VM is intended to be used in live migration. ")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool ExportForLiveMigration {
            get {
                if ((curObj["ExportForLiveMigration"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["ExportForLiveMigration"]));
            }
            set {
                curObj["ExportForLiveMigration"] = value;
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
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Path to a Msvm_VirtualSystemSettingData instance that represents the snapshot to " +
            "be exported with the VM. If the CopySnapshotConfiguration property is not set to" +
            " 2 (ExportOneSnapshot) or 3(ExportOneSnapshotForBackup), this property is ignore" +
            "d.")]
        public string SnapshotVirtualSystem {
            get {
                return ((string)(curObj["SnapshotVirtualSystem"]));
            }
            set {
                curObj["SnapshotVirtualSystem"] = value;
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
        
        private bool ShouldSerializeBackupIntent() {
            if ((this.IsBackupIntentNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetBackupIntent() {
            curObj["BackupIntent"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeCaptureLiveState() {
            if ((this.IsCaptureLiveStateNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetCaptureLiveState() {
            curObj["CaptureLiveState"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeCopySnapshotConfiguration() {
            if ((this.IsCopySnapshotConfigurationNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetCopySnapshotConfiguration() {
            curObj["CopySnapshotConfiguration"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeCopyVmRuntimeInformation() {
            if ((this.IsCopyVmRuntimeInformationNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetCopyVmRuntimeInformation() {
            curObj["CopyVmRuntimeInformation"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeCopyVmStorage() {
            if ((this.IsCopyVmStorageNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetCopyVmStorage() {
            curObj["CopyVmStorage"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeCreateVmExportSubdirectory() {
            if ((this.IsCreateVmExportSubdirectoryNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetCreateVmExportSubdirectory() {
            curObj["CreateVmExportSubdirectory"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetDifferentialBackupBase() {
            curObj["DifferentialBackupBase"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeDisableDifferentialOfIgnoredStorage() {
            if ((this.IsDisableDifferentialOfIgnoredStorageNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetDisableDifferentialOfIgnoredStorage() {
            curObj["DisableDifferentialOfIgnoredStorage"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetExcludedVirtualHardDisks() {
            curObj["ExcludedVirtualHardDisks"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeExportForLiveMigration() {
            if ((this.IsExportForLiveMigrationNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetExportForLiveMigration() {
            curObj["ExportForLiveMigration"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetSnapshotVirtualSystem() {
            curObj["SnapshotVirtualSystem"] = null;
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
            string strPath = "root\\virtualization\\v2:Msvm_VirtualSystemExportSettingData";
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
        public static VirtualSystemExportSettingDataCollection GetInstances() {
            return GetInstances(null, null, null);
        }
        
        public static VirtualSystemExportSettingDataCollection GetInstances(string condition) {
            return GetInstances(null, condition, null);
        }
        
        public static VirtualSystemExportSettingDataCollection GetInstances(string[] selectedProperties) {
            return GetInstances(null, null, selectedProperties);
        }
        
        public static VirtualSystemExportSettingDataCollection GetInstances(string condition, string[] selectedProperties) {
            return GetInstances(null, condition, selectedProperties);
        }
        
        public static VirtualSystemExportSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
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
            pathObj.ClassName = "Msvm_VirtualSystemExportSettingData";
            pathObj.NamespacePath = "root\\virtualization\\v2";
            System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
            if ((enumOptions == null)) {
                enumOptions = new System.Management.EnumerationOptions();
                enumOptions.EnsureLocatable = true;
            }
            return new VirtualSystemExportSettingDataCollection(clsObject.GetInstances(enumOptions));
        }
        
        public static VirtualSystemExportSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
            return GetInstances(mgmtScope, condition, null);
        }
        
        public static VirtualSystemExportSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string[] selectedProperties) {
            return GetInstances(mgmtScope, null, selectedProperties);
        }
        
        public static VirtualSystemExportSettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, string[] selectedProperties) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\virtualization\\v2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("Msvm_VirtualSystemExportSettingData", condition, selectedProperties));
            System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
            ObjectSearcher.Options = enumOptions;
            return new VirtualSystemExportSettingDataCollection(ObjectSearcher.Get());
        }
        
        [Browsable(true)]
        public static VirtualSystemExportSettingData CreateInstance() {
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
            return new VirtualSystemExportSettingData(tmpMgmtClass.CreateInstance());
        }
        
        [Browsable(true)]
        public void Delete() {
            PrivateLateBoundObject.Delete();
        }
        
        public enum BackupIntentValues {
            
            BackupIntentPreserveChain = 0,
            
            BackupIntentMerge = 1,
            
            NULL_ENUM_VALUE = 2,
        }
        
        public enum CaptureLiveStateValues {
            
            CaptureCrashConsistentState = 0,
            
            CaptureSavedState = 1,
            
            CaptureAppConsistentState = 2,
            
            NULL_ENUM_VALUE = 3,
        }
        
        public enum CopySnapshotConfigurationValues {
            
            ExportAllSnapshots = 0,
            
            ExportNoSnapshots = 1,
            
            ExportOneSnapshot = 2,
            
            ExportOneSnapshotForBackup = 3,
            
            NULL_ENUM_VALUE = 4,
        }
        
        // Implementering av uppräknare för klassens uppräkningsinstanser.
        public class VirtualSystemExportSettingDataCollection : object, ICollection {
            
            private ManagementObjectCollection privColObj;
            
            public VirtualSystemExportSettingDataCollection(ManagementObjectCollection objCollection) {
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
                    array.SetValue(new VirtualSystemExportSettingData(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
                }
            }
            
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return new VirtualSystemExportSettingDataEnumerator(privColObj.GetEnumerator());
            }
            
            public class VirtualSystemExportSettingDataEnumerator : object, System.Collections.IEnumerator {
                
                private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
                
                public VirtualSystemExportSettingDataEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                    privObjEnum = objEnum;
                }
                
                public virtual object Current {
                    get {
                        return new VirtualSystemExportSettingData(((System.Management.ManagementObject)(privObjEnum.Current)));
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
