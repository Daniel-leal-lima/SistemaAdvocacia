USE master
GO
DROP DATABASE IF EXISTS BDAdvocacia
GO

CREATE DATABASE BDAdvocacia
GO

USE BdAdvocacia
GO

CREATE TABLE TbUsuario(
	IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(90),
	Senha varchar(20),
	TipoAcesso VARCHAR(11) CHECK( TipoAcesso in('A','S')) NOT NULL,
);
GO

CREATE TABLE TbCliente(
	IdCliente INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(90),
	Telefone VARCHAR(11),
	CPF VARCHAR(11) UNIQUE NOT NULL
);
GO
CREATE TABLE TbParteContraria(
	IdParteContraria INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(90) NOT NULL,
	Tipo CHAR(1) CHECK( Tipo in('F','J')) NOT NULL, -------- F: física ||||| J: Juridica
	CPF VARCHAR(11) ,
	CNPJ VARCHAR(14) ,
);
GO
CREATE TABLE TbProcesso(
	IdProcesso INT IDENTITY(1,1) PRIMARY KEY,
	IdCliente INT NOT NULL,
	IdParteContraria INT NOT NULL,
	NumeroProcesso VARCHAR(20) UNIQUE NOT NULL,
	Foro VARCHAR(11) NOT NULL,
	TipoAcao VARCHAR(100) NOT NULL,
	Area VARCHAR(60) NOT NULL,
	AndamentoProcesso TEXT,
	FoiIndicacao CHAR(1) CHECK( FoiIndicacao in('S','N')) DEFAULT 'N',
	NomeCaptador VARCHAR(90),
	LocalDescobrimento VARCHAR(9),
	FOREIGN KEY (IdCliente) REFERENCES TbCliente(IdCliente),
	FOREIGN KEY (IdParteContraria) REFERENCES TbParteContraria(IdParteContraria)
);
GO
CREATE TABLE TbContrato(
	IdContrato INT IDENTITY(1,1) PRIMARY KEY,
	IdProcesso INT NOT NULL,
	TipoPagamento CHAR(1) CHECK(TipoPagamento in('C','B','A')) NOT NULL,  --- C: Cartão ||||| B:Boleto ||||| A: À Vista
	Observacao TEXT,
	Situacao CHAR(1) CHECK(Situacao in ('Q','P')) DEFAULT 'P',   ----- P: Pendente ||||| Q: Quitada
	DiaVencimento VARCHAR(2) NOT NULL,
	DataContrato DATE NOT NULL,
	QtdVezes INT,
	ValorTotal DECIMAL(10,2) NOT NULL,
	ValorEntrada DECIMAL(10,2) NOT NULL,
	ValorComissao DECIMAL(10,2) NOT NULL,
	FOREIGN KEY (IdProcesso) REFERENCES TbProcesso(IdProcesso)
);
GO
CREATE TABLE TbParcela(
	IdParcela INT IDENTITY(1,1) PRIMARY KEY,
	IdCliente INT NOT NULL,
	IdContrato INT NOT NULL,
	Valor DECIMAL(10,2) NOT NULL, --- a precisão é medida em (10-2). ou seja 8 casas antes dos ponto decimal
	DataVencimento DATE,
	Situacao CHAR(1) CHECK(Situacao in ('P','D')) DEFAULT 'D',   ----- P: Pago ||||| D:Devendo
	Observacao TEXT,
	FOREIGN KEY(IdCliente) REFERENCES TbCliente(IdCliente),
	FOREIGN KEY(IdContrato) REFERENCES TbContrato(IdContrato)

);
GO
------------------------------------------------------------------------------------------------------ TRIGGERS
CREATE TRIGGER Trgg_ChecaSePagouTudo
ON TbParcela
AFTER UPDATE,INSERT
AS
BEGIN
		DECLARE @quantidade int,
		@QtdPagos int,
		@Id int

		SELECT @Id = IdContrato from inserted

		SELECT @Quantidade = COUNT(*)
		FROM TbParcela
		WHERE IdContrato = @Id

		select @Quantidade

		select @QtdPagos=COUNT(*)
		FROM TbParcela
		WHERE IdContrato = @Id
		and Situacao = 'P'

		select @QtdPagos

			IF(@QtdPagos=@quantidade)
				BEGIN
					UPDATE TbContrato SET Situacao='Q' 
					WHERE IdContrato=@Id
				END
			ELSE
				BEGIN
					UPDATE TbContrato SET Situacao='P' 
					WHERE IdContrato=@Id
				END
