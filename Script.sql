Drop Schema If Exists santos;
Create Schema santos;
Use santos;

Create Table usuario
(
	nm_login varchar(200),
	nm_usuario varchar(200),
	nm_senha varchar(64),
	constraint pk_usuario primary key (nm_login)
);
Create Table recuperacao
(
	cd_recuperacao varchar(100),
	nm_login varchar(200),
	constraint pk_recuperacao primary key (cd_recuperacao),
	constraint fk_usuario_recuperacao foreign key (nm_login) references usuario (nm_login) 
);

Insert into usuario values ('proffreddy@etec.com', 'Frederico Arco e Flexa Machado Justo', md5('123'));
Insert into usuario values ('tavares@etec.com', 'Luiz Tavares', md5('123'));
Insert into usuario values ('andrereis@etec.com', 'Andre Reis', md5('123'));
Insert into usuario values ('maristela@etec.com', 'Maristela Gamba', md5('123'));


Delimiter $$

Drop Procedure if exists listarUsuarios$$
Create Procedure listarUsuarios()
begin
	Select nm_login, nm_usuario from usuario order by nm_usuario;  
end$$

Drop Procedure if exists acessar$$
Create Procedure acessar(pLogin varchar(200), pSenha varchar(64))
begin
	Select nm_usuario from usuario where nm_login = pLogin and nm_senha = md5(pSenha);  
end$$

Drop Procedure if exists verificarLogin$$
Create Procedure verificarLogin(pLogin varchar(200))
begin
	Select nm_usuario from usuario where nm_login = pLogin;  
end$$

Drop Procedure if exists gravarRecuperacao$$
Create Procedure gravarRecuperacao(pCodigo varchar(100),pLogin varchar(200))
begin
	Insert into recuperacao values (pCodigo,pLogin); 
end$$

Drop Procedure if exists verificarRecuperacao$$
Create Procedure verificarRecuperacao(pCodigo varchar(100),pLogin varchar(200))
begin
	Select * from recuperacao where nm_login = pLogin and cd_recuperacao = pCodigo;
end$$

Drop Procedure if exists alterarSenha$$
Create Procedure alterarSenha(pSenha varchar(64), pLogin varchar(200))
begin
	Update usuario set nm_senha = md5(pSenha) where nm_login = pLogin;
end$$

Drop Procedure if exists apagarRecuperacao$$
Create Procedure apagarRecuperacao(pLogin varchar(200))
begin
	Delete from recuperacao where nm_login = pLogin;
end$$

Delimiter ;