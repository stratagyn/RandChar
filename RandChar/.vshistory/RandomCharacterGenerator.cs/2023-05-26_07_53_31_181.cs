using System.Security.Cryptography;

namespace RandomStringGenerator;

public class RandomCharacterGenerator
{
    private static readonly int SurrogateSpaceSize = 2048
    private readonly RandomNumberGenerator _rng;

    public RandomCharacterGenerator(RandomNumberGenerator? rng) => _rng = rng ?? RandomNumberGenerator.Create();

    public static char GetCharacter()
    {

    }
}