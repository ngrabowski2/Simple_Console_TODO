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

//Displays all Todos
void SeeAllTodos(List<string> todos)
{
    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }
}

//Adds a todo
List<string> AddTodo(List<string> todos)
{
    List<string> result = new List<string>(todos);
    bool validInput = false;
    while (!validInput)
    {
        Console.WriteLine("Enter the TODO description");
        string userInput = Console.ReadLine();
        validInput = IsTODOValid(todos, userInput);
        if (validInput)
        {
            result.Add(userInput);
            Console.WriteLine("TODO successfully added: " + result[^1]);
            break;
        }
    }
    return result;
}

//removes a todo given at an index
List<string> RemoveTodo(List<string> todos)
{
    if (todos.Count != 0)
    {
        List<string> result = new List<string>(todos);
        string userInput;
        bool indexValid = false;
        int indexToRemove;
        while (!indexValid)
        {

            Console.WriteLine("Select the index of the TODO you want to remove");
            SeeAllTodos(todos);
            userInput = Console.ReadLine();
            indexValid = IsIndexValid(todos.Count, userInput, out indexToRemove);
            //Input is successfully parsed
            if (indexValid) {
                Console.WriteLine("TODO removed: " + todos[indexToRemove]);
                result.RemoveAt(indexToRemove);
                break;
            }
        }
        return result;
    }
    else
    {
        Console.WriteLine("No TODOs have been added yet");
        return todos;
    }
}

//Checks if new todo is valid
bool IsTODOValid(List<string> todos, string newTodo)
{
    if (newTodo.Length > 0 && !todos.Contains(newTodo))
    {
        return true;
    }
    else if (newTodo.Length == 0)
    {
        Console.WriteLine("The description cannot be empty.");
        return false;
    }
    else if (todos.Contains(newTodo))
    {
        Console.WriteLine("The description must be unique.");
        return false;
    }
    else
    {
        Console.WriteLine("Error");
        return false;
    }
}

//Checks if index of todo to remove is valid
bool IsIndexValid(int numOfTodos, string index, out int parsedIndex)
{
    //Parses and index is within bounds
    if (int.TryParse(index, out parsedIndex) && parsedIndex > 0 && parsedIndex <= numOfTodos)
    {
        //Convert to 0 index
        parsedIndex--;
        return true;
        //User inputs empty index
    } else if (index.Length == 0)
    {
        InvalidIndexHandler("empty");
        return false;
        //Index is out of bounds or there is some other error:
    } else
    {
        InvalidIndexHandler("OutOfBounds");
        return false;
    }
}
// Handles invalid index
void InvalidIndexHandler(string error)
{
    if (error == "empty")
    {
        Console.WriteLine("Selected index cannot be empty.");
    } else if (error == "OutOfBounds")
    {
        Console.WriteLine("The given index is not valid.");
    } else
    {
        Console.WriteLine("Internal Error");
    }
}