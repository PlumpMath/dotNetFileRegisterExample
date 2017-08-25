#### Somos especialistas em BLOCKCHAIN.
[![N|Solid](https://www.astarlabs.com/wp-content/uploads/2017/08/a-star.jpg)](https://www.astarlabs.com/)
  #### Fa�a parte da revolu��o!
  # Conecte-se a nossa  [Star Blockchain API](https://www.astarlabs.com/produtos/star-blockchain-api/)
  _
##### You can:
  - Registrar arquivos numa base de dados descentralizada, compartilhada, p�blica e criptografada conhecida tamb�m como o protocolo da confian�a.
  - Pesquisar, validar, verificar ou atestar a autenticidade de seus arquivos a qualquer momento apenas com um click
  

> A Star Blockchain API � um produto capaz de se conectar ao seu sistema de informa��o para criar registros na blockchain com os dados nele armazenados que voc� selecionar. Isso � �til aos mais variados neg�cios privados ou p�blicos, uma vez que nosso produto permite que voc� crie solu��es inovadoras para seus clientes a partir dos recursos que sua organiza��o j� possui. A utiliza��o de nossa API lhe permitir� ofertar mais do que voc� imaginava ser poss�vel em seu mercado de atua��o, simplesmente somando as funcionalidades da tecnologia blockchain.


##### Tech
Aplica��o cliente desenvolvida com [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/csharp) na [plataforma Microsoft .NET](https://docs.microsoft.com/pt-br/dotnet/framework/) para consumir os servi�os dispon�veis da [Star Blockchain API](https://www.astarlabs.com/produtos/star-blockchain-api/).

##### Installation
[AppBlockchain](https://github.com/astarlabs/dotNetFileRegisterExample/tree/master/Installer/Release) necessita do [Microsoft .NET Framework](https://www.microsoft.com/net/download/framework) 4.5.2 ou superior para executar.

##### Example Code
Bibliotecas
```sh
using System;
using AStar.Api;
using AStar.Model;
using AStar.Util;
using System.Threading.Tasks;
````

Registrar Arquivo:

```sh
namespace AppBlockchain
{
    public class ApiBlockchain
    {
        public async Task<string> Registrar(string privateKey, int account, string user, string pass, 
                                            string hashArquivo, string coin, int test)
        {
            try
            {
                // Declaracao e Instancia de objetos das classes utilizadas
                SendApi Api = new SendApi();
                SingleResult singleResult = new SingleResult();
                
                // Chamada do metodo de registro de arquivos da API
                singleResult = await Api.SendHashAsync(AStar.Util.Token.sign(privateKey), 
                                                        account, user, pass, hash, coin, test);
                
                // Verifica��o do retorno do metodo
                if (singleResult.Error != null)
                    return "Erro de execucao da rotina SendFile da API. " + singleResult.Result;
                else
                    return singleResult.Result;
            }
            catch (Exception ex)
            {
                return "Erro na chamada da rotina Registrar. Exception: " + ex.Message;
            }
        }
    }
}
```

Validar Aquivo:
```sh
namespace AppBlockchain
{
    public class ApiBlockchain
    {
        public Transaction[] SearchByHash(string privateKey, int account, string user, 
                                            string pass, int id, string hash)
        {
            try
            {
                // Daclaracao e instancia de objeto da classe utilizada
                searchApi = new SearchApi();
                // Chamada do metodo de validacao do arquivo
                Transaction[] transactions = searchApi.SearchByHash(AStar.Util.Token.sign(privateKey), 
                                                                    account, user, pass, hash);
                // Retorno dos resultados
                return transactions;
            }
            catch (Exception ex)
            {
                Transaction[] transactions = new Transaction[1];
                Transaction x = new Transaction();
                x.Errormessage = "Erro na chamada da rotina SearchByHash. Exception: " + ex.Message;
                transactions[0] = x;
                return transactions;
            }
        }
    }
}