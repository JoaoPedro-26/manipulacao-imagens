
# Image Manipulation API Descrição

A Image Manipulation API permite aos usuários adicionar marcas d'água a imagens enviadas em formato Base64. Suporta vários formatos de imagem e retorna a imagem resultante também em Base64.


## Documentação da API

#### Retorna a imagem com marca d'agua

```http
  POST /api/image
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `format` | `string` | **Obrigatório**. O formato da imagem |
| `image` | `string` | **Obrigatório**. A imagem original |

#### Response
- status: 200 OK

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `image` | `string` | **Obrigatório**. A imagem com marca d'agua |

## Instalação 
### Pré-requisitos

.NET SDK 8.0 ou superior

### Passos

- Passo 1 : Clone o repositório

```bash
  git clone https://github.com/JoaoPedro-26/manipulacao-imagens  git cd teste-tecnico-imagem
```
- Passo 2 : Restaure os pacotes

```bash
  dotnet restore
```

- Passo 3 : Execute a aplicação

```bash
  dotnet run
```

## Estrutura do projeto

    Controllers/ImageController.cs: Contém o endpoint para adicionar marcas d'água ás imagens.
    Commands/ManipulationCommandHandler.cs: Contém a lógica para manipulação da imagem e adição da marca d'água.
    Program.cs: Configuração inicial e execução da aplicação e configuração dos serviços e middleware da aplicação.
## Stack utilizada

**Back-end:** ASP.NET Core


## Licença

[MIT](https://choosealicense.com/licenses/mit/)

