select customer_id,COUNT(*) as count_no_trans
from Visits
where 1=1
and visit_id  NOT IN (select distinct visit_id from Transactions)
GROUP BY customer_id;