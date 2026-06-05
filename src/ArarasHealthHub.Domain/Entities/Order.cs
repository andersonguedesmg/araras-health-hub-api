using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Exceptions;
using ArarasHealthHub.Domain.Identity;

namespace ArarasHealthHub.Domain.Entities
{
    public class Order : BaseEntity
    {
        private readonly List<OrderItem> _items = [];

        public string? Observation { get; private set; }

        public int OrderFacilityId { get; private set; }
        public Facility OrderFacility { get; private set; } = null!;

        public int OrderStatusId { get; private set; }
        public OrderStatus OrderStatus { get; private set; } = null!;

        public DateTime CreatedAt { get; private set; }

        public int CreatedByEmployeeId { get; private set; }
        public Employee CreatedByEmployee { get; private set; } = null!;

        public int CreatedByAccountId { get; private set; }
        public ApplicationUser CreatedByAccount { get; private set; } = null!;

        public DateTime? ApprovedAt { get; private set; }

        public int? ApprovedByEmployeeId { get; private set; }
        public Employee? ApprovedByEmployee { get; private set; }

        public int? ApprovedByAccountId { get; private set; }
        public ApplicationUser? ApprovedByAccount { get; private set; }

        public DateTime? SeparatedAt { get; private set; }

        public int? SeparatedByEmployeeId { get; private set; }
        public Employee? SeparatedByEmployee { get; private set; }

        public int? SeparatedByAccountId { get; private set; }
        public ApplicationUser? SeparatedByAccount { get; private set; }

        public DateTime? FinalizedAt { get; private set; }

        public int? FinalizedByEmployeeId { get; private set; }
        public Employee? FinalizedByEmployee { get; private set; }

        public int? FinalizedByAccountId { get; private set; }
        public ApplicationUser? FinalizedByAccount { get; private set; }

        public DateTime? CanceledAt { get; private set; }

        public int? CanceledByEmployeeId { get; private set; }
        public Employee? CanceledByEmployee { get; private set; }

        public int? CanceledByAccountId { get; private set; }
        public ApplicationUser? CanceledByAccount { get; private set; }

        public string? CancellationReason { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => _items;

        private Order() { }

        public Order(
            int facilityId,
            int employeeId,
            int accountId,
            string? observation = null)
        {
            if (facilityId <= 0)
                throw new DomainException("Unidade solicitante inválida.");

            if (employeeId <= 0)
                throw new DomainException("Funcionário inválido.");

            if (accountId <= 0)
                throw new DomainException("Conta inválida.");

            OrderFacilityId = facilityId;
            CreatedByEmployeeId = employeeId;
            CreatedByAccountId = accountId;

            OrderStatusId = (int)OrderStatusEnum.PendingApproval;

            Observation = observation?.Trim();

            CreatedAt = DateTime.UtcNow;
        }

        public void AddItem(OrderItem item)
        {
            ArgumentNullException.ThrowIfNull(item);

            _items.Add(item);

            SetUpdatedOn();
        }

        public void Approve(
            int employeeId,
            int accountId)
        {
            EnsureStatus(OrderStatusEnum.PendingApproval);

            if (!_items.Any())
                throw new DomainRuleException(
                    "Pedido deve possuir itens."
                );

            if (_items.All(x => x.ApprovedQuantity <= 0))
                throw new DomainRuleException(
                    "Pedido não possui itens aprovados."
                );

            OrderStatusId = (int)OrderStatusEnum.ReadyForPicking;

            ApprovedAt = DateTime.UtcNow;
            ApprovedByEmployeeId = employeeId;
            ApprovedByAccountId = accountId;

            SetUpdatedOn();
        }

        public void StartSeparation(
            int employeeId,
            int accountId)
        {
            EnsureStatus(OrderStatusEnum.ReadyForPicking);

            OrderStatusId = (int)OrderStatusEnum.PickingInProgress;

            SeparatedAt = DateTime.UtcNow;
            SeparatedByEmployeeId = employeeId;
            SeparatedByAccountId = accountId;

            SetUpdatedOn();
        }

        public void CompleteSeparation()
        {
            EnsureStatus(OrderStatusEnum.PickingInProgress);

            OrderStatusId =
                (int)OrderStatusEnum.ReadyForFinalization;

            SetUpdatedOn();
        }

        public void Finalize(
            int employeeId,
            int accountId)
        {
            EnsureStatus(OrderStatusEnum.ReadyForFinalization);

            if (!_items.Any())
            {
                throw new DomainRuleException("Pedido deve possuir itens.");
            }

            if (_items.All(x => x.ActualQuantity <= 0))
            {
                throw new DomainRuleException("Pedido não possui itens separados.");
            }

            foreach (var item in _items.Where(x => x.ActualQuantity > 0))
            {
                var allocatedQuantity =
                    item.OrderItemLots.Sum(x => x.Quantity);

                if (allocatedQuantity != item.ActualQuantity)
                {
                    throw new DomainRuleException($"Item {item.Id} possui divergência entre quantidade separada e lotes.");
                }
            }

            OrderStatusId = (int)OrderStatusEnum.Completed;

            FinalizedAt = DateTime.UtcNow;
            FinalizedByEmployeeId = employeeId;
            FinalizedByAccountId = accountId;

            SetUpdatedOn();
        }

        public void Cancel(
            string reason,
            int employeeId,
            int accountId)
        {
            if (OrderStatusId == (int)OrderStatusEnum.Completed)
            {
                throw new DomainRuleException("Pedido finalizado não pode ser cancelado.");
            }

            if (OrderStatusId == (int)OrderStatusEnum.ReadyForFinalization)
            {
                throw new DomainRuleException("Pedido aguardando finalização não pode ser cancelado.");
            }

            if (OrderStatusId == (int)OrderStatusEnum.Cancelled)
            {
                throw new DomainRuleException("Pedido já cancelado.");
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                throw new DomainException("Motivo do cancelamento é obrigatório.");
            }

            OrderStatusId = (int)OrderStatusEnum.Cancelled;

            CancellationReason = reason.Trim();

            CanceledAt = DateTime.UtcNow;

            CanceledByEmployeeId = employeeId;

            CanceledByAccountId = accountId;

            SetUpdatedOn();
        }

        private void EnsureStatus(OrderStatusEnum expectedStatus)
        {
            if (OrderStatusId != (int)expectedStatus)
            {
                throw new DomainRuleException(
                    $"Pedido deve estar com status '{expectedStatus}'."
                );
            }
        }
    }
}
