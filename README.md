
# Image Manipulation API Descri��o

A Image Manipulation API permite aos usu�rios adicionar marcas d'�gua a imagens enviadas em formato Base64. Suporta v�rios formatos de imagem e retorna a imagem resultante tamb�m em Base64. Endpoints POST /api/image/watermark


## Documenta��o da API

#### Retorna a imagem com marca d'agua

```http
  POST /api/image
```

| Par�metro   | Tipo       | Descri��o                           |
| :---------- | :--------- | :---------------------------------- |
| `format` | `string` | **Obrigat�rio**. O formato da imagem |
| `image` | `string` | **Obrigat�rio**. A imagem original |

#### Response
- status: 200 OK

| Par�metro   | Tipo       | Descri��o                           |
| :---------- | :--------- | :---------------------------------- |
| `image` | `string` | **Obrigat�rio**. A imagem com marca d'agua |

## Instala��o 
### Pr�-requisitos

.NET SDK 8.0 ou superior

### Passos

- Passo 1 : Clone o reposit�rio

```bash
  git clone https://github.com/seu-usuario/image-manipulation-api.  git cd teste-tecnico-imagem
```
- Passo 2 : Restaure os pacotes

```bash
  dotnet restore
```

- Passo 3 : Execute a aplica��o

```bash
  dotnet run
```

## Estrutura do projeto

    Controllers/ImageController.cs: Cont�m o endpoint para adicionar marcas d'�gua �s imagens.
    Commands/ManipulationCommandHandler.cs: Cont�m a l�gica para manipula��o da imagem e adi��o da marca d'�gua.
    Program.cs: Configura��o inicial e execu��o da aplica��o e configura��o dos servi�os e middleware da aplica��o.
## Stack utilizada

**Back-end:** ASP.NET Core


## Licen�a

[MIT](https://choosealicense.com/licenses/mit/)

