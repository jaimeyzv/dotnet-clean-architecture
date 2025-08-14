using Loans.Application.UseCases.CreateLoan;
using Loans.Application.UseCases.GetAllLoans;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loans.WebAPI.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateLoanResponse>> Create(
            [FromBody] CreateLoanRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<ActionResult<GetAllLoansResponse>> GetByLoanId(CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(new GetAllLoansRequest(), cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
