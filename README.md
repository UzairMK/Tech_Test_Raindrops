# Tech Test: Raindrops

## Objective
Write a function that takes as its input a number (n) and converts it to a string, the contents of which depend on the numbers factors

- if the number has a factor of 3, output 'Pling'
- if the number has a factor of 5, output 'Plang'
- if the number has a factor of 7, output 'Plong'
- if the number does not have any of the above as a factor simply return the numbers digits

Examples
- 28's factors are 1, 2, 4, 7, 14 and 28: this would be a simple 'Plong'
- 30's factors are 1, 2, 3, 5, 6, 10, 15, 30: this would be a 'PlingPlang'
- 34 has four factors: 1, 2, 17, and 34: this would be '34'

Also create tests that cover the expected range of inputs and outputs.



## Outcome

### Function

Creating the function was very simple. I created a class library called `RaindropLib` and created a static `Raindrop` class inside it with one static function called `Input` shown below. The `Input` function takes a int32 as an input parameter and returns a string. 

In the function, an output string is initialised with an empty string. I know a number is a factor of another number if it is divisible by the number. If the input number is divisible by 3 (meaning 3 is a factor), "Pling" is appended onto the output string. If the input number is divisible by 5 (meaning 5 is a factor), "Plang" is appended onto the output string. If the input number is divisible by 7 (meaning 7 is a factor), "Plong" is appended onto the output string. To find out if a number is divisible by another number, the modulo operator is used which will equal 0 if it is divisible.

At the end of the function, if the output string is still an empty string, then this means the input number was not divisible by 3, 5 or 7 and the function should return the input number as a string as specified in the objective. If the output string is not an empty string, that means the input number was divisible by 3, 5 or 7 and the function will return the output string.

```csharp
public static string Input(int number)
{
	string output = "";
	if (number % 3 == 0)
		output += "Pling";
	if (number % 5 == 0)
		output += "Plang";
	if (number % 7 == 0)
		output += "Plong";
	if (output == "")
		return number.ToString();
	else
		return output;
}
```



### Tests

I created a NUnit project in the same solution, to write and execute my tests. This project was made dependent to the `RaindropLib` class library to gain access to the `Raindrop` class and the project also contained the following NuGet packages: Microsoft.NET.Test.Sdk, NUnit, and NUnit3TestAdapter. The aim of the tests was to make sure the created function was doing what I wanted it to do. I performed three sets of tests which I will describe below and all the tests were design to be DAMP (Descriptive And Meaningful Phrases) so they could easily be understood by anyone.



#### General tests

The aim of the tests in this set is to make sure the desired output is obtained when the input follows a certain rule.

##### Tests

- NotDivisibleBy3_5_Or7_ReturnsNumberAsString
- DivisibleBy3ButNotBy5And7_ReturnsPling
- DivisibleBy5ButNotBy3And7_ReturnsPlang
- DivisibleBy7ButNotBy3And5_ReturnsPlong
- DivisibleBy3And5ButNot7_ReturnsPlingPlang
- DivisibleBy3And7ButNot5_ReturnsPlingPlong
- DivisibleBy5And7ButNot3_ReturnsPlangPlong
- DivisibleBy3_5And7_ReturnsPlingPlangPlong

##### Example

```csharp
[TestCase(1, "1")]
[TestCase(-2, "-2")]
[TestCase(4, "4")]
[TestCase(-8, "-8")]
[TestCase(11, "11")]
public void NotDivisibleBy3_5_Or7_ReturnsNumberAsString(int input, string expected)
{
	string actual = Raindrop.Input(input);
	Assert.That(expected, Is.EqualTo(actual));
}
```



#### Boundary value tests

The aim of the tests in this set is to make sure the function can handle the maximum and minimum value of the input. The maximum and minimum values of int32 are not divisible by 3, 5 or 7, so the function should return the number as a string.

##### Tests

- RespondsToInt32MaxValue_ReturnsInt32MaxValueAsString
- RespondsToInt32MinValue_ReturnsInt32MinValueAsString

##### Example

```csharp
[Test]
public void RespondsToInt32MaxValue_ReturnsInt32MaxValueAsString()
{
	string actual = Raindrop.Input(int.MaxValue);
	Assert.That("2147483647", Is.EqualTo(actual));
}
```



#### Presence of text tests

The aim of the tests in this set is to make sure if a number is divisible by 3, 5 or 7, that the output string contains their associated text regardless of what other information might be in the string. It also makes sure that "Pling" and "Plang" are always next to each other if both are present and the same with "Plang" and "Plong".

##### Tests

- PlingPresentInAnyNumberDivisibleBy3_ReturnedStringContainsPling
- PlangPresentInAnyNumberDivisibleBy5_ReturnedStringContainsPlang
- PlongPresentInAnyNumberDivisibleBy7_ReturnedStringContainsPlong
- PlingPlangPresentInAnyNumberDivisibleBy3And5_ReturnedStringContainsPlingPlang
- PlangPlongPresentInAnyNumberDivisibleBy5And7_ReturnedStringContainsPlangPlong

##### Example

```csharp
[TestCase(3)]
[TestCase(-15)]
[TestCase(21)]
[TestCase(-105)]
public void PlingPresentInAnyNumberDivisibleBy3_ReturnedStringContainsPling(int input)
{
	string output = Raindrop.Input(input);
	Assert.That(output.Contains("Pling"), Is.True);
}
```

