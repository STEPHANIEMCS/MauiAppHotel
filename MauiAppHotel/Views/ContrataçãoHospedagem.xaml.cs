using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        // Popula o Picker com as op��es de su�te
        pck_quarto.ItemsSource = new List<string>
        {
            "Su�te Standard",
            "Su�te Luxo",
            "Su�te Master",
            "Su�te Presidencial"
        };

        // Seleciona a primeira su�te automaticamente
        if (pck_quarto.ItemsSource is IList<string> itens && itens.Count > 0)
            pck_quarto.SelectedIndex = 0;

        // Define data m�nima para check-in como hoje
        dtpck_checkin.MinimumDate = DateTime.Today;

        // Define data m�nima para check-out como amanh�
        dtpck_checkout.MinimumDate = DateTime.Today.AddDays(1);
    }

    private async void BtnAvancar_Clicked(object sender, EventArgs e)
    {
        string? suiteSelecionada = pck_quarto.SelectedItem as string;

        if (string.IsNullOrEmpty(suiteSelecionada))
        {
            await DisplayAlert("Erro", "Por favor, selecione uma su�te.", "OK");
            return;
        }

        int adultos = (int)stp_adultos.Value;
        int criancas = (int)stp_criancas.Value;

        DateTime checkin = dtpck_checkin.Date;
        DateTime checkout = dtpck_checkout.Date;

        if (checkout <= checkin)
        {
            await DisplayAlert("Erro", "Data de check-out deve ser ap�s a data de check-in.", "OK");
            return;
        }

        int dias = (checkout - checkin).Days;

        string resumo = $"Su�te: {suiteSelecionada}\n" +
                        $"Adultos: {adultos}\n" +
                        $"Crian�as: {criancas}\n" +
                        $"Check-in: {checkin:dd/MM/yyyy}\n" +
                        $"Check-out: {checkout:dd/MM/yyyy}\n" +
                        $"Dias de estadia: {dias}";

        bool confirmar = await DisplayAlert("Confirma��o da Reserva", resumo + "\n\nDeseja confirmar a reserva?", "Sim", "N�o");

        if (confirmar)
        {
            await DisplayAlert("Sucesso", "Reserva confirmada!", "OK");
            // Aqui voc� pode salvar a reserva ou navegar para outra p�gina
        }
        else
        {
            await DisplayAlert("Cancelado", "Reserva n�o confirmada.", "OK");
        }
    }
}
