using Flunt.Notifications;

namespace ShoppingList.Application.Models;

public class AddProductResponse : Notifiable<Notification>
{
    public Guid? ProductId { get; set; }
}