
 WITH HighestMonth  AS (
    SELECT PatientId, Month,cnt,ROW_NUMBER() 
    over (
        PARTITION BY PatientId
        order by cnt desc
    ) AS RowNo 
    FROM (select PatientId,MONTH( TimeOfEntry )Month,count(*) cnt from Records
group by PatientId,MONTH( TimeOfEntry ) 
) as tmp
)
SELECT PatientId,Month,cnt FROM HighestMonth WHERE RowNo =1 order by PatientId