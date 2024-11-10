namespace WebApiWithDapper.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int CompanyId { get; set; }

    }
}
