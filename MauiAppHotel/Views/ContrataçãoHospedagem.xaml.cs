using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        pck_quarto.ItemsSource = App.ListaQuartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);

        dtpck_checkin.DateSelected += (s, e) =>
        {
            dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
            dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
        };
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (pck_quarto.SelectedItem is null)
        {
            await DisplayAlert("Erro", "Selecione um quarto.", "OK");
            return;
        }

        var hospedagem = new Hospedagem
        {
            QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
            QntAdultos = (int)stp_adultos.Value,
            QntCriancas = (int)stp_criancas.Value,
            DataCheckIn = dtpck_checkin.Date,
            DataCheckOut = dtpck_checkout.Date
        };

        await Navigation.PushAsync(new HospedagemContratada
        {
            BindingContext = hospedagem
        });
    }
}
