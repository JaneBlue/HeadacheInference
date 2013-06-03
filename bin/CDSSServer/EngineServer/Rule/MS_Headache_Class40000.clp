(defrule MS_Headache_Class40000_0
(filepath ?filepath)
(Triptan_Drugin_Monthly ?Triptan_Drugin_Monthly)
(Triptan_Total_Drugin_Duration ?Triptan_Total_Drugin_Duration)
(Non_Triptan_Drugin_Monthly ?Non_Triptan_Drugin_Monthly)
(Non_Triptan_Total_Drugin_Duration ?Non_Triptan_Total_Drugin_Duration)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf >= ?Triptan_Drugin_Monthly 10.0 Triptan_Drugin_Monthly))
(bind ?CIL021 (Leaf >= ?Triptan_Total_Drugin_Duration 3.0 Triptan_Total_Drugin_Duration))
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

(bind ?CIL120 (Leaf >= ?Non_Triptan_Drugin_Monthly 15.0 Non_Triptan_Drugin_Monthly))
(bind ?CIL121 (Leaf >= ?Non_Triptan_Total_Drugin_Duration 3.0 Non_Triptan_Total_Drugin_Duration))
(if
(and (Transform ?CIL120)  (Transform ?CIL121) )
then
(bind ?CIN110 TRUE)
else
(bind ?CIN110 NULL)
(bind ?CIN110 (AddOrNot ?CIL120 ?CIN110))
(bind ?CIN110 (AddOrNot ?CIL121 ?CIN110))
(if(eq ?CIN110 NULL)
then
(bind ?CIN110 FALSE)
)
)
(bind ?RI1 ?CIN110)
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
(if(NotifyOrNot >= ?Threshhold 1 ?ShortData ?filepath Headache_Class40000)
then
(undefrule *)
(InterpretationIndex "药物过量性头痛的判断标准是非曲坦类药物要求每个月服药超过15天，大于3个月；曲坦类药物则要求每个月服用大于10天至少3个月")
(Recommendation "药物滥用引起的头痛")
(OperateFact "Headache_Diagnosis" "Medication-overuse_Headache")
(FactUsed "Triptan_Drugin_Monthly" "Triptan_Total_Drugin_Duration" "Non_Triptan_Drugin_Monthly" "Non_Triptan_Total_Drugin_Duration")
)
)


(defrule MS_Headache_Class40000_1
(filepath ?filepath)
(Triptan_Drugin_Monthly ?Triptan_Drugin_Monthly)
(Triptan_Total_Drugin_Duration ?Triptan_Total_Drugin_Duration)
(Non_Triptan_Drugin_Monthly ?Non_Triptan_Drugin_Monthly)
(Non_Triptan_Total_Drugin_Duration ?Non_Triptan_Total_Drugin_Duration)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf >= ?Triptan_Drugin_Monthly 10.0 Triptan_Drugin_Monthly))
(bind ?CIL021 (Leaf >= ?Triptan_Total_Drugin_Duration 3.0 Triptan_Total_Drugin_Duration))
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

(bind ?CIL120 (Leaf >= ?Non_Triptan_Drugin_Monthly 15.0 Non_Triptan_Drugin_Monthly))
(bind ?CIL121 (Leaf >= ?Non_Triptan_Total_Drugin_Duration 3.0 Non_Triptan_Total_Drugin_Duration))
(if
(and (Transform ?CIL120)  (Transform ?CIL121) )
then
(bind ?CIN110 TRUE)
else
(bind ?CIN110 NULL)
(bind ?CIN110 (AddOrNot ?CIL120 ?CIN110))
(bind ?CIN110 (AddOrNot ?CIL121 ?CIN110))
(if(eq ?CIN110 NULL)
then
(bind ?CIN110 FALSE)
)
)
(bind ?RI1 ?CIN110)
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
(if(NotifyOrNot < ?Threshhold 1 ?ShortData ?filepath Headache_Class40000)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class130001.clp"))
(FactUsed "Triptan_Drugin_Monthly" "Triptan_Total_Drugin_Duration" "Non_Triptan_Drugin_Monthly" "Non_Triptan_Total_Drugin_Duration")
)
)
