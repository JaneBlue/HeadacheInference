(defrule MS_Headache_Class30002_0
(filepath ?filepath)
(Uni_Pain ?Uni_Pain)
(Thrust ?Thrust)
(Discust ?Discust)
(Fair_Of_Sound ?Fair_Of_Sound)
(Fire_Of_Light ?Fire_Of_Light)
(Pulse_Pain ?Pulse_Pain)
(Middle ?Middle)
(Serious ?Serious)
(Worsen_By_Physicial_Activity ?Worsen_By_Physicial_Activity)
=>
(bind ?Threshhold 0)

(bind ?CIL030 (Leaf equals ?Thrust Yes Thrust))
(bind ?CIL031 (Leaf equals ?Discust Yes Discust))
(bind ?CIL032 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(bind ?CIL033 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(or (Transform ?CIL030)  (Transform ?CIL031)  (Transform ?CIL032)  (Transform ?CIL033) )
then
(bind ?CIN020 TRUE)
else
(bind ?CIN020 NULL)
(bind ?CIN020 (AddOrNot ?CIL030 ?CIN020))
(bind ?CIN020 (AddOrNot ?CIL031 ?CIN020))
(bind ?CIN020 (AddOrNot ?CIL032 ?CIN020))
(bind ?CIN020 (AddOrNot ?CIL033 ?CIN020))
(if(eq ?CIN020 NULL)
then
(bind ?CIN020 FALSE)
)
)
(bind ?CIL020 (Leaf equals ?Uni_Pain Yes Uni_Pain))
(if
(and (Transform ?CIL020)  (Transform ?CIN020) )
then
(bind ?CIN010 TRUE)
else
(bind ?CIN010 NULL)
(bind ?CIN010 (AddOrNot ?CIL020 ?CIN010))
(bind ?CIN010 (AddOrNot ?CIN020 ?CIN010))
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

(bind ?CIL130 (Leaf equals ?Thrust Yes Thrust))
(bind ?CIL131 (Leaf equals ?Discust Yes Discust))
(bind ?CIL132 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(bind ?CIL133 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(or (Transform ?CIL130)  (Transform ?CIL131)  (Transform ?CIL132)  (Transform ?CIL133) )
then
(bind ?CIN120 TRUE)
else
(bind ?CIN120 NULL)
(bind ?CIN120 (AddOrNot ?CIL130 ?CIN120))
(bind ?CIN120 (AddOrNot ?CIL131 ?CIN120))
(bind ?CIN120 (AddOrNot ?CIL132 ?CIN120))
(bind ?CIN120 (AddOrNot ?CIL133 ?CIN120))
(if(eq ?CIN120 NULL)
then
(bind ?CIN120 FALSE)
)
)
(bind ?CIL120 (Leaf equals ?Pulse_Pain Yes Pulse_Pain))
(if
(and (Transform ?CIL120)  (Transform ?CIN120) )
then
(bind ?CIN110 TRUE)
else
(bind ?CIN110 NULL)
(bind ?CIN110 (AddOrNot ?CIL120 ?CIN110))
(bind ?CIN110 (AddOrNot ?CIN120 ?CIN110))
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

(bind ?CIL230 (Leaf equals ?Middle Yes Middle))
(bind ?CIL231 (Leaf equals ?Serious Yes Serious))
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
(bind ?CIL232 (Leaf equals ?Thrust Yes Thrust))
(bind ?CIL233 (Leaf equals ?Discust Yes Discust))
(bind ?CIL234 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(bind ?CIL235 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(or (Transform ?CIL232)  (Transform ?CIL233)  (Transform ?CIL234)  (Transform ?CIL235) )
then
(bind ?CIN221 TRUE)
else
(bind ?CIN221 NULL)
(bind ?CIN221 (AddOrNot ?CIL232 ?CIN221))
(bind ?CIN221 (AddOrNot ?CIL233 ?CIN221))
(bind ?CIN221 (AddOrNot ?CIL234 ?CIN221))
(bind ?CIN221 (AddOrNot ?CIL235 ?CIN221))
(if(eq ?CIN221 NULL)
then
(bind ?CIN221 FALSE)
)
)
(if
(and (Transform ?CIN220)  (Transform ?CIN221) )
then
(bind ?CIN210 TRUE)
else
(bind ?CIN210 NULL)
(bind ?CIN210 (AddOrNot ?CIN220 ?CIN210))
(bind ?CIN210 (AddOrNot ?CIN221 ?CIN210))
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

(bind ?CIL330 (Leaf equals ?Thrust Yes Thrust))
(bind ?CIL331 (Leaf equals ?Discust Yes Discust))
(bind ?CIL332 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(bind ?CIL333 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(or (Transform ?CIL330)  (Transform ?CIL331)  (Transform ?CIL332)  (Transform ?CIL333) )
then
(bind ?CIN320 TRUE)
else
(bind ?CIN320 NULL)
(bind ?CIN320 (AddOrNot ?CIL330 ?CIN320))
(bind ?CIN320 (AddOrNot ?CIL331 ?CIN320))
(bind ?CIN320 (AddOrNot ?CIL332 ?CIN320))
(bind ?CIN320 (AddOrNot ?CIL333 ?CIN320))
(if(eq ?CIN320 NULL)
then
(bind ?CIN320 FALSE)
)
)
(bind ?CIL320 (Leaf equals ?Worsen_By_Physicial_Activity Yes Worsen_By_Physicial_Activity))
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
(if(NotifyOrNot <= ?Threshhold 1 ?ShortData ?filepath Headache_Class30002)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class40002.clp"))
(FactUsed "Uni_Pain" "Thrust" "Discust" "Fair_Of_Sound" "Fire_Of_Light" "Pulse_Pain" "Middle" "Serious" "Worsen_By_Physicial_Activity")
)
)


(defrule MS_Headache_Class30002_1
(filepath ?filepath)
(Middle ?Middle)
(Serious ?Serious)
(Thrust ?Thrust)
(Discust ?Discust)
(Fair_Of_Sound ?Fair_Of_Sound)
(Fire_Of_Light ?Fire_Of_Light)
(Uni_Pain ?Uni_Pain)
(Worsen_By_Physicial_Activity ?Worsen_By_Physicial_Activity)
(Pulse_Pain ?Pulse_Pain)
=>
(bind ?Threshhold 0)

(bind ?CIL030 (Leaf equals ?Middle Yes Middle))
(bind ?CIL031 (Leaf equals ?Serious Yes Serious))
(if
(or (Transform ?CIL030)  (Transform ?CIL031) )
then
(bind ?CIN020 TRUE)
else
(bind ?CIN020 NULL)
(bind ?CIN020 (AddOrNot ?CIL030 ?CIN020))
(bind ?CIN020 (AddOrNot ?CIL031 ?CIN020))
(if(eq ?CIN020 NULL)
then
(bind ?CIN020 FALSE)
)
)
(bind ?CIL032 (Leaf equals ?Thrust Yes Thrust))
(bind ?CIL033 (Leaf equals ?Discust Yes Discust))
(bind ?CIL034 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(bind ?CIL035 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(or (Transform ?CIL032)  (Transform ?CIL033)  (Transform ?CIL034)  (Transform ?CIL035) )
then
(bind ?CIN021 TRUE)
else
(bind ?CIN021 NULL)
(bind ?CIN021 (AddOrNot ?CIL032 ?CIN021))
(bind ?CIN021 (AddOrNot ?CIL033 ?CIN021))
(bind ?CIN021 (AddOrNot ?CIL034 ?CIN021))
(bind ?CIN021 (AddOrNot ?CIL035 ?CIN021))
(if(eq ?CIN021 NULL)
then
(bind ?CIN021 FALSE)
)
)
(if
(and (Transform ?CIN020)  (Transform ?CIN021) )
then
(bind ?CIN010 TRUE)
else
(bind ?CIN010 NULL)
(bind ?CIN010 (AddOrNot ?CIN020 ?CIN010))
(bind ?CIN010 (AddOrNot ?CIN021 ?CIN010))
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

(bind ?CIL130 (Leaf equals ?Thrust Yes Thrust))
(bind ?CIL131 (Leaf equals ?Discust Yes Discust))
(bind ?CIL132 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(bind ?CIL133 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(or (Transform ?CIL130)  (Transform ?CIL131)  (Transform ?CIL132)  (Transform ?CIL133) )
then
(bind ?CIN120 TRUE)
else
(bind ?CIN120 NULL)
(bind ?CIN120 (AddOrNot ?CIL130 ?CIN120))
(bind ?CIN120 (AddOrNot ?CIL131 ?CIN120))
(bind ?CIN120 (AddOrNot ?CIL132 ?CIN120))
(bind ?CIN120 (AddOrNot ?CIL133 ?CIN120))
(if(eq ?CIN120 NULL)
then
(bind ?CIN120 FALSE)
)
)
(bind ?CIL120 (Leaf equals ?Uni_Pain Yes Uni_Pain))
(if
(and (Transform ?CIL120)  (Transform ?CIN120) )
then
(bind ?CIN110 TRUE)
else
(bind ?CIN110 NULL)
(bind ?CIN110 (AddOrNot ?CIL120 ?CIN110))
(bind ?CIN110 (AddOrNot ?CIN120 ?CIN110))
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

(bind ?CIL230 (Leaf equals ?Thrust Yes Thrust))
(bind ?CIL231 (Leaf equals ?Discust Yes Discust))
(bind ?CIL232 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(bind ?CIL233 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(or (Transform ?CIL230)  (Transform ?CIL231)  (Transform ?CIL232)  (Transform ?CIL233) )
then
(bind ?CIN220 TRUE)
else
(bind ?CIN220 NULL)
(bind ?CIN220 (AddOrNot ?CIL230 ?CIN220))
(bind ?CIN220 (AddOrNot ?CIL231 ?CIN220))
(bind ?CIN220 (AddOrNot ?CIL232 ?CIN220))
(bind ?CIN220 (AddOrNot ?CIL233 ?CIN220))
(if(eq ?CIN220 NULL)
then
(bind ?CIN220 FALSE)
)
)
(bind ?CIL220 (Leaf equals ?Worsen_By_Physicial_Activity Yes Worsen_By_Physicial_Activity))
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

(bind ?CIL330 (Leaf equals ?Thrust Yes Thrust))
(bind ?CIL331 (Leaf equals ?Discust Yes Discust))
(bind ?CIL332 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(bind ?CIL333 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(or (Transform ?CIL330)  (Transform ?CIL331)  (Transform ?CIL332)  (Transform ?CIL333) )
then
(bind ?CIN320 TRUE)
else
(bind ?CIN320 NULL)
(bind ?CIN320 (AddOrNot ?CIL330 ?CIN320))
(bind ?CIN320 (AddOrNot ?CIL331 ?CIN320))
(bind ?CIN320 (AddOrNot ?CIL332 ?CIN320))
(bind ?CIN320 (AddOrNot ?CIL333 ?CIN320))
(if(eq ?CIN320 NULL)
then
(bind ?CIN320 FALSE)
)
)
(bind ?CIL320 (Leaf equals ?Pulse_Pain Yes Pulse_Pain))
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
(if(NotifyOrNot >= ?Threshhold 2 ?ShortData ?filepath Headache_Class30002)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class60000.clp"))
(FactUsed "Middle" "Serious" "Thrust" "Discust" "Fair_Of_Sound" "Fire_Of_Light" "Uni_Pain" "Worsen_By_Physicial_Activity" "Pulse_Pain")
)
)
