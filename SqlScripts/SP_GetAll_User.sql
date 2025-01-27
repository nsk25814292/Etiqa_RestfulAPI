USE [ETIQA_DB]
GO

/****** Object:  StoredProcedure [dbo].[SP_GetAll_User]    Script Date: 01/28/2025 01:20:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*  *** EXAMPLES ***
    --EXEC SP_GetAll_User -- RETURNS TRUE
        
    SELECT * FROM FreeLancers_Tbl;
    SELECT * FROM FreelancerSkills_Tbl;
    
*/

CREATE PROCEDURE [dbo].[SP_GetAll_User]
AS 
BEGIN 
    -- SET NOCOUNT ON 
			--All Record Select from FreeLancers_Tb, FreelancerSkills_Tbl
			SELECT A.*,B.Id,B.Hobbies,B.SkillSet FROM FreeLancers_Tbl A INNER JOIN FreelancerSkills_Tbl B ON A.USERID=B.Freelancer_User_Id;
END 

GO

