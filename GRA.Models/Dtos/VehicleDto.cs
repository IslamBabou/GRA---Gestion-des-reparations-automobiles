namespace GRA.Models.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string NumberPlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public char Year { get; set; }
        public string ChassisNumber { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public string EngineDescription { get; set; }
        public string Cylinder { get; set; }
        public string BodyType { get; set; }
        public decimal SizeLitre { get; set; }
        public DateTime? FirstVisit { get; set; }
    }
}
