SELECT DISTINCT num as ConsecutiveNums
FROM
(
  SELECT *
  FROM (
      SELECT 
          id,
          num,
          # LAG = 上一項
          LAG(num) OVER (ORDER BY id) as LAG_NUM,
          # LEAD = 後一項
          LEAD(num) OVER (ORDER BY id) as LEAD_NUM
      FROM Logs
  ) as t1
  # 用ID分類
  group by id
  # num=前項又=後項 => 選擇
  having num = LAG_NUM AND num = LEAD_NUM
) as T2