using MauiAppHotel.Models;
using MauiAppHotel.Views;
using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel.Views
{
    public partial class ContratacaoHospedagem : ContentPage
    {
        public ContratacaoHospedagem()
        {
            InitializeComponent();

            pck_quarto.ItemsSource = new[]
            {
                new Quarto { Descricao = "Suíte Luxo", ValorDiariaAdulto = 150, ValorDiariaCrianca = 75 },
                new Quarto { Descricao = "Quarto Standard", ValorDiariaAdulto = 100, ValorDiariaCrianca = 50 }
            };

            pck_quarto.ItemDisplayBinding = new Binding("Descricao");
        }

        private async void Button_Confirmar_Clicked(object sender, EventArgs e)
        {
            if (pck_quarto.SelectedItem is Quarto quartoSelecionado)
            {
                int adultos = (int)stp_adultos.Value;
                int criancas = (int)stp_criancas.Value;
                DateTime checkin = dtpck_checkin.Date;
                DateTime checkout = dtpck_checkout.Date;

                if (checkout <= checkin)
                {
                    await DisplayAlert("Erro", "Data de checkout deve ser maior que a de checkin.", "OK");
                    return;
                }

                int estadia = (checkout - checkin).Days;

                double total = estadia * (adultos * quartoSelecionado.ValorDiariaAdulto + criancas * quartoSelecionado.ValorDiariaCrianca);

                await Navigation.PushAsync(new HospedagemContradada(
                    quartoSelecionado.Descricao,
                    adultos,
                    criancas,
                    checkin,
                    checkout,
                    estadia,
                    total));
            }
            else
            {
                await DisplayAlert("Erro", "Selecione um quarto válido.", "OK");
            }
        }
    }
}

