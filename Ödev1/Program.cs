// See https://aka.ms/new-console-template for more information

using PasswordGenerator.Console;

Questions questions = new Questions();

Console.WriteLine($"{questions.IncludeNumbers}");
string Characters = string.Empty;

string answer = Console.ReadLine();

switch (answer)
{
    case "y":
        
      
    case "n" :
        Console.WriteLine("Ok. You wish :)");
        break;
    
    
    default:
    // return Question
        throw new Exception("You need to write y/n");
    
}

Console.WriteLine(answer);
