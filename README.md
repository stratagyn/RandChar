# `RandChar`
.NET library for generating random text.

* Installed using NuGet

```
dotnet addpackage RandChar
```

* [Documentation](https://github.com/stratagyn/RandChar/blob/master/docs/random-char.md)

<br>

```cs
using RandChar;

//Printable ASCII without space
var passwordCharacters = 
    CharSet.ASCIILowercaseLetter 
    | CharSet.ASCIIUppercaseLetter 
    | CharSet.ASCIINumber 
    | CharSet.ASCIIPunctuation;

//Generates a password with 10 distinct password characters
var password = RandChar.GetUniqueString(10, passwordCharacters);

//Generates 10 distinct passwords with 10 distinct password characters
var passwords = RandChar.GenerateUniqueStrings(10, passwordCharacters, 10)
```



