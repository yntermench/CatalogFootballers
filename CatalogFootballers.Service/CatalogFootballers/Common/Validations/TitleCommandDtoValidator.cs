using CatalogFootballers.Data;
using CatalogFootballers.Data.DTOs;
using FluentValidation;
using System.Linq;

namespace CatalogFootballers.Common.Validations
{
    public class TitleCommandDtoValidator : AbstractValidator<TitleCommandDto>
    {
        private CatalogFootballersDbContext _context;
        public TitleCommandDtoValidator(CatalogFootballersDbContext context)
        {
            _context = context;

            RuleFor(tc => tc.Title)
                .NotEmpty().WithMessage("Название команды не может быть пустым.")
                .MaximumLength(128).WithMessage("Название команды не может иметь больше 128 символов.")
                .Must(IsUniqueTitle).WithMessage("Название команды должно быть уникальным!");
        }
        
        private bool IsUniqueTitle(TitleCommandDto titleCommandDto, string title)
        {
            var uniqueElement = _context.TitlesCommands
                .Where(tc => tc.Title.ToLower() == title.ToLower())
                .FirstOrDefault();

            if (uniqueElement == null)
            {
                return true;
            }
            return uniqueElement.Title.ToLower() == titleCommandDto.Title.ToLower();
        }
    }
}
