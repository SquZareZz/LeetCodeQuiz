DELETE FROM Person 
WHERE id not IN (
    SELECT id 
    FROM (SELECT MIN(Id) Id FROM Person GROUP BY Email) as A
);