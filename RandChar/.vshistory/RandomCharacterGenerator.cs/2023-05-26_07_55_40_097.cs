using System.Security.Cryptography;

namespace RandomStringGenerator;

public class RandomCharacterGenerator
{
    private const int AdjustedCharacterMax = 0x10F7FF;
    private const int SurrogateSpaceSize = 0x0800;

    private readonly RandomNumberGenerator _rng;

    public RandomCharacterGenerator(RandomNumberGenerator? rng) => _rng = rng ?? RandomNumberGenerator.Create();

    public static char GetCharacter()
    {

    }
}