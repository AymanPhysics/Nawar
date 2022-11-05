select distinct OrderTypeId,dbo.GetOrderTypes(OrderTypeId),ShipperId,dbo.GetShipperName(ShipperId) from ImportMessages where year(DeliveredDate)>=2019 and ShipperId=5


select * from ImportMessages


update ImportMessages set Cost_OrderTypeId_Perc=0.1 where year(DeliveredDate)>=2019 and OrderTypeId=31
update ImportMessages set Cost_OrderTypeId_Perc=0.05 where year(DeliveredDate)>=2019 and OrderTypeId=31 and ShipperId=5
update ImportMessages set Cost_OrderTypeId_Perc=0.1 where year(DeliveredDate)>=2019 and OrderTypeId=22
update ImportMessages set Cost_OrderTypeId_Perc=0.05 where year(DeliveredDate)>=2019 and OrderTypeId=34

update ImportMessages set Cost_OrderTypeId=Cost_OrderTypeId_Perc*val5 where year(DeliveredDate)>=2019
