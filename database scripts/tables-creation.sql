USE master

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'OnlineLoans')
BEGIN
    DROP DATABASE [OnlineLoans]
	USE master
END

CREATE DATABASE [OnlineLoans]
GO

USE [OnlineLoans]
GO

CREATE TABLE [dbo].[Loans]
(
	LoanId			INT PRIMARY KEY IDENTITY (1, 1),
	Principal		DECIMAL(10, 2) NOT NULL,
	CurrentBalance	DECIMAL(10, 2) NOT NULL,
	BorrowerName	VARCHAR(100) NOT NULL,
	DurationMonths	INT NOT NULL,
	InterestRate	DECIMAL(10, 2) NOT NULL,
	TotalPayment	DECIMAL(10, 2) NOT NULL,
	Status			VARCHAR(20) NOT NULL
)
GO

CREATE TABLE [dbo].[LoanInstallments]
(
	LoanInstallmentId	INT PRIMARY KEY IDENTITY (1, 1),
	InstallmentNumber 	INT NOT NULL,
	DueDate				DATETIME NOT NULL,
	Amount 				DECIMAL(10, 2) NOT NULL,
	IsPaid 				BIT NOT NULL,
	PaymentDate 		DATETIME NULL,
	LoanInstallmentsLoanId	INT NOT NULL,

	FOREIGN KEY (LoanInstallmentsLoanId) REFERENCES [Loans] (LoanId)
)
GO

/*---------------------------- DATA FOR TESTING ----------------------------*/

-- Creating scenario in which the loans has 2 installments overdue
INSERT INTO Loans (Principal, CurrentBalance, BorrowerName, DurationMonths, InterestRate, TotalPayment, Status) 
VALUES
	(10000.00, 15000.00, 'Piero Zamora', 5, 0.10, 15000.00, 'Active');

INSERT INTO LoanInstallments (InstallmentNumber, DueDate, Amount, IsPaid, PaymentDate, LoanInstallmentsLoanId) 
VALUES
	(1, '2025-05-13', 3000.00, 1, '2025-05-14', 1),
	(2, '2025-06-13', 3000.00, 1, '2025-06-15', 1),
	(3, '2025-07-13', 3000.00, 0, NULL, 1),
	(4, '2025-08-13', 3000.00, 0, NULL, 1),
	(5, '2026-09-13', 3000.00, 0, NULL, 1);

-- Creating scenario in which the the loan is PAID and all installments are paid 
INSERT INTO Loans (Principal, CurrentBalance, BorrowerName, DurationMonths, InterestRate, TotalPayment, Status) 
VALUES
	(10000.00, 15000.00, 'Carol Chavez', 5, 0.10, 15000.00, 'Paid');

INSERT INTO LoanInstallments (InstallmentNumber, DueDate, Amount, IsPaid, PaymentDate, LoanInstallmentsLoanId) 
VALUES	
	(1, '2025-03-01', 3000.00, 1, '2025-03-01', 2),
	(2, '2025-04-01', 3000.00, 1, '2025-04-01', 2),
	(3, '2025-05-01', 3000.00, 1, '2025-05-02', 2),
	(4, '2025-06-01', 3000.00, 1, '2025-06-04', 2),
	(5, '2026-07-01', 3000.00, 1, '2026-07-02', 2);

/*---------------------------- SELECTS ----------------------------*/
SELECT * FROM [dbo].[Loans]
SELECT * FROM [dbo].[LoanInstallments]