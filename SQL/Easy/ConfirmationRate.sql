# CASE 處理沒資料(NULL)的案例
# SUM 統計所有合規條件
select S.user_id, 
CASE 
  WHEN SUM(C.Action='confirmed')/COUNT(C.Action) >=0 THEN ROUND(SUM(C.Action='confirmed')/COUNT(C.Action),2)
  ELSE 0
  END as confirmation_rate
from Signups as S 
LEFT join Confirmations as C on S.user_id = C.user_id
GROUP BY S.user_id