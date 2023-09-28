select  user_id,COUNT(follower_id) as followers_count
from Followers 
GROUP BY user_id 
order by user_id