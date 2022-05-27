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
// En EarlyBound-klass genererades för WMI-klassen.Msvm_EthernetSwitchPortSecuritySettingData
[System.CodeDom.Compiler.GeneratedCode("mgmtclassgen", "")]
public class EthernetSwitchPortSecuritySettingData : System.ComponentModel.Component {
    
    // En privat egenskap som ska innehålla WMI-namnområdet där klassen finns.
    public const string CreatedWmiNamespace = "root\\virtualization\\v2";
    
    // En privat egenskap som ska innehålla namnet på den WMI-klass som skapade den här klassen.
    public const string CreatedClassName = "Msvm_EthernetSwitchPortSecuritySettingData";
    
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
    public EthernetSwitchPortSecuritySettingData() {
        this.InitializeObject(null, null, null);
    }
    
    public EthernetSwitchPortSecuritySettingData(string keyInstanceID) {
        this.InitializeObject(null, new System.Management.ManagementPath(EthernetSwitchPortSecuritySettingData.ConstructPath(keyInstanceID)), null);
    }
    
    public EthernetSwitchPortSecuritySettingData(System.Management.ManagementScope mgmtScope, string keyInstanceID) {
        this.InitializeObject(((System.Management.ManagementScope)(mgmtScope)), new System.Management.ManagementPath(EthernetSwitchPortSecuritySettingData.ConstructPath(keyInstanceID)), null);
    }
    
    public EthernetSwitchPortSecuritySettingData(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
        this.InitializeObject(null, path, getOptions);
    }
    
    public EthernetSwitchPortSecuritySettingData(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
        this.InitializeObject(mgmtScope, path, null);
    }
    
    public EthernetSwitchPortSecuritySettingData(System.Management.ManagementPath path) {
        this.InitializeObject(null, path, null);
    }
    
    public EthernetSwitchPortSecuritySettingData(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
        this.InitializeObject(mgmtScope, path, getOptions);
    }
    
