select Department,Employee,salary
FROM
(
  select t2.name as Department, t1.name as Employee, t1.salary as salary,
  # 按照部門來分區，之後按照薪水高低排名
  DENSE_RANK() OVER (PARTITION BY t2.name ORDER BY t1.salary DESC) as rank_num
  from Employee as t1
  left join Department as t2 on t1.departmentId = t2.id 
) as SUB
where rank_num <=3