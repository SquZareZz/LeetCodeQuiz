# 最後，用所有不重複差距為一天的，除以所有不重複的 player_id
SELECT ROUND(COUNT(DISTINCT CASE WHEN diff = 1 THEN player_id END)/COUNT(DISTINCT player_id), 2) AS fraction
#SELECT *
FROM(
SELECT  player_id,
        # 利用 rank() 找出每個 player 的第一筆登入紀錄，將排序欄位命名為 rs，第一筆紀錄 rs = 1
        RANK() OVER(PARTITION BY player_id ORDER BY event_date) AS rs,
        # 再利用 lead() 函數找出每個用戶按 event_date 排序的下一次登入日期並將其與原先的 event_date欄位做相減
        # PARTITION BY 總結各行數加減後的天數
        DATEDIFF(LEAD(event_date) OVER(PARTITION BY player_id ORDER BY event_date), event_date) diff

FROM Activity
) a
WHERE rs = 1