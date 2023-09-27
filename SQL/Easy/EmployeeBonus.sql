select Employee.name,Bonus.bonus
from Employee
Left join Bonus on (Employee.empId=Bonus.empId )
WHERE 1=1
and Bonus.bonus IS NULL OR Bonus.bonus < 1000