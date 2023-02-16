using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAP_ANP
{

    class Program
    {
        static void Main(string[] args)
        {
            RegistraLog.Log(String.Format($"Solicitação: {args[0]}"));
            string caminho_arquivo = args[0];

            var pipe = new ArquivoPipe(caminho_arquivo);

             if(pipe.acao == "EnviarArquivo")
             {
                 var autenticacao = pipe.GetAutenticacao();

                 var arquivo = new WebServiceANP.Arquivo();
                 arquivo.Nome = pipe.valor4;
                 arquivo.Conteudo = Encoding.ASCII.GetBytes(pipe.valor5);

                 var sr = new WebServiceANP.EngineServiceClient();
                 String resposta = (string)sr.EnviarArquivo(arquivo, autenticacao);
                 RegistraLog.Log(resposta);
                 RegistraLog.SalvaXML(resposta, "EnviarArquivoResult.xml");
             }
             else if (pipe.acao == "RetornarLogProcessamento")
             {
                 var autenticacao = pipe.GetAutenticacao();
                 var protocolo    = pipe.GetProtocolo();

                 var sr = new WebServiceANP.EngineServiceClient();
                 String resposta = (string)sr.RetornarLogProcessamento(protocolo, autenticacao);
                 RegistraLog.Log(resposta, "ArquivoLog");
                 RegistraLog.SalvaXML(resposta, "EnviarArquivoResult.xml");
             }
             else if (pipe.acao == "RetornarProtolocoArquivo")
             {
                 var autenticacao = pipe.GetAutenticacao();
                 var nomeArquivo = pipe.GetNomeArquivo();

                 var sr = new WebServiceANP.EngineServiceClient();
                 String resposta = (string)sr.RetornarProtolocoArquivo(nomeArquivo, autenticacao);//nome_arquivo, autenticacao
                 RegistraLog.Log(resposta);
                 RegistraLog.SalvaXML(resposta, "RetornarProtolocoArquivoResult.xml");
             }
             else if (pipe.acao == "RetornarSituacaoArquivo")
             {
                 var autenticacao = pipe.GetAutenticacao();
                 var protocolo    = pipe.GetProtocolo();

                 var sr = new WebServiceANP.EngineServiceClient();
                 String resposta = (string)sr.RetornarSituacaoArquivo(protocolo, autenticacao);
                 RegistraLog.Log(resposta);
                 RegistraLog.SalvaXML(resposta, "RetornarSituacaoArquivoResult.xml");
             }
        }
    }
}
