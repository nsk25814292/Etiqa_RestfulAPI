USE [ETIQA_DB]
GO

/****** Object:  StoredProcedure [dbo].[SP_Create_User]    Script Date: 01/28/2025 01:19:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*  *** EXAMPLES ***
    EXEC SP_Create_User 'SIVA','NATS@GMAIL.COM',0168660794,'C#','PLAY CRICKET' -- RETURNS TRUE
        
    SELECT * FROM FreeLancers_Tbl;
    SELECT * FROM FreelancerSkills_Tbl;
    
    --DELETE FROM FreelancerSkills_Tbl;
    --DELETE FROM FreeLancers_Tbl;
    
*/

CREATE PROCEDURE [dbo].[SP_Create_User]
       @UserName              VARCHAR(50)  = NULL   , 
       @Email                 VARCHAR(50)  = NULL   ,  
       @ContactNo             INT  = NULL   ,  
       @SkillSet              VARCHAR(300)  = NULL   , 
       @Hobbies               VARCHAR(500)  = NULL 
AS 
BEGIN 
    -- SET NOCOUNT ON 
     BEGIN TRY
			 DECLARE @LAST_ID INT;
			 BEGIN TRAN
			 --Record Add into FreeLancers_Tbl
			 INSERT INTO FreeLancers_Tbl
				  (                    
					UserName,
					Email,
					ContactNo                    
		                             
				  ) 
			 VALUES 
				  ( 
					@UserName,
					@Email,
					@ContactNo                  
				  ) 
			 SELECT @LAST_ID = SCOPE_IDENTITY();
			--Record Add into FreelancerSkills_Tbl
			INSERT INTO FreelancerSkills_Tbl
				  (                    
					SkillSet,
					Hobbies,
					Freelancer_User_Id                    
		                             
				  ) 
			 VALUES 
				  ( 
					@SkillSet,
					@Hobbies,
					@LAST_ID                  
				  ) 
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

