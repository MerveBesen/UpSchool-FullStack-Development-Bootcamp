namespace PasswordGenerator.Console;

public class Generator
{
    public static void PasswordGenerate()
    {
        for (int i = 0; i < Convert.ToInt32(Data.Lenght) ; i++)
        {
            Random random = new Random();
            int sayi = random.Next(Data.Characters.Length);
            Data.Password += Data.Characters[sayi];
        }
        
        
    }
}