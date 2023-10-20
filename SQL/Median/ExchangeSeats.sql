# Write your MySQL query statement below
# id 都是從 1 開始
SELECT 
    t1.id,
    CASE
        #奇數項結尾看原本的 Name(因為沒配對到是 Null)
        WHEN t1.id % 2 = 1 AND t1.id + 1 > (SELECT MAX(id) FROM Seat) THEN
            t1.student
        #除了最後項照已經分配好的方式排列    
        ELSE
            t2.student
    END AS student
FROM 
    Seat t1
LEFT JOIN Seat t2 ON 
    #1號跟2號配、2號跟1號配
    (t1.id % 2 = 1 AND t1.id + 1 = t2.id) OR 
    (t1.id % 2 = 0 AND t1.id - 1 = t2.id);