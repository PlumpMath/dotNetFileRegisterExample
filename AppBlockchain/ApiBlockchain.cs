using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AStar;

namespace AppBlockchain
{
    public class ApiBlockchain
    {
        AStar.Api.SendApi sendApi;
        AStar.Api.SearchApi searchApi;
        AStar.Model.SingleResult singleResult;

        public string Registrar(string privateKey, int account, string user, string pass, string base64, string coin, int test)
        {
            try
            {
                AStar.Api.SendApi Api = new AStar.Api.SendApi();

                sendApi      = new AStar.Api.SendApi();
                singleResult = new AStar.Model.SingleResult();

                singleResult = Api.SendFile(AStar.Util.Token.sign(privateKey), account, user, pass, base64, coin, test);

                if ((bool)singleResult.Error)
                {
                    return "Erro de execucao da rotina SendFile da API. " + singleResult.Result;
                }
                else
                {
                    return singleResult.Result;
                }
            }
            catch(Exception ex)
            {
                return "Erro na chamada da rotina Registrar. Exception: " + ex.Message;
            }
            
        }

        public AStar.Model.Transaction SearchByHash(string privateKey, int account, string user, string pass, int id, string hash)
        {
            try
            {
                searchApi = new AStar.Api.SearchApi();
                return searchApi.SearchByHash(AStar.Util.Token.sign(privateKey), account, user, pass, hash);
            }
            catch(Exception ex)
            {
                AStar.Model.Transaction transaction = new AStar.Model.Transaction();
                transaction.Errormessage = "Erro na chamada da rotina SearchByHash. Exception: " + ex.Message;
                return transaction;
            }
            
        }
        
        public AStar.Model.Transaction SearchByApiId(string privateKey, int account, string user, string pass, int id)
        {
            try
            {
                searchApi = new AStar.Api.SearchApi();
                return searchApi.SearchByAPIID(AStar.Util.Token.sign(privateKey), account, user, pass, id);
            }
            catch(Exception ex)
            {
                AStar.Model.Transaction transaction = new AStar.Model.Transaction();
                transaction.Errormessage = "Erro na chamada da rotina SearchByHash. Exception: " + ex.Message;
                return transaction;
            }
            
        }
    }
}

