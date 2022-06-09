namespace LTR.HyperV.Management.ROOT.virtualization.v2; 
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
// En EarlyBound-klass genererades för WMI-klassen.Msvm_ConcreteJob
[System.CodeDom.Compiler.GeneratedCode("mgmtclassgen", "")]
public class ConcreteJob : System.ComponentModel.Component {
    
    // En privat egenskap som ska innehålla WMI-namnområdet där klassen finns.
    public const string CreatedWmiNamespace = "root\\virtualization\\v2";
    
    // En privat egenskap som ska innehålla namnet på den WMI-klass som skapade den här klassen.
    public const string CreatedClassName = "Msvm_ConcreteJob";
    
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
    public ConcreteJob() {
        this.InitializeObject(null, null, null);
    }
    
    public ConcreteJob(string keyInstanceID) {
        this.InitializeObject(null, new System.Management.ManagementPath(ConcreteJob.ConstructPath(keyInstanceID)), null);
    }
    
    public ConcreteJob(System.Management.ManagementScope mgmtScope, string keyInstanceID) {
        this.InitializeObject(((System.Management.ManagementScope)(mgmtScope)), new System.Management.ManagementPath(ConcreteJob.ConstructPath(keyInstanceID)), null);
    }
    
    public ConcreteJob(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
        this.InitializeObject(null, path, getOptions);
    }
    
    public ConcreteJob(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
        this.InitializeObject(mgmtScope, path, null);
    }
    
    public ConcreteJob(System.Management.ManagementPath path) {
        this.InitializeObject(null, path, null);
    }
    
    public ConcreteJob(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
        this.InitializeObject(mgmtScope, path, getOptions);
    }
    
