# Write your MySQL query statement below
select P.project_id,
# COALESCE => 把NULL項重新設定
# ROUND => 四捨五入到小數點第二位
# SUM => 確保計算每一行的總和
# COUNT => 確保計算每個人的總和
COALESCE(ROUND(SUM(E.experience_years)/COUNT(E.employee_id),2),0) as average_years 
from Project as P
left join Employee as E on (P.employee_id = E.employee_id)
group by P.project_id