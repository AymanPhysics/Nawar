update Entry set EntryTypeId=7 where EntryTypeId=0
update EntryDt set EntryTypeId=7 where EntryTypeId=0

delete EntryTypes where Id=7
insert EntryTypes select 4,7,'قيود قديمة',1,1000000,1,null
select * from EntryTypes