# Write your MySQL query statement below
# 其實只要把兩種可能共用進同一行，再計算數量即可
# 因為不會有自己給自己發好友邀請的狀況，也不會有重複邀請(1=>2，2=>1)的狀況
SELECT id, COUNT(*) as num
# 結合兩行成新表
FROM (
    SELECT requester_id as id FROM RequestAccepted 
    UNION ALL
    SELECT accepter_id as id FROM RequestAccepted 
) AS combined_table
GROUP BY id
ORDER BY num DESC
#只找最高那一筆
LIMIT 1;