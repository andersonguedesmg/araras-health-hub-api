using System.ComponentModel;

namespace ArarasHealthHub.Domain.Enums
{
    public enum OrderStatusEnum
    {
        [Description("Pendente de Aprovação")]
        PendingApproval = 1,

        [Description("Pronto para Separação")]
        ReadyForPicking = 2,

        [Description("Em Separação")]
        PickingInProgress = 3,

        [Description("Pronto para Envio/Finalização")]
        ReadyForFinalization = 4,

        [Description("Finalizado")]
        Completed = 5,

        [Description("Cancelado")]
        Cancelled = 6
    }
}
