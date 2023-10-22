using Flunt.Notifications;

namespace Application.Models
{
    public class ProductResponse : Notifiable<Notification>
    {
        public Guid? ProductId { get; set; }
    }
}