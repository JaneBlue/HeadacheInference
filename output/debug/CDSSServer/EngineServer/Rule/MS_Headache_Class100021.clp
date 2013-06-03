(defrule MS_Headache_Class100021_0
(filepath ?filepath)
(Headache_Duration_Per_Time ?Headache_Duration_Per_Time)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf > ?Headache_Duration_Per_Time 72.0 Headache_Duration_Per_Time))
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
(if(NotifyOrNot equals ?Threshhold 1 ?ShortData ?filepath Headache_Class100021)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "偏头痛持续状态")
(OperateFact "Headache_Diagnosis" "Status_Migrainosus")
(FactUsed "Headache_Duration_Per_Time")
)
)


(defrule MS_Headache_Class100021_1
(filepath ?filepath)
(Headache_Duration_Per_Time ?Headache_Duration_Per_Time)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf <= ?Headache_Duration_Per_Time 72.0 Headache_Duration_Per_Time))
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
(if(NotifyOrNot equals ?Threshhold 1 ?ShortData ?filepath Headache_Class100021)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "无先兆性偏头痛")
(OperateFact "Headache_Diagnosis" "Migraine_Without_Aura")
(FactUsed "Headache_Duration_Per_Time")
)
)
