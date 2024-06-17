using Flunt.Notifications;

namespace ShoppingList.Application.Models;

public class ProductResponse : Notifiable<Notification>
{
    public Guid? ProductId { get; set; }
}