(defrule MS_Headache_Class190042_0
(filepath ?filepath)
(Headache_Duration_Per_Time ?Headache_Duration_Per_Time)
(Headache_TotalNumber_Variable ?Headache_TotalNumber_Variable)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf >= ?Headache_Duration_Per_Time 0.03 Headache_Duration_Per_Time))
(bind ?CIL021 (Leaf <= ?Headache_Duration_Per_Time 0.5 Headache_Duration_Per_Time))
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

(bind ?CIL110 (Leaf >= ?Headache_TotalNumber_Variable 20.0 Headache_TotalNumber_Variable))
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
(if(NotifyOrNot >= ?Threshhold 2 ?ShortData ?filepath Headache_Class190042)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "Õó·¢ÐÔÆ«²àÍ·Í´")
(OperateFact "Headache_Diagnosis" "Paroxysmal_Hemicrania")
(FactUsed "Headache_Duration_Per_Time" "Headache_TotalNumber_Variable")
)
)


(defrule MS_Headache_Class190042_1
(filepath ?filepath)
(Headache_Duration_Per_Time ?Headache_Duration_Per_Time)
(Headache_TotalNumber_Variable ?Headache_TotalNumber_Variable)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf >= ?Headache_Duration_Per_Time 0.03 Headache_Duration_Per_Time))
(bind ?CIL021 (Leaf <= ?Headache_Duration_Per_Time 0.5 Headache_Duration_Per_Time))
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

(bind ?CIL110 (Leaf >= ?Headache_TotalNumber_Variable 20.0 Headache_TotalNumber_Variable))
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
(if(NotifyOrNot < ?Threshhold 2 ?ShortData ?filepath Headache_Class190042)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class190089.clp"))
(FactUsed "Headache_Duration_Per_Time" "Headache_TotalNumber_Variable")
)
)
