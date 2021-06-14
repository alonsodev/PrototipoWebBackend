using System.Threading.Tasks;

namespace ProtoWeb.Infra.Data.Agent.MailSender
{
    public interface IMailInternalSenderAgent
    {
        Task EnviarCorreoAsync(MailDto correo);
    }
}
