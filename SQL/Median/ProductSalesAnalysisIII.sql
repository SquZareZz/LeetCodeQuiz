select product_id,year as first_year,quantity,price
from
(
    select product_id,year,quantity,price,
    # DENSE_RANK 類似於 ROW_NUMBER，但不會跳過相同的項目，會給予相同的數字
    # 因此考慮到當年度可能有兩筆以上的資料，不能用不同的編號
    DENSE_RANK() OVER (PARTITION BY product_id ORDER BY year) AS NO
    from Sales 
) as temp
where NO=1