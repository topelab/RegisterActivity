using System;

Console.WriteLine("Register activities\nPress <Esc> to exit");
bool exit = false;
while (!exit)
{
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.Escape)
    {
        exit = true;
    }
}
