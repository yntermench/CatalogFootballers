using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogFootballers.Data.Models
{
    /// <summary>
    /// Provides a base class for entities.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Gets or sets the id Entity as a <see cref="int"/> value.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the CreatedDate Entity. 
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime CreatedDate { get; set; }
        /// <summary>
        ///Gets or sets the UpdatedDate Entity. 
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime UpdatedDate { get; set; }
    }
}
