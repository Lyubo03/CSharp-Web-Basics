namespace Suls.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataValidation.CommitValues;
    public class Commit
    {
        public Commit()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; private set; }
        [Required]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public string CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public string RepositoryId { get; set; }
        public virtual Repository Repository { get; set; }

    }
}