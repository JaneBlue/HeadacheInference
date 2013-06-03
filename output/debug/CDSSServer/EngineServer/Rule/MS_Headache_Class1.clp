(defrule MS_Headache_Class1_0
(filepath ?filepath)
(Headache_Duration_Variable ?Headache_Duration_Variable)
(Headache_Monthly_Duration_Variable ?Headache_Monthly_Duration_Variable)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf < ?Headache_Duration_Variable 3.0 Headache_Duration_Variable))
(bind ?RI0 ?CIL010)
(if
(eq ?RI0 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL110 (Leaf < ?Headache_Monthly_Duration_Variable 15.0 Headache_Monthly_Duration_Variable))
(bind ?RI1 ?CIL110)
(if
(eq ?RI1 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)
(bind ?ShortData NULL)
(bind ?ShortData (AddOrNot ?RI0 ?ShortData))
(bind ?ShortData (AddOrNot ?RI1 ?ShortData))
(if
(eq ?ShortData NULL)
then
(bind ?ShortData FALSE)
)
(if(NotifyOrNot >= ?Threshhold 1 ?ShortData ?filepath Headache_Class1)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class30002.clp"))
(FactUsed "Headache_Duration_Variable" "Headache_Monthly_Duration_Variable")
)
)


(defrule MS_Headache_Class1_1
(filepath ?filepath)
(Headache_Duration_Variable ?Headache_Duration_Variable)
(Headache_Monthly_Duration_Variable ?Headache_Monthly_Duration_Variable)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf >= ?Headache_Duration_Variable 3.0 Headache_Duration_Variable))
(bind ?RI0 ?CIL010)
(if
(eq ?RI0 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL110 (Leaf >= ?Headache_Monthly_Duration_Variable 15.0 Headache_Monthly_Duration_Variable))
(bind ?RI1 ?CIL110)
(if
(eq ?RI1 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)
(bind ?ShortData NULL)
(bind ?ShortData (AddOrNot ?RI0 ?ShortData))
(bind ?ShortData (AddOrNot ?RI1 ?ShortData))
(if
(eq ?ShortData NULL)
then
(bind ?ShortData FALSE)
)
(if(NotifyOrNot equals ?Threshhold 2 ?ShortData ?filepath Headache_Class1)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class40000.clp"))
(FactUsed "Headache_Duration_Variable" "Headache_Monthly_Duration_Variable")
)
)
