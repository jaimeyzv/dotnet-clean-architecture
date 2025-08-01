﻿using GWL.Application.UseCases.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GWL.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(
            CreateUserRequest request,
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
    }
}
