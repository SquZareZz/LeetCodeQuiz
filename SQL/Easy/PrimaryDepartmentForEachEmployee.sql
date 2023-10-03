SELECT 
    employee_id,
CASE 
    #如果 primary_flag = 'Y' 超過零項的話
    WHEN SUM(primary_flag = 'Y') > 0  THEN MAX(CASE WHEN primary_flag = 'Y' THEN department_id ELSE NULL END)
    WHEN COUNT(department_id) = 1 THEN department_id
    ELSE NULL
    END AS department_id
FROM 
    Employee
GROUP BY 
    employee_id
    #兩條件都不符合的話，不選取    
HAVING 
    SUM(primary_flag = 'Y') = 1 OR COUNT(DISTINCT department_id) = 1;