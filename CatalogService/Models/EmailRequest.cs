namespace EmailService.Model;

public class EmailRequest
{
    public string From { get; set; }
    public string To { get; set; }
    public string Subject{ get; set; }
    public string Html{ get; set; }
}