using System.Threading.Tasks;

using AutoMapper;

using Calabonga.AspNetCore.Controllers.Demo.Entities;
using Calabonga.AspNetCore.Controllers.Demo.ViewModels;
using Calabonga.AspNetCore.Controllers.Handlers;
using Calabonga.AspNetCore.Controllers.Queries;
using Calabonga.AspNetCore.Controllers.UpdateSteps;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;

namespace Calabonga.AspNetCore.Controllers.Demo.Controllers.Commands
{

    public class PersonPutItemQuery : PutItemQuery<Person, PersonViewModel, PersonUpdateViewModel>
    {
        public PersonPutItemQuery(PersonUpdateViewModel model) : base(model)
        {
        }
    }


    public class PersonPuttItemCommand : PutItemHandlerBase<Person, PersonViewModel, PersonUpdateViewModel>
    {
        public PersonPuttItemCommand(IUnitOfWork unitOfWork, IMapper currentMapper)
            : base(unitOfWork, currentMapper)
        {
        }

        /// <summary>
        /// Wrapper for operation result post process manipulations
        /// </summary>
        /// <param name="step"></param>
        /// <param name="operationResult"></param>
        /// <returns></returns>
        public override OperationResult<PersonViewModel> OperationResultBeforeReturn(HandlerStep step, OperationResult<PersonViewModel> operationResult)
        {
            operationResult.AppendLog("OperationResultBeforeReturn FIRED!");
            if (operationResult.Ok)
            {
                operationResult.AddSuccess("Successfully updated");
            }
            return base.OperationResultBeforeReturn(step, operationResult);
        }

        /// <summary>
        /// Setting up user audit information for operation
        /// </summary>
        /// <param name="entity"></param>
        public override void SetAuditInformation(Person entity)
        {
            entity.FirstName += "_CA";
        }

        /// <summary>
        /// Fires after changes successfully saved
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public override Task<HandlerStep> OnUpdateAfterSaveChangesSuccessAsync(HandlerStep step)
        {
            var operation = (OperationResult<PersonViewModel>)step.Context.GetOperationResult();
            operation.AppendLog("OnUpdateAfterSaveChangesSuccessAsync");
            return base.OnUpdateAfterSaveChangesSuccessAsync(step);
        }

        /// <summary>
        /// Enable/Disable AutoHistory mechanism for update logging changes in special data table. Default: false
        /// </summary>
        public override bool IsAutoHistoryEnabled { get; } = false;

        /// <summary>
        /// Fires before entity validation executed on entity updating
        /// </summary>
        /// <param name="step"></param>
        public override async Task<HandlerStep> OnUpdateBeforeAnyValidationsAsync(HandlerStep step)
        {
            var entity = (Person)step.Context.GetEntity();
            var personExists = await UnitOfWork.GetRepository<Person>().GetFirstOrDefaultAsync(predicate:
                x => x.LastName == entity.LastName
                     && x.FirstName == entity.FirstName
                     && x.Id != entity.Id);

            if (personExists != null)
            {
                step.StopWithError("Already Exists");
            }
            return step;
        }

    }
}
