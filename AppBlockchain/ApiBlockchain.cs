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
        
        // Api
        AStar.Api.SearchApi search;
        AStar.Api.SendApi send;

        // ApiClient
        AStar.Client.ApiClient client;

        // Model
        AStar.Model.ServerInfo server_info;
        AStar.Model.SingleResult singleresult;
        //AStar.Model.Transaction transaction;

        // Util
        AStar.Util.Token token;

        public int Token()
        {
            //AStar.Util.Token.sign
            return 0;
        }

        public void Registrar()
        {
            //client = new AStar.Client.ApiClient();
            send = new AStar.Api.SendApi();

            string token = "";
            int account = 0;
            string user = "";
            string pass = "";
            string base64 = "";
            string coin = "";
            int test = 0;

            send.SendFile(token, account, user, pass, base64, coin, test);
        }

        public string Validar()
        {
            
            search = new AStar.Api.SearchApi();
            
            // search.SearchByHash(AStar.Util.Token.sign(token), account, user, pass, hash);
            AStar.Model.Transaction transaction = search.SearchByAPIID(AStar.Util.Token.sign(token), account, user, pass, 333);
            return transaction.Data; // Retorna o HASH
        }
    }
}

