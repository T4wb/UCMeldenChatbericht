
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/27/2017 13:17:34
-- Generated from EDMX file: C:\Users\Lenovo\Source\Repos\UCMeldenChatbericht\UCMeldenChatbericht\UCMeldenChatbericht\ChatModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GameCartagena];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ChatSet'
CREATE TABLE [dbo].[ChatSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChatType] nvarchar(max)  NOT NULL,
    [ChatRoomName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MessageSet'
CREATE TABLE [dbo].[MessageSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [Chat_Id] int  NOT NULL
);
GO

-- Creating table 'Reports'
CREATE TABLE [dbo].[Reports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Chatmessage] nvarchar(max)  NOT NULL,
    [ChatmessageSender] nvarchar(max)  NOT NULL,
    [Reason] nvarchar(max)  NOT NULL,
    [Message_Id] int  NOT NULL
);
GO

-- Creating table 'UserChat'
CREATE TABLE [dbo].[UserChat] (
    [User_Id] int  NOT NULL,
    [Chat_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChatSet'
ALTER TABLE [dbo].[ChatSet]
ADD CONSTRAINT [PK_ChatSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MessageSet'
ALTER TABLE [dbo].[MessageSet]
ADD CONSTRAINT [PK_MessageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [PK_Reports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [User_Id], [Chat_Id] in table 'UserChat'
ALTER TABLE [dbo].[UserChat]
ADD CONSTRAINT [PK_UserChat]
    PRIMARY KEY CLUSTERED ([User_Id], [Chat_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'UserChat'
ALTER TABLE [dbo].[UserChat]
ADD CONSTRAINT [FK_UserChat_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Chat_Id] in table 'UserChat'
ALTER TABLE [dbo].[UserChat]
ADD CONSTRAINT [FK_UserChat_Chat]
    FOREIGN KEY ([Chat_Id])
    REFERENCES [dbo].[ChatSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserChat_Chat'
CREATE INDEX [IX_FK_UserChat_Chat]
ON [dbo].[UserChat]
    ([Chat_Id]);
GO

-- Creating foreign key on [Chat_Id] in table 'MessageSet'
ALTER TABLE [dbo].[MessageSet]
ADD CONSTRAINT [FK_ChatMessage]
    FOREIGN KEY ([Chat_Id])
    REFERENCES [dbo].[ChatSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChatMessage'
CREATE INDEX [IX_FK_ChatMessage]
ON [dbo].[MessageSet]
    ([Chat_Id]);
GO

-- Creating foreign key on [Message_Id] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [FK_MessageReport]
    FOREIGN KEY ([Message_Id])
    REFERENCES [dbo].[MessageSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageReport'
CREATE INDEX [IX_FK_MessageReport]
ON [dbo].[Reports]
    ([Message_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------