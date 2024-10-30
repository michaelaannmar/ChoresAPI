CREATE DATABASE ChoreDb;
GO

USE ChoreDb;
GO

CREATE TABLE Chores (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    AssignedTo NVARCHAR(255),
    Point INT NOT NULL,
    Status NVARCHAR(50),
    Frequency NVARCHAR(50)
);
GO

CREATE PROCEDURE AddChore 
    @Id UNIQUEIDENTIFIER,
    @Title NVARCHAR(100),
    @Description NVARCHAR(500),
    @AssignedTo NVARCHAR(255),
    @Point INT,
    @Status NVARCHAR(50),
    @Frequency NVARCHAR(50)
AS
BEGIN
    INSERT INTO Chores (Id, Title, Description, AssignedTo, Point, Status, Frequency)
    VALUES (@Id, @Title, @Description, @AssignedTo, @Point, @Status, @Frequency);
END
GO

CREATE PROCEDURE UpdateChore 
    @Id UNIQUEIDENTIFIER,
    @Title NVARCHAR(100),
    @Description NVARCHAR(500),
    @AssignedTo NVARCHAR(255),
    @Point INT,
    @Status NVARCHAR(50),
    @Frequency NVARCHAR(50)
AS
BEGIN
    UPDATE Chores
    SET 
        Title = @Title,
        Description = @Description,
        AssignedTo = @AssignedTo,
        Point = @Point,
        Status = @Status,
        Frequency = @Frequency
    WHERE Id = @Id;
END
GO

CREATE PROCEDURE GetChoreById
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT * FROM Chores WHERE Id = @ID
END 
GO

CREATE PROCEDURE DeleteChore
    @ID UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM Chores WHERE ID = @Id
END
GO

INSERT INTO Chores (Id, Title, Description, AssignedTo, Point, Status, Frequency) VALUES
('a62c2d1d-ef8e-4ba4-9f9b-8c57a21f2b97', 'Vacuum the house', 'Vacuum all rooms and the hallway', 'Jane Smith', 10, 'In Progress', 'Weekly'),
('b4f4d9e6-5e8a-4a70-9610-2b5a3b7e8c28', 'Take out the trash', 'Collect and dispose of the trash', 'Michael Brown', 3, 'Completed', 'Daily'),
('15fe4354-8b45-45ff-8db8-913f91ecbe2d', 'Mow the lawn', 'Mow the front and back lawns', 'Emily Johnson', 15, 'Pending', 'Bi-weekly'),
('5decb730-bf64-46c2-a32a-90a31ad98133', 'Clean the windows', 'Clean all the windows inside and outside', 'John Doe', 8, 'In Progress', 'Monthly'),
('640eaa1e-35e1-4efd-97f7-022b766bdb27', 'string', 'string', 'string', 0, 'string', 'string'),
('d5cb0d7d-d9c0-44b3-99c5-0336a954679f', 'string', 'string', 'string', 0, 'string', 'string'),
('0e99e598-30af-4580-b3b2-8fbeedc12f48', 'string', 'string', 'string', 0, 'string', 'string');
GO