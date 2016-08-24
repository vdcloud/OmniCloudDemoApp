namespace Capgemini.Demo.App.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LoginId { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
    }
}