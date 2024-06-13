

CREATE TABLE [dbo].[Employers] (
    [code]           VARCHAR (9)   NOT NULL,
    [email]          VARCHAR (60)  NOT NULL,
    [system]          VARCHAR (15)  NOT NULL,
    [phone]          VARCHAR (12)  NOT NULL,
    [firstname]      VARCHAR (15)  NULL,
    [lastname]       VARCHAR (20)  NULL,
    [CompanyName]    VARCHAR (50)  NOT NULL,
    [CompanyAddress] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([code] ASC)
);
CREATE TABLE [dbo].[criteria] (
    [code]                     INT            IDENTITY (1, 1) NOT NULL,
    [SeveralYearsOfExperience] INT            NULL,
    [Car]                      BIT            NULL,
    [NumberOfCVsSent]          INT            NULL,
    [salary]                   INT            NULL,
    [Descriptions]             VARCHAR (1000) NULL,
    PRIMARY KEY CLUSTERED ([code] ASC)
);
CREATE TABLE [dbo].[fieldOfWork] (
    [code]            INT          IDENTITY (1, 1) NOT NULL,
    [fieldOfWorkName] VARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([code] ASC)
);
CREATE TABLE [dbo].[Jobs] (
    [code]            INT IDENTITY (1, 1) NOT NULL,
    [EmployersCode]   INT NOT NULL,
    [fieldOfWorkCode] INT NOT NULL,
    [criteriaCode]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([code] ASC),
    CONSTRAINT [FK_Jobs_ToEmployers] FOREIGN KEY ([EmployersCode]) REFERENCES [dbo].[Employers] ([code]),
    CONSTRAINT [FK_Jobs_TofieldOfWork] FOREIGN KEY ([fieldOfWorkCode]) REFERENCES [dbo].[fieldOfWork] ([code]),
    CONSTRAINT [FK_Jobs_Tocriteria] FOREIGN KEY ([criteriaCode]) REFERENCES [dbo].[criteria] ([code])
);



