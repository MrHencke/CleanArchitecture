using FluentValidation;

namespace ProjectName.Domain.ExampleEntities.Commands
{
    public class AddExampleEntityCommandValidator : AbstractValidator<AddExampleEntityCommand>
    {
        public AddExampleEntityCommandValidator() 
        {
            RuleFor(x => x.ExampleValue1).NotEmpty();
            RuleFor(x => x.ExampleValue2).GreaterThanOrEqualTo(0);
        }
    }
}
