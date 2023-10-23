create database [requestForm]
use master;
use requestForm;

CREATE TABLE dbo.State (
    IdState INT IDENTITY PRIMARY KEY NOT NULL ,
    NameState varchar(50) NOT NULL
);

CREATE PROC SP_GET_STATE
AS
BEGIN
    SELECT
    IdState, NameState 
    from dbo.State
END

CREATE PROC SP_ADD_STATE(
@NameState varchar(50)
)AS
BEGIN
    INSERT INTO dbo.State(NameState)
    VALUES (@NameState)
END

CREATE PROC SP_UPDATE_STATE(
@IdState int,
@NameState varchar(50)
)AS
BEGIN
    UPDATE dbo.State SET
    NameState = isnull(@NameState, NameState)
    WHERE IdState = @IdState
END

CREATE PROC SP_DELETE_STATE(
@IdState INT 
)AS
BEGIN
    DELETE FROM dbo.State WHERE IdState = @IdState
END