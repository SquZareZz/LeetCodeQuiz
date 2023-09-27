select unique_id,name
from Employees LEFT JOIN EmployeeUNI ON Employees.id = EmployeeUNI.id;
#LEFT 是因為可能 NULL，沒有選擇對應不到的時候，改用 INNER