END
GO
CREATE TRIGGER Trgg_ChecaSePagouTudo_Deletado
ON TbParcela
AFTER DELETE
AS
BEGIN
		DECLARE @quantidade int,
		@QtdPagos int,
		@Id int

		SELECT @Id = IdContrato from deleted

		SELECT @Quantidade = COUNT(*)
		FROM TbParcela
		WHERE IdContrato = @Id

		select @Quantidade

		select @QtdPagos=COUNT(*)
		FROM TbParcela
		WHERE IdContrato = @Id
		and Situacao = 'P'

		select @QtdPagos

			IF(@quantidade=0)
				BEGIN
					UPDATE TbContrato SET Situacao='P' -- SE A QUANTIDADE DE LINHAS FOR 0, ISSO SIGNIFICA que está devendo
					WHERE IdContrato=@Id
				END
END
GO

------------------------------------------------------------------------------------------------------ VERIFICAÇÕES

CREATE PROC spIsClienteNovo  ----------- VERIFICA SE O CLIENTE É NOVO
@CPF VARCHAR(11)
As
BEGIN
	 SELECT IdCliente,CPF,Nome,Telefone FROM TbCliente WHERE CPF = @CPF
END
GO

CREATE PROC spIsParteContrariaNova  ----------- VERIFICA SE A PARTE CONTRÁRIA É NOVA PELO CPF OU CNPJ
@CPF VARCHAR(11)='',
@CNPJ VARCHAR(14)='',
@Tipo CHAR(1)
As
BEGIN
	IF(@Tipo='F')
		begin
			SELECT IdParteContraria,Nome,Tipo,CPF,CNPJ FROM TbParteContraria WHERE CPF = @CPF
		end
	ELSE
		begin
			SELECT IdParteContraria,Nome,Tipo,CPF,CNPJ FROM TbParteContraria WHERE CNPJ = @CNPJ
		end
END
GO

CREATE PROC spIsParteContrariaNovaPeloNome  ----------- VERIFICA SE A PARTE CONTRÁRIA É NOVA PELO NOME
@Nome VARCHAR(90)
As
BEGIN
	 SELECT IdParteContraria,Nome,Tipo,CPF,CNPJ FROM TbParteContraria WHERE Nome = @Nome
END
GO

CREATE PROC spPegaUltimoIdCliente -------------- PEGA ÚLTIMO ID DO CLIENTE
AS
BEGIN
	SELECT TOP 1 (IdCliente+1) from TbCliente order by IdCliente desc
END
GO

CREATE PROC spPegaUltimoIdParteContraria -------------- PEGA ÚLTIMO ID DA PARTE CONTRARIA
AS
BEGIN
	SELECT TOP 1 (IdParteContraria+1) from TbParteContraria order by IdParteContraria desc
END
GO

CREATE PROC spPegaUltimoIdContrato -------------- PEGA ÚLTIMO ID DA PARTE CONTRARIA
AS
BEGIN
	SELECT TOP 1 (IdContrato+1) from TbContrato order by IdContrato desc
END
GO

CREATE PROC spSomaParcelas
@IdContrato INT
AS
BEGIN
	SELECT SUM(Valor) as RESULTADO
	FROM TbParcela
	WHERE IdContrato = @IdContrato
		AND Situacao = 'P'
END
GO
------------------------------------------------------------------------------------------------------ CADASTROS

CREATE PROC spCadastraUsuaria
@Nome VARCHAR(90),
@Senha VARCHAR(20),
@TipoAcesso CHAR(1)
AS
BEGIN
	INSERT INTO TbUsuario(Nome,Senha,TipoAcesso)
	VALUES(@Nome,@Senha,@TipoAcesso)
