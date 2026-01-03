namespace ArarasHealthHub.Shared.Core
{
    public static class ApiMessages
    {
        public static string NotFound(string entity) => $"{entity} não encontrado.";
        public static string NotItemsFound(string entity) => $"Nenhum {entity} encontrado.";
        public static string FoundSuccessfully(string entity) => $"{entity} encontrado com sucesso.";
        public static string ItemsFoundSuccessfully(string entity) => $"{entity}s encontrados com sucesso.";
        public static string CreatedSuccessfully(string entity) => $"{entity} criado com sucesso.";
        public static string UpdatedSuccessfully(string entity) => $"{entity} atualizado com sucesso.";
        public static string DeletedSuccessfully(string entity) => $"{entity} excluído com sucesso.";
        public static string RegisteredSuccessfully(string entity) => $"{entity} registrada com sucesso.";
        public static string DeactivatedSuccessfully(string entity) => $"{entity} desativado com sucesso.";
        public static string ActivatedSuccessfully(string entity) => $"{entity} ativado com sucesso.";
        public static string NotFoundWithId(string entity, int id) => $"{entity} com ID {id} não encontrado.";
        public static string AccountStatusAlreadyAsDesired(string status) => $"O status da conta já está {status}.";
        public static string PasswordResetFailed(string errors) => $"Falha ao redefinir a senha: {errors}";
        public static string AccountsFoundForFacility(int facilityId) => $"Contas da unidade com ID {facilityId} recuperadas com sucesso.";
        public static string NoAccountsFoundForFacility(int facilityId) => $"Nenhuma conta encontrada para a unidade com ID {facilityId}.";
        public static string InsufficientStock(string productName) => $"Estoque insuficiente para o produto '{productName}'.";
        public static string ItemNotFoundInOrder(int orderItemId) => $"O item de pedido com ID {orderItemId} não foi encontrado no pedido.";
        public static string OrderSuccessfully(string status) => $"Pedido {status} com sucesso.";
        public static string CannotCancelOrderInStatus(string status) => $"Não é possível cancelar o pedido com status {status}.";
        public static string CannotReturnFromOrderInStatus(string status) => $"Não é possível retornar do pedido com status {status}.";
        public static string ExportEmpty(string entity) => $"Nenhum(a) {entity} encontrado(a) para os filtros aplicados. A exportação foi cancelada.";

        public const string OperationSuccessful = "Operação concluída com sucesso.";
        public const string InternalServerError = "Ocorreu um erro interno no servidor.";
        public const string ResourceNotFound = "O recurso solicitado não foi encontrado.";
        public const string ValidationErrors = "Ocorreram um ou mais erros de validação.";
        public const string IdMismatch = "ID na rota não corresponde ao ID no corpo da requisição.";

        public const string AccountLoginSuccessful = "Login realizado com sucesso.";
        public const string AccountIncorrect = "Credenciais inválidas.";
        public const string AccountUnauthorized = "Conta não autorizada.";
        public const string AccountDisabled = "Esta conta está desativada. Entre em contato com o administrador.";
        public const string AccountNameAlreadyInUse = "Nome da conta já está em uso.";
        public const string PasswordResetSuccessfully = "Senha redefinida com sucesso.";
        public const string FailedToCreateAccount = "Falha ao criar a conta.";
        public const string FailedToAssignRoleToAccount = "Falha ao atribuir a função a conta.";
        public const string RoleDoesNotExist = "A função informada não existe.";
        public const string FailedToUpdateAccount = "Falha ao atualizar a conta.";
        public const string FailedToChangeAccountStatus = "Falha ao alterar o status da conta.";
        public const string FacilityAlreadyExists = "Unidade já registrada.";
        public const string FacilityDoesNotExist = "A unidade informada não existe.";
        public const string CnpjAlreadyExists = "CNPJ já registrado.";
        public const string CpfAlreadyExists = "CPF já registrado.";
        public const string ProductAlreadyExists = "Produto já registrado.";
        public const string MainCategoryAlreadyExists = "Categoria principal já registrada.";
        public const string SubCategoryAlreadyExists = "Subcategoria já registrada.";
        public const string PresentationFormAlreadyExists = "Forma de apresentação já registrada.";
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
        public const string StockReleaseFailed = "A liberação de estoque falhou.";
        public const string OrderAlreadyCancelled = "Pedido já cancelado.";
        public const string DispenseReturnRecordedSuccessfully = "Estorno dos itens do pedido realizado com sucesso.";
        public const string MasterRoleExclusiveToManagement = "A função MASTER só pode ser atribuída no escopo de GERENCIAMENTO.";
        public const string OperationalScopeForbidsMasterRole = "A função MASTER não é permitida no escopo OPERACIONAL.";
        public const string AccessDenied = "Acesso negado.";
        public const string AuthorizationRequired = "Autorização necessária.";
        public const string UnauthenticatedUser = "Conta não autenticada.";
        public const string InsufficientPermissions = "Permissões insuficientes.";
        public const string OperationRestrictedToFacility = "Operação restrita à unidade.";
        public const string UnableToIdentifyFacilityOfTheLoggedAccount = "Não foi possível identificar a unidade da conta logada.";
    }
}
