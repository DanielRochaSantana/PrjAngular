CREATE TABLE [dbo].[Despesa] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Descricao]       VARCHAR (1000)   NULL,
    [Valor]           NUMERIC (19, 4)  NULL,
    [Local]           VARCHAR (100)    NULL,
    [DataCadastro]    DATETIME         NULL,
    [DataModificacao] DATETIME         NULL,
    [IsAtivo]         BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

