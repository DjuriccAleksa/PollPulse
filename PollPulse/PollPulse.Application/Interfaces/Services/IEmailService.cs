using PollPulse.Entities.EmailModel;

namespace PollPulse.Application.Interfaces.Services;

public interface IEmailService
{
    Task SendEmail<TModel>(EmailData emailData, string fileTemplateName, TModel model);
}
