CREATE TABLE [dbo].[Table]
(
	[id] INT NOT NULL , 
	[UserName] NVARCHAR(50) NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NULL,      
    [Email] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([id])
)
