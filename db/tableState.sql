create database [requestForm]

use master;
use requestForm;

CREATE TABLE dbo.State (
    IdState INT IDENTITY PRIMARY KEY NOT NULL ,
    NameState varchar(50) NOT NULL
);
--Get all states
CREATE PROC SP_GET_STATE
AS
BEGIN
    SELECT
    IdState, NameState 
    from dbo.State
END
--Insert state
CREATE PROC SP_ADD_STATE(
@NameState varchar(50)
)AS
BEGIN
    INSERT INTO dbo.State(NameState)
    VALUES (@NameState)
END
--Update State
CREATE PROC SP_UPDATE_STATE(
@IdState int,
@NameState varchar(50)
)AS
BEGIN
    UPDATE dbo.State SET
    NameState = isnull(@NameState, NameState)
    WHERE IdState = @IdState
END
--Delete State
CREATE PROC SP_DELETE_STATE(
@IdState INT 
)AS
BEGIN
    DELETE FROM dbo.State WHERE IdState = @IdState
END
drop table Municipality;
--
--Municipality
CREATE TABLE dbo.Municipality (
    IdMunicipality INT IDENTITY PRIMARY KEY NOT NULL ,
    NameMunicipality varchar(50) NOT NULL,
    StateId int,
    /*Relationship one to much*/
    constraint fk_state FOREIGN KEY(StateId) REFERENCES State(IdState)
);
--Get all Municipality
CREATE PROC SP_GET_MUN
AS
BEGIN
    SELECT
    IdMunicipality, NameMunicipality, StateId
    from dbo.Municipality
END
--Insert Municipality
CREATE PROC SP_ADD_Mun(
@NameMunicipality varchar(50),
@StateId int
)AS
BEGIN
    INSERT INTO dbo.Municipality(NameMunicipality,StateId )
    VALUES (@NameMunicipality, @StateId)
END

insert into dbo."Municipality" ("NameMunicipality", "StateId") values ('Leon', 1);
SELECT * from "Municipality";