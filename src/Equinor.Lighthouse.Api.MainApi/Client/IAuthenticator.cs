namespace Equinor.Lighthouse.Api.MainApi.Client;

public interface IAuthenticator
{
    AuthenticationType AuthenticationType { get; set; }
}