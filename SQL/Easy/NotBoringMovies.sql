select *
from Cinema 
where 1=1
and id %2 = 1
and description != "boring"
order by rating desc