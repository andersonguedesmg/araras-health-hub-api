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
        public const string FailedToUpdateAccount = "Falha ao atualizar a conta.";
        public const string FailedToChangeAccountStatus = "Falha ao alterar o status da conta.";
        public const string FacilityAlreadyExists = "Unidade já registrada.";
        public const string FacilityDoesNotExist = "A unidade informada não existe.";
        public const string CnpjAlreadyExists = "CNPJ já registrado.";
        public const string CpfAlreadyExists = "CPF já registrado.";
        public const string ProductAlreadyExists = "Produto já registrado.";
        public const string ReceivingAndStockMovementsCreatedSuccessfully = "Recebimento e movimentos de estoque criados com sucesso.";
        public const string MinimumQuantityUpdatedSuccessfully = "Quantidade mínima atualizada com sucesso.";
        public const string MinimumQuantityCannotBeNegative = "A quantidade mínima não pode ser um valor negativo.";
        public const string ProductStockUpdatedSuccessfully = "Estoque do produto atualizado com sucesso.";
        public const string StockSearchByIdSuccessful = "Busca de estoque por ID de produto realizada com sucesso.";
        public const string NoLowStockProductsFound = "Nenhum produto com estoque baixo encontrado.";
        public const string LowStockProductsFoundSuccessfully = "Lista de produtos com estoque baixo retornada com sucesso.";
        public const string OrderApprovedSuccessfully = "Pedido aprovado com sucesso.";
        public const string OrderCannotBeApproved = "O pedido não pode ser aprovado. O status atual não é 'Pendente'.";
    }
}