END
GO

CREATE PROC spCadastraCliente -------- CADASTRANDO REQUERENTE
@Nome VARCHAR(90)='',
@CPF VARCHAR(11),
@Telefone VARCHAR(11)=''
AS
BEGIN
	INSERT INTO TbCliente(Nome,CPF,Telefone) VALUES(@Nome,@CPF,@Telefone)
END
GO

CREATE PROC spCadastraParteContraria ------ CADASTRANDO PARTE CONTRARIA
@Nome VARCHAR(90),
@CPF VARCHAR(11)='',
@CNPJ VARCHAR(14)='',
@Tipo CHAR(1)
AS
BEGIN
	IF(@Tipo='F')
		begin
			INSERT INTO TbParteContraria(Nome,CPF,Tipo) VALUES(@Nome,@CPF,@Tipo)
		end
	ELSE
		begin
			INSERT INTO TbParteContraria(Nome,CNPJ,Tipo) VALUES(@Nome,@CNPJ,@Tipo)
		end
END
GO


CREATE PROC spCadastraProcesso ------ CADASTRANDO PROCESSO
@IdCliente INT,
@IdParteContraria INT,
@NumeroProcesso VARCHAR(20),
@Foro VARCHAR(11),
@TipoAcao VARCHAR(100),
@Area VARCHAR(60),
@AndamentoProcesso TEXT,
@FoiIndicacao CHAR(1),
@NomeCaptador VARCHAR(90),
@LocalDescobrimento VARCHAR(9)
AS
BEGIN
	INSERT INTO TbProcesso(IdCliente,IdParteContraria,
	NumeroProcesso,Foro,TipoAcao,Area,AndamentoProcesso,
	FoiIndicacao,NomeCaptador,LocalDescobrimento)
	VALUES(@IdCliente,@IdParteContraria,
	@NumeroProcesso,@Foro,@TipoAcao,@Area,@AndamentoProcesso,
	@FoiIndicacao,@NomeCaptador,@LocalDescobrimento)
END
GO

CREATE PROC spCadastraContrato ------ CADASTRANDO CONTRATO
@IdProcesso INT,
@TipoPagamento CHAR(1),  --- C: Cartão ||||| B:Boleto ||||| A: À Vista
@Observacao TEXT,
@DiaVencimento VARCHAR(2),
@DataContrato DATE,
@QtdVezes INT,
@ValorTotal DECIMAL(10,2),
@ValorEntrada DECIMAL(10,2),
@ValorComissao DECIMAL(10,2)
AS
BEGIN
	INSERT INTO TbContrato(IdProcesso,TipoPagamento,Observacao,
	DiaVencimento,DataContrato,QtdVezes,ValorTotal,ValorEntrada,
	ValorComissao)
	VALUES(@IdProcesso,@TipoPagamento,@Observacao,
	@DiaVencimento,@DataContrato,@QtdVezes,
	@ValorTotal,@ValorEntrada,@ValorComissao)
END
GO

CREATE PROC spCadastraParcela ------ CADASTRANDO Parcela
@IdCliente INT,
@IdContrato INT,
@Valor DECIMAL(10,2),
@DataVencimento DATE,
@Situacao CHAR(1),
@Observacao TEXT
AS
BEGIN
	INSERT INTO TbParcela(IdCliente,IdContrato,
	Valor,DataVencimento,Situacao,Observacao)
	VALUES(@IdCliente,@IdContrato,
	@Valor,@DataVencimento,@Situacao,
	@Observacao)
END
GO


------------------------------------------------------------------------------------------------------ SELECTS
CREATE PROC spGetUsuario  --VALIDA USUARIO
@Nome VARCHAR(90),
@Senha VARCHAR(20)
AS
BEGIN
	SELECT 
	IdUsuario,
	Nome,
	Senha,
	TipoAcesso
	FROM TbUsuario
	WHERE
		Nome=@Nome and
		Senha=@Senha
