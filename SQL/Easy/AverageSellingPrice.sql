# Write your MySQL query statement below
select P.product_id,
# COALESCE => 把NULL項重新設定
# ROUND => 四捨五入到小數點第二位
# SUM => 確保計算每一行的總和
COALESCE(ROUND(SUM(P.price * U.units)/SUM(u.units),2),0) as average_price
from Prices as P
LEFT JOIN UnitsSold as U
#時間條件必須在一段時間內 => BETWEEN
ON (P.product_id  = U.product_id AND U.purchase_date Between P.start_date AND P.end_date )
GROUP BY P.product_id