select MAX(num) as num
from 
(
    select num,Count(num) as CNT
    from MyNumbers
    GROUP BY num
) as  Sub
where CNT<2