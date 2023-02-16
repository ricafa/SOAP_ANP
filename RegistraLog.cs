using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace SOAP_ANP
{
    public class RegistraLog
    {
        
        private static string caminhoExe = string.Empty;
        public static bool Log(string strMensagem, string strNomeArquivo = "WebService_ANP.log")
        {
            try
            {
                caminhoExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string caminhoArquivo = Path.Combine(caminhoExe, strNomeArquivo);
                if (!File.Exists(caminhoArquivo))
                {
                    FileStream arquivo = File.Create(caminhoArquivo);
                    arquivo.Close();
                }
                using (StreamWriter w = File.AppendText(caminhoArquivo))
                {
                    AppendLog(strMensagem, w);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool SalvaXML(string strMensagem, string strNomeArquivo = "retorno.xml")
        {
            try
            {
                caminhoExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string caminhoArquivo = Path.Combine(caminhoExe, strNomeArquivo);
                if (File.Exists(caminhoArquivo))
                {
                    File.Delete(caminhoArquivo);
                }

                FileStream arquivo = File.Create(caminhoArquivo);
                arquivo.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static void AppendLog(string logMensagem, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entrada ");
                txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                txtWriter.WriteLine($"{logMensagem}");
                txtWriter.WriteLine("------------------------------------");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
