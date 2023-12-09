﻿using System.ComponentModel.DataAnnotations;

namespace FilmeNepenApi.Models
{
    public class Filme
    {
        public Filme(int id, string? nome, string? descricao, string? banner, int? anoLancamento)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Banner = banner;
            AnoLancamento = anoLancamento;
        }

        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Banner { get; set; }
        public int? AnoLancamento { get; set; }
    }
}
