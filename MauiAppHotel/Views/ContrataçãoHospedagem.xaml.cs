using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        // Popula o Picker com as opções de suíte
        pck_quarto.ItemsSource = new List<string>
        {
            "Suíte Standard",
            "Suíte Luxo",
            "Suíte Master",
            "Suíte Presidencial"
        };

        // Seleciona a primeira suíte automaticamente
        if (pck_quarto.ItemsSource is IList<string> itens && itens.Count > 0)
            pck_quarto.SelectedIndex = 0;

        // Define data mínima para check-in como hoje
        dtpck_checkin.MinimumDate = DateTime.Today;

        // Define data mínima para check-out como amanhã
        dtpck_checkout.MinimumDate = DateTime.Today.AddDays(1);
    }

    private async void BtnAvancar_Clicked(object sender, EventArgs e)
    {
        string? suiteSelecionada = pck_quarto.SelectedItem as string;

        if (string.IsNullOrEmpty(suiteSelecionada))
        {
            await DisplayAlert("Erro", "Por favor, selecione uma suíte.", "OK");
            return;
        }

        int adultos = (int)stp_adultos.Value;
        int criancas = (int)stp_criancas.Value;

        DateTime checkin = dtpck_checkin.Date;
        DateTime checkout = dtpck_checkout.Date;

        if (checkout <= checkin)
        {
            await DisplayAlert("Erro", "Data de check-out deve ser após a data de check-in.", "OK");
            return;
        }

        int dias = (checkout - checkin).Days;

        string resumo = $"Suíte: {suiteSelecionada}\n" +
                        $"Adultos: {adultos}\n" +
                        $"Crianças: {criancas}\n" +
                        $"Check-in: {checkin:dd/MM/yyyy}\n" +
                        $"Check-out: {checkout:dd/MM/yyyy}\n" +
                        $"Dias de estadia: {dias}";

        bool confirmar = await DisplayAlert("Confirmação da Reserva", resumo + "\n\nDeseja confirmar a reserva?", "Sim", "Não");

        if (confirmar)
        {
            await DisplayAlert("Sucesso", "Reserva confirmada!", "OK");
            // Aqui você pode salvar a reserva ou navegar para outra página
        }
        else
        {
            await DisplayAlert("Cancelado", "Reserva não confirmada.", "OK");
        }
    }
}
