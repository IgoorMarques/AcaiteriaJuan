namespace webApi.Controllers.Dtos
{
    public class AcompanhamentoDTO
    {
        public int IdAcompanhamento { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public class AcompanhamentoCreateDTO
    {
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
