select sell_date ,Count(DISTINCT product) as num_sold,
GROUP_CONCAT(DISTINCT product ORDER BY product SEPARATOR ',')  as products
from Activities 
group by sell_date  
order by sell_date