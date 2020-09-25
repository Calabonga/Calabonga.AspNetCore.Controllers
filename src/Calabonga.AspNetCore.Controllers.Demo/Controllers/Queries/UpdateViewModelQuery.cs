using System;

using AutoMapper;

using Calabonga.AspNetCore.Controllers.Demo.Entities;
using Calabonga.AspNetCore.Controllers.Demo.ViewModels;
using Calabonga.AspNetCore.Controllers.Handlers;
using Calabonga.AspNetCore.Controllers.Queries;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;

namespace Calabonga.AspNetCore.Controllers.Demo.Controllers.Queries
{
    public class PersonUpdateViewModelQuery : UpdateViewModelQuery<PersonUpdateViewModel>
    {
        public PersonUpdateViewModelQuery(Guid id) : base(id)
        {
        }
    }

    public class PersonUpdateViewModelHandler : UpdateViewModelHandlerBase<PersonUpdateViewModelQuery, Person, PersonUpdateViewModel>
    {
        public PersonUpdateViewModelHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Process operation result
        /// </summary>
        /// <param name="operationResult"></param>
        /// <returns></returns>
        protected override OperationResult<PersonUpdateViewModel> OperationResultBeforeReturn(OperationResult<PersonUpdateViewModel> operationResult)
        {
            operationResult.AppendLog("OperationResultBeforeReturn FIRED!");
            return base.OperationResultBeforeReturn(operationResult);
        }
    }

}
