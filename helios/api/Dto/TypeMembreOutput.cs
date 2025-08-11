using Helios.Context.Models;

public record TypeMembreOutput(int Id)
{
    public static explicit operator TypeMembreOutput(TypeMembre t) => new(t.Id);
}