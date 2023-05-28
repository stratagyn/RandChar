# RandChar
.NET library for generating random text.

```cs
using RandChar;

var asciiAlphaNum = CharSet.ASCIILowercaseLetter | CharSet.ASCIIUppercaseLetter | CharSet.ASCIINumber;

var passwordCharacters = asciiAlphaNum | CharSet.ASCIIPunctuation;

var password = RandChar.GetUniqueString(10, passwordCharacters);

foreach (var c in RandChar.GenerateCharacters(asciiAlphaNum, 10))
    Console.Write(c);
```

## Installation

`RandChar` is installed using NuGet

```
dotnet addpackage RandChar
```

