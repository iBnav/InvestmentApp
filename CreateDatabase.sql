CREATE TABLE tb_Perfil_Suitability (
	ID_perfil INT IDENTITY PRIMARY KEY,
	Descricao_perfil VARCHAR(15) NOT NULL
);

CREATE TABLE tb_Usuario (
	ID_usuario INT IDENTITY PRIMARY KEY,
	Nome_usuario VARCHAR(50) NOT NULL,
	Email_usuario VARCHAR(100) not null,
	Password_usuario VARCHAR(50) not null,
	Perfil_usuario INT,
	flag_Primeiro_Login bit NOT NULL DEFAULT 1,
	CONSTRAINT FK_perfil FOREIGN KEY (Perfil_usuario) REFERENCES tb_Perfil_Suitability(ID_perfil)
);

CREATE TABLE tb_Perguntas_Suitability(
	ID_pergunta INT IDENTITY PRIMARY KEY,
	Descricao_pergunta VARCHAR(255) NOT NULL,
);

CREATE TABLE tb_Respostas_Suitability(
	ID_resposta INT IDENTITY PRIMARY KEY,
	Descricao_resposta VARCHAR(255) NOT NULL,
	Pontuacao_resposta INT NOT NULL,
);

CREATE TABLE tb_Pergunta_Respostas(
	ID_Pergunta INT NOT NULL,
	ID_Resposta INT NOT NULL,
	CONSTRAINT FK_Pergunta FOREIGN KEY (ID_Pergunta) REFERENCES tb_Perguntas_Suitability(ID_Pergunta),
	CONSTRAINT FK_Resposta FOREIGN KEY (ID_Resposta) REFERENCES tb_Respostas_Suitability(ID_Resposta)
);

CREATE TABLE Usuario_Pergunta_Resposta(
	ID_Usuario_Pergunta_Resposta INT IDENTITY PRIMARY KEY,
	ID_Usuario INT NOT NULL,
	ID_Pergunta INT NOT NULL,
	ID_Resposta INT NOT NULL,
	CONSTRAINT FK_Usuario FOREIGN KEY (ID_Usuario) REFERENCES tb_Usuario(ID_Usuario),
	CONSTRAINT FK_Pergunta_Resposta FOREIGN KEY (ID_Pergunta) REFERENCES tb_Perguntas_Suitability(ID_Pergunta),
	CONSTRAINT FK_Resposta_Pergunta FOREIGN KEY (ID_Resposta) REFERENCES tb_Respostas_Suitability(ID_Resposta)
);

INSERT INTO tb_Perfil_Suitability(Descricao_perfil) values ('Conservador'), ('Moderado'), ('Agressivo');

INSERT INTO tb_Perguntas_Suitability(Descricao_pergunta) values
	('Selecione a frase que melhor o descreve na hora de esoclher um investimento:'),
	('O que você prioriza na hora de investir?'),
	('Como você define sua experiência com investimentos?'),
	('Se algo inesperado acontecer na economia ou no mercado e o resultado for uma oscilação grande nos seus investimentos, qual a sua atitude?'),
	('Por quanto tempo pretende deixar o dinheiro investido conosco?'),
	('Quais desses investimentos você ja realizou no passado?'),
	('Você aplicou em fundos de investimento (Fundo multimercado, Fundo de Renda Fixa, Fundos de Ação, Fundos Exclusivos, Fundos Imobiliários, ETF, Outros Fundos) nos ultimos 12 meses?'),
	('Você aplicou em Renda Variável (ações) nos últimos 12 meses?'),
	('Você aplicou em Títulos de Renda Fixa (títulos públicos, CDBs, Debentures de Câmbio/Financeira, LCI/LCA, CRI/CRA nos ultimos 12 meses?'),
	('Você aplicou em Previdência Privada nos ultimos 12 meses'),
	('Você aplicou em Derivativos (Opções, Futuros, etc) e COE nos ultimos 12 meses?'),
	('Sobre os recursos investidos conosco, quando você pretende utilizá-los?'),
	('Qual é a sua formação acadêmica?');

INSERT INTO tb_Respostas_Suitability(Descricao_resposta, Pontuacao_resposta) VALUES
	('Busco primeiro segurança, pensando no longo prazo, mesmo abrindo mão de um pouco de rentabilidade', 1),
	('Sigo o conselho de alguém que conheça mais o mercado que eu e seja de minha confiança',2),
	('Invisto em algo que eu conheça bem',3),
	('Segurança e Tranquilidade', 1),
	('Rentabilidade e Diversificação',2),
	('Nenhuma', 0),
	('Possuo conhecimento e experiência no mercado de renda fixa e fundos', 1),
	('Possuo algum conhecimento no mercado de renda variável e de derivativos',2),
	('Possuo amplo experiência no mercado de renda variável e de derivativos',3),
	('Venderia imadiatamente', 1),
	('Entendo que estou exposto a este risco para determinados ativos, mas não para todo o meu patrimônio', 2),
	('Entendo que meu patrimônio está sujeito a flutuações dessa magnitude e não estão 100% protegido', 3),
	('Menos de 1 ano', 1),
	('De 1 a 3 anos', 2),
	('De 3 a 5 anos',3),
	('Acima de 5 anos', 4),
	('Nunca investi', 0),
	('Poupança', 1),
	('Previdência privada', 1),
	('Títulos de RF', 1),
	('Fundos de Investimento', 1),
	('Bolsa de valores e derivativos', 1),
	('Sim', 1),
	('Não', 0),
	('Nos próximos 6 meses', 1),
	('Nos próximos 12 meses', 2),
	('Não tenho necessidade de utilizar os recursos', 3),
	('Ensino fundamental completo', 1),
	('Ensino médio completo', 2),
	('Ensino superior completo', 3),
	('Pós-graduação', 4);
	
INSERT INTO tb_Pergunta_Respostas(ID_Pergunta, ID_Resposta) VALUES 
	(1,1),
	(1,2),
	(1,3),
	(2,4),
	(2,5),
	(3,6),
	(3,7),
	(3,8),
	(3,9),
	(4,10),
	(4,11),
	(4,12),
	(5,13),
	(5,14),
	(5,15),
	(5,16),
	(6,17),
	(6,18),
	(6,19),
	(6,20),
	(6,21),
	(6,22),
	(7,23),
	(7,24),
	(8,23),
	(8,24),
	(9,23),
	(9,24),
	(10,23),
	(10,24),
	(11,23),
	(11,24),
	(12,25),
	(12,26),
	(12,27),
	(13,28),
	(13,29),
	(13,30),
	(13,31);