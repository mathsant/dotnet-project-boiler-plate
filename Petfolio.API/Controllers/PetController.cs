using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pet.Delete;
using Petfolio.Application.UseCases.Pet.GetAll;
using Petfolio.Application.UseCases.Pet.GetById;
using Petfolio.Application.UseCases.Pet.Register;
using Petfolio.Application.UseCases.Pet.Update;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof (ResponseRegisterPetJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof (ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestPetJson request)
    {
        var response = new RegisterPetUseCase().Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestPetJson request)
    {
        var useCase = new UpdatePetUseCase();
        useCase.Execute(id, request);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseAllPetsJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllPetsUseCase();
        var response = useCase.Execute();

        if (response.Pets.Count != 0)
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] int id)
    {
        var response = new GetPetByIdUseCase().Execute(id);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] int id)
    {
        var useCase = new DeletePetByIdUseCase();
        useCase.Execute(id);

        return NoContent();
    }
}
