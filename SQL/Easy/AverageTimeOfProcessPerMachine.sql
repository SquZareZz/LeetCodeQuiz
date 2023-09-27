# 方法一
#SELECT Activity.machine_id, ROUND(AVG(Act2.timestamp - Activity.timestamp),3) AS processing_time 
#FROM Activity
# INNER 是為了排除 NULL
#INNER JOIN Activity Act2 ON Activity.machine_id = Act2.machine_id
#WHERE 1=1
#and Activity.activity_type  = 'start' 
#AND Act2.activity_type  = 'end'
#GROUP BY Activity.machine_id
# / COUNT(CASE WHEN activity_type IN ('start', 'end') THEN 1 END)

#方法二
SELECT machine_id, 
#統計所有 end，當 activity_type = 'end'，Return 並統計 Time 總和
ROUND((SUM(CASE WHEN activity_type = 'end' THEN timestamp END) 
#同理這段換成 Start
- SUM(CASE WHEN activity_type = 'start' THEN timestamp END)) 
#透過process_id過濾重複項
/ COUNT(DISTINCT CASE WHEN activity_type IN ('start', 'end') THEN process_id END),3) AS processing_time
FROM Activity
GROUP BY machine_id;