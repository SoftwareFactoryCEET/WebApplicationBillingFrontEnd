namespace WebApplicationBilling.Models
{
    public class RegisterUser
    {
        //public string? Id { get; set; } //= new (Guid.NewGuid().ToString());
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        //public string UserName { get; set; } //Correo        
        //public string PasswordHash { get; set; }  
        //public string? Token { get; set; } //Revisar

        //[Required(ErrorMessage = "El correo de usuario es requerido")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string? FirstName { get; set; }
        //[Required(ErrorMessage = "El apellido de usuario es requerido")]
        public string? LastName { get; set; }
        //[Required(ErrorMessage = "El password es requerido")]
        public string Password { get; set; }
        public List<string>? Roles { get; set; } // Changed to List for multiple roles
        
        public string? Token { get; set; } //Revisar
    }
}
