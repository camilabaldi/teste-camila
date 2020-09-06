 create database SQLtest;

#CASE SQLSERVER
create table Cliente (
	idCli int NOT NULL identity(1,1),
	nome varchar(50),
	idade int,
    cpf varchar(16),
    tel varchar(16),
    email varchar(60),
    cep varchar(10),
    num int,
    
    primary key (idCli)
);

create table Filme (
	idFilm int NOT NULL identity(1,1),
	nome varchar(50),
	autor varchar(40),
    ano int,
	status bit,
    
    primary key (idFilm)
);

create table Locacao (
	idLoc int NOT NULL identity(1,1),
	idClie int,
	idFilm int,
	dtLocado date,
	dtDevolucao date,
    
    primary key (idLoc)
);

