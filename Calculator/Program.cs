Console.WriteLine("Hello!");
Console.WriteLine("Input the first number");
int firstNumber = int.Parse(Console.ReadLine());
Console.WriteLine("Input the second number");
int secondNumber = int.Parse(Console.ReadLine());
Console.WriteLine("What do you want to do with those numbers?");
Console.WriteLine("[A]dd");
Console.WriteLine("[S]ubtract");
Console.WriteLine("[M]ultiply");
string operation = Console.ReadLine().ToLower();


if (operation == "a")
{
    Console.WriteLine(firstNumber + " + " +  secondNumber + " = " + (firstNumber + secondNumber));
} else if (operation == "s")
{
    Console.WriteLine(firstNumber + " - " + secondNumber + " = " + (firstNumber - secondNumber));
} else if (operation == "m")
{
    Console.WriteLine(firstNumber + " * " + secondNumber + " = " + (firstNumber * secondNumber));
} else
{
    Console.WriteLine("Invalid Option");
}

Console.WriteLine("Press any key to close");
Console.ReadKey();