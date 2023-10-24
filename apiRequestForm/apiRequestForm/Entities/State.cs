
using apiRequestForm.Entities;

namespace apiRequestForm.Entities
{
    public class State
    {
        public int IdState { get; set; }
        public string NameState { get; set; } = null!;
        public ICollection<Municipality> Posts { get; } = new List<Municipality>();
    }
}