    public EthernetSwitchPortSecuritySettingData(System.Management.ManagementObject theObject) {
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
    
    public EthernetSwitchPortSecuritySettingData(System.Management.ManagementBaseObject theObject) {
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
    public bool IsAllowIeeePriorityTagNull {
        get {
            if ((curObj["AllowIeeePriorityTag"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Set to TRUE if traffic to/from port retains 802.1P info.")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public bool AllowIeeePriorityTag {
        get {
            if ((curObj["AllowIeeePriorityTag"] == null)) {
                return System.Convert.ToBoolean(0);
            }
            return ((bool)(curObj["AllowIeeePriorityTag"]));
        }
        set {
            curObj["AllowIeeePriorityTag"] = value;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsAllowMacSpoofingNull {
        get {
            if ((curObj["AllowMacSpoofing"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description(@"Indicates whether the port will allow MAC spoofing.
TRUE: The port will allow MAC addresses to be spoofed. All valid unicast MAC address values are allowed.
FALSE: The port will allow only MAC addresses configured within Hyper-V management to be used. Default value is FALSE")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public bool AllowMacSpoofing {
        get {
            if ((curObj["AllowMacSpoofing"] == null)) {
                return System.Convert.ToBoolean(0);
            }
            return ((bool)(curObj["AllowMacSpoofing"]));
        }
        set {
            curObj["AllowMacSpoofing"] = value;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsAllowTeamingNull {
        get {
            if ((curObj["AllowTeaming"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Indicates whether the NICs connected to the port can be part of a team. This appl" +
        "ies only to NICs connected to virtual machines")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public bool AllowTeaming {
        get {
            if ((curObj["AllowTeaming"] == null)) {
                return System.Convert.ToBoolean(0);
            }
            return ((bool)(curObj["AllowTeaming"]));
        }
        set {
            curObj["AllowTeaming"] = value;
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
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Description {
        get {
            return ((string)(curObj["Description"]));
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsDynamicIPAddressLimitNull {
        get {
            if ((curObj["DynamicIPAddressLimit"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Defines the limit for number of Dynamic IP addresses learned. Default is none.")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public uint DynamicIPAddressLimit {
        get {
            if ((curObj["DynamicIPAddressLimit"] == null)) {
                return System.Convert.ToUInt32(0);
            }
            return ((uint)(curObj["DynamicIPAddressLimit"]));
        }
        set {
            curObj["DynamicIPAddressLimit"] = value;
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
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsEnableDhcpGuardNull {
        get {
            if ((curObj["EnableDhcpGuard"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Set to TRUE if Dhcp Offers are blocked from the port else FALSE. Default value is" +
        " FALSE")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public bool EnableDhcpGuard {
        get {
            if ((curObj["EnableDhcpGuard"] == null)) {
                return System.Convert.ToBoolean(0);
            }
            return ((bool)(curObj["EnableDhcpGuard"]));
        }
        set {
            curObj["EnableDhcpGuard"] = value;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsEnableFixSpeed10GNull {
        get {
            if ((curObj["EnableFixSpeed10G"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Set to TRUE if Fixed Speed 10G is enabled else FALSE. Default value is FALSE")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public bool EnableFixSpeed10G {
        get {
            if ((curObj["EnableFixSpeed10G"] == null)) {
                return System.Convert.ToBoolean(0);
            }
            return ((bool)(curObj["EnableFixSpeed10G"]));
        }
        set {
            curObj["EnableFixSpeed10G"] = value;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsEnableRouterGuardNull {
        get {
            if ((curObj["EnableRouterGuard"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Set to TRUE if Router Advertisements and Router Redirects are blocked from the po" +
        "rt else FALSE. Default value is FALSE")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public bool EnableRouterGuard {
        get {
            if ((curObj["EnableRouterGuard"] == null)) {
                return System.Convert.ToBoolean(0);
            }
            return ((bool)(curObj["EnableRouterGuard"]));
        }
        set {
            curObj["EnableRouterGuard"] = value;
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
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsMonitorModeNull {
        get {
            if ((curObj["MonitorMode"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("This indicates the monitor mode of the port.")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public MonitorModeValues MonitorMode {
        get {
            if ((curObj["MonitorMode"] == null)) {
                return ((MonitorModeValues)(System.Convert.ToInt32(3)));
            }
            return ((MonitorModeValues)(System.Convert.ToInt32(curObj["MonitorMode"])));
        }
        set {
            if ((MonitorModeValues.NULL_ENUM_VALUE == value)) {
                curObj["MonitorMode"] = null;
            }
            else {
                curObj["MonitorMode"] = value;
            }
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsMonitorSessionNull {
        get {
            if ((curObj["MonitorSession"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("This gives the monitor session ID this port belongs to.")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public byte MonitorSession {
        get {
            if ((curObj["MonitorSession"] == null)) {
                return System.Convert.ToByte(0);
            }
            return ((byte)(curObj["MonitorSession"]));
        }
        set {
            curObj["MonitorSession"] = value;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsReservedNull {
        get {
            if ((curObj["Reserved"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Reserved")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public bool Reserved {
        get {
            if ((curObj["Reserved"] == null)) {
                return System.Convert.ToBoolean(0);
            }
            return ((bool)(curObj["Reserved"]));
        }
        set {
            curObj["Reserved"] = value;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsStormLimitNull {
        get {
            if ((curObj["StormLimit"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Defines the packets per second limit for broadcast and multicast traffic. Default" +
        " is none.")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public uint StormLimit {
        get {
            if ((curObj["StormLimit"] == null)) {
                return System.Convert.ToUInt32(0);
            }
            return ((uint)(curObj["StormLimit"]));
        }
        set {
            curObj["StormLimit"] = value;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Reserved.")]
    public string TeamName {
        get {
            return ((string)(curObj["TeamName"]));
        }
        set {
            curObj["TeamName"] = value;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsTeamNumberNull {
        get {
            if ((curObj["TeamNumber"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Reserved.")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public uint TeamNumber {
        get {
            if ((curObj["TeamNumber"] == null)) {
                return System.Convert.ToUInt32(0);
            }
            return ((uint)(curObj["TeamNumber"]));
        }
        set {
            curObj["TeamNumber"] = value;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
    }
    
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsVirtualSubnetIdNull {
        get {
            if ((curObj["VirtualSubnetId"] == null)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
    
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Description("Defines the Virtual Subnet membership of the Port. Default is none.")]
    [TypeConverter(typeof(WMIValueTypeConverter))]
    public uint VirtualSubnetId {
        get {
            if ((curObj["VirtualSubnetId"] == null)) {
                return System.Convert.ToUInt32(0);
            }
            return ((uint)(curObj["VirtualSubnetId"]));
        }
        set {
            curObj["VirtualSubnetId"] = value;
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
    
    private bool ShouldSerializeAllowIeeePriorityTag() {
        if ((this.IsAllowIeeePriorityTagNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetAllowIeeePriorityTag() {
        curObj["AllowIeeePriorityTag"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private bool ShouldSerializeAllowMacSpoofing() {
        if ((this.IsAllowMacSpoofingNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetAllowMacSpoofing() {
        curObj["AllowMacSpoofing"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private bool ShouldSerializeAllowTeaming() {
        if ((this.IsAllowTeamingNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetAllowTeaming() {
        curObj["AllowTeaming"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private bool ShouldSerializeDynamicIPAddressLimit() {
        if ((this.IsDynamicIPAddressLimitNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetDynamicIPAddressLimit() {
        curObj["DynamicIPAddressLimit"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private bool ShouldSerializeEnableDhcpGuard() {
        if ((this.IsEnableDhcpGuardNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetEnableDhcpGuard() {
        curObj["EnableDhcpGuard"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private bool ShouldSerializeEnableFixSpeed10G() {
        if ((this.IsEnableFixSpeed10GNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetEnableFixSpeed10G() {
        curObj["EnableFixSpeed10G"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private bool ShouldSerializeEnableRouterGuard() {
        if ((this.IsEnableRouterGuardNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetEnableRouterGuard() {
        curObj["EnableRouterGuard"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private bool ShouldSerializeMonitorMode() {
        if ((this.IsMonitorModeNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetMonitorMode() {
        curObj["MonitorMode"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private bool ShouldSerializeMonitorSession() {
        if ((this.IsMonitorSessionNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetMonitorSession() {
        curObj["MonitorSession"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private bool ShouldSerializeReserved() {
        if ((this.IsReservedNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetReserved() {
        curObj["Reserved"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private bool ShouldSerializeStormLimit() {
        if ((this.IsStormLimitNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetStormLimit() {
        curObj["StormLimit"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private void ResetTeamName() {
        curObj["TeamName"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private bool ShouldSerializeTeamNumber() {
        if ((this.IsTeamNumberNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetTeamNumber() {
        curObj["TeamNumber"] = null;
        if (((isEmbedded == false) 
                    && (AutoCommitProp == true))) {
            PrivateLateBoundObject.Put();
        }
    }
    
    private bool ShouldSerializeVirtualSubnetId() {
        if ((this.IsVirtualSubnetIdNull == false)) {
            return true;
        }
        return false;
    }
    
    private void ResetVirtualSubnetId() {
        curObj["VirtualSubnetId"] = null;
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
        string strPath = "root\\virtualization\\v2:Msvm_EthernetSwitchPortSecuritySettingData";
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
    public static EthernetSwitchPortSecuritySettingDataCollection GetInstances() {
        return GetInstances(null, null, null);
    }
    
    public static EthernetSwitchPortSecuritySettingDataCollection GetInstances(string condition) {
        return GetInstances(null, condition, null);
    }
    
    public static EthernetSwitchPortSecuritySettingDataCollection GetInstances(string[] selectedProperties) {
        return GetInstances(null, null, selectedProperties);
    }
    
    public static EthernetSwitchPortSecuritySettingDataCollection GetInstances(string condition, string[] selectedProperties) {
        return GetInstances(null, condition, selectedProperties);
    }
    
    public static EthernetSwitchPortSecuritySettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
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
        pathObj.ClassName = "Msvm_EthernetSwitchPortSecuritySettingData";
        pathObj.NamespacePath = "root\\virtualization\\v2";
        System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
        if ((enumOptions == null)) {
            enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
        }
        return new EthernetSwitchPortSecuritySettingDataCollection(clsObject.GetInstances(enumOptions));
    }
    
    public static EthernetSwitchPortSecuritySettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
        return GetInstances(mgmtScope, condition, null);
    }
    
    public static EthernetSwitchPortSecuritySettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string[] selectedProperties) {
        return GetInstances(mgmtScope, null, selectedProperties);
    }
    
    public static EthernetSwitchPortSecuritySettingDataCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, string[] selectedProperties) {
        if ((mgmtScope == null)) {
            if ((statMgmtScope == null)) {
                mgmtScope = new System.Management.ManagementScope();
                mgmtScope.Path.NamespacePath = "root\\virtualization\\v2";
            }
            else {
                mgmtScope = statMgmtScope;
            }
        }
        System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("Msvm_EthernetSwitchPortSecuritySettingData", condition, selectedProperties));
        System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
        enumOptions.EnsureLocatable = true;
        ObjectSearcher.Options = enumOptions;
        return new EthernetSwitchPortSecuritySettingDataCollection(ObjectSearcher.Get());
    }
    
    [Browsable(true)]
    public static EthernetSwitchPortSecuritySettingData CreateInstance() {
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
        return new EthernetSwitchPortSecuritySettingData(tmpMgmtClass.CreateInstance());
    }
    
    [Browsable(true)]
    public void Delete() {
        PrivateLateBoundObject.Delete();
    }
    
    public enum MonitorModeValues {
        
        None = 0,
        
        Destination = 1,
        
        Source = 2,
        
        NULL_ENUM_VALUE = 3,
    }
    
    // Implementering av uppräknare för klassens uppräkningsinstanser.
    public class EthernetSwitchPortSecuritySettingDataCollection : object, ICollection {
        
        private ManagementObjectCollection privColObj;
        
        public EthernetSwitchPortSecuritySettingDataCollection(ManagementObjectCollection objCollection) {
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
                array.SetValue(new EthernetSwitchPortSecuritySettingData(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
            }
        }
        
        public virtual System.Collections.IEnumerator GetEnumerator() {
            return new EthernetSwitchPortSecuritySettingDataEnumerator(privColObj.GetEnumerator());
        }
        
        public class EthernetSwitchPortSecuritySettingDataEnumerator : object, System.Collections.IEnumerator {
            
            private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
            
            public EthernetSwitchPortSecuritySettingDataEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                privObjEnum = objEnum;
            }
            
            public virtual object Current {
                get {
                    return new EthernetSwitchPortSecuritySettingData(((System.Management.ManagementObject)(privObjEnum.Current)));
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
