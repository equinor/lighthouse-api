namespace Equinor.Lighthouse.Api.Command.Validators;

public interface IRowVersionValidator
{
    bool IsValid(string rowVersion);
}