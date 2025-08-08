# API de Catálogo de Produtos

## Visão Geral

Este projeto é uma API de Catálogo de Produtos construída usando .NET 8.0. Ela fornece endpoints para gerenciar produtos, incluindo criação, atualização, recuperação e exclusão de produtos. A API utiliza MongoDB para armazenamento de dados e Kafka para intermediação de mensagens.

## Funcionalidades

- Operações CRUD para produtos
- Integração com MongoDB para persistência de dados
- Integração com Kafka para intermediação de mensagens
- Documentação Swagger para endpoints da API

## Pré-requisitos

- [SDK do .NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MongoDB](https://www.mongodb.com/try/download/community) (Certifique-se de que está rodando localmente ou atualize a string de conexão em `appsettings.json`)
- [Kafka](https://kafka.apache.org/quickstart) (Certifique-se de que está rodando localmente ou atualize os servidores de bootstrap em `appsettings.json`)

## Começando

### Clonar o repositório

```bash
git clone https://github.com/seuusuario/APIdeCatalogoDeProdutos.git
cd APIdeCatalogoDeProdutos
