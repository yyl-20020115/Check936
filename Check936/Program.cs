const char a1 = '\0';
const char a2 = '\xff';
const char c1 = '\ua1a1';
const char c2 = '\u7e7e';

if (args.Length == 0)
{
    Console.WriteLine("Usage: Check936 [file] ... ");
}
else
{
    for (int i = 0; i < args.Length; i++)
    {
        var file = args[i];
        if (!File.Exists(file))
        {
            Console.WriteLine($"File {file} does not exist!");
        }
        else
        {
            Console.WriteLine($"Check {file} ...");
            using (var reader = new StreamReader(file))
            {
                var text = "";
                var line = 0;
                var column = 0;
                while ((text = reader.ReadLine()) != null)
                {
                    line++;
                    column = 0;
                    for (var p = 0; p < text.Length; p++)
                    {
                        column++;
                        var c = text[p];
                        if (c >= a1 && c <= a2 || a2 >= c1 && a2 <= c2)
                        {
                            //this is common char
                        }
                        else
                        {
                            //this char is out of GB2312(CP936)
                            Console.WriteLine($"Found char ('{c}':{(int)c:X4}) which is not within CP936 at line {line}, column {column}");

                        }
                    }
                }
            }
        }
    }
}
