namespace AxityStoreBackEnd.Domain.Entities
{
    public class User
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IsActivo { get; set; }
    }
}
