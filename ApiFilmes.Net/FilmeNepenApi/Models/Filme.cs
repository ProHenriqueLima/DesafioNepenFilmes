using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmeNepenApi.Models
{
    public class Filme
    {
        public Filme()
        {
            
        }

        public Filme(int id, string nome, string descricao, string banner, string anoLancamento, string comentario, string usernameCriador)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Banner = banner;
            AnoLancamento = anoLancamento;
            Comentario = comentario;
            UsernameCriador = usernameCriador;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Banner { get; set; }
        public string AnoLancamento { get; set; }
        public string Comentario { get; set; }
        public string UsernameCriador { get; set; }
    }
}
