﻿CREATE TABLE admin
(
	id INT PRIMARY KEY IDENTITY(1,1), 
    firstName NVARCHAR(50) NOT NULL,
    middleName NVARCHAR(50),
    surname NVARCHAR(50) NOT NULL,
    contactNo BIGINT NOT NULL,
    username NVARCHAR(50) NOT NULL,
    passowrd NVARCHAR(100) NOT NULL,
    isAdmin BIT NOT NULL DEFAULT 0
)

CREATE TABLE student
(
    id INT PRIMARY KEY IDENTITY(1,1),
    studentName NVARCHAR(50) NOT NULL,
    studentNumber NVARCHAR(50) NOT NULL,
    department NVARCHAR(50) NOT NULL,
    studentContact BIGINT NOT NULL,
    studentPicture NVARCHAR(255) NULL,
    studentImage IMAGE NOT NULL
)
CREATE TABLE books
(
    id INT PRIMARY KEY IDENTITY(1,1),
    bookName NVARCHAR(100) NOT NULL,
    author NVARCHAR(50) NOT NULL,
    datePick DATE NOT NULL,
    quantity BIGINT NOT NULL,
    bookPicture NVARCHAR(255) NOT NULL,
    picture IMAGE NOT NULL,
    genre NVARCHAR(100) NOT NULL
)

CREATE TABLE issue
(
    id INT PRIMARY KEY IDENTITY(1,1),
    studentImage IMAGE NOT NULL,
    studentName NVARCHAR(50) NOT NULL,
    bookName NVARCHAR(50) NOT NULL,
    author NVARCHAR(50) NOT NULL,    
    publishedDate DATE NOT NULL,
    issueDate DATE NOT NULL,
    genre NVARCHAR(100) NOT NULL
)

CREATE TABLE returnBook
(
    id INT PRIMARY KEY IDENTITY(1,1),
    studentName NVARCHAR(50) NOT NULL,
    studentImage IMAGE NOT NULL,
    bookName NVARCHAR(50) NOT NULL,
    author NVARCHAR(50) NOT NULL,    
    publishedDate DATE NOT NULL,
    issueDate DATE NOT NULL,
    returnDate DATE NOT NULL,
    genre NVARCHAR(100) NOT NULL,
    condition NVARCHAR(4000) NOT NULL
)

SELECT * FROM admin
SELECT * FROM student
SELECT * FROM books
SELECT * FROM issue
SELECT * FROM returnBook

ALTER TABLE issue
ADD genre NVARCHAR(100) NOT NULL

DROP TABLE returnBook;
ALTER TABLE books DROP COLUMN isDeleted;

ALTER TABLE books
ALTER COLUMN bookName NVARCHAR(100) NOT NULL;

ALTER TABLE returnBook
ADD studentImage IMAGE NOT NULL;

DELETE FROM books
WHERE author = 'testing';

UPDATE admin
SET isAdmin = 1
WHERE surname = 'Catana';