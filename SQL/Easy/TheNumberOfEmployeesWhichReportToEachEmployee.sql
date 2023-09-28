select A.employee_id ,A.name,
Count(distinct B.employee_id) as reports_count , 
ROUND(Sum(B.age) / Count(B.employee_id),0) as average_age  
from Employees as A
inner join Employees as B on A.employee_id = B.reports_to 
GROUP BY A.employee_id
order by A.employee_id