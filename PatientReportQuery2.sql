

declare @PatientID varchar(100);
declare @Query varchar(MAX);
set @Query='';
DECLARE Patient_cursor CURSOR FOR 

SELECT TOP 2 PatientId FROM Patients

OPEN Patient_cursor  
FETCH NEXT FROM Patient_cursor INTO @PatientID  

WHILE @@FETCH_STATUS = 0  
BEGIN  
if (@Query<>'')
  set @Query = @Query + ' union all ';

  set @Query= @Query + ' select '''+@PatientID+''' PatientId, PatientId similarPatient from Records where DiseaseName 
    in (select distinct DiseaseName from Records where PatientId='''+@PatientID+''')
    and PatientId <>'''+@PatientID+'''
    group by PatientId having count(*)>=2 '

      FETCH NEXT FROM Patient_cursor INTO @PatientID 
END 

CLOSE Patient_cursor  
DEALLOCATE Patient_cursor  ;

EXEC @query ;