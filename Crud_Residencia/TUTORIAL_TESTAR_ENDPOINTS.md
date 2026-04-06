# 📚 Tutorial: Como Testar os Endpoints - Passo a Passo

## ⚙️ PASSO 1: Verificar Pré-Requisitos

### Verifique se tem Docker instalado:
```bash
docker --version
docker-compose --version
```

Se retornar versões, está OK. Caso contrário, instale do site: https://www.docker.com/

---

## 🚀 PASSO 2: Levantar o Mock Server

### Abra o terminal na pasta raiz do projeto (onde está docker-compose.yml)

```bash
# Exemplo (ajuste para a sua máquina)
cd "CAMINHO/DO/SEU/PROJETO"
```

### Execute o comando para iniciar o servidor mock:
```bash
docker-compose up -d
```

**Saída esperada:**
```
[+] Running 1/1
 ✓ Container docker-compose-mock-server-1  Started
```

### Verifique se está rodando:
```bash
curl http://127.0.0.1:3000/produtos
```

**Saída esperada:**
```json
{
  "produtos": [
    {
      "id": 1,
      "nome": "Produto 1",
      "descricao": "Descrição do Produto 1",
      "preco": 100.00
    }
  ]
}
```

---

## ▶️ PASSO 3: Executar o Programa .NET

### Abra OUTRO terminal (deixe o anterior aberto)

```bash
# Use a mesma pasta do projeto
cd "CAMINHO/DO/SEU/PROJETO"
```

### Execute o programa:
```bash
dotnet run
```

**Saída esperada:**
```
info: Microsoft.Hosting.Lifetime[14]
  Now listening on: http://localhost:XXXX
  Now listening on: https://localhost:YYYY
```

⚠️ A porta HTTP pode variar (ex.: 5000, 5044, etc). Guarde esse valor para os próximos testes.

---

## 🧪 PASSO 4: Testar os Endpoints - 3 Opções

Antes dos testes, defina:

- `PORTA_API` = porta HTTP exibida no `dotnet run` (ex.: 5000 ou 5044)

### ✅ OPÇÃO 1: Usando REST Client (VS Code) - RECOMENDADO

1. Abra o arquivo `Crud_C#.http` no VS Code
2. Adicione o seguinte conteúdo:

```http
### 1️⃣ GET - Obter todos os produtos
GET http://127.0.0.1:PORTA_API/api/produtos

### 2️⃣ POST - Criar novo produto
POST http://127.0.0.1:PORTA_API/api/produtos
Content-Type: application/json

{
  "nome": "Notebook Dell",
  "descricao": "Notebook para desenvolvimento",
  "preco": 2500.00
}

### 3️⃣ PUT - Atualizar produto (ID 1)
PUT http://127.0.0.1:PORTA_API/api/produtos/1
Content-Type: application/json

{
  "nome": "Notebook Dell XPS",
  "descricao": "Notebook Dell atualizado",
  "preco": 3000.00
}

### 4️⃣ DELETE - Deletar produto (ID 1)
DELETE http://127.0.0.1:PORTA_API/api/produtos/1
```

3. Clique em **"Send Request"** acima de cada um
4. Veja a resposta na aba ao lado

---

### ✅ OPÇÃO 2: Usando cURL (Terminal)

#### Git Bash / Linux / macOS

```bash
# 1. GET - Listar todos
curl http://127.0.0.1:PORTA_API/api/produtos

# 2. POST - Criar
curl -X POST http://127.0.0.1:PORTA_API/api/produtos \
  -H "Content-Type: application/json" \
  -d "{\"nome\":\"Mouse Razer\",\"descricao\":\"Mouse gamer\",\"preco\":150}"

# 3. PUT - Atualizar (ID 2)
curl -X PUT http://127.0.0.1:PORTA_API/api/produtos/2 \
  -H "Content-Type: application/json" \
  -d "{\"nome\":\"Mouse Razer Pro\",\"descricao\":\"Mouse atualizado\",\"preco\":200}"

# 4. DELETE - Deletar (ID 2)
curl -X DELETE http://127.0.0.1:PORTA_API/api/produtos/2
```

#### PowerShell (alternativa)

