(defrule MS_Headache_Class20002_0
(filepath ?filepath)
(Ipsilateral_Heyelids_Swelling ?Ipsilateral_Heyelids_Swelling)
(Headache_Periodic ?Headache_Periodic)
(Miosis_or_Blepharoptosis ?Miosis_or_Blepharoptosis)
(Conjunctival_congestion_or_Tears ?Conjunctival_congestion_or_Tears)
(Frontal_facial_Sweating ?Frontal_facial_Sweating)
(Blocked_or_Watery_Nose ?Blocked_or_Watery_Nose)
(Dysphoria ?Dysphoria)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf equals ?Ipsilateral_Heyelids_Swelling Yes Ipsilateral_Heyelids_Swelling))
(bind ?CIL021 (Leaf equals ?Headache_Periodic Yes Headache_Periodic))
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

(bind ?CIL120 (Leaf equals ?Miosis_or_Blepharoptosis Yes Miosis_or_Blepharoptosis))
(bind ?CIL121 (Leaf equals ?Headache_Periodic Yes Headache_Periodic))
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

(bind ?CIL220 (Leaf equals ?Conjunctival_congestion_or_Tears Yes Conjunctival_congestion_or_Tears))
(bind ?CIL221 (Leaf equals ?Headache_Periodic Yes Headache_Periodic))
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

