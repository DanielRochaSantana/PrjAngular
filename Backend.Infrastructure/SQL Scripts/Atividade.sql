CREATE TABLE [dbo].[Atividade] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Descricao]       VARCHAR (1000)   NULL,
    [Horario]         VARCHAR (50)     NULL,
    [Local]           VARCHAR (100)    NULL,
    [DataCadastro]    DATETIME         NULL,
    [DataModificacao] DATETIME         NULL,
    [IsAtivo]         BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

