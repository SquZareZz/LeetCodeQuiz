select x,y,z,
Case 
    WHEN (x> ABS(y-z) AND y> ABS(x-z) AND z>ABS(x-y)) THEN 'Yes'
    ELSE 'No'
    END AS triangle 
from Triangle 