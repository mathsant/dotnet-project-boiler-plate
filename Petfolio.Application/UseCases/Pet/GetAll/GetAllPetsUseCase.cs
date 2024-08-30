using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.GetAll;
public class GetAllPetsUseCase
{
    public ResponseAllPetsJson Execute()
    {
        return new ResponseAllPetsJson
        {
            Pets =
            [
                new ResponseShortPetJson { Id = 1, Name = "Marley", TypeEnum = Communication.Enums.PetTypeEnum.Dog },
                new ResponseShortPetJson { Id = 2, Name = "Bob", TypeEnum = Communication.Enums.PetTypeEnum.Cat },
            ]
        };
    }
}
