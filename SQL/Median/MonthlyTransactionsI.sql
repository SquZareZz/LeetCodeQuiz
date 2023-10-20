select 
#連接年月
CONCAT(YEAR(T.trans_date), '-', LPAD(MONTH(T.trans_date), 2, '0')) as month,
T.country,
Count(*) as trans_count,
SUM(T.state='approved') as approved_count,
SUM(amount) as trans_total_amount,
SUM(CASE WHEN T.state = 'approved' THEN amount ELSE 0 END) as approved_total_amount
from Transactions as T
# 年與月分別作條件，因為GROUP BY 子句中，只能使用已在列表中被定義的列名稱或者列的索引位置，所以不能用MONTH
group by YEAR(T.trans_date), MONTH(T.trans_date),T.country