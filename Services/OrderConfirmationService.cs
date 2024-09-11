namespace FoodCart_Hexaware.Services
{
    public class OrderConfirmationService
{
    private readonly EmailService _emailService;

    public OrderConfirmationService(EmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task SendOrderConfirmationEmailAsync(string toAddress, int orderId)
    {
        var subject = "Order Confirmation";
        var htmlMessage = $"<p>Your order with ID <strong>{orderId}</strong> has been placed successfully.</p><p>Thank you for ordering with us!</p>";
        await _emailService.SendEmailAsync(toAddress, subject, htmlMessage);
    }
}

}
