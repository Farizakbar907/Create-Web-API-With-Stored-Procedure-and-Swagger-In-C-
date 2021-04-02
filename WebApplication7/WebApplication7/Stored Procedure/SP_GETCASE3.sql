USE [DbCrud]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCase3]    Script Date: 4/2/2021 7:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER Proc [dbo].[SP_GetCase3]
@age as varchar(50),
@pageno int,
@pagesize int = 8
AS
BEGIN

	Set nocount on;
	if (@age %2 = 0)
	select name, age
	from 
	(
	select name, age,
	ROW_NUMBER() over (Order By age asc) as RowId 
	from Case3	
	where age %2 = 0 
	) T
	where T.RowId between ((@pageno-1)*@pagesize)+1 and (@pageno*@pagesize)


	else if (@age %2 <> 0)
	select name, age
	from 
	(
	select name, age,
	ROW_NUMBER() over (Order By age asc) as RowId
	from Case3
	where age %2 <> 0
	)T
	where T.RowId between ((@pageno-1)*@pagesize)+1 and (@pageno*@pagesize)

END