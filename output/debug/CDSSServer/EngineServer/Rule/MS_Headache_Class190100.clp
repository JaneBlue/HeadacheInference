(defrule MS_Headache_Class190100_0
(filepath ?filepath)
(Headache_Duration_Per_Time ?Headache_Duration_Per_Time)
(Uni_Pain ?Uni_Pain)
(Headache_TotalNumber_Variable ?Headache_TotalNumber_Variable)
(Conjunctival_congestion_or_Tears ?Conjunctival_congestion_or_Tears)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf >= ?Headache_Duration_Per_Time 0.00139 Headache_Duration_Per_Time))
(bind ?CIL021 (Leaf <= ?Headache_Duration_Per_Time 0.067 Headache_Duration_Per_Time))
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

(bind ?CIL210 (Leaf >= ?Headache_TotalNumber_Variable 20.0 Headache_TotalNumber_Variable))
(bind ?RI2 ?CIL210)
(if
(eq ?RI2 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL310 (Leaf equals ?Conjunctival_congestion_or_Tears Yes Conjunctival_congestion_or_Tears))
(bind ?RI3 ?CIL310)
(if
(eq ?RI3 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)
(bind ?ShortData NULL)
(bind ?ShortData (AddOrNot ?RI0 ?ShortData))
(bind ?ShortData (AddOrNot ?RI1 ?ShortData))
(bind ?ShortData (AddOrNot ?RI2 ?ShortData))
(bind ?ShortData (AddOrNot ?RI3 ?ShortData))
(if
(eq ?ShortData NULL)
then
(bind ?ShortData FALSE)
)
(if(NotifyOrNot >= ?Threshhold 3 ?ShortData ?filepath Headache_Class190100)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "很可能的SUNCT")
(OperateFact "Headache_Diagnosis" "Probable_SUNCT")
(FactUsed "Headache_Duration_Per_Time" "Uni_Pain" "Headache_TotalNumber_Variable" "Conjunctival_congestion_or_Tears")
)
)


(defrule MS_Headache_Class190100_1
(filepath ?filepath)
(Headache_TotalNumber_Variable ?Headache_TotalNumber_Variable)
(Uni_Pain ?Uni_Pain)
(Headache_Duration_Per_Time ?Headache_Duration_Per_Time)
(Conjunctival_congestion_or_Tears ?Conjunctival_congestion_or_Tears)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf >= ?Headache_TotalNumber_Variable 20.0 Headache_TotalNumber_Variable))
(bind ?RI0 ?CIL010)
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

(bind ?CIL220 (Leaf >= ?Headache_Duration_Per_Time 0.00139 Headache_Duration_Per_Time))
(bind ?CIL221 (Leaf <= ?Headache_Duration_Per_Time 0.067 Headache_Duration_Per_Time))
(if
(and (Transform ?CIL220)  (Transform ?CIL221) )
then
(bind ?CIN210 TRUE)
else
(bind ?CIN210 NULL)
(bind ?CIN210 (AddOrNot ?CIL220 ?CIN210))
(bind ?CIN210 (AddOrNot ?CIL221 ?CIN210))
(if(eq ?CIN210 NULL)
then
(bind ?CIN210 FALSE)
)
)
(bind ?RI2 ?CIN210)
(if
(eq ?RI2 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL310 (Leaf equals ?Conjunctival_congestion_or_Tears Yes Conjunctival_congestion_or_Tears))
(bind ?RI3 ?CIL310)
(if
(eq ?RI3 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)
(bind ?ShortData NULL)
(bind ?ShortData (AddOrNot ?RI0 ?ShortData))
(bind ?ShortData (AddOrNot ?RI1 ?ShortData))
(bind ?ShortData (AddOrNot ?RI2 ?ShortData))
(bind ?ShortData (AddOrNot ?RI3 ?ShortData))
(if
(eq ?ShortData NULL)
then
(bind ?ShortData FALSE)
)
(if(NotifyOrNot < ?Threshhold 3 ?ShortData ?filepath Headache_Class190100)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "丛集性头痛或其他三叉自主神经痛")
(OperateFact "Headache_Diagnosis" "Cluster_Headache_and_Other_Trigeminal_Autonomic_Cephalalgias")
(FactUsed "Headache_TotalNumber_Variable" "Uni_Pain" "Headache_Duration_Per_Time" "Conjunctival_congestion_or_Tears")
)
)