(bind ?CIL320 (Leaf equals ?Frontal_facial_Sweating Yes Frontal_facial_Sweating))
(bind ?CIL321 (Leaf equals ?Headache_Periodic Yes Headache_Periodic))
(if
(and (Transform ?CIL320)  (Transform ?CIL321) )
then
(bind ?CIN310 TRUE)
else
(bind ?CIN310 NULL)
(bind ?CIN310 (AddOrNot ?CIL320 ?CIN310))
(bind ?CIN310 (AddOrNot ?CIL321 ?CIN310))
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

(bind ?CIL420 (Leaf equals ?Blocked_or_Watery_Nose Yes Blocked_or_Watery_Nose))
(bind ?CIL421 (Leaf equals ?Headache_Periodic Yes Headache_Periodic))
(if
(and (Transform ?CIL420)  (Transform ?CIL421) )
then
(bind ?CIN410 TRUE)
else
(bind ?CIN410 NULL)
(bind ?CIN410 (AddOrNot ?CIL420 ?CIN410))
(bind ?CIN410 (AddOrNot ?CIL421 ?CIN410))
(if(eq ?CIN410 NULL)
then
(bind ?CIN410 FALSE)
)
)
(bind ?RI4 ?CIN410)
(if
(eq ?RI4 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL520 (Leaf equals ?Dysphoria Yes Dysphoria))
(bind ?CIL521 (Leaf equals ?Headache_Periodic Yes Headache_Periodic))
(if
(and (Transform ?CIL520)  (Transform ?CIL521) )
then
(bind ?CIN510 TRUE)
else
(bind ?CIN510 NULL)
(bind ?CIN510 (AddOrNot ?CIL520 ?CIN510))
(bind ?CIN510 (AddOrNot ?CIL521 ?CIN510))
(if(eq ?CIN510 NULL)
then
(bind ?CIN510 FALSE)
)
)
(bind ?RI5 ?CIN510)
(if
(eq ?RI5 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL610 (Leaf equals ?Ipsilateral_Heyelids_Swelling Yes Ipsilateral_Heyelids_Swelling))
(bind ?RI6 ?CIL610)
(if
(eq ?RI6 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL710 (Leaf equals ?Miosis_or_Blepharoptosis Yes Miosis_or_Blepharoptosis))
(bind ?RI7 ?CIL710)
(if
(eq ?RI7 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL810 (Leaf equals ?Conjunctival_congestion_or_Tears Yes Conjunctival_congestion_or_Tears))
(bind ?RI8 ?CIL810)
(if
(eq ?RI8 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL910 (Leaf equals ?Frontal_facial_Sweating Yes Frontal_facial_Sweating))
(bind ?RI9 ?CIL910)
(if
(eq ?RI9 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL1010 (Leaf equals ?Blocked_or_Watery_Nose Yes Blocked_or_Watery_Nose))
(bind ?RI10 ?CIL1010)
(if
(eq ?RI10 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)
(bind ?ShortData NULL)
(bind ?ShortData (AddOrNot ?RI0 ?ShortData))
(bind ?ShortData (AddOrNot ?RI1 ?ShortData))
(bind ?ShortData (AddOrNot ?RI2 ?ShortData))
(bind ?ShortData (AddOrNot ?RI3 ?ShortData))
(bind ?ShortData (AddOrNot ?RI4 ?ShortData))
(bind ?ShortData (AddOrNot ?RI5 ?ShortData))
(bind ?ShortData (AddOrNot ?RI6 ?ShortData))
(bind ?ShortData (AddOrNot ?RI7 ?ShortData))
(bind ?ShortData (AddOrNot ?RI8 ?ShortData))
(bind ?ShortData (AddOrNot ?RI9 ?ShortData))
(bind ?ShortData (AddOrNot ?RI10 ?ShortData))
(if
(eq ?ShortData NULL)
then
(bind ?ShortData FALSE)
)
(if(NotifyOrNot < ?Threshhold 1 ?ShortData ?filepath Headache_Class20002)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class1.clp"))
(FactUsed "Ipsilateral_Heyelids_Swelling" "Headache_Periodic" "Miosis_or_Blepharoptosis" "Conjunctival_congestion_or_Tears" "Frontal_facial_Sweating" "Blocked_or_Watery_Nose" "Dysphoria")
)
)


(defrule MS_Headache_Class20002_1
(filepath ?filepath)
(Ipsilateral_Heyelids_Swelling ?Ipsilateral_Heyelids_Swelling)
(Headache_Periodic ?Headache_Periodic)
(Miosis_or_Blepharoptosis ?Miosis_or_Blepharoptosis)
(Conjunctival_congestion_or_Tears ?Conjunctival_congestion_or_Tears)
(Blocked_or_Watery_Nose ?Blocked_or_Watery_Nose)
(Frontal_facial_Sweating ?Frontal_facial_Sweating)
=>
(bind ?Threshhold 0)

(bind ?CIL020 (Leaf equals ?Ipsilateral_Heyelids_Swelling Yes Ipsilateral_Heyelids_Swelling))
(bind ?CIL021 (Leaf equals ?Headache_Periodic Yes Headache_Periodic))
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

(bind ?CIL120 (Leaf equals ?Miosis_or_Blepharoptosis Yes Miosis_or_Blepharoptosis))
(bind ?CIL121 (Leaf equals ?Headache_Periodic Yes Headache_Periodic))
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

(bind ?CIL220 (Leaf equals ?Conjunctival_congestion_or_Tears Yes Conjunctival_congestion_or_Tears))
(bind ?CIL221 (Leaf equals ?Headache_Periodic Yes Headache_Periodic))
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

(bind ?CIL320 (Leaf equals ?Blocked_or_Watery_Nose Yes Blocked_or_Watery_Nose))
(bind ?CIL321 (Leaf equals ?Headache_Periodic Yes Headache_Periodic))
(if
(and (Transform ?CIL320)  (Transform ?CIL321) )
then
(bind ?CIN310 TRUE)
else
(bind ?CIN310 NULL)
(bind ?CIN310 (AddOrNot ?CIL320 ?CIN310))
(bind ?CIN310 (AddOrNot ?CIL321 ?CIN310))
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

(bind ?CIL420 (Leaf equals ?Frontal_facial_Sweating Yes Frontal_facial_Sweating))
(bind ?CIL421 (Leaf equals ?Headache_Periodic Yes Headache_Periodic))
(if
(and (Transform ?CIL420)  (Transform ?CIL421) )
then
(bind ?CIN410 TRUE)
else
(bind ?CIN410 NULL)
(bind ?CIN410 (AddOrNot ?CIL420 ?CIN410))
(bind ?CIN410 (AddOrNot ?CIL421 ?CIN410))
(if(eq ?CIN410 NULL)
then
(bind ?CIN410 FALSE)
)
)
(bind ?RI4 ?CIN410)
(if
(eq ?RI4 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL510 (Leaf equals ?Ipsilateral_Heyelids_Swelling Yes Ipsilateral_Heyelids_Swelling))
(bind ?RI5 ?CIL510)
(if
(eq ?RI5 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL610 (Leaf equals ?Miosis_or_Blepharoptosis Yes Miosis_or_Blepharoptosis))
(bind ?RI6 ?CIL610)
(if
(eq ?RI6 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL710 (Leaf equals ?Conjunctival_congestion_or_Tears Yes Conjunctival_congestion_or_Tears))
(bind ?RI7 ?CIL710)
(if
(eq ?RI7 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL810 (Leaf equals ?Frontal_facial_Sweating Yes Frontal_facial_Sweating))
(bind ?RI8 ?CIL810)
(if
(eq ?RI8 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL910 (Leaf equals ?Blocked_or_Watery_Nose Yes Blocked_or_Watery_Nose))
(bind ?RI9 ?CIL910)
(if
(eq ?RI9 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)
(bind ?ShortData NULL)
(bind ?ShortData (AddOrNot ?RI0 ?ShortData))
(bind ?ShortData (AddOrNot ?RI1 ?ShortData))
(bind ?ShortData (AddOrNot ?RI2 ?ShortData))
(bind ?ShortData (AddOrNot ?RI3 ?ShortData))
(bind ?ShortData (AddOrNot ?RI4 ?ShortData))
(bind ?ShortData (AddOrNot ?RI5 ?ShortData))
(bind ?ShortData (AddOrNot ?RI6 ?ShortData))
(bind ?ShortData (AddOrNot ?RI7 ?ShortData))
(bind ?ShortData (AddOrNot ?RI8 ?ShortData))
(bind ?ShortData (AddOrNot ?RI9 ?ShortData))
(if
(eq ?ShortData NULL)
then
(bind ?ShortData FALSE)
)
(if(NotifyOrNot >= ?Threshhold 1 ?ShortData ?filepath Headache_Class20002)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class190020.clp"))
(FactUsed "Ipsilateral_Heyelids_Swelling" "Headache_Periodic" "Miosis_or_Blepharoptosis" "Conjunctival_congestion_or_Tears" "Blocked_or_Watery_Nose" "Frontal_facial_Sweating")
)
)
