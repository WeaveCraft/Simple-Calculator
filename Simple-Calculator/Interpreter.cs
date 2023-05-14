class Interpreter
{
    public StreamReader input;

    private readonly Dictionary<string, int> registers = new Dictionary<string, int>();

    public Interpreter(StreamReader input)
    {
        this.input = input;
    }

    public void Add(string register, int value)
    {
        registers.TryGetValue(register, out int registerValue);
        registers[register] = registerValue + value;
    }

    public void Subtract(string register, int value)
    {
        registers.TryGetValue(register, out int registerValue);
        registers[register] = registerValue - value;
    }

    public void Multiply(string register, int value)
    {
        registers.TryGetValue(register, out int registerValue);
        registers[register] = registerValue * value;
    }

    public int Evaluate(string value)
    {
        return int.TryParse(value, out int intValue) ? intValue : registers.TryGetValue(value, out int registerValue) ? registerValue : 0;
    }

    public void ParseInput(string inputStr)
    {
        string[] tokens = inputStr.Trim().Split();
        if (tokens.Length == 3)
        {
            string register = tokens[0].ToLower();
            string operation = tokens[1].ToLower();
            int value = Evaluate(tokens[2]);
            switch (operation)
            {
                case "add":
                    Add(register, value);
                    break;
                case "subtract":
                    Subtract(register, value);
                    break;
                case "multiply":
                    Multiply(register, value);
                    break;
                default:
                    Console.Error.WriteLine($"Invalid operation: {operation}");
                    break;
            }
        }
        else if (tokens.Length == 2)
        {
            if (tokens[0].ToLower() == "print")
            {
                string register = tokens[1].ToLower();
                System.Console.WriteLine(registers.ContainsKey(register) ? registers[register] : 0);
            }
            else
            {
                System.Console.WriteLine($"Invalid command: {inputStr}");
            }
        }
        else if (tokens.Length == 1 && tokens[0].ToLower() == "quit")
        {
            System.Environment.Exit(0);
        }
        else
        {
            System.Console.WriteLine($"Invalid input: {inputStr}");
        }
    }
}
