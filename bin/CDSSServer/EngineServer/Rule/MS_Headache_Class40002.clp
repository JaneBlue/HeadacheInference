(defrule MS_Headache_Class40002_0
(filepath ?filepath)
(Slight ?Slight)
(Middle ?Middle)
(Discust ?Discust)
(Thrust ?Thrust)
(Fire_Of_Light ?Fire_Of_Light)
(Fair_Of_Sound ?Fair_Of_Sound)
(Worsen_By_Physicial_Activity ?Worsen_By_Physicial_Activity)
(Pressure_Pain ?Pressure_Pain)
(Bi_Pain ?Bi_Pain)
=>
(bind ?Threshhold 0)

(bind ?CIL050 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL050) )
then
(bind ?CIN040 TRUE)
else
(bind ?CIN040 NULL)
(bind ?CIN040 (AddOrNot ?CIL050 ?CIN040))
(if(eq ?CIN040 NULL)
then
(bind ?CIN040 FALSE)
)
)
(bind ?CIL051 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL051) )
then
(bind ?CIN041 TRUE)
else
(bind ?CIN041 NULL)
(bind ?CIN041 (AddOrNot ?CIL051 ?CIN041))
(if(eq ?CIN041 NULL)
then
(bind ?CIN041 FALSE)
)
)
(bind ?CIL052 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL052) )
then
(bind ?CIN042 TRUE)
else
(bind ?CIN042 NULL)
(bind ?CIN042 (AddOrNot ?CIL052 ?CIN042))
(if(eq ?CIN042 NULL)
then
(bind ?CIN042 FALSE)
)
)
(bind ?CIL053 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL053) )
then
(bind ?CIN043 TRUE)
else
(bind ?CIN043 NULL)
(bind ?CIN043 (AddOrNot ?CIL053 ?CIN043))
(if(eq ?CIN043 NULL)
then
(bind ?CIN043 FALSE)
)
)
(bind ?CIL054 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL054) )
then
(bind ?CIN044 TRUE)
else
(bind ?CIN044 NULL)
(bind ?CIN044 (AddOrNot ?CIL054 ?CIN044))
(if(eq ?CIN044 NULL)
then
(bind ?CIN044 FALSE)
)
)
(bind ?CIL055 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL055) )
then
(bind ?CIN045 TRUE)
else
(bind ?CIN045 NULL)
(bind ?CIN045 (AddOrNot ?CIL055 ?CIN045))
(if(eq ?CIN045 NULL)
then
(bind ?CIN045 FALSE)
)
)
(bind ?CIL056 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL056) )
then
(bind ?CIN046 TRUE)
else
(bind ?CIN046 NULL)
(bind ?CIN046 (AddOrNot ?CIL056 ?CIN046))
(if(eq ?CIN046 NULL)
then
(bind ?CIN046 FALSE)
)
)
(bind ?CIL057 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL057) )
then
(bind ?CIN047 TRUE)
else
(bind ?CIN047 NULL)
(bind ?CIN047 (AddOrNot ?CIL057 ?CIN047))
(if(eq ?CIN047 NULL)
then
(bind ?CIN047 FALSE)
)
)
(bind ?CIL058 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL058) )
then
(bind ?CIN048 TRUE)
else
(bind ?CIN048 NULL)
(bind ?CIN048 (AddOrNot ?CIL058 ?CIN048))
(if(eq ?CIN048 NULL)
then
(bind ?CIN048 FALSE)
)
)
(bind ?CIL059 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL059) )
then
(bind ?CIN049 TRUE)
else
(bind ?CIN049 NULL)
(bind ?CIN049 (AddOrNot ?CIL059 ?CIN049))
(if(eq ?CIN049 NULL)
then
(bind ?CIN049 FALSE)
)
)
(if
(and (Transform ?CIN040)  (Transform ?CIN041)  (Transform ?CIN042)  (Transform ?CIN043) )
then
(bind ?CIN030 TRUE)
else
(bind ?CIN030 NULL)
(bind ?CIN030 (AddOrNot ?CIN040 ?CIN030))
(bind ?CIN030 (AddOrNot ?CIN041 ?CIN030))
(bind ?CIN030 (AddOrNot ?CIN042 ?CIN030))
(bind ?CIN030 (AddOrNot ?CIN043 ?CIN030))
(if(eq ?CIN030 NULL)
then
(bind ?CIN030 FALSE)
)
)
(bind ?CIL040 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(and (Transform ?CIL040)  (Transform ?CIN044)  (Transform ?CIN045)  (Transform ?CIN046) )
then
(bind ?CIN031 TRUE)
else
(bind ?CIN031 NULL)
(bind ?CIN031 (AddOrNot ?CIL040 ?CIN031))
(bind ?CIN031 (AddOrNot ?CIN044 ?CIN031))
(bind ?CIN031 (AddOrNot ?CIN045 ?CIN031))
(bind ?CIN031 (AddOrNot ?CIN046 ?CIN031))
(if(eq ?CIN031 NULL)
then
(bind ?CIN031 FALSE)
)
)
(bind ?CIL041 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(and (Transform ?CIL041)  (Transform ?CIN047)  (Transform ?CIN048)  (Transform ?CIN049) )
then
(bind ?CIN032 TRUE)
else
(bind ?CIN032 NULL)
(bind ?CIN032 (AddOrNot ?CIL041 ?CIN032))
(bind ?CIN032 (AddOrNot ?CIN047 ?CIN032))
(bind ?CIN032 (AddOrNot ?CIN048 ?CIN032))
(bind ?CIN032 (AddOrNot ?CIN049 ?CIN032))
(if(eq ?CIN032 NULL)
then
(bind ?CIN032 FALSE)
)
)
(bind ?CIL030 (Leaf equals ?Slight Yes Slight))
(bind ?CIL031 (Leaf equals ?Middle Yes Middle))
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
(if
(or (Transform ?CIN030)  (Transform ?CIN031)  (Transform ?CIN032) )
then
(bind ?CIN021 TRUE)
else
(bind ?CIN021 NULL)
(bind ?CIN021 (AddOrNot ?CIN030 ?CIN021))
(bind ?CIN021 (AddOrNot ?CIN031 ?CIN021))
(bind ?CIN021 (AddOrNot ?CIN032 ?CIN021))
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

(bind ?CIL150 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL150) )
then
(bind ?CIN140 TRUE)
else
(bind ?CIN140 NULL)
(bind ?CIN140 (AddOrNot ?CIL150 ?CIN140))
(if(eq ?CIN140 NULL)
then
(bind ?CIN140 FALSE)
)
)
(bind ?CIL151 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL151) )
then
(bind ?CIN141 TRUE)
else
(bind ?CIN141 NULL)
(bind ?CIN141 (AddOrNot ?CIL151 ?CIN141))
(if(eq ?CIN141 NULL)
then
(bind ?CIN141 FALSE)
)
)
(bind ?CIL152 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL152) )
then
(bind ?CIN142 TRUE)
else
(bind ?CIN142 NULL)
(bind ?CIN142 (AddOrNot ?CIL152 ?CIN142))
(if(eq ?CIN142 NULL)
then
(bind ?CIN142 FALSE)
)
)
(bind ?CIL153 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL153) )
then
(bind ?CIN143 TRUE)
else
(bind ?CIN143 NULL)
(bind ?CIN143 (AddOrNot ?CIL153 ?CIN143))
(if(eq ?CIN143 NULL)
then
(bind ?CIN143 FALSE)
)
)
(bind ?CIL154 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL154) )
then
(bind ?CIN144 TRUE)
else
(bind ?CIN144 NULL)
(bind ?CIN144 (AddOrNot ?CIL154 ?CIN144))
(if(eq ?CIN144 NULL)
then
(bind ?CIN144 FALSE)
)
)
(bind ?CIL155 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL155) )
then
(bind ?CIN145 TRUE)
else
(bind ?CIN145 NULL)
(bind ?CIN145 (AddOrNot ?CIL155 ?CIN145))
(if(eq ?CIN145 NULL)
then
(bind ?CIN145 FALSE)
)
)
(bind ?CIL156 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL156) )
then
(bind ?CIN146 TRUE)
else
(bind ?CIN146 NULL)
(bind ?CIN146 (AddOrNot ?CIL156 ?CIN146))
(if(eq ?CIN146 NULL)
then
(bind ?CIN146 FALSE)
)
)
(bind ?CIL157 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL157) )
then
(bind ?CIN147 TRUE)
else
(bind ?CIN147 NULL)
(bind ?CIN147 (AddOrNot ?CIL157 ?CIN147))
(if(eq ?CIN147 NULL)
then
(bind ?CIN147 FALSE)
)
)
(bind ?CIL158 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL158) )
then
(bind ?CIN148 TRUE)
else
(bind ?CIN148 NULL)
(bind ?CIN148 (AddOrNot ?CIL158 ?CIN148))
(if(eq ?CIN148 NULL)
then
(bind ?CIN148 FALSE)
)
)
(bind ?CIL159 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL159) )
then
(bind ?CIN149 TRUE)
else
(bind ?CIN149 NULL)
(bind ?CIN149 (AddOrNot ?CIL159 ?CIN149))
(if(eq ?CIN149 NULL)
then
(bind ?CIN149 FALSE)
)
)
(if
(and (Transform ?CIN140)  (Transform ?CIN141)  (Transform ?CIN142)  (Transform ?CIN143) )
then
(bind ?CIN130 TRUE)
else
(bind ?CIN130 NULL)
(bind ?CIN130 (AddOrNot ?CIN140 ?CIN130))
(bind ?CIN130 (AddOrNot ?CIN141 ?CIN130))
(bind ?CIN130 (AddOrNot ?CIN142 ?CIN130))
(bind ?CIN130 (AddOrNot ?CIN143 ?CIN130))
(if(eq ?CIN130 NULL)
then
(bind ?CIN130 FALSE)
)
)
(bind ?CIL140 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(and (Transform ?CIL140)  (Transform ?CIN144)  (Transform ?CIN145)  (Transform ?CIN146) )
then
(bind ?CIN131 TRUE)
else
(bind ?CIN131 NULL)
(bind ?CIN131 (AddOrNot ?CIL140 ?CIN131))
(bind ?CIN131 (AddOrNot ?CIN144 ?CIN131))
(bind ?CIN131 (AddOrNot ?CIN145 ?CIN131))
(bind ?CIN131 (AddOrNot ?CIN146 ?CIN131))
(if(eq ?CIN131 NULL)
then
(bind ?CIN131 FALSE)
)
)
(bind ?CIL141 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(and (Transform ?CIL141)  (Transform ?CIN147)  (Transform ?CIN148)  (Transform ?CIN149) )
then
(bind ?CIN132 TRUE)
else
(bind ?CIN132 NULL)
(bind ?CIN132 (AddOrNot ?CIL141 ?CIN132))
(bind ?CIN132 (AddOrNot ?CIN147 ?CIN132))
(bind ?CIN132 (AddOrNot ?CIN148 ?CIN132))
(bind ?CIN132 (AddOrNot ?CIN149 ?CIN132))
(if(eq ?CIN132 NULL)
then
(bind ?CIN132 FALSE)
)
)
(bind ?CIL130 (Leaf equals ?Worsen_By_Physicial_Activity Yes Worsen_By_Physicial_Activity))
(if
(not (Transform ?CIL130) )
then
(bind ?CIN120 TRUE)
else
(bind ?CIN120 NULL)
(bind ?CIN120 (AddOrNot ?CIL130 ?CIN120))
(if(eq ?CIN120 NULL)
then
(bind ?CIN120 FALSE)
)
)
(if
(or (Transform ?CIN130)  (Transform ?CIN131)  (Transform ?CIN132) )
then
(bind ?CIN121 TRUE)
else
(bind ?CIN121 NULL)
(bind ?CIN121 (AddOrNot ?CIN130 ?CIN121))
(bind ?CIN121 (AddOrNot ?CIN131 ?CIN121))
(bind ?CIN121 (AddOrNot ?CIN132 ?CIN121))
(if(eq ?CIN121 NULL)
then
(bind ?CIN121 FALSE)
)
)
(if
(and (Transform ?CIN120)  (Transform ?CIN121) )
then
(bind ?CIN110 TRUE)
else
(bind ?CIN110 NULL)
(bind ?CIN110 (AddOrNot ?CIN120 ?CIN110))
(bind ?CIN110 (AddOrNot ?CIN121 ?CIN110))
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

(bind ?CIL250 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL250) )
then
(bind ?CIN240 TRUE)
else
(bind ?CIN240 NULL)
(bind ?CIN240 (AddOrNot ?CIL250 ?CIN240))
(if(eq ?CIN240 NULL)
then
(bind ?CIN240 FALSE)
)
)
(bind ?CIL251 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL251) )
then
(bind ?CIN241 TRUE)
else
(bind ?CIN241 NULL)
(bind ?CIN241 (AddOrNot ?CIL251 ?CIN241))
(if(eq ?CIN241 NULL)
then
(bind ?CIN241 FALSE)
)
)
(bind ?CIL252 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL252) )
then
(bind ?CIN242 TRUE)
else
(bind ?CIN242 NULL)
(bind ?CIN242 (AddOrNot ?CIL252 ?CIN242))
(if(eq ?CIN242 NULL)
then
(bind ?CIN242 FALSE)
)
)
(bind ?CIL253 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL253) )
then
(bind ?CIN243 TRUE)
else
(bind ?CIN243 NULL)
(bind ?CIN243 (AddOrNot ?CIL253 ?CIN243))
(if(eq ?CIN243 NULL)
then
(bind ?CIN243 FALSE)
)
)
(bind ?CIL254 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL254) )
then
(bind ?CIN244 TRUE)
else
(bind ?CIN244 NULL)
(bind ?CIN244 (AddOrNot ?CIL254 ?CIN244))
(if(eq ?CIN244 NULL)
then
(bind ?CIN244 FALSE)
)
)
(bind ?CIL255 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL255) )
then
(bind ?CIN245 TRUE)
else
(bind ?CIN245 NULL)
(bind ?CIN245 (AddOrNot ?CIL255 ?CIN245))
(if(eq ?CIN245 NULL)
then
(bind ?CIN245 FALSE)
)
)
(bind ?CIL256 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL256) )
then
(bind ?CIN246 TRUE)
else
(bind ?CIN246 NULL)
(bind ?CIN246 (AddOrNot ?CIL256 ?CIN246))
(if(eq ?CIN246 NULL)
then
(bind ?CIN246 FALSE)
)
)
(bind ?CIL257 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL257) )
then
(bind ?CIN247 TRUE)
else
(bind ?CIN247 NULL)
(bind ?CIN247 (AddOrNot ?CIL257 ?CIN247))
(if(eq ?CIN247 NULL)
then
(bind ?CIN247 FALSE)
)
)
(bind ?CIL258 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL258) )
then
(bind ?CIN248 TRUE)
else
(bind ?CIN248 NULL)
(bind ?CIN248 (AddOrNot ?CIL258 ?CIN248))
(if(eq ?CIN248 NULL)
then
(bind ?CIN248 FALSE)
)
)
(bind ?CIL259 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL259) )
then
(bind ?CIN249 TRUE)
else
(bind ?CIN249 NULL)
(bind ?CIN249 (AddOrNot ?CIL259 ?CIN249))
(if(eq ?CIN249 NULL)
then
(bind ?CIN249 FALSE)
)
)
(if
(and (Transform ?CIN240)  (Transform ?CIN241)  (Transform ?CIN242)  (Transform ?CIN243) )
then
(bind ?CIN230 TRUE)
else
(bind ?CIN230 NULL)
(bind ?CIN230 (AddOrNot ?CIN240 ?CIN230))
(bind ?CIN230 (AddOrNot ?CIN241 ?CIN230))
(bind ?CIN230 (AddOrNot ?CIN242 ?CIN230))
(bind ?CIN230 (AddOrNot ?CIN243 ?CIN230))
(if(eq ?CIN230 NULL)
then
(bind ?CIN230 FALSE)
)
)
(bind ?CIL240 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(and (Transform ?CIL240)  (Transform ?CIN244)  (Transform ?CIN245)  (Transform ?CIN246) )
then
(bind ?CIN231 TRUE)
else
(bind ?CIN231 NULL)
(bind ?CIN231 (AddOrNot ?CIL240 ?CIN231))
(bind ?CIN231 (AddOrNot ?CIN244 ?CIN231))
(bind ?CIN231 (AddOrNot ?CIN245 ?CIN231))
(bind ?CIN231 (AddOrNot ?CIN246 ?CIN231))
(if(eq ?CIN231 NULL)
then
(bind ?CIN231 FALSE)
)
)
(bind ?CIL241 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(and (Transform ?CIL241)  (Transform ?CIN247)  (Transform ?CIN248)  (Transform ?CIN249) )
then
(bind ?CIN232 TRUE)
else
(bind ?CIN232 NULL)
(bind ?CIN232 (AddOrNot ?CIL241 ?CIN232))
(bind ?CIN232 (AddOrNot ?CIN247 ?CIN232))
(bind ?CIN232 (AddOrNot ?CIN248 ?CIN232))
(bind ?CIN232 (AddOrNot ?CIN249 ?CIN232))
(if(eq ?CIN232 NULL)
then
(bind ?CIN232 FALSE)
)
)
(if
(or (Transform ?CIN230)  (Transform ?CIN231)  (Transform ?CIN232) )
then
(bind ?CIN220 TRUE)
else
(bind ?CIN220 NULL)
(bind ?CIN220 (AddOrNot ?CIN230 ?CIN220))
(bind ?CIN220 (AddOrNot ?CIN231 ?CIN220))
(bind ?CIN220 (AddOrNot ?CIN232 ?CIN220))
(if(eq ?CIN220 NULL)
then
(bind ?CIN220 FALSE)
)
)
(bind ?CIL220 (Leaf equals ?Pressure_Pain Yes Pressure_Pain))
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

