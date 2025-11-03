using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppHotel.Models
{
    public class Quarto
    {
        // CORREÇÃO: Inicializa a string Descricao para evitar o erro de nulidade CS8618.
        public string Descricao { get; set; } = string.Empty;

        // O compilador não reclamou destes, mas a Descricao é o alvo.
        public double ValorDiariaAdulto { get; set; }
        public double ValorDiariaCrianca { get; set; }
    }
}