```powershell
# 1. GET
curl.exe http://127.0.0.1:PORTA_API/api/produtos

# 2. POST
curl.exe -X POST http://127.0.0.1:PORTA_API/api/produtos -H "Content-Type: application/json" -d "{\"nome\":\"Mouse Razer\",\"descricao\":\"Mouse gamer\",\"preco\":150}"

# 3. PUT
curl.exe -X PUT http://127.0.0.1:PORTA_API/api/produtos/2 -H "Content-Type: application/json" -d "{\"nome\":\"Mouse Razer Pro\",\"descricao\":\"Mouse atualizado\",\"preco\":200}"

# 4. DELETE
curl.exe -X DELETE http://127.0.0.1:PORTA_API/api/produtos/2
```

---

### ✅ OPÇÃO 3: Usando Postman

1. Baixe e instale: https://www.postman.com/downloads/
2. Crie uma nova Request

#### **GET - Todos os produtos**
- **Método:** GET
- **URL:** `http://127.0.0.1:PORTA_API/api/produtos`
- **Clique:** Send

#### **POST - Criar produto**
- **Método:** POST
- **URL:** `http://127.0.0.1:PORTA_API/api/produtos`
- **Headers:** `Content-Type: application/json`
- **Body (raw JSON):**
```json
{
  "nome": "Teclado Mecânico",
  "descricao": "Teclado RGB",
  "preco": 450.00
}
```
- **Clique:** Send

#### **PUT - Atualizar produto**
- **Método:** PUT
- **URL:** `http://127.0.0.1:PORTA_API/api/produtos/1`
- **Headers:** `Content-Type: application/json`
- **Body (raw JSON):**
```json
{
  "nome": "Teclado Mecânico RGB",
  "descricao": "Teclado atualizado",
  "preco": 500.00
}
```
- **Clique:** Send

#### **DELETE - Deletar produto**
- **Método:** DELETE
- **URL:** `http://127.0.0.1:PORTA_API/api/produtos/1`
- **Clique:** Send

---

## 📊 PASSO 5: Entender as Respostas

### ✅ Response GET (200 OK)
```json
{
  "produtos": [
    {
      "id": 1,
      "nome": "Produto 1",
      "descricao": "Descrição do Produto 1",
      "preco": 100.00
    },
    {
      "id": 2,
      "nome": "Notebook Dell",
      "descricao": "Notebook para desenvolvimento",
      "preco": 2500.00
    }
  ]
}
```

### ✅ Response POST (200 OK)
```json
{
  "produtos": [
    {
      "id": 3,
      "nome": "Novo Produto",
      "descricao": "Descrição",
      "preco": 150.00
    }
  ]
}
```

### ❌ Response Erro (500 Error)
```json
{
  "message": "Erro ao criar produto",
  "error": "Connection refused 127.0.0.1:3000"
}
```
**Significa:** O mock server não está rodando! Execute `docker-compose up -d`

---

## 🛑 PASSO 6: Parar Tudo

### Parar o programa .NET:
No terminal do .NET, pressione `Ctrl + C`

### Parar o mock server:
```bash
docker-compose down
```

---

## 🎯 CHECKLIST FINAL

- [ ] Docker instalado?
- [ ] Mock server rodando com `docker-compose up -d`?
- [ ] Programa .NET rodando com `dotnet run`?
- [ ] Conseguiu fazer GET e retornou produtos?
- [ ] Conseguiu fazer POST com novo produto?
- [ ] Conseguiu fazer PUT e atualizar produto?
- [ ] Conseguiu fazer DELETE e deletar produto?

Se tudo passou, **está funcionando perfeitamente!** ✨

---

## 🐛 Troubleshooting

### Erro: "Connection refused localhost:3000"
→ O mock server não está rodando. Execute: `docker-compose up -d` e teste com `http://127.0.0.1:3000/produtos`.

### Erro: "Connection refused localhost:5000" (ou outra porta)
→ O programa .NET pode estar em outra porta. Veja a linha `Now listening on: http://localhost:XXXX` após `dotnet run` e use essa porta nas requisições.

### Erro: Docker não está instalado
→ Baixe em: https://www.docker.com/

### Erro: Porta 3000 ou 5000 já está em uso
→ Mude a porta no `docker-compose.yml` ou `Program.cs`

---

**Dúvidas? Tente novamente!** 🚀
