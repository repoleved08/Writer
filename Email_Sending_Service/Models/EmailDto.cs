namespace Email_Sending_Service.Models
{
    public class EmailDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
