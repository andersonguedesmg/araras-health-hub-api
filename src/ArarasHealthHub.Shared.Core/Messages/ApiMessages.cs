namespace ArarasHealthHub.Shared.Core.Messages
{
    public static class ApiMessages
    {
        public static string EntityNotFound(string entity) => $"{entity} não encontrado.";
        public static string EntityFound(string entity) => $"{entity} encontrado com sucesso.";
        public static string EntityCreated(string entity) => $"{entity} criado com sucesso.";
        public static string EntityUpdated(string entity) => $"{entity} atualizado com sucesso.";
        public static string EntityActivated(string entity) => $"{entity} ativado com sucesso.";
        public static string EntityDeactivated(string entity) => $"{entity} desativado com sucesso.";
        public static string EntityAlreadyExists(string entity) => $"{entity} já registrado.";
        public static string EntityAlreadyActive(string entity) => $"{entity} já está ativo.";
        public static string EntityAlreadyInactive(string entity) => $"{entity} já está inativo.";
        public static string CannotActivateBecauseInactive(string entity, string parent) => $"Não é possível ativar {entity} porque {parent} está inativo.";
        public static string NoChangesDetected() => "Nenhuma alteração detectada.";
        public static string CollectionFound(string entityPlural) => $"{entityPlural} encontrados com sucesso.";
        public static string CollectionEmpty(string entityPlural) => $"Nenhum(a) {entityPlural} encontrado(a).";

        public static string ExportEmpty(string entity) => $"Nenhum(a) {entity} encontrado(a) para os filtros aplicados. A exportação foi cancelada.";

        public const string LoginSuccessful = "Login realizado com sucesso.";
        public const string InvalidCredentials = "Credenciais inválidas.";
        public const string AccountUnauthorized = "Conta não autorizada.";
        public const string AccountDisabled = "Conta desativada.";
        public const string UnauthenticatedUser = "Conta não autenticada.";
        public const string AccessDenied = "Acesso negado.";
        public const string InsufficientPermissions = "Permissões insuficientes.";
        public const string AuthorizationRequired = "Autorização necessária.";
        public const string OperationRestrictedToFacility = "Operação restrita à unidade.";

        public const string ValidationErrors = "Ocorreram erros de validação.";
        public const string IdMismatch = "ID da rota não corresponde ao ID da requisição.";
        public const string InternalServerError = "Erro interno do servidor.";

        public const string CnpjAlreadyExists = "CNPJ já registrado.";
        public const string CpfAlreadyExists = "CPF já registrado.";

        public static string OrderStatusChanged(string status) => $"Pedido {status} com sucesso.";
        public static string OrderCannotBeCancelled(string status) => $"Não é possível cancelar pedido com status {status}.";
        public static string OrderCannotProceedFromStatus(string status) => $"Operação não permitida para pedido com status {status}.";

        public static string InsufficientStock(string productName) => $"Estoque insuficiente para o produto \"{productName}\".";
        public const string StockAdjustmentCompleted = "Ajuste de estoque realizado com sucesso.";
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
        public const string ResourceNotFound = "O recurso solicitado não foi encontrado.";
        public const string AccountLoginSuccessful = "Login realizado com sucesso.";
        public const string AccountIncorrect = "Credenciais inválidas.";
        public const string AccountNameAlreadyInUse = "Nome da conta já está em uso.";
        public const string FailedToResetPassword = "Falha ao redefinir a senha.";
        public const string PasswordResetSuccessfully = "Senha redefinida com sucesso.";
        public const string FailedToCreateAccount = "Falha ao criar a conta.";
        public const string FailedToAssignRoleToAccount = "Falha ao atribuir a função a conta.";
        public const string RoleDoesNotExist = "A função informada não existe.";
        public const string FailedToUpdateAccount = "Falha ao atualizar a conta.";
        public const string FailedToChangeAccountStatus = "Falha ao alterar o status da conta.";
        public const string ReceivingAndStockMovementsCreatedSuccessfully = "Recebimento e movimentos de estoque criados com sucesso.";
        public const string MinimumQuantityUpdatedSuccessfully = "Quantidade mínima atualizada com sucesso.";
        public const string MinimumQuantityCannotBeNegative = "A quantidade mínima não pode ser um valor negativo.";
        public const string ProductStockUpdatedSuccessfully = "Estoque do produto atualizado com sucesso.";
        public const string StockAdjustmentCompletedSuccessfully = "Ajuste de estoque realizado com sucesso.";
        public const string StockSearchByIdSuccessful = "Busca de estoque por ID de produto realizada com sucesso.";
        public const string NoLowStockProductsFound = "Nenhum produto com estoque baixo encontrado.";
        public const string StockBatchUpdatedSuccessfully = "Lote de estoque atualizado com sucesso.";
        public const string LowStockProductsFoundSuccessfully = "Lista de produtos com estoque baixo retornada com sucesso.";
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
        public const string MasterRoleExclusiveToManagement = "A função MASTER só pode ser atribuída no escopo de GERENCIAMENTO.";
        public const string OperationalScopeForbidsMasterRole = "A função MASTER não é permitida no escopo OPERACIONAL.";
        public const string UnableToIdentifyFacilityOfTheLoggedAccount = "Não foi possível identificar a unidade da conta logada.";
    }
}
