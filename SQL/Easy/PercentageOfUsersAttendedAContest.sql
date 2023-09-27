select Register.contest_id,
# ROUND(100*......,2) => 改成百分比
# COUNT(DISTINCT Register.user_id) => 統計不重複的 Register.contest_id
# UsersCount => 帶重做的表格
ROUND(100*COUNT(DISTINCT Register.user_id)/ UsersCount.total_user_count,2) as percentage
from Register 
# 重做一個原始資料的 ID 數量統計
INNER JOIN (SELECT COUNT(*) AS total_user_count FROM Users) AS UsersCount
# 根據 Register.contest_id 篩選
GROUP BY Register.contest_id
ORDER BY percentage DESC,contest_id