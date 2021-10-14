namespace TelstarLogistics.Requests
{
    public class StatusRequest
    {
        public int OrderId { get; set; }
        public bool ShippingStatus { get; set; }

        public bool Delivered { get; set; }
    }
}