# 📦 API de Clube de Assinaturas (SaaS)

API REST desenvolvida em ASP.NET Core para gerenciamento de um sistema de assinaturas, permitindo operações completas de CRUD (Create, Read, Update, Delete) para **Clientes, Planos e Assinaturas**.

---

## 🚀 Funcionalidades

* CRUD de clientes
* CRUD de planos
* CRUD de assinaturas
* Relacionamento entre cliente e plano
* Validação de dados nas assinaturas

---

## 🧠 Estrutura

A API foi organizada em:

* **Controllers** → Endpoints da API
* **Models** → Entidades do sistema
* **DbContext** → Integração com SQLite

Utiliza **Entity Framework Core** e **injeção de dependência**.

---

## 📌 Endpoints

---

# 👤 Clientes

### 🔍 Listar clientes

**GET** `/api/clientes`

---

### 🔍 Buscar cliente por ID

**GET** `/api/clientes/{id}`

**Resposta:**

* `200 OK` → Cliente encontrado
* `404 Not Found` → Não encontrado

---

### ➕ Criar cliente

**POST** `/api/clientes`

**Body:**

```json id="c1"
{
  "nome": "João Silva",
  "email": "joao@email.com"
}
```

**Resposta:**

* `201 Created`

---

### ✏️ Atualizar cliente

**PUT** `/api/clientes/{id}`

**Regras:**

* ID da URL deve ser igual ao ID do body

**Resposta:**

* `204 No Content`
* `400 Bad Request`

---

### ❌ Deletar cliente

**DELETE** `/api/clientes/{id}`

**Resposta:**

* `204 No Content`
* `404 Not Found`

---

# 💳 Planos

### 🔍 Listar planos

**GET** `/api/planos`

---

### 🔍 Buscar plano por ID

**GET** `/api/planos/{id}`

---

### ➕ Criar plano

**POST** `/api/planos`

**Body:**

```json id="c2"
{
  "nome": "Plano Premium",
  "preco": 49.90
}
```

---

### ✏️ Atualizar plano

**PUT** `/api/planos/{id}`

---

### ❌ Deletar plano

**DELETE** `/api/planos/{id}`

---

# 🔗 Assinaturas

### 🔍 Listar assinaturas

**GET** `/api/assinaturas`

---

### 🔍 Buscar assinatura por ID

**GET** `/api/assinaturas/{id}`

---

### ➕ Criar assinatura

**POST** `/api/assinaturas`

**Body:**

```json id="c3"
{
  "clienteId": 1,
  "planoId": 2,
  "dataInicio": "2026-04-22T00:00:00"
}
```

**Regras:**

* Cliente deve existir
* Plano deve existir

**Resposta:**

* `200 OK`
* `400 Bad Request`

---

### ✏️ Atualizar assinatura

**PUT** `/api/assinaturas/{id}`

---

### ❌ Deletar assinatura

**DELETE** `/api/assinaturas/{id}`

---

## ⚠️ Observações importantes

* Assinaturas dependem de clientes e planos existentes
* Validação feita no backend antes de salvar
* Banco de dados SQLite local

---

## ▶️ Como executar o projeto

### ✅ Pré-requisitos

* .NET 8 SDK

---

### 📥 Clonar o repositório

```bash id="c4"
git clone https://github.com/seu-usuario/seu-repositorio.git
```

---

### 📂 Acessar a pasta

```bash id="c5"
cd nome-do-projeto
```

---

### 📦 Restaurar dependências

```bash id="c6"
dotnet restore
```

---

### 🗄️ Criar banco

```bash id="c7"
dotnet ef database update
```

---

### ▶️ Executar

```bash id="c8"
dotnet run
```

---

## 🌐 Acessar API

```id="c9"
https://localhost:xxxx/swagger
```

---

## 🧪 Testes

Use:

* Swagger
* Postman
* Insomnia

---

## 🏗️ Tecnologias

* ASP.NET Core
* C#
* Entity Framework Core
* SQLite

---

## 📌 Conclusão

A API implementa um sistema completo de gestão de assinaturas, com CRUD completo, validações e integração com banco de dados, seguindo boas práticas de desenvolvimento.

---
