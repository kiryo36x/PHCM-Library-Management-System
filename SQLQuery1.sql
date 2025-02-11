CREATE TABLE admin
(
	id INT PRIMARY KEY IDENTITY(1,1),
    firstName NVARCHAR(50) NOT NULL,
    middleName NVARCHAR(50),
    surname NVARCHAR(50) NOT NULL,
    contactNo BIGINT NOT NULL,
    username NVARCHAR(50) NOT NULL,
    passowrd NVARCHAR(100) NOT NULL
)

SELECT * FROM admin