class Interpreter
{
    private readonly StreamReader _input;

    public StreamReader Input => _input;

    private readonly Dictionary<string, int> _registers = new Dictionary<string, int>();

    public Interpreter(StreamReader input)
    {
        _input = input;
    }

    public void Add(string register, int value)
    {
        if (_registers.ContainsKey(register))
        {
            _registers[register] += value;
        }
        else
        {
            _registers.Add(register, value);
        }
    }

    public void Subtract(string register, int value)
    {
        if (_registers.ContainsKey(register))
        {
            _registers[register] -= value;
        }
        else
        {
            _registers.Add(register, -value);
        }
    }

    public void Multiply(string register, int value)
    {
        if (_registers.ContainsKey(register))
        {
            _registers[register] *= value;
        }
        else
        {
            _registers.Add(register, value);
        }
    }

    public int Evaluate(string value)
    {
        if (int.TryParse(value, out int intValue))
        {
            return intValue;
        }
        else if (_registers.TryGetValue(value, out int registerValue))
        {
            return registerValue;
        }
        else
        {
            return 0;
        }
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
                    System.Console.WriteLine($"Invalid operation: {operation}");
                    break;
            }
        }
        else if (tokens.Length == 2)
        {
            if (tokens[0].ToLower() == "print")
            {
                string register = tokens[1].ToLower();
                System.Console.WriteLine(_registers.ContainsKey(register) ? _registers[register] : 0);
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
