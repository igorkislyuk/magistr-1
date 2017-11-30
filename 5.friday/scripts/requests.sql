-- most recent user that order 
                
-- select "User".Name, Surname from "User"
-- left join "Order"
-- on "User".ID = "Order".User_ID
-- where rownum < 2
-- order by "Order"."ORDER_DATE" Desc;

-- amount for most recent order

--select "Order".ID, DELIVERYATTRIBUTES_ID, "SUMMARY".TOTAL_AMOUNT from "Order"
--left join DELIVERYATTRIBUTES
--on "Order".DELIVERYATTRIBUTES_ID = DELIVERYATTRIBUTES.ID
--left join "SUMMARY"
--on DELIVERYATTRIBUTES.SUMMARY_ID = "SUMMARY".ID
--order by "Order".ORDER_DATE DESC;

-- most popular exchange

--select EXCHANGE.ID, AMOUNT, NOMINALS.DESCRIPTION FROM EXCHANGE
--LEFT JOIN NOMINALS
--ON EXCHANGE.NOMINALS_ID = NOMINALS.ID
--WHERE ROWNUM < 2
--ORDER BY ORDERED_TIMES ASC;


