namespace ArarasHealthHub.Shared.Messages
{
    public static class ApiMessages
    {
        public static string ExportEmpty(string entity) => $"Nenhum(a) {entity} encontrado(a) para os filtros aplicados. A exportação foi cancelada.";
        public const string InsufficientPermissions = "Permissões insuficientes.";
        public const string AuthorizationRequired = "Autorização necessária.";
        public const string OperationRestrictedToFacility = "Operação restrita à unidade.";
        public const string InternalServerError = "Erro interno do servidor.";
        public const string StockReleaseFailed = "Liberação de estoque falhou.";

        /* ========= OLD ========= */
        public static string NotFound(string entity) => $"{entity} não encontrado.";
        public static string FoundSuccessfully(string entity) => $"{entity} encontrado com sucesso.";
        public static string CreatedSuccessfully(string entity) => $"{entity} criado com sucesso.";
        public static string UpdatedSuccessfully(string entity) => $"{entity} atualizado com sucesso.";
        public static string RegisteredSuccessfully(string entity) => $"{entity} registrada com sucesso.";
        public static string NotFoundWithId(string entity, int id) => $"{entity} com ID {id} não encontrado.";
        public static string ItemNotFoundInOrder(int orderItemId) => $"O item de pedido com ID {orderItemId} não foi encontrado no pedido.";
        public static string OrderSuccessfully(string status) => $"Pedido {status} com sucesso.";
        public static string CannotCancelOrderInStatus(string status) => $"Não é possível cancelar o pedido com status {status}.";
        public static string CannotReturnFromOrderInStatus(string status) => $"Não é possível retornar do pedido com status {status}.";
        public const string OperationSuccessful = "Operação concluída com sucesso.";
        public const string ReceivingAndStockMovementsCreatedSuccessfully = "Recebimento e movimentos de estoque criados com sucesso.";
        public const string MinimumQuantityUpdatedSuccessfully = "Quantidade mínima atualizada com sucesso.";
        public const string MinimumQuantityCannotBeNegative = "A quantidade mínima não pode ser um valor negativo.";
        public const string ProductStockUpdatedSuccessfully = "Estoque do produto atualizado com sucesso.";
        public const string StockAdjustmentCompletedSuccessfully = "Ajuste de estoque realizado com sucesso.";
        public const string StockSearchByIdSuccessful = "Busca de estoque por ID de produto realizada com sucesso.";
        public const string StockBatchUpdatedSuccessfully = "Lote de estoque atualizado com sucesso.";
        public const string CostOfInventoryInitializedAndSavedSuccessfully = "Custo do estoque inicializado e salvo com sucesso.";
        public const string TheQuantityMustBeGreaterThanZero = "A quantidade de entrada deve ser maior que zero.";
        public const string TheUnitValueCannotBeNegative = "O valor unitário de entrada não pode ser negativo.";
        public const string WeightedAverageCostSuccessfullyUpdated = "Custo Médio Ponderado (CMP) atualizado com sucesso.";
        public const string OrderCannotBeApproved = "Não é possível aprovar o pedido. A aprovação só pode ser feita em pedidos com status 'Pendente'.";
        public const string OrderCannotBeSeparated = "Não é possível separar o pedido. O status atual é 'Pendente', e a separação só pode ser feita em pedidos com status 'Aprovado'.";
        public const string OrderCannotBeCompleted = "Não é possível finalizar o pedido. Para finalizar, o pedido precisa estar com o status 'Separado'.";
        public const string OrderCancelledSuccessfully = "Pedido cancelado com sucesso.";
        public const string PdfGeneratedSuccessfully = "PDF gerado com sucesso.";
        public const string OrderAlreadyCancelled = "Pedido já cancelado.";
        public const string DispenseReturnRecordedSuccessfully = "Estorno dos itens do pedido realizado com sucesso.";
        public const string UnableToIdentifyFacilityOfTheLoggedAccount = "Não foi possível identificar a unidade da conta logada.";
    }
}
