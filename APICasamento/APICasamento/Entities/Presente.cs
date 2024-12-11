using System.ComponentModel.DataAnnotations.Schema;

namespace APICasamento.Entities;
[Table("tb_Presente")]
public class Presente
{
    [Column("id")]
    public int Id { get; set; }
    public string Nome { get; set; }
    public float Preco { get; set; }
    public string Pix { get; set; }
    public string Link { get; set; }
    public string Chave_pix { get; set; }
    public string Imagem { get; set; }

}
