select * from SalesFlags


alter table SalesFlags add IsReserve int not null default 0
go
insert salesflags
select 32,'حجز أصناف للمبيعات','العميل','البائع',	0,	0,	0,	0,	'حجز أصناف للمبيعات',1



go

alter table SalesMaster add NewInvoiceNo bigint not null default 0
alter table deletedSalesMaster add NewInvoiceNo bigint not null default 0