using Loans.Application.UseCases.GetInstallmentsByLoandId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loans.WebAPI.Controllers
{
    [Route("api/loans/{loanId:int}/installments")]
    [ApiController]
    public class InstallmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstallmentController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult<GetInstallmentsByLoanIdResponse>> GetByLoanId(
            [FromRoute] int loanId,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var response = await _mediator.Send(new GetInstallmentsByLoanIdRequest { LoanId = loanId }, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
