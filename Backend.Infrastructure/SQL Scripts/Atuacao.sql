CREATE TABLE [dbo].[Atuacao] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Descricao]       VARCHAR (1000)   NULL,
    [Empresa]         VARCHAR (300)    NULL,
    [Local]           VARCHAR (100)    NULL,
    [DataCadastro]    DATETIME         NULL,
    [DataModificacao] DATETIME         NULL,
    [IsAtivo]         BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

