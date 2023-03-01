USE [Thegioididong]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_user_login]
(
    @request NVARCHAR(MAX)
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserName VARCHAR(80)
    DECLARE @Password VARCHAR(80)
	DECLARE @Token VARCHAR(MAX) = NULL

    SELECT @UserName = JSON_VALUE(@request, '$.userName')
    SELECT @Password = JSON_VALUE(@request, '$.password')

    SELECT a.ID AS Id, a.Username AS Username, a.Password AS Password,a.Role AS Role,@Token AS Token
    FROM Accounts AS a
    WHERE Username = @UserName AND Password = @Password
END
