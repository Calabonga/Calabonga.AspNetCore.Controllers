using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Calabonga.AspNetCore.Controllers.Demo.Entities;
using Calabonga.AspNetCore.Controllers.Demo.ViewModels;
using Calabonga.AspNetCore.Controllers.Handlers;
using Calabonga.AspNetCore.Controllers.Queries;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;

namespace Calabonga.AspNetCore.Controllers.Demo.Controllers.Commands
{
    public class PersonPostItemQuery : PostItemQuery<Person, PersonViewModel, PersonCreateViewModel>
    {
        public PersonPostItemQuery(PersonCreateViewModel model) : base(model)
        {
        }
    }

    public class PersonPostItemCommand : PostItemHandlerBase<Person, PersonViewModel, PersonCreateViewModel>
    {
        public PersonPostItemCommand(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Fires when entity ready to Insert but some operations still need to do before saveChanges executed
        /// This is third step for Create pipeline
        /// OrderIndex 3
        /// </summary>
        /// <param name="step"></param>
        protected override Task<HandlerStep> OnCreateBeforeSaveChangesAsync(HandlerStep step)
        {
            var entity = (Person)step.Context.GetEntity();
            entity.Addresses = new List<Address>
            {
                new Address
                {
                    Name = $"NAME_{DateTime.Now.Ticks}",
                    Content = $"CONTENT_{DateTime.Now.Ticks}"
                }
            };
            step.Context.AddOrUpdateEntity(entity);
            return Task.FromResult(step);
        }

        /// <summary>
        /// Fires before entity validation executed on entity creation
        /// This is second step for Create pipeline
        /// OrderIndex 2
        /// </summary>
        /// <param name="step"></param>
        protected override async Task<HandlerStep> OnCreateBeforeAnyValidationsAsync(HandlerStep step)
        {
            var entity = (Person)step.Context.GetEntity();
            var personExists = await UnitOfWork.GetRepository<Person>().GetFirstOrDefaultAsync(predicate: x => x.LastName == entity.LastName &&
                                                                                                             x.FirstName == entity.FirstName);
            if (personExists != null)
            {
                step.StopWithError("Already Exists");
            }
            return step;
        }

        /// <summary>
        /// Wrapper for operation result post process manipulations
        /// </summary>
        /// <param name="step"></param>
        /// <param name="operationResult">
        /// </param>
        /// <returns></returns>
        protected override OperationResult<PersonViewModel> OperationResultBeforeReturn(HandlerStep step, OperationResult<PersonViewModel> operationResult)
        {
            operationResult.AppendLog("OperationResultBeforeReturn FIRED!");
            return base.OperationResultBeforeReturn(step, operationResult);
        }
    }
}
