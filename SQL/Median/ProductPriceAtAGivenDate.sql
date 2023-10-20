# 最後選擇需要的欄位，ifnull+max 判定最高存在的金額
select product_id, ifnull(max(b.new_price),10) price
from Products a left join 
(
    # 首先選擇日期 <= '2019-08-16'，接著在這條件下排名
    select *, rank() over (partition by product_id order by change_date desc) rk
    from Products
    where change_date <= '2019-08-16'
)
# using 是為了省略掉共同條件 a.product_id = b.product_id  
b using(product_id) 
# rk is null 是因為可能有補10的項目
where rk=1 or rk is null
group by product_id