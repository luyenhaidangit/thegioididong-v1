USE [Thegioididong]
GO
/****** Object:  StoredProcedure [dbo].[sp_slide_getslidesmanage]    Script Date: 01/03/2023 2:33:45 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_slide_getslidesmanage]
(
@request NVARCHAR(MAX)
)
AS
    BEGIN
	DECLARE @PageIndex INT;
	DECLARE @PageSize INT;
	DECLARE @TotalRecords INT;
	DECLARE @TotalPages FLOAT;

	SELECT @PageIndex = JSON_VALUE(@request, '$.pageIndex');
	SELECT @PageSize = JSON_VALUE(@request, '$.pageSize');
	
	IF(@PageSize <> 0)
		BEGIN
			SET NOCOUNT ON;
				SELECT (ROW_NUMBER() OVER(ORDER BY s.Id DESC)) AS RowNumber, s.Id,s.Name,s.Page,s.Position,s.Published INTO #Temp1 FROM Slides AS s
				WHERE s.Published = 1

				SELECT @TotalRecords = COUNT(*) FROM #Temp1;

				SELECT @TotalPages = CEILING(CAST(@TotalRecords AS FLOAT) / @PageSize);

				SELECT @PageIndex AS PageIndex, @PageSize AS PageSize,@TotalRecords AS TotalRecords,@TotalPages AS TotalPages,
				(
					SELECT tp1.Id,tp1.Name,tp1.Page,tp1.Position FROM #Temp1 AS tp1
					WHERE RowNumber BETWEEN(@PageIndex - 1) * @PageSize + 1 AND(((@PageIndex - 1) * @PageSize + 1) + @PageSize) - 1 OR @PageIndex = -1
					FOR JSON PATH
				) AS Items

				DROP TABLE #Temp1
		END
	ELSE
		BEGIN
			SET NOCOUNT ON;
				SELECT (ROW_NUMBER() OVER(ORDER BY s.Id DESC)) AS RowNumber, s.Id,s.Name,s.Page,s.Position INTO #Temp2 FROM Slides AS s
				WHERE s.Published = 1

				SELECT @TotalRecords = COUNT(*) FROM #Temp2;

				SELECT @TotalPages = CEILING(CAST(@TotalRecords AS FLOAT) / @PageSize);

				SELECT @PageIndex AS PageIndex, @PageSize AS PageSize,@TotalRecords AS TotalRecords,@TotalPages AS TotalPages,
				(
					SELECT tp2.Id,tp2.Name,tp2.Page,tp2.Position FROM #Temp2 AS tp2
				) AS Items

				DROP TABLE #Temp2
		END
	END;
	


	