(bind ?CIL350 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL350) )
then
(bind ?CIN340 TRUE)
else
(bind ?CIN340 NULL)
(bind ?CIN340 (AddOrNot ?CIL350 ?CIN340))
(if(eq ?CIN340 NULL)
then
(bind ?CIN340 FALSE)
)
)
(bind ?CIL351 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL351) )
then
(bind ?CIN341 TRUE)
else
(bind ?CIN341 NULL)
(bind ?CIN341 (AddOrNot ?CIL351 ?CIN341))
(if(eq ?CIN341 NULL)
then
(bind ?CIN341 FALSE)
)
)
(bind ?CIL352 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL352) )
then
(bind ?CIN342 TRUE)
else
(bind ?CIN342 NULL)
(bind ?CIN342 (AddOrNot ?CIL352 ?CIN342))
(if(eq ?CIN342 NULL)
then
(bind ?CIN342 FALSE)
)
)
(bind ?CIL353 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL353) )
then
(bind ?CIN343 TRUE)
else
(bind ?CIN343 NULL)
(bind ?CIN343 (AddOrNot ?CIL353 ?CIN343))
(if(eq ?CIN343 NULL)
then
(bind ?CIN343 FALSE)
)
)
(bind ?CIL354 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL354) )
then
(bind ?CIN344 TRUE)
else
(bind ?CIN344 NULL)
(bind ?CIN344 (AddOrNot ?CIL354 ?CIN344))
(if(eq ?CIN344 NULL)
then
(bind ?CIN344 FALSE)
)
)
(bind ?CIL355 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL355) )
then
(bind ?CIN345 TRUE)
else
(bind ?CIN345 NULL)
(bind ?CIN345 (AddOrNot ?CIL355 ?CIN345))
(if(eq ?CIN345 NULL)
then
(bind ?CIN345 FALSE)
)
)
(bind ?CIL356 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL356) )
then
(bind ?CIN346 TRUE)
else
(bind ?CIN346 NULL)
(bind ?CIN346 (AddOrNot ?CIL356 ?CIN346))
(if(eq ?CIN346 NULL)
then
(bind ?CIN346 FALSE)
)
)
(bind ?CIL357 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL357) )
then
(bind ?CIN347 TRUE)
else
(bind ?CIN347 NULL)
(bind ?CIN347 (AddOrNot ?CIL357 ?CIN347))
(if(eq ?CIN347 NULL)
then
(bind ?CIN347 FALSE)
)
)
(bind ?CIL358 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL358) )
then
(bind ?CIN348 TRUE)
else
(bind ?CIN348 NULL)
(bind ?CIN348 (AddOrNot ?CIL358 ?CIN348))
(if(eq ?CIN348 NULL)
then
(bind ?CIN348 FALSE)
)
)
(bind ?CIL359 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL359) )
then
(bind ?CIN349 TRUE)
else
(bind ?CIN349 NULL)
(bind ?CIN349 (AddOrNot ?CIL359 ?CIN349))
(if(eq ?CIN349 NULL)
then
(bind ?CIN349 FALSE)
)
)
(if
(and (Transform ?CIN340)  (Transform ?CIN341)  (Transform ?CIN342)  (Transform ?CIN343) )
then
(bind ?CIN330 TRUE)
else
(bind ?CIN330 NULL)
(bind ?CIN330 (AddOrNot ?CIN340 ?CIN330))
(bind ?CIN330 (AddOrNot ?CIN341 ?CIN330))
(bind ?CIN330 (AddOrNot ?CIN342 ?CIN330))
(bind ?CIN330 (AddOrNot ?CIN343 ?CIN330))
(if(eq ?CIN330 NULL)
then
(bind ?CIN330 FALSE)
)
)
(bind ?CIL340 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(and (Transform ?CIL340)  (Transform ?CIN344)  (Transform ?CIN345)  (Transform ?CIN346) )
then
(bind ?CIN331 TRUE)
else
(bind ?CIN331 NULL)
(bind ?CIN331 (AddOrNot ?CIL340 ?CIN331))
(bind ?CIN331 (AddOrNot ?CIN344 ?CIN331))
(bind ?CIN331 (AddOrNot ?CIN345 ?CIN331))
(bind ?CIN331 (AddOrNot ?CIN346 ?CIN331))
(if(eq ?CIN331 NULL)
then
(bind ?CIN331 FALSE)
)
)
(bind ?CIL341 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(and (Transform ?CIL341)  (Transform ?CIN347)  (Transform ?CIN348)  (Transform ?CIN349) )
then
(bind ?CIN332 TRUE)
else
(bind ?CIN332 NULL)
(bind ?CIN332 (AddOrNot ?CIL341 ?CIN332))
(bind ?CIN332 (AddOrNot ?CIN347 ?CIN332))
(bind ?CIN332 (AddOrNot ?CIN348 ?CIN332))
(bind ?CIN332 (AddOrNot ?CIN349 ?CIN332))
(if(eq ?CIN332 NULL)
then
(bind ?CIN332 FALSE)
)
)
(if
(or (Transform ?CIN330)  (Transform ?CIN331)  (Transform ?CIN332) )
then
(bind ?CIN320 TRUE)
else
(bind ?CIN320 NULL)
(bind ?CIN320 (AddOrNot ?CIN330 ?CIN320))
(bind ?CIN320 (AddOrNot ?CIN331 ?CIN320))
(bind ?CIN320 (AddOrNot ?CIN332 ?CIN320))
(if(eq ?CIN320 NULL)
then
(bind ?CIN320 FALSE)
)
)
(bind ?CIL320 (Leaf equals ?Bi_Pain Yes Bi_Pain))
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
(if(NotifyOrNot <= ?Threshhold 1 ?ShortData ?filepath Headache_Class40002)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(Recommendation "其他类型的头痛")
(OperateFact "Headache_Diagnosis" "Other_Headache")
(FactUsed "Slight" "Middle" "Discust" "Thrust" "Fire_Of_Light" "Fair_Of_Sound" "Worsen_By_Physicial_Activity" "Pressure_Pain" "Bi_Pain")
)
)


