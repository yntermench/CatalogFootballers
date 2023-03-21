using CatalogFootballers.Data.DTOs;
using FluentValidation;

namespace CatalogFootballers.Common.Validations
{
    public class FootballerDtoValidator : AbstractValidator<FootballerDto>
    {
        public FootballerDtoValidator()
        {
            RuleFor(ftDto => ftDto.FirstName)
                .NotEmpty().WithMessage("Имя не может быть пустым.")
                .MaximumLength(128).WithMessage("Имя не может иметь больше 128 символов.");
            RuleFor(ftDto => ftDto.LastName)
                .NotEmpty().WithMessage("Фамилия не может быть пустой.")
                .MaximumLength(128).WithMessage("Фамилия не может иметь больше 128 символов.");
            RuleFor(ftDto => ftDto.Gender)
                .NotEmpty().WithMessage("Пол не может быть пустым.")
                .MaximumLength(64).WithMessage("Пол не может иметь больше 64 символов.");
            RuleFor(ftDto => ftDto.DateOfBirth)
                .NotEmpty().WithMessage("Дата рождения не может быть пустым.");
            RuleFor(ftDto => ftDto.Country)
                .NotEmpty().WithMessage("Страна не может быть пустой.");
            RuleFor(ftDto => ftDto.TitleCommandId)
                .NotEmpty().WithMessage("Название команды не может быть пустой.");
        }
    }
}
