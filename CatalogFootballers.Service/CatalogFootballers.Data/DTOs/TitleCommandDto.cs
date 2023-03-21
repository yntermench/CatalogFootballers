using CatalogFootballers.Data.Models;
using System.Collections.Generic;

namespace CatalogFootballers.Data.DTOs
{
    /// <summary>
    /// Provides properties for creating DTO TitleCommand.
    /// </summary>
    public class TitleCommandDto : EntityBaseDTO
    {
        /// <summary>
        /// Gets or sets the Title <see cref="TitleCommandDto"/>. 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the Footballers <see cref="TitleCommandDto"/>. 
        /// </summary>
        public ICollection<Footballer> Footballers { get; set; }
    }
}
