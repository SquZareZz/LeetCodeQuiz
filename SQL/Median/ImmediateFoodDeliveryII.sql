select 
ROUND(
    SUM(CASE WHEN order_date = customer_pref_delivery_date THEN 1 ELSE 0 END) / COUNT(*) * 100
    ,2)
as immediate_percentage 
from Delivery as D
#子表先找出合題意的選項：最早訂單、唯一ID
INNER JOIN
(
    select customer_id as ID ,MIN(order_date) as date
    from Delivery 
    group by customer_id
) as B on (B.ID=D.customer_id and B.date=D.order_date)
