SELECT S.student_id, S.student_name, Sub.subject_name, COUNT(E.subject_name) AS attended_exams
#如果 Examinations 的 subject_name 有空值(1 NULL)的話，
#要改成 COALESCE(COUNT(E.subject_name)) 來回傳非NULL值
FROM Students as S
# CROSS JOIN 為組合兩表，A表長度為m*n、B表長度為x*y，得到的新表長度為(m+x)*(n*y)
# EX:1*3 & 1*3 CROSS JOIN=> 2*9
CROSS JOIN Subjects as Sub
#ID 和 SUBJECT 都配對
LEFT JOIN Examinations as E ON S.student_id = E.student_id AND Sub.subject_name = E.subject_name
GROUP BY S.student_id, S.student_name, Sub.subject_name
ORDER BY S.student_id, Sub.subject_name;