END
GO
CREATE PROC spSelectProcessoBASE
@Filtro VARCHAR(MAX)
AS
BEGIN
		 EXEC ('SELECT Cliente.IdCliente,
	ParteContraria.IdParteContraria,
	Processo.IdProcesso,
	Cliente.Nome,
	Cliente.CPF,
	Cliente.Telefone,
	ParteContraria.Nome as Parte_Contraria,
	Processo.NumeroProcesso
	FROM TbProcesso Processo
		INNER JOIN TbCliente Cliente 
			ON Processo.IdCliente = Cliente.IdCliente
		INNER JOIN TbParteContraria ParteContraria
			ON Processo.IdParteContraria = ParteContraria.IdParteContraria
	'+@Filtro)
END
GO

CREATE PROC spGetFiltragemSimplesProcesso
AS
BEGIN
	exec spSelectProcessoBASE @Filtro=''
END
GO

CREATE PROC spGetFiltragemAvancadaProcesso
@Filtro VARCHAR(11),
@Texto VARCHAR(90)
AS
BEGIN
	DECLARE @ComandoFiltro VARCHAR(500)
	IF(@Filtro='Nome')
		begin
			set @ComandoFiltro =
			'WHERE Cliente.Nome like CONCAT(''%'','+'''' + @Texto+ '''' +',''%'')'

			EXEC spSelectProcessoBASE @Filtro= @ComandoFiltro
		end
	IF(@Filtro='CPF')
		begin
			set @ComandoFiltro =
			'WHERE Cliente.CPF like CONCAT(''%'','+'''' + @Texto+ '''' +',''%'')'

			EXEC spSelectProcessoBASE @Filtro= @ComandoFiltro
		end
	IF(@Filtro='Telefone')
		begin
			set @ComandoFiltro =
			'WHERE Cliente.Telefone like CONCAT(''%'','+'''' + @Texto+ '''' +',''%'')'

			EXEC spSelectProcessoBASE @Filtro= @ComandoFiltro
		end
	IF(@Filtro='Nº Processo')
		begin
			set @ComandoFiltro =
			'WHERE Processo.NumeroProcesso like CONCAT(''%'','+'''' + @Texto+ '''' +',''%'')'

			EXEC spSelectProcessoBASE @Filtro= @ComandoFiltro
		end
END
GO

CREATE PROC spGetProcessoCliente   --- PEGA O PROCESSO PARA CONSULTAR CLIENTE
@IdCliente INT,
@IdProcesso INT,
@IdParteContraria INT
AS
BEGIN
	SELECT IdProcesso,
	Processo.IdCliente,
	Processo.IdParteContraria,
	Processo.NumeroProcesso,
	Processo.Foro,
	Processo.TipoAcao,
	Processo.Area,
	Processo.FoiIndicacao,
	Processo.NomeCaptador,
	Processo.LocalDescobrimento,
	Processo.AndamentoProcesso,
	Cliente.Nome,
	Cliente.CPF,
	Cliente.Telefone,
	ParteContraria.Nome,
	ParteContraria.CPF,
	ParteContraria.CNPJ,
	ParteContraria.Tipo
	FROM TbProcesso Processo
		INNER JOIN TbCliente Cliente 
			ON Processo.IdCliente = Cliente.IdCliente
		INNER JOIN TbParteContraria ParteContraria 
			ON Processo.IdParteContraria = ParteContraria.IdParteContraria
	WHERE Cliente.IdCliente = @IdCliente AND
		  Processo.IdProcesso = @IdProcesso AND
		  ParteContraria.IdParteContraria = @IdParteContraria
END
GO
CREATE PROC spGetProcessoContrato   --- PEGA O PROCESSO PARA O CONTRATO
@IdCliente INT,
@IdProcesso INT
AS
BEGIN
	SELECT IdProcesso,
	Processo.IdCliente,
	Processo.NumeroProcesso,
	Processo.FoiIndicacao,
	Processo.NomeCaptador,
	Processo.LocalDescobrimento,
	Cliente.Nome,
	Cliente.CPF,
	Cliente.Telefone
	FROM TbProcesso Processo
		INNER JOIN TbCliente Cliente 
			ON Processo.IdCliente = Cliente.IdCliente
	WHERE Cliente.IdCliente = @IdCliente AND
		  Processo.IdProcesso = @IdProcesso
