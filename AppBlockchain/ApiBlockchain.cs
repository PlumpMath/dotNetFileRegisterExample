using AStar.Api;
using AStar.Model;
using System;
using System.Threading.Tasks;

namespace AppBlockchain
{
    public class ApiBlockchain
    {
        public async Task<string> Registrar(string privateKey, int account, string user, string pass, string hash, string coin, int test)
        {
            try
            {
                SendApi Api = new SendApi();
                SingleResult singleResult = new SingleResult();


                singleResult = await Api.SendHashAsync(AStar.Util.Token.sign(privateKey), account, user, pass, hash, coin, test);

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
                searchApi = new SearchApi();
                Transaction[] transactions = searchApi.SearchByHash(AStar.Util.Token.sign(privateKey), account, user, pass, hash);
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

        public Transaction SearchByApiId(string privateKey, int account, string user, string pass, int id)
        {
            try
            {
                searchApi = new SearchApi();
                return searchApi.SearchByAPIID(AStar.Util.Token.sign(privateKey), account, user, pass, id);
            }
            catch (Exception ex)
            {
                Transaction transaction = new AStar.Model.Transaction();
                transaction.Errormessage = "Erro na chamada da rotina SearchByHash. Exception: " + ex.Message;
                return transaction;
            }

        }
    }
}

