using System;
using AutoMapper;

using Calabonga.AspNetCore.Controllers.Demo.Entities;
using Calabonga.AspNetCore.Controllers.Demo.ViewModels;
using Calabonga.AspNetCore.Controllers.Handlers;
using Calabonga.AspNetCore.Controllers.Queries;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;

namespace Calabonga.AspNetCore.Controllers.Demo.Controllers.Commands
{
    public class PersonDeleteItemQuery : DeleteByIdQuery<Person, PersonViewModel>
    {
        public PersonDeleteItemQuery(Guid id) : base(id)
        {
        }
    }

    public class PersonDeleteItemHandler : DeleteByIdHandlerBase<Person, PersonViewModel>
    {
        public PersonDeleteItemHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override OperationResult<PersonViewModel> OperationResultBeforeReturn(OperationResult<PersonViewModel> operationResult)
        {
            operationResult.AppendLog("OperationResultBeforeReturn FIRED!");
            return base.OperationResultBeforeReturn(operationResult);
        }
    }
}
