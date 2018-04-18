namespace ProjectRider.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Budget { get; set; }

    }
}
