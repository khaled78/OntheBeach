USE [Onthebeach_Demo]
GO
/****** Object:  StoredProcedure [dbo].[AnnualAmountRetrieve_GBP]    Script Date: 13/04/2015 23:40:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Khaled>
-- Create date: <Create Date,11/04/2015,>
-- Description:	<Description,OnTheBeach,>
-- =============================================
ALTER PROCEDURE [dbo].[AnnualAmountRetrieve_GBP] 
	-- Add the parameters for the stored procedure here
	@name nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
      e.name Name
    , s.Annual_Amount,c.Unit AS Unit
    , (s.annual_Amount * c.Conversion_Factor) AS 'Amount In GBP'
FROM Employees e
JOIN Salaries s ON e.Id = s.Employee_id
JOIN Currencies c on c.Id = s.Currency
Where e.name=@name
END