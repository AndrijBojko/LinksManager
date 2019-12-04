namespace LinksManager.Entities
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Link")]
    public partial class Link
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Category { get; set; }

        [Required]
        [StringLength(25)]
        public string Url { get; set; }

        [Required]
        [StringLength(25)]
        public string Description { get; set; }
    }
}
