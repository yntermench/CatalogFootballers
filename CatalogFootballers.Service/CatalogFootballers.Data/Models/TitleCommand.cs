using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogFootballers.Data.Models
{
    /// <summary>
    /// Provides properties for creating Entity TitleCommand.
    /// </summary>
    public class TitleCommand : EntityBase
    {
        /// <summary>
        /// Gets or sets the Title <see cref="TitleCommand"/>. 
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the Footballers <see cref="TitleCommand"/>. 
        /// </summary>
        public ICollection<Footballer> Footballers { get; set; } 
    }
}
