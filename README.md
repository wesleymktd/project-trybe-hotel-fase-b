## 🧐 Sobre

<p align="left"> 
O projeto Trybe Hotel se trata da implementação de uma Api de um site de reserva de uma rede de Hoteis, onde nessa segunda fase foram implementados os seguintes processos:

### Cadastro de pessoas usuárias
  - Rota de cadastro POST /user
    - O corpo da requisição deve seguir o formato abaixo:

```json
{
	"Name":"Rebeca",
	"Email": "rebeca.santos@trybehotel.com",
	"Password": "123456"
}
```
### Login
  - Rota Login POST /login
    - O corpo da resposta deve seguir o formato abaixo:

```json
[
    {
	"Email": "rebeca.santos@trybehotel.com",
	"Password": "123456"
    }
]
```
  - Rota de cadastro de Hoteis POST /hotel
    - O corpo da requisição deve seguir o padrão abaixo

```json
{
	"Name":"Trybe Hotel RJ",
	"Address":"Avenida Atlântica, 1400",
	"CityId": 2
}
```
### Cadastro e listagem de reservas
  - Rota de cadastro de reservas POST /booking
    - O corpo da requisição deve seguir o formato abaixo:

```json
{
	"CheckIn":"2030-08-27",
	"CheckOut":"2030-08-28",
	"GuestQuant":"1",
	"RoomId":1
}
```
  - Rota de listagem de reserva GET /booking/:id
    - O corpo da requisição é vazio

### Adicionar autorização às rotas protegidas
### Testes automatizados

## ⚒ Instalando <a name = "installing"></a>

```bash
# Clone o projeto
$ git clone git@github.com:wesleymktd/project-trybe-hotel-fase-b.git
# Acesse
$ cd ./project-trybe-hotel-fase-b/src
# Instale as dependencias
$ dotnet restore
# Acesse o diretório TrybeHotel
$ cd TrybeHotel
# Inicie o projeto
$ dotnet run

```

## ⚒ Testes automatizados <a name = "installing"></a>

```bash
# Clone o projeto
$ git clone git@github.com:wesleymktd/project-trybe-hotel-fase-b.git
# Acesse o diretório TrybeHotel.test

# Execute o comando dotnet test
# para filtrar por algum teste específico execute o comando
$ dotnet test --filter `nome_do_teste`

```

## Principais tecnologias utilizadas:
- C#;
- ASP.NET
- EntityFramework
- Xunit
- JWT
- azure sql edge
