# Write your MySQL query statement below
# 每查到一種類型以後，用 UNION ALL 聯表
SELECT "Low Salary" category, COUNT(*) accounts_count FROM Accounts WHERE income < 20000
UNION ALL
SELECT "Average Salary" category, COUNT(*) accounts_count FROM Accounts WHERE income >= 20000 AND income <= 50000
UNION ALL
SELECT "High Salary" category, COUNT(*) accounts_count FROM Accounts WHERE income > 50000