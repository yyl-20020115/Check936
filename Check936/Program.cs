if (args.Length == 0)
{
    Console.WriteLine("Usage: Check936 [file]");
}
else if (!File.Exists(args[0]))
{
    Console.WriteLine($"File {args[0]} does not exist!");
}
else
{
    using var reader = new StreamReader(args[0]);
    var text = "";
    var line = 0;
    var column = 0;
    var a1 = '\0';
    var a2 = '\xff';
    var c1 = '\ua1a1';
    var c2 = '\u7e7e';
    while ((text = reader.ReadLine()) != null)
    {
        line++;
        column = 0;
        for (var i = 0; i < text.Length; i++)
        {
            column++;
            var c = text[i];
            if (c >= a1 && c <= a2 || a2 >= c1 && a2 <= c2)
            {
                //this is common char
            }
            else
            {
                //this char is out of GB2312(CP936)
                Console.WriteLine($"Found char ({c}) which is not within CP936 at line {line}, column {column}");
            }
        }
    }
}