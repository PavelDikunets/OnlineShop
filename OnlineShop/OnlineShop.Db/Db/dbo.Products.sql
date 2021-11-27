CREATE TABLE [dbo].[Products] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (MAX)   NULL,
    [Cost]        MONEY  NOT NULL,
    [Description] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

