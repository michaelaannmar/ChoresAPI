namespace ChoresAPI.Models
{
    public class Chore
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AssignedTo { get; set; }

        public int Point { get; set; }

        public string Status { get; set; }

        public string Frequency { get; set; }

    }
}
