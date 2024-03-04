CREATE TABLE Employers (
    code int IDENTITY(1,1) PRIMARY KEY not null,
    email varchar(60) not null,
    phone varchar(12) not null,
    firstname varchar(15),
    lastname varchar(20),
    CompanyName varchar(50) not null,
    CompanyAddress varchar(100) not null
);
CREATE TABLE fieldOfWork (
    code int IDENTITY(1,1) PRIMARY KEY not null,
    fieldOfWorkName varchar(15) not null,
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
drop table jobs
CREATE TABLE [dbo].[Jobs] (
    [code]            INT IDENTITY (1, 1) NOT NULL,
    [EmployersCode]   INT NOT NULL,
    [fieldOfWorkCode] INT NOT NULL,
    [criteriaCode]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([code] ASC), 
    CONSTRAINT [FK_Jobs_ToEmployers] FOREIGN KEY (EmployersCode) REFERENCES [Employers]([code]), 
    CONSTRAINT [FK_Jobs_TofieldOfWork] FOREIGN KEY (fieldOfWorkCode) REFERENCES [fieldOfWork]([code]), 
    CONSTRAINT [FK_Jobs_Tocriteria] FOREIGN KEY (criteriaCode) REFERENCES [criteria]([code])
);