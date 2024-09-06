namespace webApi.Controllers.Dtos
{
    public class AcaiDTO
    {
        public int IdAcai { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int MaxAcompahamentoGratuito { get; set; }
        public decimal Valor { get; set; }
        public int MaxAdicional { get; set; }
        public List<AcaiAcompanhamentoDTO> AcaiAcompanhamentos { get; set; }
    }

    public class AcaiCreateDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int MaxAcompahamentoGratuito { get; set; }
        public decimal Valor { get; set; }
        public int MaxAdicional { get; set; }
    }
}
