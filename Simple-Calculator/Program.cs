class Program
{
    static Dictionary<string, List<Tuple<string, string>>> registerDict = new();

    static int LazyEvaluate(List<Tuple<string, string>> operationList, int registerValue = 0)
    {
        if (operationList.Count == 0)
        {
            return registerValue;
        }
        var operationSet = operationList.First();
        var operationListRest = operationList.Skip(1).ToList();
        return LazyEvaluate(operationListRest, ParseInput(registerValue, operationSet));
    }

    static int ParseInput(int registerValue, Tuple<string, string> operationSet)
    {
        var register = operationSet.Item1;
        var operation = operationSet.Item2;
        if (!int.TryParse(operation, out int argumentValue))
        {
            argumentValue = LazyEvaluate(registerDict[operation]);
        }

        switch (register)
        {
            case "add":
                return registerValue + argumentValue;
            case "subtract":
                return registerValue - argumentValue;
            case "multiply":
                return registerValue * argumentValue; 
            default:
                Console.Error.WriteLine($"WARN: Invalid operation {operationSet}");
                return registerValue;
        }
    }

    static void Main()
    {
        var userInput = Console.ReadLine()?.ToLower().Trim();

        while (userInput != "quit")
        {
            var argsList = userInput?.Split().ToList();

            if (argsList?.Count == 2 && argsList[0] == "print" && registerDict.ContainsKey(argsList[1]))
            {
                var registerName = argsList[1];
                Console.WriteLine(LazyEvaluate(registerDict[registerName]));
            }
            else if (argsList?.Count == 3)
            {
                var registerName = argsList[0];
                var operationSet = Tuple.Create(argsList[1], argsList[2]);

                if (!registerDict.ContainsKey(registerName))
                {
                    registerDict[registerName] = new List<Tuple<string, string>>();
                }
                registerDict[registerName].Add(operationSet);
            }
            else if (!string.IsNullOrEmpty(userInput))
            {
                Console.Error.WriteLine($"Invalid command: {userInput}");
            }

            userInput = Console.ReadLine()?.ToLower().Trim();
        }
    }

}
