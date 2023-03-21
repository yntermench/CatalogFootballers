using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogFootballers.Data.Models
{
    /// <summary>
    /// Provides properties for creating entity Footballer.
    /// </summary>
    public class Footballer : EntityBase
    {
        /// <summary>
        /// Gets or sets the FirstName <see cref="Footballer"/>. 
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the LastName <see cref="Footballer"/>. 
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the Gender <see cref="Footballer"/>. 
        /// </summary>
        [Required]
        [MaxLength(64)]
        public string Gender { get; set; }
        /// <summary>
        /// Gets or sets the DateOfBirth <see cref="Footballer"/>. 
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Gets or sets the Country <see cref="Footballer"/>. 
        /// </summary>
        [Required]
        public Country Country { get; set; }
        /// <summary>
        /// Gets or sets the TitleCommandId <see cref="Footballer"/>. 
        /// </summary>
        [Required]
        public int TitleCommandId { get; set; }
        /// <summary>
        /// Gets or sets the TitleCommand <see cref="Footballer"/>. 
        /// </summary>
        [Required]
        public TitleCommand TitleCommand { get; set; }
    }
}
