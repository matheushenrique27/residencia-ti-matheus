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