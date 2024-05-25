namespace Examen1_API.Models
{
    public class Pokemon
    {
        public string name { get; set; }
        public string imagen { get; set; }
        public string type { get; set; }

        public List<string> movimiento {  get; set; }     
    }
}