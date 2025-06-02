namespace MauiAppHotel.Models;

public class Hospedagem
{
    public required Quarto QuartoSelecionado { get; set; }
    public int QntAdultos { get; set; }
    public int QntCriancas { get; set; }
    public DateTime DataCheckIn { get; set; }
    public DateTime DataCheckOut { get; set; }

    public int Estadia => (int)(DataCheckOut - DataCheckIn).TotalDays;

    public double ValorTotal =>
        (Estadia * (QntAdultos * QuartoSelecionado.ValorDiariaAdulto)) +
        (Estadia * (QntCriancas * QuartoSelecionado.ValorDiariaCrianca));
}
