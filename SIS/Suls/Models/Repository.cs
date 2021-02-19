namespace Suls.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataValidation.RepositoryValues;

    public class Repository
    {
        public Repository()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; private set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}