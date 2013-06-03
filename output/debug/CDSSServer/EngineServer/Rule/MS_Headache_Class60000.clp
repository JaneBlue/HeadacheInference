(defrule MS_Headache_Class60000_0
(filepath ?filepath)
(Feeling_Aura ?Feeling_Aura)
(Allolalia ?Allolalia)
(Hemi_Visual_Aura ?Hemi_Visual_Aura)
(Bilateral_Visual_Aura ?Bilateral_Visual_Aura)
(Dyscinesia ?Dyscinesia)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf equals ?Feeling_Aura Yes Feeling_Aura))
(bind ?RI0 ?CIL010)
(if
(eq ?RI0 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL110 (Leaf equals ?Allolalia Yes Allolalia))
(bind ?RI1 ?CIL110)
(if
(eq ?RI1 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL220 (Leaf equals ?Hemi_Visual_Aura Yes Hemi_Visual_Aura))
(bind ?CIL221 (Leaf equals ?Bilateral_Visual_Aura Yes Bilateral_Visual_Aura))
(if
(or (Transform ?CIL220)  (Transform ?CIL221) )
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

(bind ?CIL310 (Leaf equals ?Dyscinesia Yes Dyscinesia))
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
(if(NotifyOrNot < ?Threshhold 1 ?ShortData ?filepath Headache_Class60000)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class140025.clp"))
(FactUsed "Feeling_Aura" "Allolalia" "Hemi_Visual_Aura" "Bilateral_Visual_Aura" "Dyscinesia")
)
)


(defrule MS_Headache_Class60000_1
(filepath ?filepath)
(Feeling_Aura ?Feeling_Aura)
(Allolalia ?Allolalia)
(Dyscinesia ?Dyscinesia)
(Hemi_Visual_Aura ?Hemi_Visual_Aura)
(Bilateral_Visual_Aura ?Bilateral_Visual_Aura)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf equals ?Feeling_Aura Yes Feeling_Aura))
(bind ?RI0 ?CIL010)
(if
(eq ?RI0 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL110 (Leaf equals ?Allolalia Yes Allolalia))
(bind ?RI1 ?CIL110)
(if
(eq ?RI1 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL210 (Leaf equals ?Dyscinesia Yes Dyscinesia))
(bind ?RI2 ?CIL210)
(if
(eq ?RI2 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL320 (Leaf equals ?Hemi_Visual_Aura Yes Hemi_Visual_Aura))
(bind ?CIL321 (Leaf equals ?Bilateral_Visual_Aura Yes Bilateral_Visual_Aura))
(if
(or (Transform ?CIL320)  (Transform ?CIL321) )
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
(if(NotifyOrNot >= ?Threshhold 1 ?ShortData ?filepath Headache_Class60000)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class100006.clp"))
(FactUsed "Feeling_Aura" "Allolalia" "Dyscinesia" "Hemi_Visual_Aura" "Bilateral_Visual_Aura")
)
)