END
GO
------------------------------------------------------------------------------------------------ BASE DA PROCEDURE DO CONTRATO
CREATE PROC spSelectContratoBASE
@Filtro VARCHAR(MAX)
AS
BEGIN
		 EXEC ('SELECT Processo.IdCliente,
	Processo.IdProcesso,
	Contrato.IdContrato,
	Cliente.Nome,
	Cliente.CPF,
	Cliente.Telefone,
	Processo.NumeroProcesso,
	CASE
		WHEN
			FORMAT (
				(Select top 1 DataVencimento From TbParcela P
					where P.IdContrato = Contrato.IdContrato
						and P.Situacao = ''D''
							order by DataVencimento asc) 
			, ''dd/MM/yy'') IS NULL then ''SEM DATA''
		ELSE
			FORMAT(
				(Select top 1 DataVencimento From TbParcela P
					where P.IdContrato = Contrato.IdContrato
						and P.Situacao = ''D''
							order by DataVencimento asc) 
			, ''dd/MM/yy'')
					end
		AS DataVencimento
		FROM TbContrato Contrato
		INNER JOIN TbProcesso Processo
			on Contrato.IdProcesso=Processo.IdProcesso
		INNER JOIN TbCliente Cliente
			ON Processo.IdCliente= Cliente.IdCliente
			WHERE Contrato.Situacao =''P''
	'+@Filtro)
END
GO

------------------------------------------------------------------------------------------------ BASE DA PROCEDURE DO CONTRATO
CREATE PROC spGetFiltragemSimplesContrato
AS
BEGIN
	EXEC spSelectContratoBASE @Filtro=''
END
GO

CREATE PROC spGetFiltragemAvancadaContrato -------- FILTRAGEM AVANCADA CONTRATO
@Filtro VARCHAR(30),
@Texto VARCHAR(90)
AS
BEGIN
	DECLARE @ComandoFiltro VARCHAR(500)
	IF(@Filtro='Nome')
		begin
			set @ComandoFiltro =
			'AND Cliente.Nome like CONCAT(''%'','+'''' + @Texto+ '''' +',''%'')'

			EXEC spSelectContratoBASE @Filtro= @ComandoFiltro
		end
	IF(@Filtro='CPF')
		begin
			set @ComandoFiltro =
			'AND Cliente.CPF like CONCAT(''%'','+'''' + @Texto+ '''' +',''%'')'
			EXEC spSelectContratoBASE @Filtro= @ComandoFiltro
		end
		IF(@Filtro='Nº Processo')
		begin
			set @ComandoFiltro =
			'AND Processo.NumeroProcesso like CONCAT(''%'','+'''' + @Texto+ '''' +',''%'')'
			EXEC spSelectContratoBASE @Filtro= @ComandoFiltro
		end
	IF(@Filtro='Data de Pagamento')
		begin
			set @ComandoFiltro =
			'AND FORMAT((Select top 1 DataVencimento From TbParcela P
					where P.IdContrato = Contrato.IdContrato
						and P.Situacao = ''D''
							order by DataVencimento asc) 
			, ''dd/MM/yy'') like CONCAT(''%'','+'''' + @Texto + '''' +',''%'')'
			EXEC spSelectContratoBASE @Filtro= @ComandoFiltro
		end
	IF(@Filtro='Telefone')
		begin
			set @ComandoFiltro =
			'AND Cliente.Telefone like CONCAT(''%'','+'''' + @Texto+ '''' +',''%'')'
			EXEC spSelectContratoBASE @Filtro= @ComandoFiltro
		end
	IF(@Filtro='Processos Não Registrados')
		begin
			SELECT Cliente.IdCliente,
			Processo.IdProcesso,
			Cliente.Nome,
			Cliente.CPF,
			Cliente.Telefone,
			ParteContraria.Nome as ParteContraria
				FROM TbProcesso Processo
				INNER JOIN TbCliente Cliente					--- CLIENTES SEM DIVIDAS
					ON Cliente.IdCliente = Processo.IdCliente
				INNER JOIN TbParteContraria ParteContraria
					ON Processo.IdParteContraria= ParteContraria.IdParteContraria
				WHERE Processo.IdProcesso
					NOT IN (SELECT IdProcesso FROM TbContrato)
		end
	IF(@Filtro='Dívidas não Registradas')
		begin
			SELECT Cliente.IdCliente,
			Processo.IdProcesso,
			Cliente.Nome,
			Cliente.CPF,
			Cliente.Telefone,
			ParteContraria.Nome as ParteContraria
				FROM TbProcesso Processo
				INNER JOIN TbCliente Cliente					--- PROCESSOS COM DÍVIDAS NÃO CADASTRADAS
					ON Cliente.IdCliente = Processo.IdCliente
				INNER JOIN TbParteContraria ParteContraria
					ON Processo.IdParteContraria= ParteContraria.IdParteContraria
				WHERE Processo.IdProcesso
					IN (SELECT IdProcesso FROM TbContrato)
					AND Cliente.IdCliente
					NOT IN (SELECT Cliente.IdCliente FROM TbParcela)
		end
