class Program
{
    static void Main(string[] args)
    {
        var interpreter = new Interpreter(args.Length > 0 ? new StreamReader(args[0]) : null);
        while (true)
        {
            try
            {
                string inputStr;
                if (interpreter.input != null)
                {
                    inputStr = interpreter.input.ReadLine();
                    if (inputStr == null)
                    {
                        break;
                    }
                }
                else
                {
                    Console.Write("> ");
                    inputStr = Console.ReadLine();
                }
                interpreter.ParseInput(inputStr);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
