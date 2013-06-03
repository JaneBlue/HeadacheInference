(defrule MS_Headache_Class140025_0
(filepath ?filepath)
(Headache_TotalNumber_Variable ?Headache_TotalNumber_Variable)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf < ?Headache_TotalNumber_Variable 5.0 Headache_TotalNumber_Variable))
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
(if(NotifyOrNot >= ?Threshhold 1 ?ShortData ?filepath Headache_Class140025)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "很可能的偏头痛")
(OperateFact "Headache_Diagnosis" "Probable_Migraine")
(FactUsed "Headache_TotalNumber_Variable")
)
)


(defrule MS_Headache_Class140025_1
(filepath ?filepath)
(Headache_TotalNumber_Variable ?Headache_TotalNumber_Variable)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf >= ?Headache_TotalNumber_Variable 5.0 Headache_TotalNumber_Variable))
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
(if(NotifyOrNot >= ?Threshhold 1 ?ShortData ?filepath Headache_Class140025)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class100021.clp"))
(FactUsed "Headache_TotalNumber_Variable")
)
)
