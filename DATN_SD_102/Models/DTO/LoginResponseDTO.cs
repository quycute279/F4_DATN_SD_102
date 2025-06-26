namespace F4_API.Models.DTO
{
    public class LoginResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Message { get; set; }
    }
}
