using Ionic.Zip;

namespace LauncherWPFOTC.Classes
{
    class Sprite:Config
    { 
        //Verifica se Existe Sprite Compactada.
        public bool existe()
        {
            return System.IO.File.Exists(DirSprite + "graficos.zip");
        }

        //Extrai a Sprite Compactada.
        public void extrair()
        {
            ZipFile zipa = ZipFile.Read(DirSprite + "graficos.zip");
            foreach(ZipEntry arquivo in zipa)
            {
                arquivo.Extract(DirSprite, ExtractExistingFileAction.OverwriteSilently);
            }
        }
    }
}
