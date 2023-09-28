select teacher_id, COUNT(DISTINCT subject_id) as cnt
from  Teacher 
GROUP by teacher_id