END
GO

CREATE PROC spGetContrato
@IdContrato INT
AS
BEGIN
	SELECT Cliente.IdCliente,
	Contrato.IdContrato,
	Processo.IdProcesso,
	Parcela.idParcela,
	Parcela.Valor,
	FORMAT (Parcela.DataVencimento, 'dd/MM/yy') as DataVencimento, ------------------- DENTRO DA CONSULTA
	CASE WHEN Parcela.Situacao ='P' 
			THEN 'Pago'
		WHEN Parcela.Situacao='D'
			THEN 'Devendo'
		end as SituacaoParcela,
	Parcela.Observacao
	FROM TbParcela Parcela
	INNER JOIN TbCliente Cliente
		ON Parcela.IdCliente = Cliente.IdCliente
	INNER JOIN TbContrato Contrato
		ON Parcela.IdContrato = Contrato.IdContrato
	INNER JOIN TbProcesso Processo
		ON Parcela.IdCliente = Processo.IdCliente
		WHERE Contrato.IdContrato=@IdContrato
END
GO

CREATE PROC spGetConsultaContrato -----------------------------------------PEGA OS DADOS PRINCIPAIS DO CONTRATO
@IdContrato INT
AS
BEGIN
SELECT Contrato.IdContrato,
Contrato.TipoPagamento,
Contrato.Observacao,
Contrato.DiaVencimento,
FORMAT(Contrato.DataContrato,'dd/MM/yy') as DataContrato,
Contrato.QtdVezes,
Contrato.ValorTotal,
Contrato.ValorEntrada,
Contrato.ValorComissao
FROM TbContrato Contrato
INNER JOIN TbProcesso Processo
	ON Contrato.IdProcesso = Processo.IdProcesso
WHERE Contrato.IdContrato=@IdContrato
END
GO

------------------------------------------------------------------------------------------------------ ALTERANDO
CREATE PROC spUpdateCliente 
@IdCliente INT,
@Nome VARCHAR(90),
@CPF VARCHAR(11),
@Telefone VARCHAR(11)
AS
BEGIN
	UPDATE TbCliente 
	SET Nome=@Nome,CPF = @CPF,
	Telefone=@Telefone
	WHERE IdCliente = @IdCliente
END
GO

CREATE PROC spUpdateParteContraria
@IdParteContraria INT,
@Nome VARCHAR(90),
@CPF VARCHAR(11)='',
@CNPJ VARCHAR(14)='',
@Tipo CHAR(1)
AS
BEGIN
	UPDATE TbParteContraria
	SET Nome=@Nome,Tipo=@Tipo,
	CPF=@CPF, CNPJ=@CNPJ
	WHERE IdParteContraria = @IdParteContraria
