
namespace apiRequestForm.Entities
{
    public class Municipality
    {
        public int IdMunicipality { get; set; }
        public string NameMunicipality { get; set; } = null!;
        public int StateId { get; set; } // Required foreign key property
        public State State { get; set; } = null!;

    }
}
