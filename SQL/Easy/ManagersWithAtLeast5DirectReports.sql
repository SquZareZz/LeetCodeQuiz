select E1.name 
from Employee as E1
INNER join 
(select managerId,
Count(managerId) as CountId 
from Employee 
group by managerId having CountId>=5) as E2 on E1.id=E2.managerId 