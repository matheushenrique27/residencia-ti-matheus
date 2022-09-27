### Introdução

Este documento serve como norte para o treinamento nas Tecnologias e formas de como estão os sistemas da Liga, assim como seus desafios de desenvolvimento e suporte.

### Objetivos

- Dá uma visão geral de sistemas da Liga
- Treinar boas práticas de desenvolvimento
- Se familiarizar com as tecnologias utilizadas

### Perfil Técnico 

- Os sistemas desktop são feitos no Framework Delphi que utiliza a lingaguem de programação Pascal
- O nosso banco de dados é o Microsoft SQL Server
- Utilizamos o SQL Server Management Studio (SSMS) para manuzear dados no banco e testar querys, Podendo ser substituido pelo DBeaver se achar melhor.
- A maioria dos servidores de aplicação são Windows server, sendo s-apl01, s-apl04, s-apl06 e pep servidores de produção, e temos o s-aplh01 como servidor de homologação.
- Temos o servidor islandia aplicações Docker, rodando um Debian.
- Usamos a plataforma .net para desenvolvimento web e alguns scripts de automação. Utilizamos o AspNet Full Framework 4.5.2 para o pep e o gerador de pdfs, e asp.net core desde a 2.2 até a 3.1 nos demais sistemas já atualizando para o .net 6.0;
- A maioria são sistemas MVC (model-view-controller), seguindo padrões de DDD (Domain-Driven Design).
- Temos algumas APIs que servem como integração com sistemas de terceiros e alguns internos no padrão REST.
- Temos ferramentas desenvolvidas com Vue e React.
- Utilizamos o Redis para cache de aplicações e envios de E-mail em alguns casos, o Redis é um banco de dados não relacional.
- Utilizamso também em apenas um caso o RabbitMQ para mensageria entre serviçõs de exames integrado com o DNA Center.

### Treinamento

Para o treinamento, vamos exercitar o uso do git com um repositorio único para todos os residentes, com o objetivo puramente didática no uso do git e github em um repositório colaborativo.

Cada residente deverá criar uma branch com suas iniciais e o nome do projeto, por exemplo: westefns-projeto-mvc e na Raiz do projeto, no mesmo nivel do Arquivo Readme.md, deve criar uma pasta com seu nome e uma para para cada projeto assim que for criando.

Vamos Fazer a mesma aplicação de diferente formas de arquiteturas, iniciando de forma simples com um mvc rodando em um windows até chegar-mos a api com frontend separado rodando em um docker.

## O projeto base

O nosso projeto base será um sistema para controle financeiro de pessoas.

### Esse sistema deve ser capaz de:

- Realizar login/logout como o cadastro de novos usuários e a recupeção de senhas.
- Receber um novo deposito, com valor, descrição, data de depósito, usuário de depósito sendo o usuário logado.
- Realizar um saque, com valor, descrição, data do saque, finalidade, usuário de depósito sendo o usuário logado.
- A finalidade do saque são por exemplo: Alimentação, Entreterimento, Educação. Tendo um CRUD para isso com sendo o delete apenas marcando com inativo, e cada usuário poderá ter sua lista própria de finalidades.
- O sistema deverá mostrar uma listagem de deposito e saques na home da aplicação, com a possibilidade de realização de filtros por data, finalidades, filtrar apenas os saques, depósitos ou mostrar saques e depositos.

### Projeto em MVC 

Esse projeto deve está na sua pasta dentro de uma pasta com o nome MVC

Nesse modo, você pode criar um app mvc do .net 6, utiliza um Banco em Memoria (Memory Database) ou se prefirir subir um postgres em um docker e utilizar migrações apenas para esse projeto.

O objetivo é criar a aplicação usando apenas o .net 6 com bootstrap 5 e jquery se precisar.