END
GO

CREATE PROC spUpdateProcesso
@IdProcesso INT,
@IdCliente INT,
@IdParteContraria INT,
@NumeroProcesso VARCHAR(20),
@Foro VARCHAR(11),
@TipoAcao VARCHAR(100),
@Area VARCHAR(60),
@AndamentoProcesso TEXT,
@FoiIndicacao CHAR(1),
@NomeCaptador VARCHAR(90),
@LocalDescobrimento VARCHAR(9)
AS
BEGIN
		UPDATE TbProcesso
		SET IdCliente=@IdCliente, IdParteContraria=@IdParteContraria,
		NumeroProcesso=@NumeroProcesso,Foro=@Foro,TipoAcao=@TipoAcao,
		Area=@Area,AndamentoProcesso=@AndamentoProcesso,
		FoiIndicacao = @FoiIndicacao, NomeCaptador = @NomeCaptador,
		LocalDescobrimento = @LocalDescobrimento
		WHERE IdProcesso = @IdProcesso
END
GO

CREATE PROC spUpdateContrato 
@IdContrato INT,
@TipoPagamento CHAR(1),
@Observacao VARCHAR(11),
@DiaVencimento VARCHAR(2),
@DataContrato DATE,
@QtdVezes INT,
@ValorTotal DECIMAL(10,2),
@ValorEntrada DECIMAL(10,2),
@ValorComissao DECIMAL(10,2)
AS
BEGIN
	UPDATE TbContrato 
	SET TipoPagamento=@TipoPagamento,
	Observacao=@Observacao,
	DiaVencimento = @DiaVencimento,
	@DataContrato = @DataContrato,
	QtdVezes=@QtdVezes,
	ValorTotal=@ValorTotal,
	ValorEntrada=@ValorEntrada,
	ValorComissao=@ValorComissao
	WHERE IdContrato=@IdContrato
END
GO

CREATE PROC spUpdateParcela
@IdParcela INT,
@Valor DECIMAL(10,2),
@DataVencimento DATE,
@Situacao CHAR(1),
@Observacao TEXT
AS
BEGIN
	UPDATE TbParcela 
	SET Valor=@Valor,
	DataVencimento=@DataVencimento,
	Situacao=@Situacao,
	Observacao =@Observacao
	WHERE IdParcela=@IdParcela
END
GO
------------------------------------------------------------------------------------------------------ REMOVENDO
CREATE PROC spDeletaParcela
@IdParcela INT
AS
BEGIN
	DELETE FROM TbParcela 
	WHERE IdParcela=@IdParcela
END
GO


----------------------------------------------------------------------- INSERE REGISTROS PARA FAZER LOGIN
EXEC spCadastraUsuaria @Nome='Admin', @Senha='12456',@TipoAcesso='A'
GO
EXEC spCadastraUsuaria @Nome='Sec', @Senha='123',@TipoAcesso='A'
GO

------------------------------------------------------------------------- RELATORIO
CREATE PROC spPesquisaRelatorio
@NomeCaptador VARCHAR(90),
@Mes VARCHAR(2),
@Ano VARCHAR(4)
AS
BEGIN
	SELECT Cliente.Nome as 'Cliente',
	Processo.NomeCaptador as 'Nome do(a) Captador(a)',
	FORMAT (Contrato.ValorComissao,'C') as 'Valor da comissão'
	FROM TbContrato Contrato 
	INNER JOIN TbProcesso Processo
		ON Processo.IdProcesso = Contrato.IdProcesso
	INNER JOIN TbCliente Cliente
		ON Processo.IdCliente = Cliente.IdCliente
	WHERE MONTH(DataContrato)= @Mes and YEAR(DataContrato)=@Ano
		AND Processo.NomeCaptador = @NomeCaptador
END
GO

CREATE PROC spListaNomesCaptadores
AS
BEGIN
	SELECT Distinct(NomeCaptador) 
	FROM TbProcesso
END
GO