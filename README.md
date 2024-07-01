
# Documentação da API - V1

## Visão Geral
A API Emodiario é construída usando .NET Core 6.0, utilizando Minimal API e conectando-se a um banco de dados PostgreSQL.

## Funcionalidades
Esta API permite gerenciar criação e autenticação usuários, suas categorias e avaliações.

## Endpoints

### Registro de Usuário

- **URI:** `/api/register`
- **Método:** POST
- **Descrição:** Registra um novo usuário.
- **Request:**
  ```json
  {
    "nome": "string",
    "email": "string",
    "senha": "string",
    "telefone": "string"
  }
  ```
- **Response:**
  ```json
  {
    "id": 1,
    "nome": "string",
    "email": "string",
    "telefone": "string",
    "avaliacoes": []
  }
  ```

### Login de Usuário

- **URI:** `/api/login`
- **Método:** POST
- **Descrição:** Autentica um usuário e retorna seus dados.
- **Request:**
  ```json
  {
    "email": "string",
    "senha": "string"
  }
  ```
- **Response:**
  ```json
  {
    "id": 1,
    "nome": "string",
    "email": "string",
    "telefone": "string",
    "avaliacoes": [
      {
        "id": 1,
        "valor": 5,
        "descricao": "string",
        "dataAtualizacao": "2024-01-01T00:00:00",
        "idCategoria": 1,
        "categoria": {
          "id": 1,
          "nome": "string",
          "descricao": "string"
        }
      }
    ]
  }
  ```

### Buscar Usuário por ID

- **URI:** `/api/users/{id}`
- **Método:** GET
- **Descrição:** Retorna os dados de um usuário específico pelo ID.
- **Response:**
  ```json
  {
    "id": 1,
    "nome": "string",
    "email": "string",
    "telefone": "string",
    "avaliacoes": [
      {
        "id": 1,
        "valor": 5,
        "descricao": "string",
        "dataAtualizacao": "2024-01-01T00:00:00",
        "idCategoria": 1,
        "categoria": {
          "id": 1,
          "nome": "string",
          "descricao": "string"
        }
      }
    ]
  }
  ```

### Criar Categoria

- **URI:** `/api/categorias`
- **Método:** POST
- **Descrição:** Cria uma nova categoria.
- **Request:**
  ```json
  {
    "nome": "string",
    "descricao": "string"
  }
  ```
- **Response:**
  ```json
  {
    "id": 1,
    "nome": "string",
    "descricao": "string"
  }
  ```

### Buscar Categorias do Usuário

- **URI:** `/api/categorias/usuario/{usuarioId}`
- **Método:** GET
- **Descrição:** Retorna as categorias associadas às avaliações de um usuário específico pelo ID do usuário.
- **Response:**
  ```json
  [
    {
      "id": 1,
      "nome": "string",
      "descricao": "string"
    }
  ]
  ```

### Criar Avaliação

- **URI:** `/api/avaliacoes`
- **Método:** POST
- **Descrição:** Cria uma nova avaliação.
- **Request:**
  ```json
  {
    "valor": 3,
    "descricao": "string",
    "idCategoria": 1,
    "idUsuario": 1
  }
  ```
- **Response:**
  ```json
  {
    "id": 1,
    "valor": 3,
    "descricao": "string",
    "dataAtualizacao": "2024-01-01T00:00:00",
    "idCategoria": 1,
    "categoria": {
      "id": 1,
      "nome": "string",
      "descricao": "string"
    }
  }
  ```

### Buscar Avaliações por Usuário

- **URI:** `/api/avaliacoes/usuario/{usuarioId}`
- **Método:** GET
- **Descrição:** Retorna as avaliações de um usuário específico pelo ID do usuário, com filtro opcional por categoria.
- **Query Parameters:**
  - `categoriaId` (opcional): ID da categoria para filtrar as avaliações.
- **Response:**
  ```json
  [
    {
      "id": 1,
      "valor": 5,
      "descricao": "string",
      "dataAtualizacao": "2024-01-01T00:00:00",
      "idCategoria": 1,
      "categoria": {
        "id": 1,
        "nome": "string",
        "descricao": "string"
      }
    }
  ]
  ```