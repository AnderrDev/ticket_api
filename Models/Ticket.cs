namespace TicketingSystem.Models
{
    public class Ticket
    {
        // id, un usuario, una fecha de creación, una fecha de actualización y un estatus (abierto/cerrado).
        public int Id { get; set; }
        public string User { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public string Status { get; set; }
    }
}