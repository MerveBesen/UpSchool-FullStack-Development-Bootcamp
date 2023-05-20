
using PasswordGenerator.Console;

int again = 1;
int question = 1;

switch (again)
{
    case 1:
        switch (question)

        {
            case 1:
                Console.WriteLine($"{Questions.IncludeNumbers}");

                string number = Console.ReadLine().ToLower();
                switch (number)
                {
                    case "y":
                        Data.Characters += Data.Numbers;
                        question += 1;
                        break;


                    case "n":
                        Console.WriteLine("Ok. You wish :)");
                        question += 1;
                        break;
                    default:
                        return;
                }

                break;

                
            case 2:

                Console.WriteLine($"{Questions.IncludeLowercaseCharacters}");

                string lower = Console.ReadLine().ToLower();
                switch (lower)
                {
                    case "y":
                        Data.Characters += Data.LowercaseCharacters;
                        question += 1;
                        break;

                    case "n":
                        Console.WriteLine("Ok. You wish :)");
                        question += 1;
                        break;
                    default:
                        return;
                }

                break;
            case 3:
                Console.WriteLine($"{Questions.IncludeSpecialCharacters}");

                string special = Console.ReadLine().ToLower();

                switch (special)
                {
                    case "y":
                        Data.Characters += Data.SpecialCharacters;
                        question += 1;
                        break;

                    case "n":
                        Console.WriteLine("Ok. You wish :)");
                        question += 1;
                        break;
                    default:
                        return;

                }

                break;
            case 4:
                Console.WriteLine($"{Questions.IncludeUppercaseCharacters}");

                string upper = Console.ReadLine().ToLower();

                switch (upper)
                {
                    case "y":
                        Data.Characters += Data.UppercaseCharacters;
                        break;

                    case "n":
                        Console.WriteLine("Ok. You wish :)");
                        break;
                    default:
                        return;
                }

                break;

        }

        
        break;
    case 2:
        break;
}


for (int i = 0; i < 4; i++)
{
    
    
    
    question += 1;
}


if (Data.Characters.Length==0)
{
    again = 1;
    Console.WriteLine("You said all questions no. Please try again");
    
}
else
{
    again = 2;
    Console.WriteLine($"{Questions.PasswordLenght}");
    Data.Lenght = Console.ReadLine();
    Generator.PasswordGenerate();
    Console.WriteLine(Data.Password);
}





