using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class PersonDto
    {
        public int IdPerson { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El apellido solo puede contener letras.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El documento de identidad es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "El documento de identidad solo puede contener caracteres alfanuméricos.")]
        public string DocumentNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime Birthdate { get; set; }
        public string? ErrorMessage { get; set; }

        public List<string> Phones { get; set; } = new List<string>();
        public List<string> Emails { get; set; } = new List<string>();
        public List<string> Addresses { get; set; } = new List<string>();
    }
}
