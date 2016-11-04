using LibGit2Sharp;
using System;
using System.ComponentModel;
using System.Threading;
// code por Savio Macedo.
// Classe Manipulação do cliente GitHub.
namespace LauncherWPFOTC.Classes
{
    class GitHub
    {
        private string gitRepositorio = Properties.Settings.Default.gitRepositorio;
        private string git = AppDomain.CurrentDomain.BaseDirectory + "cliente/";
        private string gitNome = Properties.Settings.Default.Nome;
        private string gitEmail = Properties.Settings.Default.Email;
        BackgroundWorker Worker;
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
                Worker.ReportProgress(70, "Atualizando Arquivos ... 75%");
                repo.Branches.Update(
                    repo.Head,
                    b => b.Remote = "origin",
                    b => b.UpstreamBranch = "refs/heads/master"
                );
                MergeResult mergeResult = repo.Network.Pull(new Signature(gitNome,gitEmail, new DateTimeOffset(DateTime.Now)), new PullOptions());
                Worker.ReportProgress(100, "Arquivos Atualizados e Verificados");
            }            
        }
    }
}
