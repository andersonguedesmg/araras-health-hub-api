namespace ArarasHealthHub.Shared.Core
{
    public class ApiMessages
    {
        public const string MsgInternalServerError = "Ocorreu um erro interno no servidor.";
        public const string Msg400BadRequestError = "Ocorreu um erro interno.";
        public const string MsgIdMismatch = "ID na rota não corresponde ao ID no corpo da requisição.";
        public const string MsgValidationErrors = "Ocorreram um ou mais erros de validação.";

        public const string MsgEmployeeNotFound = "Funcionário não encontrado.";
        public const string MsgNotEmployeesFound = "Nenhum funcionário encontrado.";
        public const string MsgEmployeeCreatedSuccessfully = "Funcionário criado com sucesso.";
        public const string MsgEmployeeFoundSuccessfully = "Funcionário encontrado com sucesso.";
        public const string MsgEmployeesFoundSuccessfully = "Funcionários encontrados com sucesso.";
        public const string MsgEmployeeUpdatedSuccessfully = "Funcionário atualizado com sucesso.";
        public const string MsgEmployeeDisabledSuccessfully = "Funcionário desativado com sucesso.";
        public const string MsgEmployeeActivatedSuccessfully = "Funcionário ativado com sucesso.";
        public const string MsgEmployeeDeletedSuccessfully = "Funcionário excluído com sucesso.";
        public const string MsgEmployeeInvalid = "Funcionário inválido.";

        public const string MsgSupplierNotFound = "Fornecedor não encontrado.";
        public const string MsgNotSuppliersFound = "Nenhum fornecedor encontrado.";
        public const string MsgSupplierCreatedSuccessfully = "Fornecedor criado com sucesso.";
        public const string MsgSupplierFoundSuccessfully = "Fornecedor encontrado com sucesso.";
        public const string MsgSuppliersFoundSuccessfully = "Fornecedores encontrados com sucesso.";
        public const string MsgSupplierUpdatedSuccessfully = "Fornecedor atualizado com sucesso.";
        public const string MsgSupplierDeactivatedSuccessfully = "Fornecedor desativado com sucesso.";
        public const string MsgSupplierActivatedSuccessfully = "Fornecedor ativado com sucesso.";
        public const string MsgSupplierDeletedSuccessfully = "Fornecedor excluído com sucesso.";
        public const string MsgSupplierStatusAlreadyAsDesired = "Fornecedor já está no status desejado.";
        public const string MsgCnpjAlreadyExists = "CNPJ já registrado.";

        public const string MsgFacilityNotFound = "Unidade não encontrada.";
        public const string MsgNotFacilitiesFound = "Nenhuma unidade encontrada.";
        public const string MsgFacilityDoesNotExist = "A unidade informada não existe.";
        public const string MsgFacilityCreatedSuccessfully = "Unidade criada com sucesso.";
        public const string MsgFacilityFoundSuccessfully = "Unidade encontrada com sucesso.";
        public const string MsgFacilitiesFoundSuccessfully = "Unidades encontradas com sucesso.";
        public const string MsgFacilityUpdatedSuccessfully = "Unidade atualizada com sucesso.";
        public const string MsgFacilityDisabledSuccessfully = "Unidade desativada com sucesso.";
        public const string MsgFacilityActivatedSuccessfully = "Unidade ativada com sucesso.";
        public const string MsgFacilityDeletedSuccessfully = "Unidade excluída com sucesso.";

        public const string MsgAccountUnauthorized = "Conta não autorizada.";
        public const string MsgAccountIncorrect = "Senha ou Usuário incorreto.";
        public const string MsgAccountLoginSuccessful = "Login realizado sucesso.";
        public const string MsgAccountNotFound = "Conta não encontrada.";
        public const string MsgAccountCreatedSuccessfully = "Conta criada com sucesso.";
        public const string MsgAccountFoundSuccessfully = "Conta encontrada com sucesso.";
        public const string MsgAccountsFoundSuccessfully = "Contas encontradas com sucesso.";
        public const string MsgAccountUpdatedSuccessfully = "Conta atualizada com sucesso.";
        public const string MsgAccountDeletedSuccessfully = "Conta excluída com sucesso.";
        public const string MsgAccountCreationFailed = "Falha ao criar a Conta.";
        public const string MsgRoleAssignmentFailed = "Falha ao atribuir o papel a Conta.";
        public const string MsgAccountDisabledSuccessfully = "Conta desativada com sucesso.";
        public const string MsgAccountActivatedSuccessfully = "Conta ativada com sucesso.";
        public const string MsgAccountInvalid = "Conta inválida.";
        public const string MsgAccountPasswordResetSuccessfully = "Senha redefinida com sucesso.";
        public const string MsgAccountPasswordResetFailed = "Falha na redefinição da senha.";

        public const string MsgProductNotFound = "Produto não encontrado.";
        public const string MsgNotProductsFound = "Nenhum produto encontrado.";
        public const string MsgProductCreatedSuccessfully = "Produto criado com sucesso.";
        public const string MsgProductFoundSuccessfully = "Produto encontrado com sucesso.";
        public const string MsgProductsFoundSuccessfully = "Produtos encontrados com sucesso.";
        public const string MsgProductUpdatedSuccessfully = "Produto atualizado com sucesso.";
        public const string MsgProductDisabledSuccessfully = "Produto desativado com sucesso.";
        public const string MsgProductActivatedSuccessfully = "Produto ativado com sucesso.";
        public const string MsgProductDeletedSuccessfully = "Produto excluído com sucesso.";

        public const string MsgReceivingNotFound = "Entrada não encontrada.";
        public const string MsgNotReceivingsFound = "Nenhum Entrada encontrada.";
        public const string MsgReceivingCreatedSuccessfully = "Entrada criada com sucesso.";
        public const string MsgReceivingFoundSuccessfully = "Entrada encontrada com sucesso.";
        public const string MsgReceivingsFoundSuccessfully = "Entradas encontradas com sucesso.";

        public const string MsgNotStocksFound = "Nenhum estoque encontrado.";
        public const string MsgProductStockFoundSuccessfully = "Estoque do produto não encontrado.";
        public const string MsgProductStockNotFound = "Estoque do produto encontrado com sucesso.";
        public const string MsgStocksFoundSuccessfully = "Estoques encontrados com sucesso.";

        public const string MsgOrderNotFound = "Pedido não encontrado.";
        public const string MsgNotOrdersFound = "Nenhum pedido encontrado.";
        public const string MsgOrderCreatedSuccessfully = "Pedido criado com sucesso.";
        public const string MsgOrderApprovedSuccessfully = "Pedido aprovado com sucesso.";
        public const string MsgOrderFoundSuccessfully = "Pedido encontrado com sucesso.";
        public const string MsgOrdersFoundSuccessfully = "Pedidos encontrados com sucesso.";
        public const string MsgOrderStatusInvalid = "Status Inválido.";
        public const string MsgOrderCannotBeApprovedInItsCurrentStatus = "O pedido não pode ser aprovado em seu status atual.";
    }
}
