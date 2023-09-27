# Write your MySQL query statement below
# 首先要計算每個不同的 query_name 的總數
# 接著，因為有了 query_name 的總數叫 TotalByQueryName.Total，所以可以算 quality 的數值
# 最後，以 rating < 3的條件(Case) 來統計 poor_query_percentage
SELECT Q.query_name,
ROUND(SUM(rating / position) / TotalByQueryName.Total,2) AS quality,
ROUND(100 * SUM(CASE WHEN rating < 3 THEN 1 ELSE 0 END) / TotalByQueryName.Total,2) AS poor_query_percentage
FROM Queries as Q
INNER JOIN
(SELECT Q.query_name, COUNT(*) AS Total FROM Queries as Q GROUP BY Q.query_name) AS TotalByQueryName
ON Q.query_name = TotalByQueryName.query_name
GROUP BY Q.query_name;