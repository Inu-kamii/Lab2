namespace Domain.Dto;

public class User
{
    public int UserId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Type { get; set; }
}