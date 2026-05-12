CREATE TABLE [dbo].[Curso] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Descricao]       VARCHAR (1000)   NULL,
    [Instituicao]     VARCHAR (100)    NULL,
    [Local]           VARCHAR (100)    NULL,
    [DataCadastro]    DATETIME         NULL,
    [DataModificacao] DATETIME         NULL,
    [IsAtivo]         BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

