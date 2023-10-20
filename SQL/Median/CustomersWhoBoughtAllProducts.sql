#SELECT *
SELECT b.customer_id 
FROM Product AS a
LEFT JOIN Customer AS b ON a.product_key = b.product_key
#ID內重複符合的項目不重複累計
GROUP BY b.customer_id
# 比對正確的數量，不重複的應該跟配對到的一樣多
HAVING COUNT(DISTINCT b.product_key) = (SELECT COUNT(*) FROM Product);