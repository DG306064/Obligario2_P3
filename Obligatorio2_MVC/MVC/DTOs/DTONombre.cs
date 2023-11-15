

namespace MVC.DTOs
{
    public class DTONombre
    {
        public static int MinLargoCharNombre { get; set; }
        public static int MaxLargoCharNombre { get; set; }
        public string? Value { get; private set; }

        public DTONombre(string value)
        {
            Value = value;
        }
    }
}
