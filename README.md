# `RandChar`
.NET library for generating random text.

* Installed using NuGet

```
dotnet add package RandChar
```

* [Documentation](https://github.com/stratagyn/RandChar/blob/master/docs/random-char.md)

```cs
using RandChar;

//Printable ASCII without space
var passwordCharacters = 
    CharSet.ASCIILowercaseLetter 
    | CharSet.ASCIIUppercaseLetter 
    | CharSet.ASCIINumber 
    | CharSet.ASCIIPunctuation;

//Generates a password with 10 distinct password characters
var password = RandomCharGenerator.GetUniqueString(10, passwordCharacters);

//Generates 10 passwords, each with 10 distinct password characters
var passwords = RandomCharGenerator.GenerateUniqueStrings(10, passwordCharacters, 10)
```



