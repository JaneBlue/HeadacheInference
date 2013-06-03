(defrule MS_Headache_Class70000_0
(filepath ?filepath)
(Headache_Monthly_Duration_Variable ?Headache_Monthly_Duration_Variable)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf < ?Headache_Monthly_Duration_Variable 1.0 Headache_Monthly_Duration_Variable))
(bind ?RI0 ?CIL010)
(if
(eq ?RI0 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)
(bind ?ShortData NULL)
(bind ?ShortData (AddOrNot ?RI0 ?ShortData))
(if
(eq ?ShortData NULL)
then
(bind ?ShortData FALSE)
)
(if(NotifyOrNot equals ?Threshhold 1 ?ShortData ?filepath Headache_Class70000)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "偶尔发作性紧张型头痛")
(OperateFact "Headache_Diagnosis" "Infrequent_Episodic_Tension-type_Headache")
(FactUsed "Headache_Monthly_Duration_Variable")
)
)


(defrule MS_Headache_Class70000_1
(filepath ?filepath)
(Headache_Monthly_Duration_Variable ?Headache_Monthly_Duration_Variable)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf >= ?Headache_Monthly_Duration_Variable 1.0 Headache_Monthly_Duration_Variable))
(bind ?RI0 ?CIL010)
(if
(eq ?RI0 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)
(bind ?ShortData NULL)
(bind ?ShortData (AddOrNot ?RI0 ?ShortData))
(if
(eq ?ShortData NULL)
then
(bind ?ShortData FALSE)
)
(if(NotifyOrNot equals ?Threshhold 1 ?ShortData ?filepath Headache_Class70000)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "频繁阵发性紧张型头痛")
(OperateFact "Headache_Diagnosis" "Frequent_Episodic_Tension-type_Headache")
(FactUsed "Headache_Monthly_Duration_Variable")
)
)
