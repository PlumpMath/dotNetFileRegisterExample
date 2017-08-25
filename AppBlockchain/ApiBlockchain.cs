using System;
using AStar.Api;
using AStar.Model;
using AStar.Util;
using System.Threading.Tasks;


namespace AppBlockchain
{
    public class ApiBlockchain
    {
        public async Task<string> Registrar(string privateKey, int account, string user, string pass, string hash, string coin, int test)
        {
            try
            {
                // Declaração e Instancia de objetos das classes utilizadas
                SendApi Api = new SendApi();
                SingleResult singleResult = new SingleResult();

                // Chamada do metodo de registro de arquivos da API
                singleResult = await Api.SendHashAsync(AStar.Util.Token.sign(privateKey), account, user, pass, hash, coin, test);

                // Verificação do retorno do metodo
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

        SearchApi searchApi;

        public Transaction[] SearchByHash(string privateKey, int account, string user, string pass, int id, string hash)
        {
            try
            {
                // Daclaracao e instancia de objeto da classe utilizada
                searchApi = new SearchApi();

                // Chamada do metodo de validacao do arquivo
                Transaction[] transactions = searchApi.SearchByHash(Token.sign(privateKey), account, user, pass, hash);
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

