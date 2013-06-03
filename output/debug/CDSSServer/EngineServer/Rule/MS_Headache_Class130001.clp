(defrule MS_Headache_Class130001_0
(filepath ?filepath)
(Bi_Pain ?Bi_Pain)
(Daily_Headache ?Daily_Headache)
(Pressure_Pain ?Pressure_Pain)
(Slight ?Slight)
(Middle ?Middle)
(Worsen_By_Physicial_Activity ?Worsen_By_Physicial_Activity)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf equals ?Bi_Pain Yes Bi_Pain))
(bind ?CIL021 (Leaf equals ?Daily_Headache Yes Daily_Headache))
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

(bind ?CIL120 (Leaf equals ?Pressure_Pain Yes Pressure_Pain))
(bind ?CIL121 (Leaf equals ?Daily_Headache Yes Daily_Headache))
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

(bind ?CIL230 (Leaf equals ?Slight Yes Slight))
(bind ?CIL231 (Leaf equals ?Middle Yes Middle))
(if
(or (Transform ?CIL230)  (Transform ?CIL231) )
then
(bind ?CIN220 TRUE)
else
(bind ?CIN220 NULL)
(bind ?CIN220 (AddOrNot ?CIL230 ?CIN220))
(bind ?CIN220 (AddOrNot ?CIL231 ?CIN220))
(if(eq ?CIN220 NULL)
then
(bind ?CIN220 FALSE)
)
)
(bind ?CIL220 (Leaf equals ?Daily_Headache Yes Daily_Headache))
(if
(and (Transform ?CIL220)  (Transform ?CIN220) )
then
(bind ?CIN210 TRUE)
else
(bind ?CIN210 NULL)
(bind ?CIN210 (AddOrNot ?CIL220 ?CIN210))
(bind ?CIN210 (AddOrNot ?CIN220 ?CIN210))
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

(bind ?CIL330 (Leaf equals ?Worsen_By_Physicial_Activity Yes Worsen_By_Physicial_Activity))
(if
(not (Transform ?CIL330) )
then
(bind ?CIN320 TRUE)
else
(bind ?CIN320 NULL)
(bind ?CIN320 (AddOrNot ?CIL330 ?CIN320))
(if(eq ?CIN320 NULL)
then
(bind ?CIN320 FALSE)
)
)
(bind ?CIL320 (Leaf equals ?Daily_Headache Yes Daily_Headache))
(if
(and (Transform ?CIL320)  (Transform ?CIN320) )
then
(bind ?CIN310 TRUE)
else
(bind ?CIN310 NULL)
(bind ?CIN310 (AddOrNot ?CIL320 ?CIN310))
(bind ?CIN310 (AddOrNot ?CIN320 ?CIN310))
(if(eq ?CIN310 NULL)
then
(bind ?CIN310 FALSE)
)
)
(bind ?RI3 ?CIN310)
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
(if(NotifyOrNot >= ?Threshhold 2 ?ShortData ?filepath Headache_Class130001)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "新发每日持续性头痛")
(OperateFact "Headache_Diagnosis" "New_Daily_Persistent_Headache")
(FactUsed "Bi_Pain" "Daily_Headache" "Pressure_Pain" "Slight" "Middle" "Worsen_By_Physicial_Activity")
)
)


(defrule MS_Headache_Class130001_1
(filepath ?filepath)
(Pressure_Pain ?Pressure_Pain)
(Daily_Headache ?Daily_Headache)
(Bi_Pain ?Bi_Pain)
(Worsen_By_Physicial_Activity ?Worsen_By_Physicial_Activity)
(Slight ?Slight)
(Middle ?Middle)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf equals ?Pressure_Pain Yes Pressure_Pain))
(bind ?CIL021 (Leaf equals ?Daily_Headache Yes Daily_Headache))
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

(bind ?CIL120 (Leaf equals ?Bi_Pain Yes Bi_Pain))
(bind ?CIL121 (Leaf equals ?Daily_Headache Yes Daily_Headache))
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

(bind ?CIL230 (Leaf equals ?Worsen_By_Physicial_Activity Yes Worsen_By_Physicial_Activity))
(if
(not (Transform ?CIL230) )
then
(bind ?CIN220 TRUE)
else
(bind ?CIN220 NULL)
(bind ?CIN220 (AddOrNot ?CIL230 ?CIN220))
(if(eq ?CIN220 NULL)
then
(bind ?CIN220 FALSE)
)
)
(bind ?CIL220 (Leaf equals ?Daily_Headache Yes Daily_Headache))
(if
(and (Transform ?CIL220)  (Transform ?CIN220) )
then
(bind ?CIN210 TRUE)
else
(bind ?CIN210 NULL)
(bind ?CIN210 (AddOrNot ?CIL220 ?CIN210))
(bind ?CIN210 (AddOrNot ?CIN220 ?CIN210))
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

(bind ?CIL330 (Leaf equals ?Slight Yes Slight))
(bind ?CIL331 (Leaf equals ?Middle Yes Middle))
(if
(or (Transform ?CIL330)  (Transform ?CIL331) )
then
(bind ?CIN320 TRUE)
else
(bind ?CIN320 NULL)
(bind ?CIN320 (AddOrNot ?CIL330 ?CIN320))
(bind ?CIN320 (AddOrNot ?CIL331 ?CIN320))
(if(eq ?CIN320 NULL)
then
(bind ?CIN320 FALSE)
)
)
(bind ?CIL320 (Leaf equals ?Daily_Headache Yes Daily_Headache))
(if
(and (Transform ?CIL320)  (Transform ?CIN320) )
then
(bind ?CIN310 TRUE)
else
(bind ?CIN310 NULL)
(bind ?CIN310 (AddOrNot ?CIL320 ?CIN310))
(bind ?CIN310 (AddOrNot ?CIN320 ?CIN310))
(if(eq ?CIN310 NULL)
then
(bind ?CIN310 FALSE)
)
)
(bind ?RI3 ?CIN310)
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
(if(NotifyOrNot <= ?Threshhold 1 ?ShortData ?filepath Headache_Class130001)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class50000.clp"))
(FactUsed "Pressure_Pain" "Daily_Headache" "Bi_Pain" "Worsen_By_Physicial_Activity" "Slight" "Middle")
)
)
