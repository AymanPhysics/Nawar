declare @tbl table(OLD bigint,New bigint)
insert @tbl select 121101,4501
insert @tbl select 121102,4502
insert @tbl select 121103,4503
insert @tbl select 121104,4504
insert @tbl select 121105,4505

insert @tbl select 121201,6001

insert @tbl select 3402,5002
insert @tbl select 3403,5003
insert @tbl select 3404,5004
insert @tbl select 3405,5005

insert @tbl select 4205,6002
insert @tbl select 44,6003
insert @tbl select 43,6004
insert @tbl select 706011,120109


insert @tbl select 4501,121101
insert @tbl select 4502,121102
insert @tbl select 4503,121103
insert @tbl select 4504,121104
insert @tbl select 4505,121105


update EntryDt set MainAccNo=ISNULL((select New from @tbl where Old=MainAccNo),MainAccNo)
update Entry2 set MainAccNo1=ISNULL((select New from @tbl where Old=MainAccNo1),MainAccNo1)
update Entry2 set MainAccNo2=ISNULL((select New from @tbl where Old=MainAccNo2),MainAccNo2)

update InComeTypes set AccNo=ISNULL((select New from @tbl where Old=AccNo),AccNo)
update OutComeTypes set AccNo=ISNULL((select New from @tbl where Old=AccNo),AccNo)
update OrderTypes set AccNo=ISNULL((select New from @tbl where Old=AccNo),AccNo)
update OrderTypes set AccNo1=ISNULL((select New from @tbl where Old=AccNo1),AccNo1)
update OrderTypes set AccNo2=ISNULL((select New from @tbl where Old=AccNo2),AccNo2)
update OrderTypes set AccNo3=ISNULL((select New from @tbl where Old=AccNo3),AccNo3)

update ImportMessages set AccNo=ISNULL((select New from @tbl where Old=AccNo),AccNo)
update ImportMessageCostHistoryVal3 set MainAccNo=ISNULL((select New from @tbl where Old=MainAccNo),MainAccNo)
update ImportMessageCostHistoryVal4 set MainAccNo=ISNULL((select New from @tbl where Old=MainAccNo),MainAccNo)

 