using System.ComponentModel.DataAnnotations.Schema;

namespace APICasamento.Entities
{
    [Table("tb_informacoes")]
    public class Informacoes
    {
        [Column("id")]
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

    }
}
