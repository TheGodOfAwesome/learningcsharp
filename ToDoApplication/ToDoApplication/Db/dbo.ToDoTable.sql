CREATE TABLE [dbo].[ToDoTable] (
    [Id]          NUMERIC (18)   NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (100) NULL,
    [DateTime]    DATETIME2 (7)  NULL,
    [Priority]    NVARCHAR (50)  NULL,
    [IsComplete]  INT            NULL, 
    CONSTRAINT [PK_ToDoTable] PRIMARY KEY ([Id])
);

