CREATE DATABASE AFP;
USE AFP;
CREATE TABLE PACIENTE(
    Id int PRIMARY KEY IDENTITY,
    Nombre varchar(100) not null,
    fechaNacimiento DATE not null,
    sexo varchar(10) not null,

)
CREATE TABLE DIAGNOSTICO(
    Id int PRIMARY KEY IDENTITY,
    Descripcion varchar(500) not null,
    Tratamiento varchar(500) not null,
    Paciente int,
    FOREIGN KEY (Paciente) REFERENCES PACIENTE(Id)

)
CREATE TABLE DOCTOR(
     Id int PRIMARY KEY IDENTITY,
     Nombre varchar(100) not null,
     Especialidad varchar(50) not null,
     fechaNacimiento Date not null,
     sexo varchar(10) not null
)

CREATE TABLE CITA(
    Id int IDENTITY,
    FechaCita datetime not null,
    Descripcion varchar(500) not null,
    Paciente int,
    Doctor int,
    PRIMARY KEY (Id),
    FOREIGN KEY (Paciente) REFERENCES PACIENTE(Id),
    FOREIGN KEY (Doctor) REFERENCES DOCTOR(Id)   

)