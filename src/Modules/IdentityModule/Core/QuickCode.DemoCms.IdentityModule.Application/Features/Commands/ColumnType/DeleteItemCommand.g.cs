using System;
using System.Linq;
using QuickCode.DemoCms.Common.Mediator;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.IdentityModule.Domain.Entities;
using QuickCode.DemoCms.IdentityModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.IdentityModule.Application.Dtos.ColumnType;
using QuickCode.DemoCms.IdentityModule.Domain.Enums;

namespace QuickCode.DemoCms.IdentityModule.Application.Features.ColumnType
{
    public class DeleteItemColumnTypeCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }

        public DeleteItemColumnTypeCommand(int id)
        {
            this.Id = id;
        }

        public class DeleteItemColumnTypeHandler : IRequestHandler<DeleteItemColumnTypeCommand, Response<bool>>
        {
            private readonly ILogger<DeleteItemColumnTypeHandler> _logger;
            private readonly IColumnTypeRepository _repository;
            public DeleteItemColumnTypeHandler(ILogger<DeleteItemColumnTypeHandler> logger, IColumnTypeRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteItemColumnTypeCommand request, CancellationToken cancellationToken)
            {
                var deleteItem = await _repository.GetByPkAsync(request.Id);
                if (deleteItem.Code == 404)
                    return Response<bool>.NotFound();
                var returnValue = await _repository.DeleteAsync(deleteItem.Value);
                return returnValue.ToResponse();
            }
        }
    }
}