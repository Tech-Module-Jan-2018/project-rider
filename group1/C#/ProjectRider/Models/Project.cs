namespace ProjectRider.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Budget { get; set; }

    }
}
