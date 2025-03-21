using System.ComponentModel.DataAnnotations.Schema;

namespace APICasamanto.Entities
{
        [Table("tb_formulario")]
        public class Formulario
        {
            [Column("id")]
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Resposta { get; set; }
            public string? Convidado { get; set; }
            public string? Mensagem { get; set; }

        }
}