(defrule MS_Headache_Class40002_1
(filepath ?filepath)
(Bi_Pain ?Bi_Pain)
(Discust ?Discust)
(Thrust ?Thrust)
(Fire_Of_Light ?Fire_Of_Light)
(Fair_Of_Sound ?Fair_Of_Sound)
(Pressure_Pain ?Pressure_Pain)
(Slight ?Slight)
(Middle ?Middle)
(Worsen_By_Physicial_Activity ?Worsen_By_Physicial_Activity)
=>
(bind ?Threshhold 0)

(bind ?CIL050 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL050) )
then
(bind ?CIN040 TRUE)
else
(bind ?CIN040 NULL)
(bind ?CIN040 (AddOrNot ?CIL050 ?CIN040))
(if(eq ?CIN040 NULL)
then
(bind ?CIN040 FALSE)
)
)
(bind ?CIL051 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL051) )
then
(bind ?CIN041 TRUE)
else
(bind ?CIN041 NULL)
(bind ?CIN041 (AddOrNot ?CIL051 ?CIN041))
(if(eq ?CIN041 NULL)
then
(bind ?CIN041 FALSE)
)
)
(bind ?CIL052 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL052) )
then
(bind ?CIN042 TRUE)
else
(bind ?CIN042 NULL)
(bind ?CIN042 (AddOrNot ?CIL052 ?CIN042))
(if(eq ?CIN042 NULL)
then
(bind ?CIN042 FALSE)
)
)
(bind ?CIL053 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL053) )
then
(bind ?CIN043 TRUE)
else
(bind ?CIN043 NULL)
(bind ?CIN043 (AddOrNot ?CIL053 ?CIN043))
(if(eq ?CIN043 NULL)
then
(bind ?CIN043 FALSE)
)
)
(bind ?CIL054 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL054) )
then
(bind ?CIN044 TRUE)
else
(bind ?CIN044 NULL)
(bind ?CIN044 (AddOrNot ?CIL054 ?CIN044))
(if(eq ?CIN044 NULL)
then
(bind ?CIN044 FALSE)
)
)
(bind ?CIL055 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL055) )
then
(bind ?CIN045 TRUE)
else
(bind ?CIN045 NULL)
(bind ?CIN045 (AddOrNot ?CIL055 ?CIN045))
(if(eq ?CIN045 NULL)
then
(bind ?CIN045 FALSE)
)
)
(bind ?CIL056 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL056) )
then
(bind ?CIN046 TRUE)
else
(bind ?CIN046 NULL)
(bind ?CIN046 (AddOrNot ?CIL056 ?CIN046))
(if(eq ?CIN046 NULL)
then
(bind ?CIN046 FALSE)
)
)
(bind ?CIL057 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL057) )
then
(bind ?CIN047 TRUE)
else
(bind ?CIN047 NULL)
(bind ?CIN047 (AddOrNot ?CIL057 ?CIN047))
(if(eq ?CIN047 NULL)
then
(bind ?CIN047 FALSE)
)
)
(bind ?CIL058 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL058) )
then
(bind ?CIN048 TRUE)
else
(bind ?CIN048 NULL)
(bind ?CIN048 (AddOrNot ?CIL058 ?CIN048))
(if(eq ?CIN048 NULL)
then
(bind ?CIN048 FALSE)
)
)
(bind ?CIL059 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL059) )
then
(bind ?CIN049 TRUE)
else
(bind ?CIN049 NULL)
(bind ?CIN049 (AddOrNot ?CIL059 ?CIN049))
(if(eq ?CIN049 NULL)
then
(bind ?CIN049 FALSE)
)
)
(if
(and (Transform ?CIN040)  (Transform ?CIN041)  (Transform ?CIN042)  (Transform ?CIN043) )
then
(bind ?CIN030 TRUE)
else
(bind ?CIN030 NULL)
(bind ?CIN030 (AddOrNot ?CIN040 ?CIN030))
(bind ?CIN030 (AddOrNot ?CIN041 ?CIN030))
(bind ?CIN030 (AddOrNot ?CIN042 ?CIN030))
(bind ?CIN030 (AddOrNot ?CIN043 ?CIN030))
(if(eq ?CIN030 NULL)
then
(bind ?CIN030 FALSE)
)
)
(bind ?CIL040 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(and (Transform ?CIL040)  (Transform ?CIN044)  (Transform ?CIN045)  (Transform ?CIN046) )
then
(bind ?CIN031 TRUE)
else
(bind ?CIN031 NULL)
(bind ?CIN031 (AddOrNot ?CIL040 ?CIN031))
(bind ?CIN031 (AddOrNot ?CIN044 ?CIN031))
(bind ?CIN031 (AddOrNot ?CIN045 ?CIN031))
(bind ?CIN031 (AddOrNot ?CIN046 ?CIN031))
(if(eq ?CIN031 NULL)
then
(bind ?CIN031 FALSE)
)
)
(bind ?CIL041 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(and (Transform ?CIL041)  (Transform ?CIN047)  (Transform ?CIN048)  (Transform ?CIN049) )
then
(bind ?CIN032 TRUE)
else
(bind ?CIN032 NULL)
(bind ?CIN032 (AddOrNot ?CIL041 ?CIN032))
(bind ?CIN032 (AddOrNot ?CIN047 ?CIN032))
(bind ?CIN032 (AddOrNot ?CIN048 ?CIN032))
(bind ?CIN032 (AddOrNot ?CIN049 ?CIN032))
(if(eq ?CIN032 NULL)
then
(bind ?CIN032 FALSE)
)
)
(if
(or (Transform ?CIN030)  (Transform ?CIN031)  (Transform ?CIN032) )
then
(bind ?CIN020 TRUE)
else
(bind ?CIN020 NULL)
(bind ?CIN020 (AddOrNot ?CIN030 ?CIN020))
(bind ?CIN020 (AddOrNot ?CIN031 ?CIN020))
(bind ?CIN020 (AddOrNot ?CIN032 ?CIN020))
(if(eq ?CIN020 NULL)
then
(bind ?CIN020 FALSE)
)
)
(bind ?CIL020 (Leaf equals ?Bi_Pain Yes Bi_Pain))
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

