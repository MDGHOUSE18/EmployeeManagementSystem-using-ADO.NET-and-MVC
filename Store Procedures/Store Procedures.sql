Create DATABASE EmployeeManagementSystem;

use EmployeeManagementSystem;

CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL,
    Gender VARCHAR(10) NOT NULL CHECK (Gender IN ('Male', 'Female', 'Other')),
    Age INT NOT NULL,
    Designation VARCHAR(50) NOT NULL,
    City VARCHAR(50) NOT NULL
);

Create Procedure spAddEmployee
	@Name Varchar(50),
	@Gender Varchar(10),
	@Age Varchar(50), 
	@Designation Varchar(50),
	@City Varchar(50)
AS
BEGIN
	INSERT INTO dbo.Employees(Name, Gender, Age, Designation, City)
	VALUES(@Name, @Gender, @Age, @Designation, @City)
END;

Create Procedure spUpdateEmployee
	@id int,
	@Name Varchar(50),
	@Gender Varchar(10),
	@Age Varchar(50), 
	@Designation Varchar(50),
	@City Varchar(50)
AS
BEGIN
	Update dbo.Employees
	Set Name = @Name,
		Gender = @Gender,
		Age = @Age,
		Designation = @Designation,
		City = @City
	WHERE id = @id;
END;

Create Procedure spDeleteEmployee
	@id int
AS
BEGIN
	DELETE FROM dbo.Employees 
	WHERE id=@id;
END;

Create Procedure spGetEmployeeById
	@id int
AS
BEGIN
	Select * FROM dbo.Employees
	WHERE id = @id;
END;

Create OR ALTER Procedure spGetAllEmployees
AS
BEGIN
	Select * FROM dbo.Employees;
END;