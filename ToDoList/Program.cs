string userInput;
List<string> todos = new List<string>();

Console.WriteLine("Hello!");
do
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    userInput = Console.ReadLine().ToLower();

    switch (userInput)
    {
        case "s":
            if (todos.Count > 0)
            {
                SeeAllTodos(todos);
            }
            else
            {
                Console.WriteLine("No TODOs have been added yet");
            }
            break;
        case "a":
            todos = AddTodo(todos);
            break;
        case "r":
            todos = RemoveTodo(todos);
            break;
        case "e":
            break;
        default:
            Console.WriteLine("Incorrect input");
            break;
    }
} while (userInput != "e");

void SeeAllTodos(List<string> todos)
{
    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }
}

List<string> AddTodo(List<string> todos)
{
    List<string> result = new List<string>(todos);
    do
    {
        Console.WriteLine("Enter the TODO description");
        string userInput = Console.ReadLine();
        if (userInput.Length > 0 && !todos.Contains(userInput))
        {
            result.Add(userInput);
            Console.WriteLine("TODO successfully added: " + result[^1]);
        }
        else if (userInput.Length == 0)
        {
            Console.WriteLine("The description cannot be empty.");
        }
        else if (todos.Contains(userInput))
        {
            Console.WriteLine("The description must be unique.");
        }
        else
        {
            Console.WriteLine("Error");
        }
    } while (userInput.Length == 0 || todos.Contains(userInput));
    return result;
}

List<string> RemoveTodo(List<string> todos)
{
    if (todos.Count != 0)
    {
        List<string> result = new List<string>(todos);
        string userInput;
        do
        {
            Console.WriteLine("Select the index of the TODO you want to remove");
            SeeAllTodos(todos);
            userInput = Console.ReadLine();
            int indexToRemove;
            //Input is successfully parsed
            if (int.TryParse(userInput, out indexToRemove))
            {
                //Index is valid
                if (indexToRemove > 0 && indexToRemove <= todos.Count)
                {
                    Console.WriteLine("TODO removed: " + todos[--indexToRemove]);
                    result.RemoveAt(indexToRemove);
                    //Index is out of bounds
                }
                else
                {
                    Console.WriteLine("The given index is not valid");
                    //Allows for loop to continue
                    userInput = "";
                }
            }
            else
            //Index not parsed
            {
                //Empty
                if (userInput == "")
                {
                    Console.WriteLine("Selected index cannot be empty.");
                    //Index not number or error parsing
                }
                else
                {
                    Console.WriteLine("The given index is not valid");
                    //Allows for loop to continue
                    userInput = "";
                }
            }
        } while (userInput.Length == 0);
        return result;
    }
    else
    {
        Console.WriteLine("No TODOs have been added yet");
        return todos;
    }
}