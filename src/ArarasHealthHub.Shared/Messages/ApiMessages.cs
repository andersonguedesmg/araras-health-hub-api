namespace ArarasHealthHub.Shared.Messages
{
    public static class ApiMessages
    {
        public const string InsufficientPermissions = "Permissões insuficientes.";
        public const string AuthorizationRequired = "Autorização necessária.";
        public static string NotFound(string entity) => $"{entity} não encontrado.";
        public static string FoundSuccessfully(string entity) => $"{entity} encontrado com sucesso.";
        public static string CreatedSuccessfully(string entity) => $"{entity} criado com sucesso.";
        public static string NotFoundWithId(string entity, int id) => $"{entity} com ID {id} não encontrado.";
        public static string OrderSuccessfully(string status) => $"Pedido {status} com sucesso.";
        public const string OperationSuccessful = "Operação concluída com sucesso.";
        public const string MinimumQuantityUpdatedSuccessfully = "Quantidade mínima atualizada com sucesso.";
        public const string ProductStockUpdatedSuccessfully = "Estoque do produto atualizado com sucesso.";
        public const string StockSearchByIdSuccessful = "Busca de estoque por ID de produto realizada com sucesso.";
        public const string OrderCannotBeSeparated = "Não é possível separar o pedido. O status atual é 'Pendente', e a separação só pode ser feita em pedidos com status 'Aprovado'.";
        public const string OrderCancelledSuccessfully = "Pedido cancelado com sucesso.";
        public const string PdfGeneratedSuccessfully = "PDF gerado com sucesso.";
        public const string DispenseReturnRecordedSuccessfully = "Estorno dos itens do pedido realizado com sucesso.";
    }
}
