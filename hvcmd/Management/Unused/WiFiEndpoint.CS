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
    // En EarlyBound-klass genererades för WMI-klassen.CIM_WiFiEndpoint
    public class WiFiEndpoint : System.ComponentModel.Component {
        
        // En privat egenskap som ska innehålla WMI-namnområdet där klassen finns.
        private static string CreatedWmiNamespace = "root\\virtualization\\v2";
        
        // En privat egenskap som ska innehålla namnet på den WMI-klass som skapade den här klassen.
        private static string CreatedClassName = "CIM_WiFiEndpoint";
        
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
        public WiFiEndpoint() {
            this.InitializeObject(null, null, null);
        }
        
        public WiFiEndpoint(string keyCreationClassName, string keyName, string keySystemCreationClassName, string keySystemName) {
            this.InitializeObject(null, new System.Management.ManagementPath(WiFiEndpoint.ConstructPath(keyCreationClassName, keyName, keySystemCreationClassName, keySystemName)), null);
        }
        
        public WiFiEndpoint(System.Management.ManagementScope mgmtScope, string keyCreationClassName, string keyName, string keySystemCreationClassName, string keySystemName) {
            this.InitializeObject(((System.Management.ManagementScope)(mgmtScope)), new System.Management.ManagementPath(WiFiEndpoint.ConstructPath(keyCreationClassName, keyName, keySystemCreationClassName, keySystemName)), null);
        }
        
        public WiFiEndpoint(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(null, path, getOptions);
        }
        
        public WiFiEndpoint(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
            this.InitializeObject(mgmtScope, path, null);
        }
        
        public WiFiEndpoint(System.Management.ManagementPath path) {
            this.InitializeObject(null, path, null);
        }
        
        public WiFiEndpoint(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(mgmtScope, path, getOptions);
        }
        
        public WiFiEndpoint(System.Management.ManagementObject theObject) {
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
        
        public WiFiEndpoint(System.Management.ManagementBaseObject theObject) {
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
        [Description(@"AccessPointAddress shall contain the MAC address of the access point with which the WiFiEndpoint is currently associated. If the WiFiEndpoint is not currently associated, then AccessPointAddress shall be NULL.The MAC address shall be formatted as twelve hexadecimal digits (for example, ""010203040506""), with each pair representing one of the six octets of the MAC address in ""canonical"" bit order. (Therefore, the Group address bit is found in the low order bit of the first character of the string.)")]
        public string AccessPointAddress {
            get {
                return ((string)(curObj["AccessPointAddress"]));
            }
            set {
                curObj["AccessPointAddress"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] AliasAddresses {
            get {
                return ((string[])(curObj["AliasAddresses"]));
            }
            set {
                curObj["AliasAddresses"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAssociatedNull {
            get {
                if ((curObj["Associated"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Associated shall indicate whether or not the WiFiEndpoint is currently associated" +
            " to an access point or client station.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public bool Associated {
            get {
                if ((curObj["Associated"] == null)) {
                    return System.Convert.ToBoolean(0);
                }
                return ((bool)(curObj["Associated"]));
            }
            set {
                curObj["Associated"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAuthenticationMethodNull {
            get {
                if ((curObj["AuthenticationMethod"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("AuthenticationMethod shall specify the method used to authenticate the WiFiEndpoi" +
            "nt and the network to one another.\n\t* Unknown (0): shall indicate that the authe" +
            "ntication method is unknown to the server.\t* Other (1): shall indicate that the " +
            "authentication method is known to the server but not specified in the list below" +
            ". If AuthenticationMethod contains 1, OtherAuthenticationMethod shall not be NUL" +
            "L and shall not be empty.\n\t* Open System (2): shall indicate that the authentica" +
            "tion method is Open System. AuthenticationMethod shall contain 2 only if Encrypt" +
            "ionMethod contains 2 (\"WEP\").\n\t* Shared Key (3): shall indicate that the authent" +
            "ication method is Shared Key. AuthenticationMethod shall contain 3 only if Encry" +
            "ptionMethod contains 2 (\"WEP\").\n\t* WPA PSK (4): shall indicate that the authenti" +
            "cation method is WPA (Wi-Fi Protected Access) PSK (Pre-Shared Key). Authenticati" +
            "onMethod shall contain 4 only if EncryptionMethod contains 3 (\"TKIP\") or 4 (\"CCM" +
            "P\").\n\t* WPA IEEE 802.1x (5): shall indicate that the authentication method is WP" +
            "A (Wi-Fi Protected Access) IEEE 802.1x. AuthenticationMethod shall contain 5 onl" +
            "y if EncryptionMethod contains 3 (\"TKIP\") or 4 (\"CCMP\").\n\t* WPA2 PSK (6): shall " +
            "indicate that the authentication method is WPA2 (Wi-Fi Protected Access Version " +
            "2) PSK (Pre-Shared Key). AuthenticationMethod shall contain 6 only if Encryption" +
            "Method contains 3 (\"TKIP\") or 4 (\"CCMP\").\n\t* WPA2 IEEE 802.1x (7): shall indicat" +
            "e that the authentication method is WPA2 (Wi-Fi Protected Access Version 2) IEEE" +
            " 802.1x. AuthenticationMethod shall contain 6 only if EncryptionMethod contains " +
            "3 (\"TKIP\") or 4 (\"CCMP\").\n\t* CCKM IEEE 802.1x (8): CCKM (Cisco Centralized Key M" +
            "anagement with LEAP or EAP-FAST)")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort AuthenticationMethod {
            get {
                if ((curObj["AuthenticationMethod"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["AuthenticationMethod"]));
            }
            set {
                curObj["AuthenticationMethod"] = value;
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
        public bool IsBSSTypeNull {
            get {
                if ((curObj["BSSType"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"BSSType shall indicate the Basic Service Set (BSS) Type of the network that corresponds to the instance. A Basic Service Set is a set of stations controlled by a single coordination function.
	* Independent: the WiFiEndpoint is associated directly to another client station.
	* Infrastructure: the WiFiEndpoint is associated to a network via an access point.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort BSSType {
            get {
                if ((curObj["BSSType"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["BSSType"]));
            }
            set {
                curObj["BSSType"] = value;
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
        public bool IsEncryptionMethodNull {
            get {
                if ((curObj["EncryptionMethod"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"EncryptionMethod shall specify the encryption method in use to protect the confidentiality of data sent and received by the WiFiEndpoint.
	* Unknown (0): shall indicate that the encryption method is unknown to the server.
	* Other (1): shall indicate that the encryption method is known to the server but not defined in the list below. If EncryptionMethod contains 1, OtherEncryptionMethod shall not be NULL and shall not be empty.
	* WEP (2): shall indicate that the encryption method is Wired Equivalency Privacy (WEP). The value of EncryptionMethod shall be 2 only if the value of AuthenticationMethod is 2 (""Open System"") or 3 (""Shared Key"").
	* TKIP (3): shall indicate that the encryption method is Temporal Key Integrity Protocol (TKIP). The value of EncryptionMethod shall be 3 only if the value of AuthenticationMethod is 4 (""WPA PSK""), 5 (""WPA IEEE 802.1x""), 6 (""WPA2 PSK""), or 7 (""WPA2 IEEE 802.1x"").
	* CCMP (4): shall indicate that the encryption method is Counter Mode with Cipher Block Chaining Message Authentication Code Protocol (CCMP). The value of EncryptionMethod shall be 4 only if the value of AuthenticationMethod is 4 (""WPA PSK""), 5 (""WPA IEEE 802.1x""), 6 (""WPA2 PSK""), or 7 (""WPA2 IEEE 802.1x"").
	* None (5): shall indicate that no encryption method is in use. The value of EncryptionMethod shall be 5 only if the value of AuthenticationMethod is 2 (""Open System"") or 3 (""Shared Key"").")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort EncryptionMethod {
            get {
                if ((curObj["EncryptionMethod"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["EncryptionMethod"]));
            }
            set {
                curObj["EncryptionMethod"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] GroupAddresses {
            get {
                return ((string[])(curObj["GroupAddresses"]));
            }
            set {
                curObj["GroupAddresses"] = value;
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
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsIEEE8021xAuthenticationProtocolNull {
            get {
                if ((curObj["IEEE8021xAuthenticationProtocol"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("IEEE8021xAuthenticationProtocol shall contain the EAP (Extensible Authentication " +
            "Protocol) type if and only if AuthenticationMethod contains \"WPA IEEE 802.1x\" or" +
            " \"WPA2 IEEE 802.1x\" or \"CCKM IEEE 802.1x\"\n.\t* EAP-TLS (0): shall indicate the Tr" +
            "ansport Layer Security EAP type specified in RFC 2716.\n\t* EAP-TTLS/MSCHAPv2 (1):" +
            " shall indicate the Tunneled TLS Authentication Protocol EAP type (specified in " +
            "draft-ietf-pppext-eap-ttls) with Microsoft PPP CHAP Extensions, Version 2 (MSCHA" +
            "Pv2) as the inner authentication method.\n\t* PEAPv0/EAP-MSCHAPv2 (2): shall indic" +
            "ate the Protected Extensible Authentication Protocol (PEAP) Version 0 EAP type (" +
            "specified in draft-kamath-pppext-peapv0), with Microsoft PPP CHAP Extensions, Ve" +
            "rsion 2 (MSCHAPv2) as the inner authentication method.\n\t* PEAPv1/EAP-GTC (3): sh" +
            "all indicate the Protected Extensible Authentication Protocol (PEAP) Version 1 E" +
            "AP type (specified in draft-josefsson-pppext-eap-tls-eap), with Generic Token Ca" +
            "rd (GTC) as the inner authentication method.\n\t* EAP-FAST/MSCHAPv2 (4): shall ind" +
            "icate the Flexible Authentication Extensible Authentication Protocol EAP type sp" +
            "ecified in IETF RFC 4851, with Microsoft PPP CHAP Extensions, Version 2 (MSCHAPv" +
            "2) as the inner authentication method.\n\t* EAP-FAST/GTC (5): shall indicate the F" +
            "lexible Authentication Extensible Authentication Protocol EAP type specified in " +
            "IETF RFC 4851, with Generic Token Card (GTC) as the inner authentication method." +
            "\n\t* EAP-MD5 (6): shall indicate the EAP MD5 authentication method, specified in " +
            "RFC 3748.\n\t* EAP-PSK (7): shall indicate the EAP-PSK (Pre-shared Key) Protocol s" +
            "pecified in RFC 4764.\n\t* EAP-SIM (8): shall indicate the Extensible Authenticati" +
            "on Protocol Method for Global System for Mobile Communications (GSM) Subscriber " +
            "Identity Modules (EAP-SIM), specified in RFC 4186.\n\t* EAP-AKA (9): shall indicat" +
            "e the Extensible Authentication Protocol Method for 3rd Generation Authenticatio" +
            "n and Key Agreement (EAP-AKA) authentication method, specified in RFC 4187.\n\t* E" +
            "AP-FAST/TLS (10): shall indicate the Flexible Authentication Extensible Authenti" +
            "cation Protocol EAP type specified in IETF RFC 4851, with TLS as the inner authe" +
            "ntication method.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort IEEE8021xAuthenticationProtocol {
            get {
                if ((curObj["IEEE8021xAuthenticationProtocol"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["IEEE8021xAuthenticationProtocol"]));
            }
            set {
                curObj["IEEE8021xAuthenticationProtocol"] = value;
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
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("LANID shall contain the Service Set Identifier (SSID) of the wireless LAN with wh" +
            "ich the Endpoint is associated, or shall be NULL if the Endpoint is not currentl" +
            "y associated or this information is not known.")]
        public string LANID {
            get {
                return ((string)(curObj["LANID"]));
            }
            set {
                curObj["LANID"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLANTypeNull {
            get {
                if ((curObj["LANType"] == null)) {
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
        public ushort LANType {
            get {
                if ((curObj["LANType"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["LANType"]));
            }
            set {
                curObj["LANType"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MACAddress {
            get {
                return ((string)(curObj["MACAddress"]));
            }
            set {
                curObj["MACAddress"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMaxDataSizeNull {
            get {
                if ((curObj["MaxDataSize"] == null)) {
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
        public uint MaxDataSize {
            get {
                if ((curObj["MaxDataSize"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["MaxDataSize"]));
            }
            set {
                curObj["MaxDataSize"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NameFormat {
            get {
                return ((string)(curObj["NameFormat"]));
            }
            set {
                curObj["NameFormat"] = value;
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
        [Description("OtherAuthenticationMethod shall specify the 802.11 authentication method if and o" +
            "nly if AuthenticationMethod contains \"Other\". The format of this string shall be" +
            " vendor-specific.")]
        public string OtherAuthenticationMethod {
            get {
                return ((string)(curObj["OtherAuthenticationMethod"]));
            }
            set {
                curObj["OtherAuthenticationMethod"] = value;
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
        [Description("OtherEncryptionMethod shall specify the 802.11 encryption method if and only if E" +
            "ncryptionMethod contains \"Other\". The format of this string shall be vendor-spec" +
            "ific.")]
        public string OtherEncryptionMethod {
            get {
                return ((string)(curObj["OtherEncryptionMethod"]));
            }
            set {
                curObj["OtherEncryptionMethod"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OtherLANType {
            get {
                return ((string)(curObj["OtherLANType"]));
            }
            set {
                curObj["OtherLANType"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OtherTypeDescription {
            get {
                return ((string)(curObj["OtherTypeDescription"]));
            }
            set {
                curObj["OtherTypeDescription"] = value;
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
        public bool IsProtocolIFTypeNull {
            get {
                if ((curObj["ProtocolIFType"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("ProtocolIFType\'s enumeration is limited to Wi-Fi and reserved values for this sub" +
            "class of ProtocolEndpoint.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort ProtocolIFType {
            get {
                if ((curObj["ProtocolIFType"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["ProtocolIFType"]));
            }
            set {
                curObj["ProtocolIFType"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsProtocolTypeNull {
            get {
                if ((curObj["ProtocolType"] == null)) {
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
        public ushort ProtocolType {
            get {
                if ((curObj["ProtocolType"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["ProtocolType"]));
            }
            set {
                curObj["ProtocolType"] = value;
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
        
        private void ResetAccessPointAddress() {
            curObj["AccessPointAddress"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetAliasAddresses() {
            curObj["AliasAddresses"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeAssociated() {
            if ((this.IsAssociatedNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetAssociated() {
            curObj["Associated"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeAuthenticationMethod() {
            if ((this.IsAuthenticationMethodNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetAuthenticationMethod() {
            curObj["AuthenticationMethod"] = null;
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
        
        private bool ShouldSerializeBSSType() {
            if ((this.IsBSSTypeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetBSSType() {
            curObj["BSSType"] = null;
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
        
        private bool ShouldSerializeEncryptionMethod() {
            if ((this.IsEncryptionMethodNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetEncryptionMethod() {
            curObj["EncryptionMethod"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetGroupAddresses() {
            curObj["GroupAddresses"] = null;
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
        
        private bool ShouldSerializeIEEE8021xAuthenticationProtocol() {
            if ((this.IsIEEE8021xAuthenticationProtocolNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetIEEE8021xAuthenticationProtocol() {
            curObj["IEEE8021xAuthenticationProtocol"] = null;
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
        
        private void ResetLANID() {
            curObj["LANID"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeLANType() {
            if ((this.IsLANTypeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetLANType() {
            curObj["LANType"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetMACAddress() {
            curObj["MACAddress"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeMaxDataSize() {
            if ((this.IsMaxDataSizeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetMaxDataSize() {
            curObj["MaxDataSize"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetNameFormat() {
            curObj["NameFormat"] = null;
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
        
        private void ResetOtherAuthenticationMethod() {
            curObj["OtherAuthenticationMethod"] = null;
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
        
        private void ResetOtherEncryptionMethod() {
            curObj["OtherEncryptionMethod"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherLANType() {
            curObj["OtherLANType"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherTypeDescription() {
            curObj["OtherTypeDescription"] = null;
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
        
        private bool ShouldSerializeProtocolIFType() {
            if ((this.IsProtocolIFTypeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetProtocolIFType() {
            curObj["ProtocolIFType"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeProtocolType() {
            if ((this.IsProtocolTypeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetProtocolType() {
            curObj["ProtocolType"] = null;
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
        
        private static string ConstructPath(string keyCreationClassName, string keyName, string keySystemCreationClassName, string keySystemName) {
            string strPath = "root\\virtualization\\v2:CIM_WiFiEndpoint";
            strPath = string.Concat(strPath, string.Concat(".CreationClassName=", string.Concat("\"", string.Concat(keyCreationClassName, "\""))));
            strPath = string.Concat(strPath, string.Concat(",Name=", string.Concat("\"", string.Concat(keyName, "\""))));
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
        public static WiFiEndpointCollection GetInstances() {
            return GetInstances(null, null, null);
        }
        
        public static WiFiEndpointCollection GetInstances(string condition) {
            return GetInstances(null, condition, null);
        }
        
        public static WiFiEndpointCollection GetInstances(string[] selectedProperties) {
            return GetInstances(null, null, selectedProperties);
        }
        
        public static WiFiEndpointCollection GetInstances(string condition, string[] selectedProperties) {
            return GetInstances(null, condition, selectedProperties);
        }
        
        public static WiFiEndpointCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
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
            pathObj.ClassName = "CIM_WiFiEndpoint";
            pathObj.NamespacePath = "root\\virtualization\\v2";
            System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
            if ((enumOptions == null)) {
                enumOptions = new System.Management.EnumerationOptions();
                enumOptions.EnsureLocatable = true;
            }
            return new WiFiEndpointCollection(clsObject.GetInstances(enumOptions));
        }
        
        public static WiFiEndpointCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
            return GetInstances(mgmtScope, condition, null);
        }
        
        public static WiFiEndpointCollection GetInstances(System.Management.ManagementScope mgmtScope, string[] selectedProperties) {
            return GetInstances(mgmtScope, null, selectedProperties);
        }
        
        public static WiFiEndpointCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, string[] selectedProperties) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\virtualization\\v2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("CIM_WiFiEndpoint", condition, selectedProperties));
            System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
            ObjectSearcher.Options = enumOptions;
            return new WiFiEndpointCollection(ObjectSearcher.Get());
        }
        
        [Browsable(true)]
        public static WiFiEndpoint CreateInstance() {
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
            return new WiFiEndpoint(tmpMgmtClass.CreateInstance());
        }
        
        [Browsable(true)]
        public void Delete() {
            PrivateLateBoundObject.Delete();
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
        
        // Implementering av uppräknare för klassens uppräkningsinstanser.
        public class WiFiEndpointCollection : object, ICollection {
            
            private ManagementObjectCollection privColObj;
            
            public WiFiEndpointCollection(ManagementObjectCollection objCollection) {
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
                    array.SetValue(new WiFiEndpoint(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
                }
            }
            
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return new WiFiEndpointEnumerator(privColObj.GetEnumerator());
            }
            
            public class WiFiEndpointEnumerator : object, System.Collections.IEnumerator {
                
                private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
                
                public WiFiEndpointEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                    privObjEnum = objEnum;
                }
                
                public virtual object Current {
                    get {
                        return new WiFiEndpoint(((System.Management.ManagementObject)(privObjEnum.Current)));
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
