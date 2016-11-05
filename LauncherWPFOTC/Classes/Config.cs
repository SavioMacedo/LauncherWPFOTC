using System;
using System.Configuration;

namespace LauncherWPFOTC.Classes
{
    //Leitura do Arquivo de Configuração.
    class Config
    {
        public string NomeOT = LerTexto("NomeOT");
        public bool OTClient = LerBooleano("OTClient");

        public string Nome = LerTexto("Nome");
        public string Email = LerTexto("Email");

        public string gitRepositorio = LerTexto("gitRepositorio");
        public string urlNoticia = LerTexto("urlNoticia");

        public string DirSprite = AppDomain.CurrentDomain.BaseDirectory + "cliente/" + LerTexto("DirSprite");

        public string Background = LerTexto("Background");
        public string BtnFechar = LerTexto("BtnFechar");
        public string BtnMinimizar = LerTexto("BtnMinimizar");

        public string EsquemaCor = LerTexto("EsquemaCor");

        static string LerTexto(string texto)
        {
            return ConfigurationManager.AppSettings[texto];
        }

        static bool LerBooleano(string booleano)
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings[booleano]);
        }
    }
}
