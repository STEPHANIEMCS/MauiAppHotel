using MauiAppHotel.Models;

namespace MauiAppHotel;

public partial class App : Application
{
    public static List<Quarto> ListaQuartos { get; private set; } = new();

    public App()
    {
        InitializeComponent();

        ListaQuartos = new List<Quarto>
        {
            new Quarto
            {
                Descricao = "Suíte Luxo",
                ValorDiariaAdulto = 250,
                ValorDiariaCrianca = 150
            },
            new Quarto
            {
                Descricao = "Suíte Master",
                ValorDiariaAdulto = 350,
                ValorDiariaCrianca = 200
            },
            new Quarto
            {
                Descricao = "Suíte Super Luxo",
                ValorDiariaAdulto = 500,
                ValorDiariaCrianca = 300
            }
        };

        MainPage = new NavigationPage(new Views.ContratacaoHospedagem());
    }
}
