// code por Savio Macedo.
// Classe Manipulação da WebView de Noticias.
namespace LauncherWPFOTC.Classes
{
    class Noticia
    {
        //setando padrão da url de noticias.
        private string urlnoticia = Properties.Settings.Default.urlNoticia;

        //Puxa dados da string urlnoticia.
        public string getNoticia()
        {
            return this.urlnoticia;
        }
    }
}
