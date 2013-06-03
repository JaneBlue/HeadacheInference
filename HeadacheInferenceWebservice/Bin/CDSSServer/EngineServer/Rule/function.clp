;�ж�Ҷ�ӽڵ��ֵ���������ʵ�����ڣ�������ʵ��
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

;����ַ���ֵ����TRUE����FALSE������ת��ΪFALSE
(deffunction Transform(?CValue)
(
	if(eq ?CValue TRUE)
	then
	(return TRUE)
	else
	(return FALSE)
)
)

;����Ƿ�ȱ������
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

;�ȽϽ������ֵ�Ĵ�С�������ж��Ƿ���Ҫ����Ƿ�ȱ������strict_rule_in
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

;�ж��Ƿ�ȱ������,��ȱ�٣�����Ҫ�������Ϊtrue����false������ԭֵ����
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