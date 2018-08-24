CREATE DATABASE hackathon;
USE hackathon;

CREATE TABLE clinica(
    clinica_id integer NOT NULL AUTO_INCREMENT,
    nome varchar(100) NOT NULL DEFAULT '',
    logradouro varchar(100) NOT NULL DEFAULT '',
    numero varchar(10) NOT NULL DEFAULT '',
    bairro varchar(50) NOT NULL DEFAULT '',
    cep varchar(10) NOT NULL DEFAULT '',
    cidade varchar(50) NOT NULL DEFAULT '',
    uf char(2) NOT NULL DEFAULT '',
	telefone varchar(50) NOT NULL DEFAULT '',
	localizacao varchar(100) NOT NULL DEFAULT '',
    usuario varchar(100) NOT NULL DEFAULT '',
	senha varchar(100) NOT NULL DEFAULT '',
    PRIMARY KEY pk_clinica (clinica_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE paciente(
    paciente_id integer NOT NULL AUTO_INCREMENT,
    cpf varchar(11) NOT NULL DEFAULT '',
    nome varchar(100) NOT NULL DEFAULT '',
    telefone varchar(50) NOT NULL DEFAULT '',
	logradouro varchar(100) NOT NULL DEFAULT '',
    numero varchar(10) NOT NULL DEFAULT '',
    bairro varchar(50) NOT NULL DEFAULT '',
    cep varchar(10) NOT NULL DEFAULT '',
    cidade varchar(50) NOT NULL DEFAULT '',
    uf char(2) NOT NULL DEFAULT '',
	localizacao varchar(100) NOT NULL DEFAULT '',
    data_nascimento date NOT NULL DEFAULT '1900-01-01',
    email varchar(100) NOT NULL DEFAULT '',
	senha varchar(100) NOT NULL DEFAULT '',
    PRIMARY KEY pk_paciente (paciente_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE medico(
    medico_id integer NOT NULL AUTO_INCREMENT,
    crm varchar(11) NOT NULL DEFAULT '',
    nome varchar(100) NOT NULL DEFAULT '',
    telefone varchar(50) NOT NULL DEFAULT '',
    PRIMARY KEY pk_medico (medico_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE especialidade(
    especialidade_id integer NOT NULL AUTO_INCREMENT,
    descricao varchar(100) NOT NULL DEFAULT '',
    PRIMARY KEY pk_especialidade (especialidade_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE medico_especialidade(
    medico_especialidade_id integer NOT NULL,
    medico_id integer NOT NULL,
    PRIMARY KEY pk_medico_especialidade (medico_especialidade_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE clinica_medico(
    clinica_id integer NOT NULL,
    medico_id integer NOT NULL,
    PRIMARY KEY pk_clinica_medico (clinica_id, medico_id),
    KEY k_clinica_medico_1 (clinica_id),
    KEY k_clinica_medico_2 (medico_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE agenda(
    agenda_id integer NOT NULL,
    clinica_id integer NOT NULL,
    medico_id integer NOT NULL,
    paciente_id integer NOT NULL,
    data_hora_marcado datetime NOT NULL DEFAULT '1900-01-01 00:00:00',
    data_hora_inicio datetime NOT NULL DEFAULT '1900-01-01 00:00:00',
    tempo_estimado time NOT NULL DEFAULT '00:00:00',
    PRIMARY KEY pk_agenda (agenda_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

