using LibGit2Sharp;
using System;
using System.ComponentModel;
using System.Threading;
// code por Savio Macedo.
// Classe Manipulação do cliente GitHub.
namespace LauncherWPFOTC.Classes
{
    class GitHub:Config
    {
        private string git = AppDomain.CurrentDomain.BaseDirectory + "cliente/";
        BackgroundWorker Worker;

        Sprite sprite = new Sprite();

        public void initGit(BackgroundWorker worker)
        {
            Worker = worker;
            if (!Repository.IsValid(git))
            {
                Worker.ReportProgress(25, "Baixando Cliente do Zero ... 25%");
                Repository.Clone(gitRepositorio, git);
            }
            using (var repo = new Repository(git))
            {
                Worker.ReportProgress(50, "Verificando Integridade dos Arquivos ... 50%");
                Thread.Sleep(100);
                repo.Reset(ResetMode.Hard, "master");
                Worker.ReportProgress(65, "Atualizando Arquivos ... 65%");
                repo.Branches.Update(
                    repo.Head,
                    b => b.Remote = "origin",
                    b => b.UpstreamBranch = "refs/heads/master"
                );
                MergeResult mergeResult = repo.Network.Pull(new Signature(Nome,Email, new DateTimeOffset(DateTime.Now)), new PullOptions());
                
                //Verifica se Existe Sprite Compactada.
                if (sprite.existe())
                {
                    Worker.ReportProgress(85, "Extraindo Arquivos Compactados ... 85%");
                    sprite.extrair();
                }

                Worker.ReportProgress(100, "Atualização Finalizada ...  100%");
            }            
        }
    }
}
