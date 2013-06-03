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
(if(NotifyOrNot < ?Threshhold 1 ?ShortData ?filepath Headache_Class100006)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "ÏÈÕ×ÐÔÆ«Í·Í´")
(OperateFact "Headache_Diagnosis" "Migraine_With_Aura")
(FactUsed "Hemi_Visual_Aura")
)
)
