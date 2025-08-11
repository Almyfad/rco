using Helios.Context.Models;

public record CentreOutput(int Id)
{
    public static explicit operator CentreOutput(Centre c) => new(c.Id);
}
