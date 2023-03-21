using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CatalogFootballers.Data.DTOs
{
    /// <summary>
    /// Provides a base class for DTO.
    /// </summary>
    public abstract class EntityBaseDTO
    {
        /// <summary>
        /// Gets or sets the id DTO as a <see cref="int"/> value.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the CreatedDate DTO. 
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime CreatedDate { get; set; }
        /// <summary>
        ///Gets or sets the UpdatedDate DTO. 
        /// </summary>
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime UpdatedDate { get; set; }
    }
}
