public record CentreProgrammeDTO(int? Id, string? Libelle, IEnumerable<ProgrammeDTO>? Programmes)
{
    public static implicit operator CentreProgrammeDTO(Helios.Context.Models.Centre? c) => new(
       Id: c?.Id,
       Libelle: c?.Libelle,
       Programmes: c?.Programmes?.Select(p =>
       {
           p.Centres = null!;
           return (ProgrammeDTO)p!;
       })!);
       
}
