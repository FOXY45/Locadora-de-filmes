/*
using ReactiveUI;
using System.Reactive;

namespace LocadoraDeFilmes.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private string _titulo = "Locadora de Filmes";
        public string Titulo
        {
            get => _titulo;
            set => this.RaiseAndSetIfChanged(ref _titulo, value);
        }

        public ReactiveCommand<Unit, Unit> ComandoExemplo { get; }

        public MainWindowViewModel()
        {
            ComandoExemplo = ReactiveCommand.Create(() =>
            {
                // Ação do comando
            });
        }
    }
}
*/