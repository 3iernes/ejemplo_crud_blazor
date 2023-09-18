namespace WebBlazorDocsLP.Shared
{
    public class SistemasDists
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public SistemasDists()
        {
            FechaCreacion = DateTime.Now;
        }
    }
}
