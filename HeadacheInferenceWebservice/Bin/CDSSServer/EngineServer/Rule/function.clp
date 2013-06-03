;判断叶子节点的值，如果其事实不存在，返回事实名
(deffunction Leaf(?Relation ?Fact ?FactValue ?FactName)
(
	if(eq ?Fact NULL)
		then
		(return ?FactName)
		else
		(
			switch ?Relation
				(case equals then
					(return (eq ?Fact ?FactValue))
				)
				(case > then
					(return (> ?Fact ?FactValue))
				)
				(case < then
					(return (< ?Fact ?FactValue))
				)
				(case >= then
					(return (>= ?Fact ?FactValue))
				)
				(case <= then
					(return (<= ?Fact ?FactValue))
				)
		)
)
)

;如果字符串值不是TRUE或者FALSE，则将其转化为FALSE
(deffunction Transform(?CValue)
(
	if(eq ?CValue TRUE)
	then
	(return TRUE)
	else
	(return FALSE)
)
)

;检查是否缺少数据
(deffunction Check(?ShortData ?FilePath ?FileName)
(
	if(eq ?ShortData TRUE)
		then
		(return TRUE)
		else
		(if(eq ?ShortData FALSE)
			then
			(return TRUE)
			else
			;(printout t "short data:" ?ShortData crlf)
			(DataNotify ?ShortData)
			(FileLoadNotify (str-cat ?FilePath ?FileName) "DataNotify")
			(return FALSE)
		)
)
)

;比较结果和阈值的大小，并且判断是否需要检查是否缺少数据strict_rule_in
(deffunction NotifyOrNot(?Relation ?T ?TValue ?ShortData ?FilePath ?FileName)
(
	switch ?Relation
		(case equals then
			(if(> ?T ?TValue)
				then
				(return FALSE)
				else
				(if(eq ?T ?TValue)
					then
					(return (Check ?ShortData ?FilePath ?FileName))
					else
					(Check ?ShortData ?FilePath ?FileName)
					(return FALSE)
				)
			)
		)
		(case > then
			(if(> ?T ?TValue)
				then
				(return TRUE)
				else
				(Check ?ShortData ?FilePath ?FileName)
				(return FALSE)
			)
		)
		(case < then
			(if(>= ?T ?TValue)
				then
				(return FALSE)
				else
				(return (Check ?ShortData ?FilePath ?FileName))
			)
		)
		(case >= then
			(if(>= ?T ?TValue)
				then
				(return TRUE)
				else
				(Check ?ShortData ?FilePath ?FileName)
				(return FALSE)
			)
		)
		(case <= then
			(if(> ?T ?TValue)
				then
				(return FALSE)
				else
				(return (Check ?ShortData ?FilePath ?FileName))
			)
		)
)
)

;判断是否缺少数据,若缺少，则需要输出，若为true或者false，则用原值代替
(deffunction AddOrNot(?ShortData ?Output)
(
	if(eq ?ShortData TRUE)
		then
		(return ?Output)
		else
		(if(eq ?ShortData FALSE)
			then
			(return ?Output)
			else
			(return (str-cat ?Output "+" ?ShortData)) 
		)
)
)

(deffunction DataShortJudge(?InputData ?DataName)
(if (eq ?InputData NULL)
then
(DataNotify ?DataName)
(return FALSE)
else
(return TRUE)
)
)