using Asp.Versioning;
using Contract.Abstraction.Shared;
using Contract.DTOs.RoleDTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstractions;
using static Contract.Service.Role.Command;

namespace Presentation.Controller
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/Test")]
    public class RoleController : APIController
    {
        protected RoleController(ISender sender) : base(sender){}

        [HttpPost()]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDTO CreateRoleDTO)
        {
            var command = new CreateRole(CreateRoleDTO);
            Result response = await Sender.Send(command);
            if (response.IsFailure) HandleFailure(response);
            return Ok(response);
        }

        [HttpPut("/{Role_id}")]
        public async Task<IActionResult> UpdateRole(Guid Role_id, [FromBody] UpdateRoleDTO UpdateRoleDTO)
        {
            var command = new UpdateRole(Role_id, UpdateRoleDTO);
            Result response = await Sender.Send(command);
            if (response.IsFailure) HandleFailure(response);
            return Ok(response);
        }

    }
}
