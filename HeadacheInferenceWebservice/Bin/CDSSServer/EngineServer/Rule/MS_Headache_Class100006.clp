(defrule MS_Headache_Class100006_0
(filepath ?filepath)
(Hemi_Visual_Aura ?Hemi_Visual_Aura)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf equals ?Hemi_Visual_Aura Yes Hemi_Visual_Aura))
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
(if(NotifyOrNot >= ?Threshhold 1 ?ShortData ?filepath Headache_Class100006)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "ÊÓÍøÄ¤ÐÔÆ«Í·Í´")
(OperateFact "Headache_Diagnosis" "Retinal_Migraine")
(FactUsed "Hemi_Visual_Aura")
)
)


(defrule MS_Headache_Class100006_1
(filepath ?filepath)
(Bilateral_Visual_Aura ?Bilateral_Visual_Aura)
(Feeling_Aura ?Feeling_Aura)
(Dyscinesia ?Dyscinesia)
(Allolalia ?Allolalia)
=>
(bind ?Threshhold 0)

(bind ?CIL010 (Leaf equals ?Bilateral_Visual_Aura Yes Bilateral_Visual_Aura))
(bind ?RI0 ?CIL010)
(if
(eq ?RI0 TRUE)
then
(bind ?Threshhold (+ ?Threshhold 1))
)

(bind ?CIL110 (Leaf equals ?Feeling_Aura Yes Feeling_Aura))
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

(bind ?CIL310 (Leaf equals ?Allolalia Yes Allolalia))
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
(if(NotifyOrNot >= ?Threshhold 1 ?ShortData ?filepath Headache_Class100006)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "ÏÈÕ×ÐÔÆ«Í·Í´")
(OperateFact "Headache_Diagnosis" "Migraine_With_Aura")
(FactUsed "Bilateral_Visual_Aura" "Feeling_Aura" "Dyscinesia" "Allolalia")
)
)
