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
	('O que voc� prioriza na hora de investir?'),
	('Como voc� define sua experi�ncia com investimentos?'),
	('Se algo inesperado acontecer na economia ou no mercado e o resultado for uma oscila��o grande nos seus investimentos, qual a sua atitude?'),
	('Por quanto tempo pretende deixar o dinheiro investido conosco?'),
	('Quais desses investimentos voc� ja realizou no passado?'),
	('Voc� aplicou em fundos de investimento (Fundo multimercado, Fundo de Renda Fixa, Fundos de A��o, Fundos Exclusivos, Fundos Imobili�rios, ETF, Outros Fundos) nos ultimos 12 meses?'),
	('Voc� aplicou em Renda Vari�vel (a��es) nos �ltimos 12 meses?'),
	('Voc� aplicou em T�tulos de Renda Fixa (t�tulos p�blicos, CDBs, Debentures de C�mbio/Financeira, LCI/LCA, CRI/CRA nos ultimos 12 meses?'),
	('Voc� aplicou em Previd�ncia Privada nos ultimos 12 meses'),
	('Voc� aplicou em Derivativos (Op��es, Futuros, etc) e COE nos ultimos 12 meses?'),
	('Sobre os recursos investidos conosco, quando voc� pretende utiliz�-los?'),
	('Qual � a sua forma��o acad�mica?');

INSERT INTO tb_Respostas_Suitability(Descricao_resposta, Pontuacao_resposta) VALUES
	('Busco primeiro seguran�a, pensando no longo prazo, mesmo abrindo m�o de um pouco de rentabilidade', 1),
	('Sigo o conselho de algu�m que conhe�a mais o mercado que eu e seja de minha confian�a',2),
	('Invisto em algo que eu conhe�a bem',3),
	('Seguran�a e Tranquilidade', 1),
	('Rentabilidade e Diversifica��o',2),
	('Nenhuma', 0),
	('Possuo conhecimento e experi�ncia no mercado de renda fixa e fundos', 1),
	('Possuo algum conhecimento no mercado de renda vari�vel e de derivativos',2),
	('Possuo amplo experi�ncia no mercado de renda vari�vel e de derivativos',3),
	('Venderia imadiatamente', 1),
	('Entendo que estou exposto a este risco para determinados ativos, mas n�o para todo o meu patrim�nio', 2),
	('Entendo que meu patrim�nio est� sujeito a flutua��es dessa magnitude e n�o est�o 100% protegido', 3),
	('Menos de 1 ano', 1),
	('De 1 a 3 anos', 2),
	('De 3 a 5 anos',3),
	('Acima de 5 anos', 4),
	('Nunca investi', 0),
	('Poupan�a', 1),
	('Previd�ncia privada', 1),
	('T�tulos de RF', 1),
	('Fundos de Investimento', 1),
	('Bolsa de valores e derivativos', 1),
	('Sim', 1),
	('N�o', 0),
	('Nos pr�ximos 6 meses', 1),
	('Nos pr�ximos 12 meses', 2),
	('N�o tenho necessidade de utilizar os recursos', 3),
	('Ensino fundamental completo', 1),
	('Ensino m�dio completo', 2),
	('Ensino superior completo', 3),
	('P�s-gradua��o', 4);
	
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