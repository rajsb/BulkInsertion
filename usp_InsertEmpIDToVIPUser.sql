USE [Training_2017]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rajkumar Balakrishnan
-- Create date: 24/02/2018
-- Description:	Sp to insert employeeID into VIPUSer table
-- Exec [dbo].[usp_InsertEmpIDToVIPUser] '110305'
-- =============================================
ALTER PROCEDURE [dbo].[usp_InsertEmpIDToVIPUser]
	@EmpID varchar(20),
	@EmpName varchar(200)
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Employee WHERE EmpID = @EmpUID)
		BEGIN
			Insert into VIPUser(EmployeeId, [Role], CreatedDate,UpdatedDate,CreatedBy,UpdatedBy,IsDeleted,Reason)
			 VALUES ((select EmpID from Employees where EmpID = @EmpID), null,GETDATE(),GETDATE(),'13795','13795',0,'VIP User')

		END
	ELSE
		BEGIN
			Insert into Employee(EmpID, EmpName) VALUES (@EmpID,@EmpName)
		END

END
GO

------------------------------------------------------Example for deleting datetime format-----------

--DELETE from VIPUser where CONVERT(VARCHAR(25), CreatedDate, 126) LIKE '2018-02-13%'
-----------------------------------------------------------------------------------------------------
