USE [ETIQA_DB]
GO

/****** Object:  StoredProcedure [dbo].[SP_Search_User]    Script Date: 01/28/2025 01:20:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*  *** EXAMPLES ***
    --EXEC SP_Search_User 15,113-- RETURNS TRUE
        
    SELECT * FROM FreeLancers_Tbl;
    SELECT * FROM FreelancerSkills_Tbl;
    
*/

CREATE PROCEDURE [dbo].[SP_Search_User](
	   @UserId INT--,
	   --@Id INT
      )
AS 
BEGIN 
    -- SET NOCOUNT ON 
			--Record Select base on ID parameter from FreeLancers_Tbl, FreelancerSkills_Tbl
			SELECT A.*,B.Id,B.Hobbies,B.SkillSet FROM FreeLancers_Tbl A INNER JOIN FreelancerSkills_Tbl B ON A.USERID=B.Freelancer_User_Id
			WHERE UserId=@UserId;
END 

GO

