select activity_date as day,Count(DISTINCT user_id) as active_users 
from Activity
where activity_date between '2019-06-28' and '2019-07-27'
GROUP BY activity_date