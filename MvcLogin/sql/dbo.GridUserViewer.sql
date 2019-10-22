CREATE PROCEDURE [dbo].[GridUserViewer]
	@param1 int = 0
AS
SELECT
	c.*
FROM Customer AS c
INNER JOIN 
	UserSys AS us
ON
	c.UserId = us.Id
WHERE
	c.UserId = @Param1
RETURN 0