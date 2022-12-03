namespace MP.ApiDotnet6.Application.DTOs
{
    [Serializable]
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
    }
}