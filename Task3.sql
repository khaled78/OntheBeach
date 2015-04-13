USE [Onthebeach_Demo]
GO
/****** Object:  StoredProcedure [dbo].[StaffLevel]    Script Date: 13/04/2015 23:43:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Khaled>
-- Create date: <Create Date,11/04/2015>
-- Description:	<Description,OntheBeach>
-- =============================================
ALTER PROCEDURE [dbo].[StaffLevel] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
    e.name AS 'Employee Name',r.Name AS 'Role Name',s.annual_amount AS 'Annual Salary',c.unit AS 'Currencies',(s.annual_amount*c.conversion_factor) AS 'Amount In GBP'
  FROM Employees e
  JOIN Roles r on r.id=e.role_id
  JOIN Salaries s on e.id=s.employee_id
  JOIN Currencies c on c.id=s.currency
  ORDER BY s.annual_amount DESC
END