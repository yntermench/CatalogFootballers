using CatalogFootballers.Data.Models;
using System;

namespace CatalogFootballers.Data.DTOs
{
    /// <summary>
    /// Provides properties for creating DTO Footballer.
    /// </summary>
    public class FootballerDto : EntityBaseDTO
    {
        /// <summary>
        /// Gets or sets the FirstName <see cref="FootballerDto"/>. 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the LastName <see cref="FootballerDto"/>. 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the Gender <see cref="FootballerDto"/>. 
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Gets or sets the DateOfBirth <see cref="FootballerDto"/>. 
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Gets or sets the Country <see cref="FootballerDto"/>. 
        /// </summary>
        public Country Country { get; set; }
        /// <summary>
        /// Gets or sets the TitleCommandId <see cref="FootballerDto"/>. 
        /// </summary>
        public TitleCommand TitleCommand { get; set; }
        /// <summary>
        /// Gets or sets the TitleCommand <see cref="FootballerDto"/>. 
        /// </summary>
        public int TitleCommandId { get; set; }
    }
}
