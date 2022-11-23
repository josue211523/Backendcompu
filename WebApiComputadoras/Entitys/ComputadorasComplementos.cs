namespace WebApiComputadoras.Entitys
{
    public class ComputadorasComplementos
    {
        public int ComputadorasId { get; set; }
        public int ComplentosId { get; set; }
        public Computadoras Computadoras { get; set; }
        public Complementos Complementos { get; set; }
    }
}
