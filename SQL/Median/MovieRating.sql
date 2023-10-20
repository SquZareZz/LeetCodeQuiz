# Write your MySQL query statement below
#兩個關聯性不大問題分開做，最後再合併
#選最後結果
select name as results
From(
  #名字要按照升序，但次數是降序，所以分開寫
select *,ROW_NUMBER() OVER (ORDER BY RatedTimes DESC, Name ASC) as rn
  from(
      select t2.user_id,t2.Name ,COUNT(*) as RatedTimes
      from MovieRating as t1
      left join Users as t2 ON 
          (t1.user_id = t2.user_id)
      group by t2.user_id
      ) as sub1
  order by user_id    
) as sub2
where rn=1

#合併
UNION ALL

#選最後結果
Select title as results
FROM(
  #名字要按照升序，但次數是降序，所以分開寫
  select *,ROW_NUMBER() OVER (ORDER BY RatedCount DESC, title ASC) as rn
  FROM(
      select t1.movie_id,t2.title ,SUM(rating)/COUNT(rating) as RatedCount
      from MovieRating as t1
      left join Movies as t2 
      on(t1.movie_id = t2.movie_id AND (t1.created_at Between '2020-02-01' AND '2020-02-28'))
      where t2.movie_id IS NOT NULL
      group by t1.movie_id
  ) as SUB1
) as SUB2
where rn=1