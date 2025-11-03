namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto? QuartoSelecionado { get; set; } // Permite ser nulo
        public int QntAdultos { get; set; }
        public int QntCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public int Estadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }
        public double ValorTotal
        {
            get
            {
                // CORREÇÃO: Usamos o operador '!' para dizer ao compilador 
                // que QuartoSelecionado NÃO será nulo neste ponto de execução.
                double valor_adultos = QntAdultos * QuartoSelecionado!.ValorDiariaAdulto;
                double valor_criancas = QntCriancas * QuartoSelecionado!.ValorDiariaCrianca;

                double total = (valor_adultos + valor_criancas) * Estadia;

                return total;
            }
        }
    }
}