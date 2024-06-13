drop table jobs;
drop table employers;
CREATE TABLE [dbo].[Employers] (
    [id]           VARCHAR (9)   NOT NULL,
    [email]          VARCHAR (60)  NOT NULL,
    [system]          VARCHAR (15)  NOT NULL,
    [phone]          VARCHAR (12)  NOT NULL,
    [firstname]      VARCHAR (15)  NULL,
    [lastname]       VARCHAR (20)  NULL,
    [CompanyName]    VARCHAR (50)  NOT NULL,
    [CompanyAddress] VARCHAR (100) NOT NULL,
    
);
CREATE TABLE [dbo].[Jobs] (
    [code]            INT IDENTITY (1, 1) NOT NULL,
    [EmployersId]   VARCHAR (9) NOT NULL,
    [fieldOfWorkCode] INT NOT NULL,
    [criteriaCode]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([code] ASC),
    CONSTRAINT [FK_Jobs_ToEmployers] FOREIGN KEY ([EmployersId]) REFERENCES [dbo].[Employers] ([id]),
    CONSTRAINT [FK_Jobs_TofieldOfWork] FOREIGN KEY ([fieldOfWorkCode]) REFERENCES [dbo].[fieldOfWork] ([code]),
    CONSTRAINT [FK_Jobs_Tocriteria] FOREIGN KEY ([criteriaCode]) REFERENCES [dbo].[criteria] ([code])
);
