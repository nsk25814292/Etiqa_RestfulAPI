USE [ETIQA_DB]
GO

/****** Object:  StoredProcedure [dbo].[SP_Delete_User]    Script Date: 01/28/2025 01:19:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*  *** EXAMPLES ***
    --EXEC SP_Delete_User 15,113-- RETURNS TRUE
        
    SELECT * FROM FreeLancers_Tbl;
    SELECT * FROM FreelancerSkills_Tbl;
    
    --DELETE FROM FreelancerSkills_Tbl;
    --DELETE FROM FreeLancers_Tbl;
    
*/

CREATE PROCEDURE [dbo].[SP_Delete_User](
	   @UserId INT--,
	  -- @Id INT
      )
AS 
BEGIN 
    -- SET NOCOUNT ON 
     BEGIN TRY
			 BEGIN TRAN
			 	
			--Record Delete from FreelancerSkills_Tbl
			DELETE FreelancerSkills_Tbl WHERE Freelancer_User_Id=@UserId; --Id=@Id AND    
			
			 --Record Delete from FreeLancers_Tbl
			DELETE FreeLancers_Tbl WHERE UserId=@UserId;
			
				            
			COMMIT TRAN;
			
	END TRY
	BEGIN CATCH
	IF @@ERROR > 0
        BEGIN
        ROLLBACK TRAN;
			SELECT  
				ERROR_NUMBER() AS ErrorNumber  
				,ERROR_SEVERITY() AS ErrorSeverity  
				,ERROR_STATE() AS ErrorState  
				,ERROR_PROCEDURE() AS ErrorProcedure  
				,ERROR_LINE() AS ErrorLine  
				,ERROR_MESSAGE() AS ErrorMessage;  
			--PRINT('Raise the caught error again');
		END
    END CATCH
	
END 

GO