    public ConcreteJob(System.Management.ManagementObject theObject) {
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
    
    public ConcreteJob(System.Management.ManagementBaseObject theObject) {
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
    public bool IsCancellableNull {
        get {
            if ((curObj["Cancellable"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Indicates whether the job can be cancelled. The value of this property does not g" +
        "uarantee that a request to cancel the job will succeed.")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public bool Cancellable {
        get {
            if ((curObj["Cancellable"] == null)) {
                return System.Convert.ToBoolean(0);
            }
            return ((bool)(curObj["Cancellable"]));
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
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsDeleteOnCompletionNull {
        get {
            if ((curObj["DeleteOnCompletion"] == null)) {
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
    public bool DeleteOnCompletion {
        get {
            if ((curObj["DeleteOnCompletion"] == null)) {
                return System.Convert.ToBoolean(0);
            }
            return ((bool)(curObj["DeleteOnCompletion"]));
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Description {
        get {
            return ((string)(curObj["Description"]));
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
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsElapsedTimeNull {
        get {
            if ((curObj["ElapsedTime"] == null)) {
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
    public System.DateTime ElapsedTime {
        get {
            if ((curObj["ElapsedTime"] != null)) {
                return ToDateTime(((string)(curObj["ElapsedTime"])));
            }
            else {
                return System.DateTime.MinValue;
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
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsErrorCodeNull {
        get {
            if ((curObj["ErrorCode"] == null)) {
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
    public ushort ErrorCode {
        get {
            if ((curObj["ErrorCode"] == null)) {
                return System.Convert.ToUInt16(0);
            }
            return ((ushort)(curObj["ErrorCode"]));
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string ErrorDescription {
        get {
            return ((string)(curObj["ErrorDescription"]));
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string ErrorSummaryDescription {
        get {
            return ((string)(curObj["ErrorSummaryDescription"]));
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
    public bool IsJobRunTimesNull {
        get {
            if ((curObj["JobRunTimes"] == null)) {
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
    public uint JobRunTimes {
        get {
            if ((curObj["JobRunTimes"] == null)) {
                return System.Convert.ToUInt32(0);
            }
            return ((uint)(curObj["JobRunTimes"]));
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsJobStateNull {
        get {
            if ((curObj["JobState"] == null)) {
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
    public ushort JobState {
        get {
            if ((curObj["JobState"] == null)) {
                return System.Convert.ToUInt16(0);
            }
            return ((ushort)(curObj["JobState"]));
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string JobStatus {
        get {
            return ((string)(curObj["JobStatus"]));
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsJobTypeNull {
        get {
            if ((curObj["JobType"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Indicates the type of Job being tracked by this object.")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public JobTypeValues JobType {
        get {
            if ((curObj["JobType"] == null)) {
                return ((JobTypeValues)(System.Convert.ToInt32(171)));
            }
            return ((JobTypeValues)(System.Convert.ToInt32(curObj["JobType"])));
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsLocalOrUtcTimeNull {
        get {
            if ((curObj["LocalOrUtcTime"] == null)) {
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
    public ushort LocalOrUtcTime {
        get {
            if ((curObj["LocalOrUtcTime"] == null)) {
                return System.Convert.ToUInt16(0);
            }
            return ((ushort)(curObj["LocalOrUtcTime"]));
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Name {
        get {
            return ((string)(curObj["Name"]));
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Notify {
        get {
            return ((string)(curObj["Notify"]));
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
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ushort[] OperationalStatus {
        get {
            return ((ushort[])(curObj["OperationalStatus"]));
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string OtherRecoveryAction {
        get {
            return ((string)(curObj["OtherRecoveryAction"]));
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Owner {
        get {
            return ((string)(curObj["Owner"]));
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsPercentCompleteNull {
        get {
            if ((curObj["PercentComplete"] == null)) {
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
    public ushort PercentComplete {
        get {
            if ((curObj["PercentComplete"] == null)) {
                return System.Convert.ToUInt16(0);
            }
            return ((ushort)(curObj["PercentComplete"]));
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
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsPriorityNull {
        get {
            if ((curObj["Priority"] == null)) {
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
    public uint Priority {
        get {
            if ((curObj["Priority"] == null)) {
                return System.Convert.ToUInt32(0);
            }
            return ((uint)(curObj["Priority"]));
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsRecoveryActionNull {
        get {
            if ((curObj["RecoveryAction"] == null)) {
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
    public ushort RecoveryAction {
        get {
            if ((curObj["RecoveryAction"] == null)) {
                return System.Convert.ToUInt16(0);
            }
            return ((ushort)(curObj["RecoveryAction"]));
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsRunDayNull {
        get {
            if ((curObj["RunDay"] == null)) {
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
    public sbyte RunDay {
        get {
            if ((curObj["RunDay"] == null)) {
                return System.Convert.ToSByte(0);
            }
            return ((sbyte)(curObj["RunDay"]));
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsRunDayOfWeekNull {
        get {
            if ((curObj["RunDayOfWeek"] == null)) {
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
    public sbyte RunDayOfWeek {
        get {
            if ((curObj["RunDayOfWeek"] == null)) {
                return System.Convert.ToSByte(0);
            }
            return ((sbyte)(curObj["RunDayOfWeek"]));
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsRunMonthNull {
        get {
            if ((curObj["RunMonth"] == null)) {
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
    public byte RunMonth {
        get {
            if ((curObj["RunMonth"] == null)) {
                return System.Convert.ToByte(0);
            }
            return ((byte)(curObj["RunMonth"]));
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsRunStartIntervalNull {
        get {
            if ((curObj["RunStartInterval"] == null)) {
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
    public System.DateTime RunStartInterval {
        get {
            if ((curObj["RunStartInterval"] != null)) {
                return ToDateTime(((string)(curObj["RunStartInterval"])));
            }
            else {
                return System.DateTime.MinValue;
            }
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsScheduledStartTimeNull {
        get {
            if ((curObj["ScheduledStartTime"] == null)) {
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
    public System.DateTime ScheduledStartTime {
        get {
            if ((curObj["ScheduledStartTime"] != null)) {
                return ToDateTime(((string)(curObj["ScheduledStartTime"])));
            }
            else {
                return System.DateTime.MinValue;
            }
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsStartTimeNull {
        get {
            if ((curObj["StartTime"] == null)) {
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
    public System.DateTime StartTime {
        get {
            if ((curObj["StartTime"] != null)) {
                return ToDateTime(((string)(curObj["StartTime"])));
            }
            else {
                return System.DateTime.MinValue;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Status {
        get {
            return ((string)(curObj["Status"]));
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string[] StatusDescriptions {
        get {
            return ((string[])(curObj["StatusDescriptions"]));
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsTimeBeforeRemovalNull {
        get {
            if ((curObj["TimeBeforeRemoval"] == null)) {
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
    public System.DateTime TimeBeforeRemoval {
        get {
            if ((curObj["TimeBeforeRemoval"] != null)) {
                return ToDateTime(((string)(curObj["TimeBeforeRemoval"])));
            }
            else {
                return System.DateTime.MinValue;
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
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsTimeSubmittedNull {
        get {
            if ((curObj["TimeSubmitted"] == null)) {
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
    public System.DateTime TimeSubmitted {
        get {
            if ((curObj["TimeSubmitted"] != null)) {
                return ToDateTime(((string)(curObj["TimeSubmitted"])));
            }
            else {
                return System.DateTime.MinValue;
            }
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsUntilTimeNull {
        get {
            if ((curObj["UntilTime"] == null)) {
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
    public System.DateTime UntilTime {
        get {
            if ((curObj["UntilTime"] != null)) {
                return ToDateTime(((string)(curObj["UntilTime"])));
            }
            else {
                return System.DateTime.MinValue;
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
    
    private bool ShouldSerializeCancellable() {
        if ((this.IsCancellableNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeCommunicationStatus() {
        if ((this.IsCommunicationStatusNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeDeleteOnCompletion() {
        if ((this.IsDeleteOnCompletionNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeDetailedStatus() {
        if ((this.IsDetailedStatusNull == false)) {
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
    
    private bool ShouldSerializeElapsedTime() {
        if ((this.IsElapsedTimeNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeErrorCode() {
        if ((this.IsErrorCodeNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeHealthState() {
        if ((this.IsHealthStateNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeInstallDate() {
        if ((this.IsInstallDateNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeJobRunTimes() {
        if ((this.IsJobRunTimesNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeJobState() {
        if ((this.IsJobStateNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeJobType() {
        if ((this.IsJobTypeNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeLocalOrUtcTime() {
        if ((this.IsLocalOrUtcTimeNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeOperatingStatus() {
        if ((this.IsOperatingStatusNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializePercentComplete() {
        if ((this.IsPercentCompleteNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializePrimaryStatus() {
        if ((this.IsPrimaryStatusNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializePriority() {
        if ((this.IsPriorityNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeRecoveryAction() {
        if ((this.IsRecoveryActionNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeRunDay() {
        if ((this.IsRunDayNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeRunDayOfWeek() {
        if ((this.IsRunDayOfWeekNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeRunMonth() {
        if ((this.IsRunMonthNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeRunStartInterval() {
        if ((this.IsRunStartIntervalNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeScheduledStartTime() {
        if ((this.IsScheduledStartTimeNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeStartTime() {
        if ((this.IsStartTimeNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeTimeBeforeRemoval() {
        if ((this.IsTimeBeforeRemovalNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeTimeOfLastStateChange() {
        if ((this.IsTimeOfLastStateChangeNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeTimeSubmitted() {
        if ((this.IsTimeSubmittedNull == false)) {
            return true;
        }
        return false;
    }
    
    private bool ShouldSerializeUntilTime() {
        if ((this.IsUntilTimeNull == false)) {
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
        string strPath = "root\\virtualization\\v2:Msvm_ConcreteJob";
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
    public static ConcreteJobCollection GetInstances() {
        return GetInstances(null, null, null);
    }
    
    public static ConcreteJobCollection GetInstances(string condition) {
        return GetInstances(null, condition, null);
    }
    
    public static ConcreteJobCollection GetInstances(string[] selectedProperties) {
        return GetInstances(null, null, selectedProperties);
    }
    
    public static ConcreteJobCollection GetInstances(string condition, string[] selectedProperties) {
        return GetInstances(null, condition, selectedProperties);
    }
    
    public static ConcreteJobCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
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
        pathObj.ClassName = "Msvm_ConcreteJob";
        pathObj.NamespacePath = "root\\virtualization\\v2";
        System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
        if ((enumOptions == null)) {
            enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
        }
        return new ConcreteJobCollection(clsObject.GetInstances(enumOptions));
    }
    
    public static ConcreteJobCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
        return GetInstances(mgmtScope, condition, null);
    }
    
    public static ConcreteJobCollection GetInstances(System.Management.ManagementScope mgmtScope, string[] selectedProperties) {
        return GetInstances(mgmtScope, null, selectedProperties);
    }
    
    public static ConcreteJobCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, string[] selectedProperties) {
        if ((mgmtScope == null)) {
            if ((statMgmtScope == null)) {
                mgmtScope = new System.Management.ManagementScope();
                mgmtScope.Path.NamespacePath = "root\\virtualization\\v2";
            }
            else {
                mgmtScope = statMgmtScope;
            }
        }
        System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("Msvm_ConcreteJob", condition, selectedProperties));
        System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
        enumOptions.EnsureLocatable = true;
        ObjectSearcher.Options = enumOptions;
        return new ConcreteJobCollection(ObjectSearcher.Get());
    }
    
    [Browsable(true)]
    public static ConcreteJob CreateInstance() {
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
        return new ConcreteJob(tmpMgmtClass.CreateInstance());
    }
    
    [Browsable(true)]
    public void Delete() {
        PrivateLateBoundObject.Delete();
    }
    
    public uint GetError(out string Error) {
        if ((isEmbedded == false)) {
            System.Management.ManagementBaseObject inParams = null;
            System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("GetError", inParams, null);
            Error = System.Convert.ToString(outParams.Properties["Error"].Value);
            return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
        }
        else {
            Error = null;
            return System.Convert.ToUInt32(0);
        }
    }
    
    public uint GetErrorEx(out string[] Errors) {
        if ((isEmbedded == false)) {
            System.Management.ManagementBaseObject inParams = null;
            System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("GetErrorEx", inParams, null);
            Errors = ((string[])(outParams.Properties["Errors"].Value));
            return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
        }
        else {
            Errors = null;
            return System.Convert.ToUInt32(0);
        }
    }
    
    public uint KillJob(bool DeleteOnKill) {
        if ((isEmbedded == false)) {
            System.Management.ManagementBaseObject inParams = null;
            inParams = PrivateLateBoundObject.GetMethodParameters("KillJob");
            inParams["DeleteOnKill"] = ((bool)(DeleteOnKill));
            System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("KillJob", inParams, null);
            return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
        }
        else {
            return System.Convert.ToUInt32(0);
        }
    }
    
    public uint RequestStateChange(ushort RequestedState, System.DateTime TimeoutPeriod) {
        if ((isEmbedded == false)) {
            System.Management.ManagementBaseObject inParams = null;
            inParams = PrivateLateBoundObject.GetMethodParameters("RequestStateChange");
            inParams["RequestedState"] = ((ushort)(RequestedState));
            inParams["TimeoutPeriod"] = ToDmtfDateTime(((System.DateTime)(TimeoutPeriod)));
            System.Management.ManagementBaseObject outParams = PrivateLateBoundObject.InvokeMethod("RequestStateChange", inParams, null);
            return System.Convert.ToUInt32(outParams.Properties["ReturnValue"].Value);
        }
        else {
            return System.Convert.ToUInt32(0);
        }
    }
    
    public enum JobTypeValues {
        
        Unknown0 = 0,
        
        Define_Virtual_Machine = 1,
        
        Modify_Virtual_Machine = 2,
        
        Destroy_Virtual_Machine = 3,
        
        Modify_Management_Service_Settings = 4,
        
        Initialize_Virtual_Machine = 10,
        
        Waiting_to_Start_Virtual_Machine = 11,
        
        Start_Virtual_Machine = 12,
        
        Power_Off_Virtual_Machine = 13,
        
        Save_Virtual_Machine = 14,
        
        Restore_Virtual_Machine = 15,
        
        Pause_Virtual_Machine = 26,
        
        Resume_Virtual_Machine = 27,
        
        Reset_Virtual_Machine = 28,
        
        Add_Virtual_Machine_Resources = 30,
        
        Modify_Virtual_Machine_Resources = 31,
        
        Remove_Virtual_Machine_Resources = 32,
        
        Request_Initial_Virtual_Machine_Memory = 40,
        
        Add_Memory_to_Virtual_Machine = 41,
        
        Remove_Memory_from_Virtual_Machine = 42,
        
        Merging_VHD_Disks = 50,
        
        Create_VSS_Snapshot_inside_Virtual_Machine = 51,
        
        Get_Import_Setting_Data = 60,
        
        Import_Virtual_Machine = 61,
        
        Export_Virtual_Machine = 62,
        
        Register_Configuration = 63,
        
        Unregister_Configuration = 64,
        
        Snapshot_Virtual_Machine = 70,
        
        Apply_Virtual_Machine_Snapshot = 71,
        
        Delete_Virtual_Machine_Snapshot = 72,
        
        Clear_Virtual_Machine_Snapshot_State = 73,
        
        Add_Resources_to_Resource_Pool = 80,
        
        Remove_Resources_from_Resource_Pool = 81,
        
        Modify_Replication_Server_Settings = 90,
        
        Create_Replication_Relationship = 91,
        
        Modify_Replication_Relationship_Settings = 92,
        
        Remove_Replication_Relationship = 93,
        
        Start_Inband_Initial_Replication = 94,
        
        Import_Replication = 95,
        
        Replicate_State_Change = 96,
        
        Initiate_Failover = 97,
        
        Revert_Failover = 98,
        
        Commit_Failover = 99,
        
        Inititate_Synced_Replication = 100,
        
        Cancel_Synced_Replication = 101,
        
        Initiate_Test_Replica = 102,
        
        Remove_Test_Replica = 103,
        
        Reverse_Replication = 104,
        
        Replication_Sending_Delta = 105,
        
        Replication_Receiving_Delta = 106,
        
        Resynchronizing = 107,
        
        Apply_change_log = 108,
        
        Stop_Initial_Replication = 109,
        
        Stop_Resynchronizing = 110,
        
        Get_Replica_statistics = 111,
        
        Prepare_for_Consistency_Checker = 112,
        
        Consistency_Checker = 113,
        
        Stop_Consistency_Checker = 114,
        
        Test_Replication_Connection = 115,
        
        Sending_Initial_Replica = 116,
        
        Start_Resync_Initial_Replication = 117,
        
        Start_Export_Initial_Replication = 118,
        
        Reset_Replica_Statistics = 119,
        
        Apply_Registered_Deltas = 120,
        
        Resynchronizing_Extended_Replication = 121,
        
        Reading_Test_Replica_Configuration = 122,
        
        Change_the_replication_mode_to_primary = 123,
        
        Initiate_Failback = 124,
        
        Define_Ethernet_Switch = 130,
        
        Modify_Ethernet_Switch_Settings = 131,
        
        Destroy_Ethernet_Switch = 132,
        
        Add_Ethernet_Switch_Resources = 133,
        
        Modify_Ethernet_Switch_Resources = 134,
        
        Remove_Ethernet_Switch_Resources = 135,
        
        Validate_Planned_Virtual_Machine = 140,
        
        Realizing_Virtual_Machine = 141,
        
        Creating_a_Resource_Pool = 150,
        
        Changing_the_Parent_Resources_of_a_Resource_Pool = 151,
        
        Changing_the_Non_alloction_Settings_of_a_Resource_Pool = 152,
        
        Deleting_a_Resource_Pool = 153,
        
        Enable_RemoteFx_GPU = 160,
        
        Disable_RemoteFx_GPU = 161,
        
        Backup_Virtual_Machine = 170,
        
        NULL_ENUM_VALUE = 171,
    }
    
    // Implementering av uppräknare för klassens uppräkningsinstanser.
    public class ConcreteJobCollection : object, ICollection {
        
        private ManagementObjectCollection privColObj;
        
        public ConcreteJobCollection(ManagementObjectCollection objCollection) {
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
                array.SetValue(new ConcreteJob(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
            }
        }
        
        public virtual System.Collections.IEnumerator GetEnumerator() {
            return new ConcreteJobEnumerator(privColObj.GetEnumerator());
        }
        
        public class ConcreteJobEnumerator : object, System.Collections.IEnumerator {
            
            private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
            
            public ConcreteJobEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                privObjEnum = objEnum;
            }
            
            public virtual object Current {
                get {
                    return new ConcreteJob(((System.Management.ManagementObject)(privObjEnum.Current)));
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
