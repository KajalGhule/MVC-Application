namespace ShipmentLib
{
    public class Shipment
    {
        public Shipment() { }
        public int Id { get; set; }
        public string ShipmentNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public string Carrier { get; set; }
        public string TrackingNumber { get; set; }

    }
}
