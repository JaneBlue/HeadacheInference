(defrule MS_Headache_Instance_10047_0
(filepath ?filepath)
(Headache_Diagnosis_Event ?Headache_Diagnosis_Event)
=>
(if
(eq ?Headache_Diagnosis_Event on)
then
(undefrule *)
(InterpretationIndex "Õ∑Õ¥’Ô∂œ")
(load (str-cat ?filepath "MS_Headache_Class160000.clp"))))
