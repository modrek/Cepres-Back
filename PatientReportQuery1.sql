
begin
 WITH HighestMonth  AS (
    SELECT PatientId, CriticalMonth,cnt,ROW_NUMBER() 
    over (
        PARTITION BY PatientId
        order by cnt desc
    ) AS RowNo 
    FROM (select PatientId,MONTH( TimeOfEntry )CriticalMonth,count(*) cnt from Records
group by PatientId,MONTH( TimeOfEntry ) 
) as tmp
)

select p.PatientName,max(hm.CriticalMonth)CriticalMonth,datediff(YEAR, p.DateOfBirth,getdate()) Age,cast(AVG(r.Bill) as decimal(9,2)) AvarageOfBill,cast(STDEV(r.Bill)  as decimal(9,2)) StdevOfBill
from Patients p 
join Records r on p.PatientId=r.PatientId
join HighestMonth hm on hm.PatientId=p.PatientId and RowNo =1
group by p.PatientName,p.DateOfBirth
end
begin
        WITH TOPFive AS (
    SELECT RecordId, PatientId, DiseaseName,TimeOfEntry,description,bill, ROW_NUMBER() 
    over (
        PARTITION BY PatientId
        order by TimeOfEntry
    ) AS RowNo 
    FROM Records
)
SELECT * FROM TOPFive WHERE RowNo <= 5 order by PatientId
end 





