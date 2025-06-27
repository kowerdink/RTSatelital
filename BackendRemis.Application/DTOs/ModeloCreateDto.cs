namespace BackendRemis.Application.DTOs
{
    public class ModeloCreateDto
    {
        public string Nombre { get; set; } = null!;
        public Guid MarcaId { get; set; }
    }
}
