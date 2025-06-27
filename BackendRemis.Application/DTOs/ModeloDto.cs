namespace BackendRemis.Application.DTOs
{
    public class ModeloDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public Guid MarcaId { get; set; }           // Relación con la marca
    }
}
