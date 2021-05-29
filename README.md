# API - CartaoVirtual
Projeto criado para o desafio Vai Voa.

## Stack utilizada
 - C# com .Net Core e Entity Framework Core.
 

## Endpoints

### GET /api/cartaovirtual/email/{email}
Retorna todos os cartões virtuais de acordo com o email.

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `email` | required | string  | Email com cartões cadastrados                                                                                                             |

**Response**

```
  {
    "id": "29cc3ad3-f53d-466c-acc5-bf827c751b12",
    "email": "user@outlook.com",
    "numeroCartao": "659635495694915",
    "dataCriacao": "2021-05-28T21:25:59.6906611-03:00"
  },
  
```
___

### POST /api/cartaovirtual
Cria um cartão virtual e registra o numero de acordo como email passado.

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `email` | required | string  | Email para vinculação do numero gerado                                                                                                     |

**Response**

```
{
  "numeroCartao": "352892344974948"
}
