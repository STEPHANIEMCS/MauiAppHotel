using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel.Views
{
    public partial class HospedagemContradada : ContentPage
    {
        // Construtor padrão (pode ser necessário para design ou testes)
        public HospedagemContradada()
        {
            InitializeComponent();
        }

        // Construtor com parâmetros para receber dados da hospedagem
        public HospedagemContradada(string descricao, int adultos, int criancas, DateTime checkin, DateTime checkout, int estadia, double total) : this()
        {
            lbl_suite.Text = descricao;
            lbl_adultos.Text = adultos.ToString();
            lbl_criancas.Text = criancas.ToString();
            lbl_checkin.Text = checkin.ToString("dd/MM/yyyy");
            lbl_checkout.Text = checkout.ToString("dd/MM/yyyy");
            lbl_estadia.Text = estadia.ToString();
            lbl_total.Text = $"R$ {total:F2}";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
