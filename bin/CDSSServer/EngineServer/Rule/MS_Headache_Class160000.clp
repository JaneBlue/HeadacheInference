(defrule MS_Headache_Class160000_0
(filepath ?filepath)
(Headache_Duration_Per_Time ?Headache_Duration_Per_Time)
(Electric_Shock_Like_Pain ?Electric_Shock_Like_Pain)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf <= ?Headache_Duration_Per_Time 0.02 Headache_Duration_Per_Time))
(bind ?CIL021 (Leaf equals ?Electric_Shock_Like_Pain Yes Electric_Shock_Like_Pain))
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
(bind ?ShortData NULL)
(bind ?ShortData (AddOrNot ?RI0 ?ShortData))
(if
(eq ?ShortData NULL)
then
(bind ?ShortData FALSE)
)
(if(NotifyOrNot < ?Threshhold 1 ?ShortData ?filepath Headache_Class160000)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class20002.clp"))
(FactUsed "Headache_Duration_Per_Time" "Electric_Shock_Like_Pain")
)
)


(defrule MS_Headache_Class160000_1
(filepath ?filepath)
(Headache_Duration_Per_Time ?Headache_Duration_Per_Time)
(Electric_Shock_Like_Pain ?Electric_Shock_Like_Pain)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf <= ?Headache_Duration_Per_Time 0.02 Headache_Duration_Per_Time))
(bind ?CIL021 (Leaf equals ?Electric_Shock_Like_Pain Yes Electric_Shock_Like_Pain))
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
(bind ?ShortData NULL)
(bind ?ShortData (AddOrNot ?RI0 ?ShortData))
(if
(eq ?ShortData NULL)
then
(bind ?ShortData FALSE)
)
(if(NotifyOrNot >= ?Threshhold 1 ?ShortData ?filepath Headache_Class160000)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "颅神经痛和中枢源性面痛")
(OperateFact "Headache_Diagnosis" "Cranial_Neuralgias_and_Central_Causes_of_Facial_Pain")
(FactUsed "Headache_Duration_Per_Time" "Electric_Shock_Like_Pain")
)
)
