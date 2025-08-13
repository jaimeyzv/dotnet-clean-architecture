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

--Loans are based in months
CREATE TABLE [dbo].[Loans]
(
	LoanId			INT PRIMARY KEY IDENTITY (1, 1),
	Principal		DECIMAL(10, 2) NOT NULL,
	CurrentBalance	DECIMAL(10, 2) NOT NULL,
	BorrowerName	VARCHAR(100) NOT NULL,
	LoanTerm		INT NOT NULL,
	InterestRate	DECIMAL(10, 2) NOT NULL,
	TotalPayment	DECIMAL(10, 2) NOT NULL,
	Status			VARCHAR(20) NOT NULL
)
GO

--Tabla para Status de la tabla Loans?  Activo y Pagado?
--Tabla para status de las cuotas? Pagado, Atrasado, Pendiente?
--Tabla de historia de las cuotas para ver  si se pago o no la fecha pactada? Aplicar multa por demora?
-- Tabla para cuotas? con fechas de las cuotas?
-- Tabla para los pagos a cualquier tiempo mas no en cuotas? Es decir, plazo de 6 meses y cuando quiere paga algo o todo pero dentro del tiempo 
--CREATE TABLE [dbo].[LoansHistory]
--(
--	LoanHistoryId	INT PRIMARY KEY IDENTITY (1, 1),	
--	Amount			DECIMAL(10, 2) NULL,
--	PayDate			DATETIME NOT NULL,
--	LoanId			INT,
	
--	FOREIGN KEY (LoanId) REFERENCES Loans (LoanId)
--)
--GO

/*---------------------------- SELECTS ----------------------------*/
SELECT * FROM [dbo].[Loans]
--SELECT * FROM [dbo].[LoansHistory]
delete from [dbo].[Loans] where LoanId in (5, 6)

-- 100,000.00