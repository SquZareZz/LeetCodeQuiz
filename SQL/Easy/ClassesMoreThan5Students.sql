#法1 INNER JOIN 比較慢
#SELECT A.class
#FROM Courses A
#INNER JOIN Courses B ON A.CLASS = B.CLASS AND A.student  <> B.student 
#GROUP BY A.CLASS
#HAVING COUNT(DISTINCT A.student) >= 5;

#法2
SELECT class
From
(SELECT class, COUNT(DISTINCT student) AS student_count
  FROM Courses 
  GROUP BY class) As Sub
  where student_count>=5