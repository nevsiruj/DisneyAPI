namespace DisneyAPI
{
    public class Obra
    {
        public int ObraId { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public int Calificacion { get; set; }
        public int currentGeneroId  { get; set; }   
        public Genero? Genero { get; set; }
    }
}
