CREATE TABLE Employers (
    code int IDENTITY(1,1) PRIMARY KEY not null,
    email varchar(60) not null,
    phone varchar(12) not null,
    firstname varchar(15),
    lastname varchar(20),
    CompanyName varchar(50) not null,
    CompanyAddress varchar(100) not null
);
CREATE TABLE lands (
    code int IDENTITY(1,1) PRIMARY KEY not null,
    landType varchar(15) not null,
);
