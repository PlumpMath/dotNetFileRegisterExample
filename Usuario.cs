using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlockchain
{
    class Usuario
    {
        public string nome       { get; }
        public int    id         { get; }
        public string user       { get; }
        public string pass       { get; }
        public int    account    { get; }
        public string privateKey { get; }

        public Usuario(string usuario)
        {
            // Carregar informações do usuario
            nome = "NomeDoUsuario";
            id = 0;
            user = usuario;
            pass = null;
            account = 0;
            privateKey = null;
        }
    }
}
