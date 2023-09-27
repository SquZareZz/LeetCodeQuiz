select product_name ,year,price
from Product INNER JOIN(Sales) ON Product.product_id = Sales.product_id 