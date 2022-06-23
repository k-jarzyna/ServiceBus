namespace Order.Api.Order;

public class PlaceOrderRequest
{
    public List<int> Products { get; set; }
    
    public int CustomerId { get; set; }
}