namespace ApiSaas.Models
{
   public class Assinatura
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int PlanoId { get; set; }
    public DateTime DataInicio { get; set; }
}
}
