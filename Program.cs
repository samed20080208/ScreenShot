using System.Diagnostics;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Text.Encodings.Web;


string imagesFolderPath = $"C:\\Users\\{Environment.UserName}\\Desktop\\Images";
List<string> filenames = new List<string>();

string[] allSSnames = Directory.GetFiles(imagesFolderPath);

for (int i = 0; i < allSSnames.Length; i++)
{

    filenames.Add(allSSnames[i]);
}

if (!Directory.Exists(imagesFolderPath))
{
    Directory.CreateDirectory(imagesFolderPath);
}

dynamic key;
while (true)
{
    Console.Clear();
    Console.Write("\n\n\n\n\n\n\n\n\n\n");
    Console.Write("\t\t\t");
    Console.Write("Press enter take a screenshot and press Tab for list of all screen shots: ");
    key = Console.ReadKey();

    if (key.Key == ConsoleKey.Enter)
    {
        using Bitmap screenshot = new(1920, 1080);

        using Graphics graphics = Graphics.FromImage(screenshot);

        graphics.CopyFromScreen(0, 0, 0, 0, new Size(1920, 1080));

        string saved_path = $"{imagesFolderPath}\\Screenshot {filenames.Count + 1}.png";
        screenshot.Save(saved_path);
        filenames.Add(saved_path);
    }

    else if (key.Key == ConsoleKey.Tab)
    {
        Console.Clear();
        int index = 0;
        int index_input;
        foreach (var item in filenames)
        {
            Console.WriteLine($"{index}){item}");
            index++;
        }

        Console.WriteLine("press any key for going back");
        Console.ReadKey();
    }

    else if (key.Key == ConsoleKey.Escape)
    {
        break;
    }
}


