select *
from Users
where mail REGEXP '^[A-Za-z]+[A-Za-z0-9._-]*@leetcode\\.com$'
#[A-Za-z0-9._-]* 「*」代表這個配對允許0個或多個
#[A-Za-z0-9]+ 「+」代表這個配對允許1個或多個
# 小數點前面要加 \\
# $代表結尾