SELECT today.id
FROM Weather AS today
#昨天 = DATE_SUB(今天，INTERVAL 1 DAY) 
JOIN Weather AS yesterday ON DATE(yesterday.recordDate) = DATE(DATE_SUB(today.recordDate, INTERVAL 1 DAY))
WHERE today.temperature > yesterday.temperature;