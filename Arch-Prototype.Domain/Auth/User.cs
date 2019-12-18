namespace Arch_Prototype.Domain.Auth
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}