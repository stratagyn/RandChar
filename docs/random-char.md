# `RandChar`

A collection of methods for generating random characters and strings.

# Content

* [Character Sets](#character-sets)
* [Methods](#methods)
  * [`Fill`](#ufillu)
  * [`FillUnique`](#ufilluniqueu)
  * [`GenerateCharacters`](#ugeneratecharactersu)
  * [`GenerateUniqueCharacters`](#ugenerateuniquecharactersu)
  * [`GenerateStrings`](#ugeneratestringsu)
  * [`GenerateUniqueStrings`](#ugenerateuniquestringsu)
  * [`GetCharacter`](#ugetcharacteru)
  * [`GetCharacters`](#ugetcharactersu)
  * [`GetUniqueCharacters`](#ugetuniquecharactersu)
  * [`GetString`](#ugetstringu)
  * [`GetUniqueString`](#ugetuniquestringu)


## Character Sets

Characters generated have a unicode value in the range **[0x0000, 0xD7FF]** or **[0xE000, 0x10FFFF]**. Generation can be restricted to subsets defined by the `CharSet` enum. `CharSet` constants can be combined to create mixed subsets.

For example, to generate the set of ASCII letters:

```cs
var charSet = CharSet.ASCIILowercaseLetter | CharSet.ASCIIUppercaseLetter
```


### `CharSet` Constants
* `ASCIILowercaseLetter`
* `ASCIINumber`
* `ASCIIPunctuation`
* `ASCIIUppercaseLetter`
* `Control`
* `Format`
* `LowercaseLetter`
* `ModifierLetter`
* `OtherLetter`
* `TitlecaseLetter`
* `UppercaseLetter`
* `SpacingCombiningMark`
* `EnclosingMark`
* `NonSpacingMark`
* `DecimalDigitNumber`
* `LetterNumber`
* `OtherNumber`
* `ConnectorPunctuation`
* `DashPunctuation`
* `ClosePunctuation`
* `FinalQuotePunctuation`
* `InitialQuotePunctuation`
* `OtherPunctuation`
* `OpenPunctuation`
* `CurrencySymbol`
* `ModifierSymbol`
* `MathSymbol`
* `OtherSymbol`
* `LineSeparator`
* `ParagraphSeparator`
* `SpaceSeparator`

## Methods

### <u>`Fill`</u>

Fills `chars` with random characters.

```cs
void Fill(char[] chars)
```

<br>

Fills `chars` with random characters chosen from the set defined by `charSet`.

```cs
void Fill(char[] chars, CharSet charSet)
```

<br>

Fills `chars` with random characters chosen from `charSet`.

```cs
void Fill(char[] chars, IList<char> charSet)
```

<br>

Fills `chars` with `count` random characters starting from `at`.

```cs
void Fill(char[] chars, int at, int count)
```

<br>

Fills `chars` with `count` random characters chosen from the set defined by `charSet` starting from `at`.

```cs
void Fill(char[] chars, int at, int count, CharSet charSet)
```

<br>

Fills `chars` with `count` random characters chosen from `charSet` starting from `at`.

```cs
void Fill(char[] chars, int at, int count, IList<char> charSet)
```

<br>

Fills `chars` with random characters.

```cs
void Fill(Span<char> chars)
```

<br>

Fills `chars` with random characters chosen from the set defined by `charSet`.

```cs
void Fill(Span<char> chars, CharSet charSet)
```

<br>

Fills `chars` with random characters chosen from `charSet`.

```cs
void Fill(Span<char> chars, IList<char> charSet)
```

<br>

Fills `chars` with `count` random characters starting from `at`.

```cs
void Fill(Span<char> chars, int at, int count)
```

<br>

Fills `chars` with `count` random characters chosen from the set defined by `charSet` starting from `at`.

```cs
void Fill(Span<char> chars, int at, int cout, CharSet charSet)
```

<br>

Fills `chars` with `count` random characters chosen from `charSet` starting from `at`.

```cs
void Fill(Span<char> chars, int at, int cout, IList<char> charSet)
```
---

### <u>`FillUnique`</u>

Fills `chars` with distinct random characters.

```cs
void FillUnique(char[] chars)
```

<br>

Fills `chars` with distinct random characters chosen from the set defined by `charSet`.

```cs
void FillUnique(char[] chars, CharSet charSet)
```

<br>

Fills `chars` with distinct random characters chosen from `charSet`.

```cs
void FillUnique(char[] chars, IList<char> charSet)
```

<br>

Fills `chars` with `count` distinct random characters starting from `at`.

```cs
void FillUnique(char[] chars, int at, int count)
```

<br>

Fills `chars` with `count` distinct random characters chosen from the set defined by `charSet` starting from `at`.

```cs
void FillUnique(char[] chars, int at, int count, CharSet charSet)
```

<br>

Fills `chars` with `count` distinct random characters chosen from `charSet` starting from `at`.

```cs
void FillUnique(char[] chars, int at, int count, IList<char> charSet)
```

<br>

Fills `chars` with distinct random characters.

```cs
void FillUnique(Span<char> chars)
```

<br>

Fills `chars` with distinct random characters chosen from the set defined by `charSet`.

```cs
void FillUnique(Span<char> chars, CharSet charSet)
```

<br>

Fills `chars` with distinct random characters chosen from `charSet`.

```cs
void FillUnique(Span<char> chars, IList<char> charSet)
```

<br>

Fills `chars` with `count` distinct random characters starting from `at`.

```cs
void FillUnique(Span<char> chars, int at, int count)
```

<br>

Fills `chars` with `count` distinct random characters chosen from the set defined by `charSet` starting from `at`.

```cs
void FillUnique(Span<char> chars, int at, int cout, CharSet charSet)
```

<br>

Fills `chars` with `count` distinct random characters chosen from `charSet` starting from `at`.

```cs
void FillUnique(Span<char> chars, int at, int cout, IList<char> charSet)
```

---

### <u>`GenerateCharacters`</u>

Generates `count` random characters. If `count` is negative,
generation continues infinitely.

```cs
IEnumerable<char> GenerateCharacters(int count = -1)
```

<br>

Generates `count` random characters chosen from the set defined by `charSet`.
If `count` is negative, generation continues infinitely.

```cs
IEnumerable<char> GenerateCharacters(CharSet charSet, int count = -1)
```

<br>

Generates `count` random characters chosen from `charSet`.
If `count` is negative, generation continues infinitely.

```cs
IEnumerable<char> GenerateCharacters(IList<char> charSet, int count = -1)
```

---

### <u>`GenerateUniqueCharacters`</u>

Generates `count` distinct random characters. If `count` is negative, generation 
continues until all possible characters have been generated.

```cs
IEnumerable<char> GenerateUniqueCharacters(int count = -1)
```

<br>

Generates `count` random characters chosen from the set  defined by `charSet`. 
If `count` is negative, generation continues until all possible characters have 
been generated.

```cs
IEnumerable<char> GenerateUniqueCharacters(CharSet charSet, int count = -1)
```

<br>

Generates `count` random characters chosen from `charSet`. 
If `count` is negative, generation continues until all possible characters have 
been generated.

```cs
IEnumerable<char> GenerateUniqueCharacters(IList<char> charSet, int count = -1)
```

---

### <u>`GenerateStrings`</u>

Generates `count` distinct strings with `length` random characters. If `count` 
is negative, generation continues infinitely.

```cs
char[] GenerateStrings(int length, int count = -1)
```

<br>

Generates `count` strings with `length` random characters chosen from the set defined by `charSet`.
If `count` is negative, generation continues infinitely.

```cs
char[] GenerateStrings(int length, CharSet charSet, int count = -1)
```

<br>

Generates `count` strings with `length` random characters chosen from `charSet`.
If `count` is negative, generation continues infinitely.

```cs
char[] GenerateStrings(int length, IList<char> charSet, int count = -1)
```

---

### <u>`GenerateUniqueStrings`</u>

Generates `count` distinct strings with `length` distinct random characters. 
If `count` is negative, generation continues until all possible characters have 
been generated.

```cs
IEnumerable<char> GenerateUniqueStrings(int length, int count = -1)
```

<br>

Generates `count` distinct strings with `length` random characters chosen from the set 
defined by `charSet`. If `count` is negative, generation continues until all possible 
characters have been generated.

```cs
IEnumerable<char> GenerateUniqueStrings(int length, CharSet charSet, int count = -1)
```

<br>

Generates `count` distinct strings with `length` random characters chosen from `charSet`. If `count` is negative, generation continues until all possible 
characters have been generated.

```cs
IEnumerable<char> GenerateUniqueStrings(int length, IList<char> charSet, int count = -1)
```

---

### <u>`GetCharacter`</u>

Generates a random character

```cs
char GetCharacter()
```

<br>

Generates a random character chosen from the set defined by `charSet`.

```cs
char GetCharacter(CharSet charSet)
```

<br>

Generates a random character chosen from `charSet`.

```cs
char GetCharacter(IList<char> charSet)
```

---

### <u>`GetCharacters`</u>

Generates `count` random characters

```cs
char[] GetCharacters(int count)
```

<br>

Generates `count` random characters chosen from the set defined by `charSet`.

```cs
char[] GetCharacters(int count, CharSet charSet)
```

<br>

Generates `count` random characters chosen from `charSet`.

```cs
char[] GetCharacters(int count, IList<char> charSet)
```

---

### <u>`GetUniqueCharacters`</u>

Generates `count` distinct random characters

```cs
char[] GetUniqueCharacters(int count)
```

<br>

Generates `count` distinct random characters chosen from the set defined by `charSet`.

```cs
char[] GetUniqueCharacters(int count, CharSet charSet)
```

<br>

Generates `count` distinct random characters chosen from `charSet`.

```cs
char[] GetUniqueCharacters(int count, IList<char> charSet)
```

---

### <u>`GetString`</u>

Generates a random string with `length` characters.

```cs
string GetString(int length)
```

<br>

Generates a random string with `length` characters chosen from the set defined by `charSet`.

```cs
string GetString(int length, CharSet charSet)
```

<br>

Generates a random string with `length` characters chosen from `charSet`.

```cs
string GetString(int length, IList<char> charSet)
```

---

### <u>`GetUniqueString`</u>

Generates a random string with `length` distinct characters.

```cs
string GetUniqueString(int length)
```

<br>

Generates a random string with `length` distinct characters chosen from the set defined by `charSet`.

```cs
string GetUniqueString(int length, CharSet charSet)
```

<br>

Generates a random string with `length` distinct characters chosen from `charSet`.

```cs
string GetUniqueString(int length, IList<char> charSet)
```