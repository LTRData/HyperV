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
    // En EarlyBound-klass genererades för WMI-klassen.CIM_AlertIndication
    public class AlertIndication : System.ComponentModel.Component {
        
        // En privat egenskap som ska innehålla WMI-namnområdet där klassen finns.
        private static string CreatedWmiNamespace = "root\\virtualization\\v2";
        
        // En privat egenskap som ska innehålla namnet på den WMI-klass som skapade den här klassen.
        private static string CreatedClassName = "CIM_AlertIndication";
        
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
        public AlertIndication() {
            this.InitializeObject(null, null, null);
        }
        
        public AlertIndication(System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(null, path, getOptions);
        }
        
        public AlertIndication(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path) {
            this.InitializeObject(mgmtScope, path, null);
        }
        
        public AlertIndication(System.Management.ManagementPath path) {
            this.InitializeObject(null, path, null);
        }
        
        public AlertIndication(System.Management.ManagementScope mgmtScope, System.Management.ManagementPath path, System.Management.ObjectGetOptions getOptions) {
            this.InitializeObject(mgmtScope, path, getOptions);
        }
        
        public AlertIndication(System.Management.ManagementObject theObject) {
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
        
        public AlertIndication(System.Management.ManagementBaseObject theObject) {
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
        public bool IsAlertingElementFormatNull {
            get {
                if ((curObj["AlertingElementFormat"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The format of the AlertingManagedElement property is interpretable based upon the value of this property. Values are defined as: 
0 - Unknown. The format is unknown or not meaningfully interpretable by a CIM client application. 
1 - Other. The format is defined by the value of the OtherAlertingElementFormat property. 
2 - CIMObjectPath. The format is a CIMObjectPath, with format <NamespacePath>:<ClassName>.<Prop1>=""<Value1>"", <Prop2>=""<Value2>"", . . . specifying an instance in the CIM Schema.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public AlertingElementFormatValues AlertingElementFormat {
            get {
                if ((curObj["AlertingElementFormat"] == null)) {
                    return ((AlertingElementFormatValues)(System.Convert.ToInt32(3)));
                }
                return ((AlertingElementFormatValues)(System.Convert.ToInt32(curObj["AlertingElementFormat"])));
            }
            set {
                if ((AlertingElementFormatValues.NULL_ENUM_VALUE == value)) {
                    curObj["AlertingElementFormat"] = null;
                }
                else {
                    curObj["AlertingElementFormat"] = value;
                }
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The identifying information of the entity (ie, the instance) for which this Indication is generated. The property contains the path of an instance, encoded as a string parameter - if the instance is modeled in the CIM Schema. If not a CIM instance, the property contains some identifying string that names the entity for which the Alert is generated. The path or identifying string is formatted per the AlertingElementFormat property.")]
        public string AlertingManagedElement {
            get {
                return ((string)(curObj["AlertingManagedElement"]));
            }
            set {
                curObj["AlertingManagedElement"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAlertTypeNull {
            get {
                if ((curObj["AlertType"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"Primary classification of the Indication. The following values are defined: 
1 - Other. The Indication's OtherAlertType property conveys its classification. Use of ""Other"" in an enumeration is a standard CIM convention. It means that the current Indication does not fit into the categories described by this enumeration. 
2 - Communications Alert. An Indication of this type is principally associated with the procedures and/or processes required to convey information from one point to another. 
3 - Quality of Service Alert. An Indication of this type is principally associated with a degradation or errors in the performance or function of an entity. 
4 - Processing Error. An Indication of this type is principally associated with a software or processing fault. 
5 - Device Alert. An Indication of this type is principally associated with an equipment or hardware fault. 
6 - Environmental Alert. An Indication of this type is principally associated with a condition relating to an enclosure in which the hardware resides, or other environmental considerations. 
7 - Model Change. The Indication addresses changes in the Information Model. For example, it may embed a Lifecycle Indication to convey the specific model change being alerted. 
8 - Security Alert. An Indication of this type is associated with security violations, detection of viruses, and similar issues.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public AlertTypeValues AlertType {
            get {
                if ((curObj["AlertType"] == null)) {
                    return ((AlertTypeValues)(System.Convert.ToInt32(0)));
                }
                return ((AlertTypeValues)(System.Convert.ToInt32(curObj["AlertType"])));
            }
            set {
                if ((AlertTypeValues.NULL_ENUM_VALUE == value)) {
                    curObj["AlertType"] = null;
                }
                else {
                    curObj["AlertType"] = value;
                }
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] CorrelatedIndications {
            get {
                return ((string[])(curObj["CorrelatedIndications"]));
            }
            set {
                curObj["CorrelatedIndications"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A short description of the Indication.")]
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
        [Description(@"An instrumentation or provider specific value that describes the underlying ""real-world"" event represented by the Indication. Two Indications with the same, non NULL EventID value are considered, by the creating entity, to represent the same event. The comparison of two EventID values is only defined for Alert Indications with identical, non NULL values of SystemCreateClassName, SystemName and ProviderName.")]
        public string EventID {
            get {
                return ((string)(curObj["EventID"]));
            }
            set {
                curObj["EventID"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEventTimeNull {
            get {
                if ((curObj["EventTime"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description(@"The time and date the underlying event was first detected. If specified, this property MUST be set to NULL if the creating entity is not capable of providing this information. This value is based on the notion of local date and time of the Managed System Element generating the Indication.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public System.DateTime EventTime {
            get {
                if ((curObj["EventTime"] != null)) {
                    return ToDateTime(((string)(curObj["EventTime"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
            set {
                curObj["EventTime"] = ToDmtfDateTime(((System.DateTime)(value)));
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string IndicationFilterName {
            get {
                return ((string)(curObj["IndicationFilterName"]));
            }
            set {
                curObj["IndicationFilterName"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string IndicationIdentifier {
            get {
                return ((string)(curObj["IndicationIdentifier"]));
            }
            set {
                curObj["IndicationIdentifier"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsIndicationTimeNull {
            get {
                if ((curObj["IndicationTime"] == null)) {
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
        public System.DateTime IndicationTime {
            get {
                if ((curObj["IndicationTime"] != null)) {
                    return ToDateTime(((string)(curObj["IndicationTime"])));
                }
                else {
                    return System.DateTime.MinValue;
                }
            }
            set {
                curObj["IndicationTime"] = ToDmtfDateTime(((System.DateTime)(value)));
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
        [Description("A string that uniquely identifies, within the scope of the OwningEntity, the form" +
            "at of the Message.")]
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
        [Description(@"A string defining ""Other"" values for AlertingElementFormat. This value MUST be set to a non NULL value when AlertingElementFormat is set to a value of 1 (""Other""). For all other values of AlertingElementFormat, the value of this string must be set to NULL.")]
        public string OtherAlertingElementFormat {
            get {
                return ((string)(curObj["OtherAlertingElementFormat"]));
            }
            set {
                curObj["OtherAlertingElementFormat"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A string describing the Alert type - used when the AlertType property is set to 1" +
            ", \"Other State Change\".")]
        public string OtherAlertType {
            get {
                return ((string)(curObj["OtherAlertType"]));
            }
            set {
                curObj["OtherAlertType"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OtherSeverity {
            get {
                return ((string)(curObj["OtherSeverity"]));
            }
            set {
                curObj["OtherSeverity"] = value;
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
        [Description(@"An enumerated value that describes the severity of the Alert Indication from the notifier's point of view: 
1 - Other, by CIM convention, is used to indicate that the Severity's value can be found in the OtherSeverity property. 
3 - Degraded/Warning should be used when its appropriate to let the user decide if action is needed. 
4 - Minor should be used to indicate action is needed, but the situation is not serious at this time. 
5 - Major should be used to indicate action is needed NOW. 
6 - Critical should be used to indicate action is needed NOW and the scope is broad (perhaps an imminent outage to a critical resource will result). 
7 - Fatal/NonRecoverable should be used to indicate an error occurred, but it's too late to take remedial action. 
2 and 0 - Information and Unknown (respectively) follow common usage. Literally, the AlertIndication is purely informational or its severity is simply unknown.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public PerceivedSeverityValues PerceivedSeverity {
            get {
                if ((curObj["PerceivedSeverity"] == null)) {
                    return ((PerceivedSeverityValues)(System.Convert.ToInt32(8)));
                }
                return ((PerceivedSeverityValues)(System.Convert.ToInt32(curObj["PerceivedSeverity"])));
            }
            set {
                if ((PerceivedSeverityValues.NULL_ENUM_VALUE == value)) {
                    curObj["PerceivedSeverity"] = null;
                }
                else {
                    curObj["PerceivedSeverity"] = value;
                }
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
        [Description("An enumerated value that describes the probable cause of the situation which resu" +
            "lted in the AlertIndication.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public ProbableCauseValues ProbableCause {
            get {
                if ((curObj["ProbableCause"] == null)) {
                    return ((ProbableCauseValues)(System.Convert.ToInt32(131)));
                }
                return ((ProbableCauseValues)(System.Convert.ToInt32(curObj["ProbableCause"])));
            }
            set {
                if ((ProbableCauseValues.NULL_ENUM_VALUE == value)) {
                    curObj["ProbableCause"] = null;
                }
                else {
                    curObj["ProbableCause"] = value;
                }
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Provides additional information related to the ProbableCause.")]
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
        [Description("The name of the Provider generating this Indication.")]
        public string ProviderName {
            get {
                return ((string)(curObj["ProviderName"]));
            }
            set {
                curObj["ProviderName"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Free form descriptions of the recommended actions to take to resolve the cause of" +
            " the notification.")]
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
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public byte[] SECURITY_DESCRIPTOR {
            get {
                return ((byte[])(curObj["SECURITY_DESCRIPTOR"]));
            }
            set {
                curObj["SECURITY_DESCRIPTOR"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SequenceContext {
            get {
                return ((string)(curObj["SequenceContext"]));
            }
            set {
                curObj["SequenceContext"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSequenceNumberNull {
            get {
                if ((curObj["SequenceNumber"] == null)) {
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
        public long SequenceNumber {
            get {
                if ((curObj["SequenceNumber"] == null)) {
                    return System.Convert.ToInt64(0);
                }
                return ((long)(curObj["SequenceNumber"]));
            }
            set {
                curObj["SequenceNumber"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The scoping System\'s CreationClassName for the Provider generating this Indicatio" +
            "n.")]
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
        [Description("The scoping System\'s Name for the Provider generating this Indication.")]
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
        public bool IsTIME_CREATEDNull {
            get {
                if ((curObj["TIME_CREATED"] == null)) {
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
        public ulong TIME_CREATED {
            get {
                if ((curObj["TIME_CREATED"] == null)) {
                    return System.Convert.ToUInt64(0);
                }
                return ((ulong)(curObj["TIME_CREATED"]));
            }
            set {
                curObj["TIME_CREATED"] = value;
                if (((isEmbedded == false) 
                            && (AutoCommitProp == true))) {
                    PrivateLateBoundObject.Put();
                }
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsTrendingNull {
            get {
                if ((curObj["Trending"] == null)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Provides information on trending - trending up, down or no change.")]
        [TypeConverter(typeof(WMIValueTypeConverter))]
        public TrendingValues Trending {
            get {
                if ((curObj["Trending"] == null)) {
                    return ((TrendingValues)(System.Convert.ToInt32(5)));
                }
                return ((TrendingValues)(System.Convert.ToInt32(curObj["Trending"])));
            }
            set {
                if ((TrendingValues.NULL_ENUM_VALUE == value)) {
                    curObj["Trending"] = null;
                }
                else {
                    curObj["Trending"] = value;
                }
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
        
        private bool ShouldSerializeAlertingElementFormat() {
            if ((this.IsAlertingElementFormatNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetAlertingElementFormat() {
            curObj["AlertingElementFormat"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetAlertingManagedElement() {
            curObj["AlertingManagedElement"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeAlertType() {
            if ((this.IsAlertTypeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetAlertType() {
            curObj["AlertType"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetCorrelatedIndications() {
            curObj["CorrelatedIndications"] = null;
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
        
        private void ResetEventID() {
            curObj["EventID"] = null;
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
        
        private bool ShouldSerializeEventTime() {
            if ((this.IsEventTimeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetEventTime() {
            curObj["EventTime"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetIndicationFilterName() {
            curObj["IndicationFilterName"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetIndicationIdentifier() {
            curObj["IndicationIdentifier"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeIndicationTime() {
            if ((this.IsIndicationTimeNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetIndicationTime() {
            curObj["IndicationTime"] = null;
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
        
        private void ResetOtherAlertingElementFormat() {
            curObj["OtherAlertingElementFormat"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherAlertType() {
            curObj["OtherAlertType"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetOtherSeverity() {
            curObj["OtherSeverity"] = null;
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
        
        private void ResetProviderName() {
            curObj["ProviderName"] = null;
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
        
        private void ResetSECURITY_DESCRIPTOR() {
            curObj["SECURITY_DESCRIPTOR"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetSequenceContext() {
            curObj["SequenceContext"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeSequenceNumber() {
            if ((this.IsSequenceNumberNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetSequenceNumber() {
            curObj["SequenceNumber"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetSystemCreationClassName() {
            curObj["SystemCreationClassName"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private void ResetSystemName() {
            curObj["SystemName"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeTIME_CREATED() {
            if ((this.IsTIME_CREATEDNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetTIME_CREATED() {
            curObj["TIME_CREATED"] = null;
            if (((isEmbedded == false) 
                        && (AutoCommitProp == true))) {
                PrivateLateBoundObject.Put();
            }
        }
        
        private bool ShouldSerializeTrending() {
            if ((this.IsTrendingNull == false)) {
                return true;
            }
            return false;
        }
        
        private void ResetTrending() {
            curObj["Trending"] = null;
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
            string strPath = "root\\virtualization\\v2:CIM_AlertIndication";
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
        public static AlertIndicationCollection GetInstances() {
            return GetInstances(null, null, null);
        }
        
        public static AlertIndicationCollection GetInstances(string condition) {
            return GetInstances(null, condition, null);
        }
        
        public static AlertIndicationCollection GetInstances(string[] selectedProperties) {
            return GetInstances(null, null, selectedProperties);
        }
        
        public static AlertIndicationCollection GetInstances(string condition, string[] selectedProperties) {
            return GetInstances(null, condition, selectedProperties);
        }
        
        public static AlertIndicationCollection GetInstances(System.Management.ManagementScope mgmtScope, System.Management.EnumerationOptions enumOptions) {
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
            pathObj.ClassName = "CIM_AlertIndication";
            pathObj.NamespacePath = "root\\virtualization\\v2";
            System.Management.ManagementClass clsObject = new System.Management.ManagementClass(mgmtScope, pathObj, null);
            if ((enumOptions == null)) {
                enumOptions = new System.Management.EnumerationOptions();
                enumOptions.EnsureLocatable = true;
            }
            return new AlertIndicationCollection(clsObject.GetInstances(enumOptions));
        }
        
        public static AlertIndicationCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition) {
            return GetInstances(mgmtScope, condition, null);
        }
        
        public static AlertIndicationCollection GetInstances(System.Management.ManagementScope mgmtScope, string[] selectedProperties) {
            return GetInstances(mgmtScope, null, selectedProperties);
        }
        
        public static AlertIndicationCollection GetInstances(System.Management.ManagementScope mgmtScope, string condition, string[] selectedProperties) {
            if ((mgmtScope == null)) {
                if ((statMgmtScope == null)) {
                    mgmtScope = new System.Management.ManagementScope();
                    mgmtScope.Path.NamespacePath = "root\\virtualization\\v2";
                }
                else {
                    mgmtScope = statMgmtScope;
                }
            }
            System.Management.ManagementObjectSearcher ObjectSearcher = new System.Management.ManagementObjectSearcher(mgmtScope, new SelectQuery("CIM_AlertIndication", condition, selectedProperties));
            System.Management.EnumerationOptions enumOptions = new System.Management.EnumerationOptions();
            enumOptions.EnsureLocatable = true;
            ObjectSearcher.Options = enumOptions;
            return new AlertIndicationCollection(ObjectSearcher.Get());
        }
        
        [Browsable(true)]
        public static AlertIndication CreateInstance() {
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
            return new AlertIndication(tmpMgmtClass.CreateInstance());
        }
        
        [Browsable(true)]
        public void Delete() {
            PrivateLateBoundObject.Delete();
        }
        
        public enum AlertingElementFormatValues {
            
            Unknown0 = 0,
            
            Other0 = 1,
            
            CIMObjectPath = 2,
            
            NULL_ENUM_VALUE = 3,
        }
        
        public enum AlertTypeValues {
            
            Other0 = 1,
            
            Communications_Alert = 2,
            
            Quality_of_Service_Alert = 3,
            
            Processing_Error = 4,
            
            Device_Alert = 5,
            
            Environmental_Alert = 6,
            
            Model_Change = 7,
            
            Security_Alert = 8,
            
            NULL_ENUM_VALUE = 0,
        }
        
        public enum PerceivedSeverityValues {
            
            Unknown0 = 0,
            
            Other0 = 1,
            
            Information = 2,
            
            Degraded_Warning = 3,
            
            Minor = 4,
            
            Major = 5,
            
            Critical = 6,
            
            Fatal_NonRecoverable = 7,
            
            NULL_ENUM_VALUE = 8,
        }
        
        public enum ProbableCauseValues {
            
            Unknown0 = 0,
            
            Other0 = 1,
            
            Adapter_Card_Error = 2,
            
            Application_Subsystem_Failure = 3,
            
            Bandwidth_Reduced = 4,
            
            Connection_Establishment_Error = 5,
            
            Communications_Protocol_Error = 6,
            
            Communications_Subsystem_Failure = 7,
            
            Configuration_Customization_Error = 8,
            
            Congestion = 9,
            
            Corrupt_Data = 10,
            
            CPU_Cycles_Limit_Exceeded = 11,
            
            Dataset_Modem_Error = 12,
            
            Degraded_Signal = 13,
            
            DTE_DCE_Interface_Error = 14,
            
            Enclosure_Door_Open = 15,
            
            Equipment_Malfunction = 16,
            
            Excessive_Vibration = 17,
            
            File_Format_Error = 18,
            
            Fire_Detected = 19,
            
            Flood_Detected = 20,
            
            Framing_Error = 21,
            
            HVAC_Problem = 22,
            
            Humidity_Unacceptable = 23,
            
            I_O_Device_Error = 24,
            
            Input_Device_Error = 25,
            
            LAN_Error = 26,
            
            Non_Toxic_Leak_Detected = 27,
            
            Local_Node_Transmission_Error = 28,
            
            Loss_of_Frame = 29,
            
            Loss_of_Signal = 30,
            
            Material_Supply_Exhausted = 31,
            
            Multiplexer_Problem = 32,
            
            Out_of_Memory = 33,
            
            Output_Device_Error = 34,
            
            Performance_Degraded = 35,
            
            Power_Problem = 36,
            
            Pressure_Unacceptable = 37,
            
            Processor_Problem_Internal_Machine_Error_ = 38,
            
            Pump_Failure = 39,
            
            Queue_Size_Exceeded = 40,
            
            Receive_Failure = 41,
            
            Receiver_Failure = 42,
            
            Remote_Node_Transmission_Error = 43,
            
            Resource_at_or_Nearing_Capacity = 44,
            
            Response_Time_Excessive = 45,
            
            Retransmission_Rate_Excessive = 46,
            
            Software_Error = 47,
            
            Software_Program_Abnormally_Terminated = 48,
            
            Software_Program_Error_Incorrect_Results_ = 49,
            
            Storage_Capacity_Problem = 50,
            
            Temperature_Unacceptable = 51,
            
            Threshold_Crossed = 52,
            
            Timing_Problem = 53,
            
            Toxic_Leak_Detected = 54,
            
            Transmit_Failure = 55,
            
            Transmitter_Failure = 56,
            
            Underlying_Resource_Unavailable = 57,
            
            Version_MisMatch = 58,
            
            Previous_Alert_Cleared = 59,
            
            Login_Attempts_Failed = 60,
            
            Software_Virus_Detected = 61,
            
            Hardware_Security_Breached = 62,
            
            Denial_of_Service_Detected = 63,
            
            Security_Credential_MisMatch = 64,
            
            Unauthorized_Access = 65,
            
            Alarm_Received = 66,
            
            Loss_of_Pointer = 67,
            
            Payload_Mismatch = 68,
            
            Transmission_Error = 69,
            
            Excessive_Error_Rate = 70,
            
            Trace_Problem = 71,
            
            Element_Unavailable = 72,
            
            Element_Missing = 73,
            
            Loss_of_Multi_Frame = 74,
            
            Broadcast_Channel_Failure = 75,
            
            Invalid_Message_Received = 76,
            
            Routing_Failure = 77,
            
            Backplane_Failure = 78,
            
            Identifier_Duplication = 79,
            
            Protection_Path_Failure = 80,
            
            Sync_Loss_or_Mismatch = 81,
            
            Terminal_Problem = 82,
            
            Real_Time_Clock_Failure = 83,
            
            Antenna_Failure = 84,
            
            Battery_Charging_Failure = 85,
            
            Disk_Failure = 86,
            
            Frequency_Hopping_Failure = 87,
            
            Loss_of_Redundancy = 88,
            
            Power_Supply_Failure = 89,
            
            Signal_Quality_Problem = 90,
            
            Battery_Discharging = 91,
            
            Battery_Failure = 92,
            
            Commercial_Power_Problem = 93,
            
            Fan_Failure = 94,
            
            Engine_Failure = 95,
            
            Sensor_Failure = 96,
            
            Fuse_Failure = 97,
            
            Generator_Failure = 98,
            
            Low_Battery = 99,
            
            Low_Fuel = 100,
            
            Low_Water = 101,
            
            Explosive_Gas = 102,
            
            High_Winds = 103,
            
            Ice_Buildup = 104,
            
            Smoke = 105,
            
            Memory_Mismatch = 106,
            
            Out_of_CPU_Cycles = 107,
            
            Software_Environment_Problem = 108,
            
            Software_Download_Failure = 109,
            
            Element_Reinitialized = 110,
            
            Timeout = 111,
            
            Logging_Problems = 112,
            
            Leak_Detected = 113,
            
            Protection_Mechanism_Failure = 114,
            
            Protecting_Resource_Failure = 115,
            
            Database_Inconsistency = 116,
            
            Authentication_Failure = 117,
            
            Breach_of_Confidentiality = 118,
            
            Cable_Tamper = 119,
            
            Delayed_Information = 120,
            
            Duplicate_Information = 121,
            
            Information_Missing = 122,
            
            Information_Modification = 123,
            
            Information_Out_of_Sequence = 124,
            
            Key_Expired = 125,
            
            Non_Repudiation_Failure = 126,
            
            Out_of_Hours_Activity = 127,
            
            Out_of_Service = 128,
            
            Procedural_Error = 129,
            
            Unexpected_Information = 130,
            
            NULL_ENUM_VALUE = 131,
        }
        
        public enum TrendingValues {
            
            Unknown0 = 0,
            
            Not_Applicable = 1,
            
            Trending_Up = 2,
            
            Trending_Down = 3,
            
            No_Change = 4,
            
            NULL_ENUM_VALUE = 5,
        }
        
        // Implementering av uppräknare för klassens uppräkningsinstanser.
        public class AlertIndicationCollection : object, ICollection {
            
            private ManagementObjectCollection privColObj;
            
            public AlertIndicationCollection(ManagementObjectCollection objCollection) {
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
                    array.SetValue(new AlertIndication(((System.Management.ManagementObject)(array.GetValue(nCtr)))), nCtr);
                }
            }
            
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return new AlertIndicationEnumerator(privColObj.GetEnumerator());
            }
            
            public class AlertIndicationEnumerator : object, System.Collections.IEnumerator {
                
                private ManagementObjectCollection.ManagementObjectEnumerator privObjEnum;
                
                public AlertIndicationEnumerator(ManagementObjectCollection.ManagementObjectEnumerator objEnum) {
                    privObjEnum = objEnum;
                }
                
                public virtual object Current {
                    get {
                        return new AlertIndication(((System.Management.ManagementObject)(privObjEnum.Current)));
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
