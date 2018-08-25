using System.ComponentModel;

namespace Hackathon.Domain.Enums
{
    public enum StatusEnum
    {
        [Description("Aguardando confirmação")]
        Aguardando = 0,
        [Description("Confirmado")]
        Confirmado = 1,
        [Description("Iniciado")]
        Iniciado = 2,
        [Description("Cancelado")]
        Cancelado = 3,
        [Description("Concluído")]
        Concluido = 4
    }
}
