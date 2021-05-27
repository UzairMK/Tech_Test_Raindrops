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

Create tests that cover your expected range of inputs and outputs.

You will be assessed on the quality of your code, functional correctness, and your approach to quality assurance and testing.



## Outcome

### Function

Creating the function was very simple. I created a class library called `RaindropLib` and created a static `Raindrop` class inside it with one static function called `Input` shown below. The `Input` function takes a int32 as an input parameter and the function returns a string. 

In the function, an output string is initialised with an empty string. If the input number is divisible by 3, "Pling" is appended onto the output string. If the input number is divisible by 5, "Plang" is appended onto the output string. If the input number is divisible by 7, "Plong" is appended onto the output string. To find out if a number is divisible by another number, the modulo operator is used which will equal 0 if it is divisible.

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

I created a NUnit project in the same solution, to write and execute my tests. The aim of the tests was to make sure the created function was doing what I wanted it to do. I performed three sets of test which I will describe below.



#### General value tests

The aim of the tests in this set is to make sure the desired output is obtained when the input follows a certain rule.

##### Tests

- NotDivisibleBy3_5_Or7
- OnlyDivisibleBy3
- OnlyDivisibleBy5
- OnlyDivisibleBy7
- DivisibleBy3And5ButNot7
- DivisibleBy3And7ButNot5
- DivisibleBy5And7ButNot3
- DivisibleBy3_5And7

##### Example

```csharp
[TestCase(1, "1")]
[TestCase(-2, "-2")]
[TestCase(4, "4")]
[TestCase(-8, "-8")]
[TestCase(11, "11")]
public void NotDivisibleBy3_5_Or7(int input, string expected)
{
	string actual = Raindrop.Input(input);
	Assert.AreEqual(expected, actual);
}
```



#### Boundary value tests

The aim of the tests in this set is to make sure the function can handle the maximum and minimum value of the possible inputs.

##### Tests

- RespondsToInt32MaxValue
- RespondsToInt32MinValue

##### Example

```csharp
[Test]
public void RespondsToInt32MaxValue()
{
	string actual = Raindrop.Input(int.MaxValue);
	Assert.AreEqual("2147483647", actual);
}
```



#### Presence of string tests

The aim of the tests in this set is to make sure if a number is divisible by 3, 5 or 7, that the output string contains their associated text regardless of what other information might be in the string. It also makes sure that "Pling" and "Plang" are always next to each other if both are present and the same with "Plang" and "Plong".

##### Tests

- PlingPresentInAnyNumberDivisibleBy3
- PlangPresentInAnyNumberDivisibleBy5
- PlongPresentInAnyNumberDivisibleBy7
- PlingPlangPresentInAnyNumberDivisibleBy3And5
- PlangPlongPresentInAnyNumberDivisibleBy5And7

##### Example

```csharp
[TestCase(3)]
[TestCase(-15)]
[TestCase(21)]
[TestCase(-105)]
public void PlingPresentInAnyNumberDivisibleBy3(int input)
{
	string output = Raindrop.Input(input);
	Assert.IsTrue(output.Contains("Pling"));
}
```

