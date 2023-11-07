using EntityFramework7Reletionships.Models;

namespace EntityFramework7Reletionships.DTOs
{
    public record struct CharacterCreateDto(
        string Name, 
        BackPackCreateDto BackPack,
        List<WeponCreateDto> Wepons,
        List<FactionCreateDto> Fractions
        )
    {

    }
}