(bind ?CIL150 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL150) )
then
(bind ?CIN140 TRUE)
else
(bind ?CIN140 NULL)
(bind ?CIN140 (AddOrNot ?CIL150 ?CIN140))
(if(eq ?CIN140 NULL)
then
(bind ?CIN140 FALSE)
)
)
(bind ?CIL151 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL151) )
then
(bind ?CIN141 TRUE)
else
(bind ?CIN141 NULL)
(bind ?CIN141 (AddOrNot ?CIL151 ?CIN141))
(if(eq ?CIN141 NULL)
then
(bind ?CIN141 FALSE)
)
)
(bind ?CIL152 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL152) )
then
(bind ?CIN142 TRUE)
else
(bind ?CIN142 NULL)
(bind ?CIN142 (AddOrNot ?CIL152 ?CIN142))
(if(eq ?CIN142 NULL)
then
(bind ?CIN142 FALSE)
)
)
(bind ?CIL153 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL153) )
then
(bind ?CIN143 TRUE)
else
(bind ?CIN143 NULL)
(bind ?CIN143 (AddOrNot ?CIL153 ?CIN143))
(if(eq ?CIN143 NULL)
then
(bind ?CIN143 FALSE)
)
)
(bind ?CIL154 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL154) )
then
(bind ?CIN144 TRUE)
else
(bind ?CIN144 NULL)
(bind ?CIN144 (AddOrNot ?CIL154 ?CIN144))
(if(eq ?CIN144 NULL)
then
(bind ?CIN144 FALSE)
)
)
(bind ?CIL155 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL155) )
then
(bind ?CIN145 TRUE)
else
(bind ?CIN145 NULL)
(bind ?CIN145 (AddOrNot ?CIL155 ?CIN145))
(if(eq ?CIN145 NULL)
then
(bind ?CIN145 FALSE)
)
)
(bind ?CIL156 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL156) )
then
(bind ?CIN146 TRUE)
else
(bind ?CIN146 NULL)
(bind ?CIN146 (AddOrNot ?CIL156 ?CIN146))
(if(eq ?CIN146 NULL)
then
(bind ?CIN146 FALSE)
)
)
(bind ?CIL157 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL157) )
then
(bind ?CIN147 TRUE)
else
(bind ?CIN147 NULL)
(bind ?CIN147 (AddOrNot ?CIL157 ?CIN147))
(if(eq ?CIN147 NULL)
then
(bind ?CIN147 FALSE)
)
)
(bind ?CIL158 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL158) )
then
(bind ?CIN148 TRUE)
else
(bind ?CIN148 NULL)
(bind ?CIN148 (AddOrNot ?CIL158 ?CIN148))
(if(eq ?CIN148 NULL)
then
(bind ?CIN148 FALSE)
)
)
(bind ?CIL159 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL159) )
then
(bind ?CIN149 TRUE)
else
(bind ?CIN149 NULL)
(bind ?CIN149 (AddOrNot ?CIL159 ?CIN149))
(if(eq ?CIN149 NULL)
then
(bind ?CIN149 FALSE)
)
)
(if
(and (Transform ?CIN140)  (Transform ?CIN141)  (Transform ?CIN142)  (Transform ?CIN143) )
then
(bind ?CIN130 TRUE)
else
(bind ?CIN130 NULL)
(bind ?CIN130 (AddOrNot ?CIN140 ?CIN130))
(bind ?CIN130 (AddOrNot ?CIN141 ?CIN130))
(bind ?CIN130 (AddOrNot ?CIN142 ?CIN130))
(bind ?CIN130 (AddOrNot ?CIN143 ?CIN130))
(if(eq ?CIN130 NULL)
then
(bind ?CIN130 FALSE)
)
)
(bind ?CIL140 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(and (Transform ?CIL140)  (Transform ?CIN144)  (Transform ?CIN145)  (Transform ?CIN146) )
then
(bind ?CIN131 TRUE)
else
(bind ?CIN131 NULL)
(bind ?CIN131 (AddOrNot ?CIL140 ?CIN131))
(bind ?CIN131 (AddOrNot ?CIN144 ?CIN131))
(bind ?CIN131 (AddOrNot ?CIN145 ?CIN131))
(bind ?CIN131 (AddOrNot ?CIN146 ?CIN131))
(if(eq ?CIN131 NULL)
then
(bind ?CIN131 FALSE)
)
)
(bind ?CIL141 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(and (Transform ?CIL141)  (Transform ?CIN147)  (Transform ?CIN148)  (Transform ?CIN149) )
then
(bind ?CIN132 TRUE)
else
(bind ?CIN132 NULL)
(bind ?CIN132 (AddOrNot ?CIL141 ?CIN132))
(bind ?CIN132 (AddOrNot ?CIN147 ?CIN132))
(bind ?CIN132 (AddOrNot ?CIN148 ?CIN132))
(bind ?CIN132 (AddOrNot ?CIN149 ?CIN132))
(if(eq ?CIN132 NULL)
then
(bind ?CIN132 FALSE)
)
)
(if
(or (Transform ?CIN130)  (Transform ?CIN131)  (Transform ?CIN132) )
then
(bind ?CIN120 TRUE)
else
(bind ?CIN120 NULL)
(bind ?CIN120 (AddOrNot ?CIN130 ?CIN120))
(bind ?CIN120 (AddOrNot ?CIN131 ?CIN120))
(bind ?CIN120 (AddOrNot ?CIN132 ?CIN120))
(if(eq ?CIN120 NULL)
then
(bind ?CIN120 FALSE)
)
)
(bind ?CIL120 (Leaf equals ?Pressure_Pain Yes Pressure_Pain))
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

