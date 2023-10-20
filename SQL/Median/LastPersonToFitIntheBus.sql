# Write your MySQL query statement below
SELECT person_name 
FROM(
SELECT *,ROW_NUMBER() OVER (ORDER BY Total_Weight DESC) AS rn
from(
  select turn,
  person_name,
  # 計算總重量
  SUM(weight) OVER (ORDER BY turn) AS Total_Weight
  from Queue 
) as Count_Total_Weight
#只保留總重<=1000的項目
where Total_Weight<=1000
) as Rank_Weight
#只找總重最重的項目
where rn=1
