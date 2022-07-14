using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain
{
    public class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UptatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