(bind ?CIL250 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL250) )
then
(bind ?CIN240 TRUE)
else
(bind ?CIN240 NULL)
(bind ?CIN240 (AddOrNot ?CIL250 ?CIN240))
(if(eq ?CIN240 NULL)
then
(bind ?CIN240 FALSE)
)
)
(bind ?CIL251 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL251) )
then
(bind ?CIN241 TRUE)
else
(bind ?CIN241 NULL)
(bind ?CIN241 (AddOrNot ?CIL251 ?CIN241))
(if(eq ?CIN241 NULL)
then
(bind ?CIN241 FALSE)
)
)
(bind ?CIL252 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL252) )
then
(bind ?CIN242 TRUE)
else
(bind ?CIN242 NULL)
(bind ?CIN242 (AddOrNot ?CIL252 ?CIN242))
(if(eq ?CIN242 NULL)
then
(bind ?CIN242 FALSE)
)
)
(bind ?CIL253 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL253) )
then
(bind ?CIN243 TRUE)
else
(bind ?CIN243 NULL)
(bind ?CIN243 (AddOrNot ?CIL253 ?CIN243))
(if(eq ?CIN243 NULL)
then
(bind ?CIN243 FALSE)
)
)
(bind ?CIL254 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL254) )
then
(bind ?CIN244 TRUE)
else
(bind ?CIN244 NULL)
(bind ?CIN244 (AddOrNot ?CIL254 ?CIN244))
(if(eq ?CIN244 NULL)
then
(bind ?CIN244 FALSE)
)
)
(bind ?CIL255 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL255) )
then
(bind ?CIN245 TRUE)
else
(bind ?CIN245 NULL)
(bind ?CIN245 (AddOrNot ?CIL255 ?CIN245))
(if(eq ?CIN245 NULL)
then
(bind ?CIN245 FALSE)
)
)
(bind ?CIL256 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL256) )
then
(bind ?CIN246 TRUE)
else
(bind ?CIN246 NULL)
(bind ?CIN246 (AddOrNot ?CIL256 ?CIN246))
(if(eq ?CIN246 NULL)
then
(bind ?CIN246 FALSE)
)
)
(bind ?CIL257 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL257) )
then
(bind ?CIN247 TRUE)
else
(bind ?CIN247 NULL)
(bind ?CIN247 (AddOrNot ?CIL257 ?CIN247))
(if(eq ?CIN247 NULL)
then
(bind ?CIN247 FALSE)
)
)
(bind ?CIL258 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL258) )
then
(bind ?CIN248 TRUE)
else
(bind ?CIN248 NULL)
(bind ?CIN248 (AddOrNot ?CIL258 ?CIN248))
(if(eq ?CIN248 NULL)
then
(bind ?CIN248 FALSE)
)
)
(bind ?CIL259 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL259) )
then
(bind ?CIN249 TRUE)
else
(bind ?CIN249 NULL)
(bind ?CIN249 (AddOrNot ?CIL259 ?CIN249))
(if(eq ?CIN249 NULL)
then
(bind ?CIN249 FALSE)
)
)
(if
(and (Transform ?CIN240)  (Transform ?CIN241)  (Transform ?CIN242)  (Transform ?CIN243) )
then
(bind ?CIN230 TRUE)
else
(bind ?CIN230 NULL)
(bind ?CIN230 (AddOrNot ?CIN240 ?CIN230))
(bind ?CIN230 (AddOrNot ?CIN241 ?CIN230))
(bind ?CIN230 (AddOrNot ?CIN242 ?CIN230))
(bind ?CIN230 (AddOrNot ?CIN243 ?CIN230))
(if(eq ?CIN230 NULL)
then
(bind ?CIN230 FALSE)
)
)
(bind ?CIL240 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(and (Transform ?CIL240)  (Transform ?CIN244)  (Transform ?CIN245)  (Transform ?CIN246) )
then
(bind ?CIN231 TRUE)
else
(bind ?CIN231 NULL)
(bind ?CIN231 (AddOrNot ?CIL240 ?CIN231))
(bind ?CIN231 (AddOrNot ?CIN244 ?CIN231))
(bind ?CIN231 (AddOrNot ?CIN245 ?CIN231))
(bind ?CIN231 (AddOrNot ?CIN246 ?CIN231))
(if(eq ?CIN231 NULL)
then
(bind ?CIN231 FALSE)
)
)
(bind ?CIL241 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(and (Transform ?CIL241)  (Transform ?CIN247)  (Transform ?CIN248)  (Transform ?CIN249) )
then
(bind ?CIN232 TRUE)
else
(bind ?CIN232 NULL)
(bind ?CIN232 (AddOrNot ?CIL241 ?CIN232))
(bind ?CIN232 (AddOrNot ?CIN247 ?CIN232))
(bind ?CIN232 (AddOrNot ?CIN248 ?CIN232))
(bind ?CIN232 (AddOrNot ?CIN249 ?CIN232))
(if(eq ?CIN232 NULL)
then
(bind ?CIN232 FALSE)
)
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
(if
(or (Transform ?CIN230)  (Transform ?CIN231)  (Transform ?CIN232) )
then
(bind ?CIN221 TRUE)
else
(bind ?CIN221 NULL)
(bind ?CIN221 (AddOrNot ?CIN230 ?CIN221))
(bind ?CIN221 (AddOrNot ?CIN231 ?CIN221))
(bind ?CIN221 (AddOrNot ?CIN232 ?CIN221))
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

(bind ?CIL350 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL350) )
then
(bind ?CIN340 TRUE)
else
(bind ?CIN340 NULL)
(bind ?CIN340 (AddOrNot ?CIL350 ?CIN340))
(if(eq ?CIN340 NULL)
then
(bind ?CIN340 FALSE)
)
)
(bind ?CIL351 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL351) )
then
(bind ?CIN341 TRUE)
else
(bind ?CIN341 NULL)
(bind ?CIN341 (AddOrNot ?CIL351 ?CIN341))
(if(eq ?CIN341 NULL)
then
(bind ?CIN341 FALSE)
)
)
(bind ?CIL352 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL352) )
then
(bind ?CIN342 TRUE)
else
(bind ?CIN342 NULL)
(bind ?CIN342 (AddOrNot ?CIL352 ?CIN342))
(if(eq ?CIN342 NULL)
then
(bind ?CIN342 FALSE)
)
)
(bind ?CIL353 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL353) )
then
(bind ?CIN343 TRUE)
else
(bind ?CIN343 NULL)
(bind ?CIN343 (AddOrNot ?CIL353 ?CIN343))
(if(eq ?CIN343 NULL)
then
(bind ?CIN343 FALSE)
)
)
(bind ?CIL354 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL354) )
then
(bind ?CIN344 TRUE)
else
(bind ?CIN344 NULL)
(bind ?CIN344 (AddOrNot ?CIL354 ?CIN344))
(if(eq ?CIN344 NULL)
then
(bind ?CIN344 FALSE)
)
)
(bind ?CIL355 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(not (Transform ?CIL355) )
then
(bind ?CIN345 TRUE)
else
(bind ?CIN345 NULL)
(bind ?CIN345 (AddOrNot ?CIL355 ?CIN345))
(if(eq ?CIN345 NULL)
then
(bind ?CIN345 FALSE)
)
)
(bind ?CIL356 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL356) )
then
(bind ?CIN346 TRUE)
else
(bind ?CIN346 NULL)
(bind ?CIN346 (AddOrNot ?CIL356 ?CIN346))
(if(eq ?CIN346 NULL)
then
(bind ?CIN346 FALSE)
)
)
(bind ?CIL357 (Leaf equals ?Thrust Yes Thrust))
(if
(not (Transform ?CIL357) )
then
(bind ?CIN347 TRUE)
else
(bind ?CIN347 NULL)
(bind ?CIN347 (AddOrNot ?CIL357 ?CIN347))
(if(eq ?CIN347 NULL)
then
(bind ?CIN347 FALSE)
)
)
(bind ?CIL358 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(not (Transform ?CIL358) )
then
(bind ?CIN348 TRUE)
else
(bind ?CIN348 NULL)
(bind ?CIN348 (AddOrNot ?CIL358 ?CIN348))
(if(eq ?CIN348 NULL)
then
(bind ?CIN348 FALSE)
)
)
(bind ?CIL359 (Leaf equals ?Discust Yes Discust))
(if
(not (Transform ?CIL359) )
then
(bind ?CIN349 TRUE)
else
(bind ?CIN349 NULL)
(bind ?CIN349 (AddOrNot ?CIL359 ?CIN349))
(if(eq ?CIN349 NULL)
then
(bind ?CIN349 FALSE)
)
)
(if
(and (Transform ?CIN340)  (Transform ?CIN341)  (Transform ?CIN342)  (Transform ?CIN343) )
then
(bind ?CIN330 TRUE)
else
(bind ?CIN330 NULL)
(bind ?CIN330 (AddOrNot ?CIN340 ?CIN330))
(bind ?CIN330 (AddOrNot ?CIN341 ?CIN330))
(bind ?CIN330 (AddOrNot ?CIN342 ?CIN330))
(bind ?CIN330 (AddOrNot ?CIN343 ?CIN330))
(if(eq ?CIN330 NULL)
then
(bind ?CIN330 FALSE)
)
)
(bind ?CIL340 (Leaf equals ?Fair_Of_Sound Yes Fair_Of_Sound))
(if
(and (Transform ?CIL340)  (Transform ?CIN344)  (Transform ?CIN345)  (Transform ?CIN346) )
then
(bind ?CIN331 TRUE)
else
(bind ?CIN331 NULL)
(bind ?CIN331 (AddOrNot ?CIL340 ?CIN331))
(bind ?CIN331 (AddOrNot ?CIN344 ?CIN331))
(bind ?CIN331 (AddOrNot ?CIN345 ?CIN331))
(bind ?CIN331 (AddOrNot ?CIN346 ?CIN331))
(if(eq ?CIN331 NULL)
then
(bind ?CIN331 FALSE)
)
)
(bind ?CIL341 (Leaf equals ?Fire_Of_Light Yes Fire_Of_Light))
(if
(and (Transform ?CIL341)  (Transform ?CIN347)  (Transform ?CIN348)  (Transform ?CIN349) )
then
(bind ?CIN332 TRUE)
else
(bind ?CIN332 NULL)
(bind ?CIN332 (AddOrNot ?CIL341 ?CIN332))
(bind ?CIN332 (AddOrNot ?CIN347 ?CIN332))
(bind ?CIN332 (AddOrNot ?CIN348 ?CIN332))
(bind ?CIN332 (AddOrNot ?CIN349 ?CIN332))
(if(eq ?CIN332 NULL)
then
(bind ?CIN332 FALSE)
)
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
(if
(or (Transform ?CIN330)  (Transform ?CIN331)  (Transform ?CIN332) )
then
(bind ?CIN321 TRUE)
else
(bind ?CIN321 NULL)
(bind ?CIN321 (AddOrNot ?CIN330 ?CIN321))
(bind ?CIN321 (AddOrNot ?CIN331 ?CIN321))
(bind ?CIN321 (AddOrNot ?CIN332 ?CIN321))
(if(eq ?CIN321 NULL)
then
(bind ?CIN321 FALSE)
)
)
(if
(and (Transform ?CIN320)  (Transform ?CIN321) )
then
(bind ?CIN310 TRUE)
else
(bind ?CIN310 NULL)
(bind ?CIN310 (AddOrNot ?CIN320 ?CIN310))
(bind ?CIN310 (AddOrNot ?CIN321 ?CIN310))
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
(if(NotifyOrNot >= ?Threshhold 2 ?ShortData ?filepath Headache_Class40002)
then
(undefrule *)
(InterpretationIndex "NO_VALUE")
(load (str-cat ?filepath "MS_Headache_Class140037.clp"))
(FactUsed "Bi_Pain" "Discust" "Thrust" "Fire_Of_Light" "Fair_Of_Sound" "Pressure_Pain" "Slight" "Middle" "Worsen_By_Physicial_Activity")
)
)
