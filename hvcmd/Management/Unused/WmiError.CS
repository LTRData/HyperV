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
    // En EarlyBound-klass genererades för WMI-klassen.MSFT_WmiError
    public class WmiError : System.ComponentModel.Component {
        
        // En privat egenskap som ska innehålla WMI-namnområdet där klassen finns.
        private static string CreatedWmiNamespace = "root\\virtualization\\v2";
        
        // En privat egenskap som ska innehålla namnet på den WMI-klass som skapade den här klassen.
        private static string CreatedClassName = "MSFT_WmiError";
        
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
        public WmiError() {
            this.InitializeObject(null, null, null);
        }
        
        public WmiError(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(null, path, getOptions);
        }
        
        public WmiError(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
            this.InitializeObject(mgmtScope, path, null);
        }
        
        public WmiError(System.Management.ManagementPath path) {
            this.InitializeObject(null, path, null);
        }
        
        public WmiError(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(mgmtScope, path, getOptions);
        }
        
        public WmiError(System.Management.ManagementObject theObject) {
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
        
        public WmiError(System.Management.ManagementBaseObject theObject) {
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
        public bool IsCIMStatusCodeNull {
            get {
                if ((curObj["CIMStatusCode"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The CIM status code that characterizes this instance. \nThis property defines the " +
            "status codes that MAY be return by a conforming CIM Server or Listener. Note tha" +
            "t not all status codes are valid for each operation. The specification for each " +
            "operation SHOULD define the status codes that may be returned by that operation." +
            " \nThe following values for CIM status code are defined: \n1 - CIM_ERR_FAILED. A g" +
            "eneral error occurred that is not covered by a more specific error code. \n2 - CI" +
            "M_ERR_ACCESS_DENIED. Access to a CIM resource was not available to the client. \n" +
            "3 - CIM_ERR_INVALID_NAMESPACE. The target namespace does not exist. \n4 - CIM_ERR" +
            "_INVALID_PARAMETER. One or more parameter values passed to the method were inval" +
            "id. \n5 - CIM_ERR_INVALID_CLASS. The specified Class does not exist. \n6 - CIM_ERR" +
            "_NOT_FOUND. The requested object could not be found. \n7 - CIM_ERR_NOT_SUPPORTED." +
            " The requested operation is not supported. \n8 - CIM_ERR_CLASS_HAS_CHILDREN. Oper" +
            "ation cannot be carried out on this class since it has instances. \n9 - CIM_ERR_C" +
            "LASS_HAS_INSTANCES. Operation cannot be carried out on this class since it has i" +
            "nstances. \n10 - CIM_ERR_INVALID_SUPERCLASS. Operation cannot be carried out sinc" +
            "e the specified superclass does not exist. \n11 - CIM_ERR_ALREADY_EXISTS. Operati" +
            "on cannot be carried out because an object already exists. \n12 - CIM_ERR_NO_SUCH" +
            "_PROPERTY. The specified Property does not exist. \n13 - CIM_ERR_TYPE_MISMATCH. T" +
            "he value supplied is incompatible with the type. \n14 - CIM_ERR_QUERY_LANGUAGE_NO" +
            "T_SUPPORTED. The query language is not recognized or supported. \n15 - CIM_ERR_IN" +
            "VALID_QUERY. The query is not valid for the specified query language. \n16 - CIM_" +
            "ERR_METHOD_NOT_AVAILABLE. The extrinsic Method could not be executed. \n17 - CIM_" +
            "ERR_METHOD_NOT_FOUND. The specified extrinsic Method does not exist. \n18 - CIM_E" +
            "RR_UNEXPECTED_RESPONSE. The returned response to the asynchronous operation was " +
            "not expected. \n19 - CIM_ERR_INVALID_RESPONSE_DESTINATION. The specified destinat" +
            "ion for the asynchronous response is not valid. \n20 - CIM_ERR_NAMESPACE_NOT_EMPT" +
            "Y. The specified Namespace is not empty.\n21 - CIM_ERR_INVALID_ENUMERATION_CONTEX" +
            "T. The enumeration context supplied is not valid.\n22 - CIM_ERR_INVALID_OPERATION" +
            "_TIMEOUT. The specified Namespace is not empty.\n23 - CIM_ERR_PULL_HAS_BEEN_ABAND" +
            "ONED. The specified Namespace is not empty.\n24 - CIM_ERR_PULL_CANNOT_BE_ABANDONE" +
            "D. The attempt to abandon a pull operation has failed.\n25 - CIM_ERR_FILTERED_ENU" +
            "MERATION_NOT_SUPPORTED. Filtered Enumeratrions are not supported.\n26 - CIM_ERR_C" +
            "ONTINUATION_ON_ERROR_NOT_SUPPORTED. Continue on error is not supported.\n27 - CIM" +
            "_ERR_SERVER_LIMITS_EXCEEDED. The WBEM Server limits have been exceeded (e.g. mem" +
            "ory, connections, ...).\n28 - CIM_ERR_SERVER_IS_SHUTTING_DOWN. The WBEM Server is" +
            " shutting down.\n29 - CIM_ERR_QUERY_FEATURE_NOT_SUPPORTED. The specified Query Fe" +
            "ature is not supported.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint CIMStatusCode {
            get {
                if ((curObj["CIMStatusCode"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["CIMStatusCode"]));
            }
            set {
                curObj["CIMStatusCode"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A free-form string containing a human-readable description of CIMStatusCode. This" +
            " description MAY extend, but MUST be consistent with, the definition of CIMStatu" +
            "sCode.")]
        public string CIMStatusCodeDescription {
            get {
                return ((string)(curObj["CIMStatusCodeDescription"]));
            }
            set {
                curObj["CIMStatusCodeDescription"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The identifying information of the entity (i.e., the instance) generating the error. If this entity is modeled in the CIM Schema, this property contains the path of the instance encoded as a string parameter. If not modeled, the property contains some identifying string that names the entity that generated the error. The path or identifying string is formatted per the ErrorSourceFormat property.")]
        public string ErrorSource {
            get {
                return ((string)(curObj["ErrorSource"]));
            }
            set {
                curObj["ErrorSource"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsErrorSourceFormatNull {
            get {
                if ((curObj["ErrorSourceFormat"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("An array containing the dynamic content of the message.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort ErrorSourceFormat {
            get {
                if ((curObj["ErrorSourceFormat"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["ErrorSourceFormat"]));
            }
            set {
                curObj["ErrorSourceFormat"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsErrorTypeNull {
            get {
                if ((curObj["ErrorType"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Primary classification of the error. The following values are defined: 
2 - Communications Error. Errors of this type are principally associated with the procedures and/or processes required to convey information from one point to another. 
3 - Quality of Service Error. Errors of this type are principally associated with failures that result in reduced functionality or performance. 
4 - Software Error. Error of this type are principally associated with a software or processing fault. 
5 - Hardware Error. Errors of this type are principally associated with an equipment or hardware failure. 
6 - Environmental Error. Errors of this type are principally associated with a failure condition relating the to facility, or other environmental considerations. 
7 - Security Error. Errors of this type are associated with security violations, detection of viruses, and similar issues. 
8 - Oversubscription Error. Errors of this type are principally associated with the failure to allocate sufficient resources to complete the operation. 
9 - Unavailable Resource Error. Errors of this type are principally associated with the failure to access a required resource. 
10 -Unsupported Operation Error. Errors of this type are principally associated with requests that are not supported.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort ErrorType {
            get {
                if ((curObj["ErrorType"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["ErrorType"]));
            }
            set {
                curObj["ErrorType"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Iserror_CategoryNull {
            get {
                if ((curObj["error_Category"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Error Category.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort error_Category {
            get {
                if ((curObj["error_Category"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["error_Category"]));
            }
            set {
                curObj["error_Category"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Iserror_CodeNull {
            get {
                if ((curObj["error_Code"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Error code.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public uint error_Code {
            get {
                if ((curObj["error_Code"] == null)) {
                    return System.Convert.ToUInt32(0);
                }
                return ((uint)(curObj["error_Code"]));
            }
            set {
                curObj["error_Code"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Error Type.")]
        public string error_Type {
            get {
                return ((string)(curObj["error_Type"]));
            }
            set {
                curObj["error_Type"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Windows error message.")]
        public string error_WindowsErrorMessage {
            get {
                return ((string)(curObj["error_WindowsErrorMessage"]));
            }
            set {
                curObj["error_WindowsErrorMessage"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The formatted message. This message is constructed by combining some or all of the dynamic elements specified in the MessageArguments property with the static elements uniquely identified by the MessageID in a message registry or other catalog associated with the OwningEntity.")]
        public string Message {
            get {
                return ((string)(curObj["Message"]));
            }
            set {
                curObj["Message"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("An array containing the dynamic content of the message.")]
        public string[] MessageArguments {
            get {
                return ((string[])(curObj["MessageArguments"]));
            }
            set {
                curObj["MessageArguments"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("An opaque string that uniquely identifies, within the scope of the OwningEntity, " +
            "the format of the Message.")]
        public string MessageID {
            get {
                return ((string)(curObj["MessageID"]));
            }
            set {
                curObj["MessageID"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A string defining \"Other\" values for ErrorSourceFormat. This value MUST be set to" +
            " a non NULL value when ErrorSourceFormat is set to a value of 1 (\"Other\"). For a" +
            "ll other values of ErrorSourceFormat, the value of this string must be set to NU" +
            "LL.")]
        public string OtherErrorSourceFormat {
            get {
                return ((string)(curObj["OtherErrorSourceFormat"]));
            }
            set {
                curObj["OtherErrorSourceFormat"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A free-form string describing the ErrorType when 1, \"Other\", is specified as the " +
            "ErrorType.")]
        public string OtherErrorType {
            get {
                return ((string)(curObj["OtherErrorType"]));
            }
            set {
                curObj["OtherErrorType"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"A string that uniquely identifies the entity that owns the definition of the format of the Message described in this instance. OwningEntity MUST include a copyrighted, trademarked or otherwise unique name that is owned by the business entity or standards body defining the format.")]
        public string OwningEntity {
            get {
                return ((string)(curObj["OwningEntity"]));
            }
            set {
                curObj["OwningEntity"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPerceivedSeverityNull {
            get {
                if ((curObj["PerceivedSeverity"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"An enumerated value that describes the severity of the Indication from the notifier's point of view: 
0 - the Perceived Severity of the indication is unknown or indeterminate. 
1 - Other, by CIM convention, is used to indicate that the Severity's value can be found in the OtherSeverity property. 
2 - Information should be used when providing an informative response. 
3 - Degraded/Warning should be used when its appropriate to let the user decide if action is needed. 
4 - Minor should be used to indicate action is needed, but the situation is not serious at this time. 
5 - Major should be used to indicate action is needed NOW. 
6 - Critical should be used to indicate action is needed NOW and the scope is broad (perhaps an imminent outage to a critical resource will result). 
7 - Fatal/NonRecoverable should be used to indicate an error occurred, but it's too late to take remedial action. 
2 and 0 - Information and Unknown (respectively) follow common usage. Literally, the Error is purely informational or its severity is simply unknown.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort PerceivedSeverity {
            get {
                if ((curObj["PerceivedSeverity"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["PerceivedSeverity"]));
            }
            set {
                curObj["PerceivedSeverity"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsProbableCauseNull {
            get {
                if ((curObj["ProbableCause"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("An enumerated value that describes the probable cause of the error.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ushort ProbableCause {
            get {
                if ((curObj["ProbableCause"] == null)) {
                    return System.Convert.ToUInt16(0);
                }
                return ((ushort)(curObj["ProbableCause"]));
            }
            set {
                curObj["ProbableCause"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A free-form string describing the probable cause of the error.")]
        public string ProbableCauseDescription {
            get {
                return ((string)(curObj["ProbableCauseDescription"]));
            }
            set {
                curObj["ProbableCauseDescription"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A free-form string describing recommended actions to take to resolve the error.")]
        public string[] RecommendedActions {
            get {
                return ((string[])(curObj["RecommendedActions"]));
            }
            set {
                curObj["RecommendedActions"] = value;
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
        
        private bool ShouldSerializeCIMStatusCode() {
            if ((this.IsCIMStatusCodeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetCIMStatusCode() {
            curObj["CIMStatusCode"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetCIMStatusCodeDescription() {
            curObj["CIMStatusCodeDescription"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetErrorSource() {
            curObj["ErrorSource"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeErrorSourceFormat() {
            if ((this.IsErrorSourceFormatNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetErrorSourceFormat() {
            curObj["ErrorSourceFormat"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeErrorType() {
            if ((this.IsErrorTypeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetErrorType() {
            curObj["ErrorType"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeerror_Category() {
            if ((this.Iserror_CategoryNull == false)) {
                return true;
            }
            return false;
        }
        
        private void Reseterror_Category() {
            curObj["error_Category"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeerror_Code() {
            if ((this.Iserror_CodeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void Reseterror_Code() {
            curObj["error_Code"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void Reseterror_Type() {
            curObj["error_Type"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void Reseterror_WindowsErrorMessage() {
            curObj["error_WindowsErrorMessage"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetMessage() {
            curObj["Message"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetMessageArguments() {
            curObj["MessageArguments"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetMessageID() {
            curObj["MessageID"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherErrorSourceFormat() {
            curObj["OtherErrorSourceFormat"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherErrorType() {
            curObj["OtherErrorType"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOwningEntity() {
            curObj["OwningEntity"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializePerceivedSeverity() {
            if ((this.IsPerceivedSeverityNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetPerceivedSeverity() {
            curObj["PerceivedSeverity"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeProbableCause() {
            if ((this.IsProbableCauseNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetProbableCause() {
            curObj["ProbableCause"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetProbableCauseDescription() {
            curObj["ProbableCauseDescription"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetRecommendedActions() {
            curObj["RecommendedActions"] = null;
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
        
        private static string ConstructPath() {
            string strPath = "root\\virtualization\\v2:MSFT_WmiError";
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
        public static WmiErrorCollection GetInstances() {
            return GetInstances(null, null, null);
        }
        
        public static WmiErrorCollection GetInstances(string condition) {
            return GetInstances(null, condition, null);
        }
        
        public static WmiErrorCollection GetInstances(string[] selectedProperties) {
            return GetInstances(null, null, selectedProperties);
        }
        
        public static WmiErrorCollection GetInstances(string condition, string[] selectedProperties) {
            return GetInstances(null, condition, selectedProperties);
        }
        
        public static WmiErrorCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
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
            pathObj.ClassName = "MSFT_WmiError";
            pathObj.NamespacePath = "root\\virtualization\\v2";
            System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
            if ((enumOptions == null)) {
                enumOptions = new System.Management.EnumerationOptions();
                enumOptions.EnsureLocatable = true;
            }
            return new WmiErrorCollection(clsObject.GetInstances(enumOptions));
        }
        
        public static WmiErrorCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
            return GetInstances(mgmtScope, condition, null);
        }
        
        public static WmiErrorCollection GetInstances(System.Management.ManagementScope mgmtScope, string[] selectedProperties) {
            return GetInstances(mgmtScope, null, selectedProperties);
        }
        
        public static WmiErrorCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, string[] selectedProperties) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\virtualization\\v2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("MSFT_WmiError", condition, selectedProperties));
            System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
            ObjectSearcher.Options = enumOptions;
            return new WmiErrorCollection(ObjectSearcher.Get());
        }
        
        [Browsable(true)]
        public static WmiError CreateInstance() {
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
            return new WmiError(tmpMgmtClass.CreateInstance());
        }
        
        [Browsable(true)]
        public void Delete() {
            PrivateLateBoundObject.Delete();
        }
        
        // Implementering av uppräknare för klassens uppräkningsinstanser.
        public class WmiErrorCollection : object, ICollection {
            
            private ManagementObjectCollection privColObj;
            
            public WmiErrorCollection(ManagementObjectCollection objCollection) {
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
                    array.SetValue(new WmiError(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
                }
            }
            
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return new WmiErrorEnumerator(privColObj.GetEnumerator());
            }
            
            public class WmiErrorEnumerator : object, System.Collections.IEnumerator {
                
                private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
                
                public WmiErrorEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                    privObjEnum = objEnum;
                }
                
                public virtual object Current {
                    get {
                        return new WmiError(((System.Management.ManagementObject)(privObjEnum.Current)));
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
