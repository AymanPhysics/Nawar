
--ãÔÇßá ÓÚÑ ÕÑÝ
select * from BankCash_G2 where MainValue<>Value and CurrencyId=1 
union all
select * from BankCash_G2 where MainValue2<>Value and CurrencyId2=1
order by InvoiceNo