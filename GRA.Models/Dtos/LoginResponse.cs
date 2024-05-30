namespace GRA.Models.Dtos
{
    public class LoginResponse
    {
        public string JwtToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}