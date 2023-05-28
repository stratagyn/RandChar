# `RandChar`

A collection of methods for generating random characters and strings.

# Content

* [Character Categories](#character-categories)
  * [ASCII Categories](#ascii-categories)
  * [Supported Unicode Categories](#unicode-categories)
* [Methods](#methods)
  * [`Fill`](#ufillu)
  * [`FillUnique`](#ufilluniqueu)
  * [`GetCharacter`](#ugetcharacteru)
  * [`GetCharacters`](#ugetcharactersu)
  * [`GetUniqueCharacters`](#ugetuniquecharactersu)
  * [`GetString`](#ugetstringu)
  * [`GetUniqueString`](#ugetuniquestringu)


## Character Categories

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

Fills `chars` with random characters chosen from the set defined by `categories`.

```cs
void Fill(char[] chars, CharSet charSet)
```

<br>

Fills `chars` with `count` random characters starting from `at`.

```cs
void Fill(char[] chars, int at, int count)
```

<br>

Fills `chars` with `count` random characters chosen from the set defined by `categories` starting from `at`.

```cs
void Fill(char[] chars, int at, int count, CharSet charSet)
```

<br>

Fills `chars` with random characters.

```cs
void Fill(Span<char> chars)
```

<br>

Fills `chars` with random characters chosen from the set defined by `categories`.

```cs
void Fill(Span<char> chars, CharSet charSet)
```

<br>

Fills `chars` with `count` random characters starting from `at`.

```cs
void Fill(Span<char> chars, int at, int count)
```

<br>

Fills `chars` with `count` random characters chosen from the set defined by `categories` starting from `at`.

```cs
void Fill(Span<char> chars, int at, int cout, CharSet charSet)
```
---

### <u>`FillUnique`</u>

Fills `chars` with distinct random characters.

```cs
void FillUnique(char[] chars)
```

<br>

Fills `chars` with distinct random characters chosen from the set defined by `categories`.

```cs
void FillUnique(char[] chars, CharSet charSet)
```

<br>

Fills `chars` with `count` distinct random characters starting from `at`.

```cs
void FillUnique(char[] chars, int at, int count)
```

<br>

Fills `chars` with `count` distinct random characters chosen from the set defined by `categories` starting from `at`.

```cs
void FillUnique(char[] chars, int at, int count, CharSet charSet)
```

<br>

Fills `chars` with distinct random characters.

```cs
void FillUnique(Span<char> chars)
```

<br>

Fills `chars` with distinct random characters chosen from the set defined by `categories`.

```cs
void FillUnique(Span<char> chars, CharSet charSet)
```

<br>

Fills `chars` with `count` distinct random characters starting from `at`.

```cs
void FillUnique(Span<char> chars, int at, int count)
```

<br>

Fills `chars` with `count` distinct random characters chosen from the set defined by `categories` starting from `at`.

```cs
void FillUnique(Span<char> chars, int at, int cout, CharSet charSet)
```

---

### <u>`GetCharacter`</u>

Generates a random character

```cs
char GetCharacter()
```

<br>

Generates a random character chosen from the set defined by `categories`.

```cs
char GetCharacter(CharSet charSet)
```

---

### <u>`GetCharacters`</u>

Generates `count` random characters

```cs
char[] GetCharacters(int count)
```

<br>

Generates `count` random characters chosen from the set defined by `categories`.

```cs
char[] GetCharacters(int count, CharSet charSet)
```

---

### <u>`GetUniqueCharacters`</u>

Generates `count` distinct random characters

```cs
char[] GetUniqueCharacters(int count)
```

<br>

Generates `count` distinct random characters chosen from the set defined by `categories`.

```cs
char[] GetUniqueCharacters(int count, CharSet charSet)
```

---

### <u>`GetString`</u>

Generates a random string with `length` characters.

```cs
string GetString(int length)
```

<br>

Generates a random string with `length` characters chosen from the set defined by `categories`.

```cs
string GetString(int length, CharSet charSet)
```

---

### <u>`GetUniqueString`</u>

Generates a random string with `length` distinct characters.

```cs
string GetUniqueString(int length)
```

<br>

Generates a random string with `length` distinct characters chosen from the set defined by `categories`.

```cs
string GetUniqueString(int length, CharSet charSet)
```