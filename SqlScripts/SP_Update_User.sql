USE [ETIQA_DB]
GO

/****** Object:  StoredProcedure [dbo].[SP_Update_User]    Script Date: 01/28/2025 01:20:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*  *** EXAMPLES ***
    EXEC SP_Update_User 15,113, 'Senthil','NATS2@GMAIL.COM',0168660795,'VB#','PLAY FOOTBALL' -- RETURNS TRUE
        
    SELECT * FROM FreeLancers_Tbl;
    SELECT * FROM FreelancerSkills_Tbl;
    
    --DELETE FROM FreelancerSkills_Tbl;
    --DELETE FROM FreeLancers_Tbl;
    
*/

CREATE PROCEDURE [dbo].[SP_Update_User](
	   @UserId INT,
	   @Id INT,
       @UserName              VARCHAR(50)  = NULL   , 
       @Email                 VARCHAR(50)  = NULL   ,  
       @ContactNo             INT  = NULL   ,  
       @SkillSet              VARCHAR(300)  = NULL   , 
       @Hobbies               VARCHAR(500)  = NULL )
AS 
BEGIN 
    -- SET NOCOUNT ON 
     BEGIN TRY
			 BEGIN TRAN
			 --Record update into FreeLancers_Tbl
			 UPDATE FreeLancers_Tbl SET
					UserName=@UserName,
					Email=@Email,
					ContactNo=@ContactNo                    
			WHERE UserId=@UserId;
			
					
			--Record Add into FreelancerSkills_Tbl
			UPDATE FreelancerSkills_Tbl
				  SET                    
					SkillSet=@SkillSet,
					Hobbies=@Hobbies
			 WHERE Freelancer_User_Id=@UserId;               
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

