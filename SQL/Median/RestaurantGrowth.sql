#average_amount 要四捨五入到第二位
select visited_on,amount,ROUND(amount/7,2) as average_amount 
from(
    select visited_on,
    # SUM(amount)=>算一到七天資料 => SUM(SUM(amount)) 算不只一筆的一到七天資料
    # RANGE BETWEEN INTERVAL 6 DAY PRECEDING AND CURRENT ROW =>
    # 算今天與六天內的總合
    SUM(SUM(amount)) OVER(ORDER BY visited_on RANGE BETWEEN INTERVAL 6 DAY PRECEDING AND CURRENT ROW) AS amount
    from Customer 
    group by visited_on   
) as SUB1
GROUP BY visited_on
# visited_on 有六天時間差 => 涵蓋七天資料
#(select MIN(visited_on) from Customer) => 不重做的話 MIN 都是 GROUP BY 後的結果
HAVING DATEDIFF(visited_on, (select MIN(visited_on) from Customer)) >=6