namespace MauiAppHotel.Models;

public class Quarto
{
    public required string Descricao { get; set; }
    public double ValorDiariaAdulto { get; set; }
    public double ValorDiariaCrianca { get; set; }

    public override string ToString()
    {
        return Descricao;
    }
}
