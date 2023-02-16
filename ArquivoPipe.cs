using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SOAP_ANP
{
    class ArquivoPipe
    {
        public string[] arquivo;
        public string[] linha;
        public string   acao;
        public string   valor1;
        public string   valor2;
        public string   valor3;
        public string   valor4;
        public string   valor5;
        public string   valor6;

        public ArquivoPipe(string arquivo_completo)
        {
            try
            {
                arquivo = File.ReadAllLines(arquivo_completo);
            }
            catch (Exception e)
            {
                //RegistraLog.Log(String.Format($"{"Log criado em "} : {DateTime.Now}. Erro: {e.GetType()}"));
                RegistraLog.Log(String.Format($"Erro: {e.Message}"));
            }
            linha = arquivo[0].Split('|');
            acao = linha[0];
            valor1 = linha[1];

            if (linha.Length >= 3) { valor2 = linha[2]; }
            if (linha.Length >= 4) { valor3 = linha[3]; }
            if (linha.Length >= 5) { valor4 = linha[4]; }
            if (linha.Length >= 6) { valor5 = linha[5]; }
            if (linha.Length >= 7) { valor6 = linha[6]; }
        }

        public WebServiceANP.InformacaoAutenticacao GetAutenticacao()
        {
            var autenticacao = new WebServiceANP.InformacaoAutenticacao();

            if (linha.Length >= 2) { autenticacao.Login = valor1; }
            if (linha.Length >= 3) { autenticacao.CNPJ  = valor2; }
            if (linha.Length >= 4) { autenticacao.Senha = valor3; }

            return autenticacao;
        }
        public string GetProtocolo()
        {
            return valor4;
        }
        public string GetNomeArquivo()
        {
            return valor4;
        }
    }

}
