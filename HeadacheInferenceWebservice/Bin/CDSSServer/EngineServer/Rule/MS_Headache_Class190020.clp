(defrule MS_Headache_Class190020_0
(filepath ?filepath)
(Headache_Duration_Per_Time ?Headache_Duration_Per_Time)
(Headache_TotalNumber_Variable ?Headache_TotalNumber_Variable)
(Uni_Pain ?Uni_Pain)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf >= ?Headache_Duration_Per_Time 0.25 Headache_Duration_Per_Time))
(bind ?CIL021 (Leaf <= ?Headache_Duration_Per_Time 3.0 Headache_Duration_Per_Time))
(if
(and (Transform ?CIL020)  (Transform ?CIL021) )
then
(bind ?CIN010 TRUE)
else
(bind ?CIN010 NULL)
(bind ?CIN010 (AddOrNot ?CIL020 ?CIN010))
(bind ?CIN010 (AddOrNot ?CIL021 ?CIN010))
(if(eq ?CIN010 NULL)
then
(bind ?CIN010 FALSE)
)
)
(bind ?RI0 ?CIN010)
(if
(eq ?RI0 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL110 (Leaf >= ?Headache_TotalNumber_Variable 5.0 Headache_TotalNumber_Variable))
(bind ?RI1 ?CIL110)
(if
(eq ?RI1 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL210 (Leaf equals ?Uni_Pain Yes Uni_Pain))
(bind ?RI2 ?CIL210)
(if
(eq ?RI2 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)
(bind ?ShortData NULL)
(bind ?ShortData (AddOrNot ?RI0 ?ShortData))
(bind ?ShortData (AddOrNot ?RI1 ?ShortData))
(bind ?ShortData (AddOrNot ?RI2 ?ShortData))
(if
(eq ?ShortData NULL)
then
(bind ?ShortData FALSE)
)
(if(NotifyOrNot >= ?Threshhold 3 ?ShortData ?filepath Headache_Class190020)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "´Ô¼¯ÐÔÍ·Í´")
(OperateFact "Headache_Diagnosis" "Cluster_Headache")
(FactUsed "Headache_Duration_Per_Time" "Headache_TotalNumber_Variable" "Uni_Pain")
)
)


(defrule MS_Headache_Class190020_1
(filepath ?filepath)
(Headache_Duration_Per_Time ?Headache_Duration_Per_Time)
(Uni_Pain ?Uni_Pain)
(Headache_TotalNumber_Variable ?Headache_TotalNumber_Variable)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf >= ?Headache_Duration_Per_Time 0.25 Headache_Duration_Per_Time))
(bind ?CIL021 (Leaf <= ?Headache_Duration_Per_Time 3.0 Headache_Duration_Per_Time))
(if
(and (Transform ?CIL020)  (Transform ?CIL021) )
then
(bind ?CIN010 TRUE)
else
(bind ?CIN010 NULL)
(bind ?CIN010 (AddOrNot ?CIL020 ?CIN010))
(bind ?CIN010 (AddOrNot ?CIL021 ?CIN010))
(if(eq ?CIN010 NULL)
then
(bind ?CIN010 FALSE)
)
)
(bind ?RI0 ?CIN010)
(if
(eq ?RI0 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL110 (Leaf equals ?Uni_Pain Yes Uni_Pain))
(bind ?RI1 ?CIL110)
(if
(eq ?RI1 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL210 (Leaf >= ?Headache_TotalNumber_Variable 5.0 Headache_TotalNumber_Variable))
(bind ?RI2 ?CIL210)
(if
(eq ?RI2 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)
(bind ?ShortData NULL)
(bind ?ShortData (AddOrNot ?RI0 ?ShortData))
(bind ?ShortData (AddOrNot ?RI1 ?ShortData))
(bind ?ShortData (AddOrNot ?RI2 ?ShortData))
(if
(eq ?ShortData NULL)
then
(bind ?ShortData FALSE)
)
(if(NotifyOrNot < ?Threshhold 3 ?ShortData ?filepath Headache_Class190020)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class190073.clp"))
(FactUsed "Headache_Duration_Per_Time" "Uni_Pain" "Headache_TotalNumber_Variable")
)
)
