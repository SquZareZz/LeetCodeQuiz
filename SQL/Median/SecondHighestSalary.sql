# 用 COALESCE 把空值轉成NULL
SELECT COALESCE
((select salary 
from 
(
    select salary,
    RANK() OVER (ORDER BY Salary DESC) AS Ranking
    from Employee
    # 薪水可能有等高的
    GROUP BY SALARY
) as TEMP
WHERE RANKING=2
LIMIT 1)) AS SecondHighestSalary