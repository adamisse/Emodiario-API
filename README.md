# Documentação da API Emodiario

## Visão Geral
A API Emodiario fornece endpoints para registro de usuários, login, gerenciamento de categorias e avaliações. É construída usando .NET Minimal API e conecta-se a um banco de dados PostgreSQL.

## URL Base
`http://localhost:5000` (Temporário)

## Endpoints

### Registro de Usuário

**POST** `/api/register`

Registra um novo usuário.

**Corpo da Requisição:**
```json
{
  "nome": "string",
  "email": "string",
  "senha": "string",
  "telefone": "string"
}
```

**Resposta:**
- **201 Created**
  ```json
  {
    "id": "int",
    "nome": "string",
    "email": "string",
    "telefone": "string"
  }
  ```
- **400 Bad Request**
  ```json
  {
    "errors": [
      "mensagem de erro"
    ]
  }
  ```

### Login de Usuário

**POST** `/api/login`

Autentica um usuário.

**Corpo da Requisição:**
```json
{
  "email": "string",
  "senha": "string"
}
```

**Resposta:**
- **200 OK**
  ```json
  {
  "id": "int",
  "nome": "string",
  "email": "string",
  "telefone": "string",
  "avaliacoes": [
    {
      "id": 1,
      "descricao": "Avaliacao 1",
      "valor": 5,
      "dataAtualizacao": "2023-06-29T12:34:56",
      "idCategoria": 1,
      "categoria": {
        "id": 1,
        "nome": "Categoria 1",
        "descricao": "Descricao da Categoria 1"
      }
    },
    {
      "id": 2,
      "descricao": "Avaliacao 2",
      "valor": 4,
      "dataAtualizacao": "2023-06-29T12:34:56",
      "idCategoria": 2,
      "categoria": {
        "id": 2,
        "nome": "Categoria 2",
        "descricao": "Descricao da Categoria 2"
      }
    }
  ]
}

- **401 Unauthorized**
  ```json
  {
    "error": "Unauthorized"
  }
  ```

### Criar Categoria

**POST** `/api/categorias`

Cria uma nova categoria.

**Corpo da Requisição:**
```json
{
  "nome": "string",
  "descricao": "string"
}
```

**Resposta:**
- **201 Created**
  ```json
  {
    "id": "int",
    "nome": "string",
    "descricao": "string"
  }
  ```
- **400 Bad Request**
  ```json
  {
    "errors": [
      "mensagem de erro"
    ]
  }
  ```

### Criar Avaliação

**POST** `/api/avaliacoes`

Cria uma nova avaliação para um usuário.

**Corpo da Requisição:**
```json
{
  "descricao": "string",
  "valor": 5,
  "idCategoria": "int",
  "idUsuario": "int"
}
```

**Resposta:**
- **201 Created**
  ```json
  {
    "id": "int",
    "descricao": "string",
    "valor": 5,
    "dataAtualizacao": "datetime",
    "idCategoria": "int",
    "categoria": {
      "id": "int",
      "nome": "string",
      "descricao": "string"
    }
  }
  ```
- **400 Bad Request**
  ```json
  {
    "errors": [
      "mensagem de erro"
    ]
  }
  ```

### Listar Avaliações de Usuário

**GET** `/api/avaliacoes/usuario/{usuarioId}`

Recupera as avaliações de um usuário específico.

**Resposta:**
- **200 OK**
  ```json
  [
    {
      "id": "int",
      "descricao": "string",
      "valor": 4,
      "dataAtualizacao": "datetime",
      "idCategoria": "int",
      "categoria": {
        "id": "int",
        "nome": "string",
        "descricao": "string"
      }
    }
  ]
  ```

### Enum Valor

```json
{
  "Excellent": 5,
  "Good": 4,
  "Normal": 3,
  "Bad": 2,
  "Awful": 1
}
```