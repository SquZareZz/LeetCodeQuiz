select ROUND(SUM(tiv_2016),2) as tiv_2016 
FROM(
  #SELECT 符合條件 tiv_2015 相同價值的項目
select DISTINCT A.*
      from Insurance as A
      JOIN Insurance as B ON A.tiv_2015 = B.tiv_2015 AND B.PID != A.PID
      ) as SUB
LEFT JOIN 
  (select DISTINCT A.PID 
  FROM Insurance AS A 
  JOIN Insurance AS B ON (B.PID != A.PID AND B.LAT = A.LAT AND B.LON = A.LON)) as B 
ON SUB.PID=B.PID
WHERE B.PID IS NULL