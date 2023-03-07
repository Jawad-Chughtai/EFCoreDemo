// See https://aka.ms/new-console-template for more information

using EFCoreDemoConsole.Services;
using System.Globalization;
using System.Runtime.InteropServices;

Start();
//private readonly ItemService _itemService = new ItemService();
void Start()
{
    Console.Clear();
    Console.WriteLine("Hello! Good Day");
    Console.WriteLine("Enter \n1: For Category\n2: For Item");
    var choice = int.TryParse(Console.ReadLine(), out int x);

    if (x == 1)
    {
        InitCategory();
    }
    else if (x == 2)
    {
        InitItem();
    }
    else
    {
        Console.WriteLine("Invalid Choice, Press any key to continue");
        Console.ReadLine();
        Start();
    }
}


void InitCategory()
{
    Console.WriteLine("Enter \n1: For Adding New Category\n2: For Existing Categories");
    var choice = int.TryParse(Console.ReadLine(), out int x);
    var _categoryService = new CategoryService();

    if (x == 2)
    {
        try
        {
            Console.WriteLine("\tCategories");
            var categories = _categoryService.GetList();
            Console.WriteLine(" Id\t\t Name");
            foreach (var category in categories)
            {
                Console.WriteLine($" {category.Id}\t\t {category.Name}");
            }
            _ = Console.ReadLine();
            Start();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    else if (x == 1)
    {
        Console.WriteLine("\tCategories");
        Console.Write("Enter Category Name : ");
        var name = Console.ReadLine();
        if(name == null)
        {
            Console.WriteLine("Name cannot be null.");
            Console.ReadLine();
            InitCategory();
        }
        _categoryService.Create(name);
        Console.WriteLine("Category Created.");
        Console.ReadLine();
        Start();
    }
    else
    {
        Console.WriteLine("Invalid Choice, Press any key to continue");
        Console.ReadLine();
        Start();
    }
}

void InitItem()
{
    Console.WriteLine("Enter \n1: For Adding New Item\n2: For Existing Item");
    var choice = int.TryParse(Console.ReadLine(), out int x);
    var _itemService = new ItemService();

    if (x == 2)
    {
        try
        {
            Console.WriteLine("\tItems");
            var categories = _itemService.GetList();
            Console.WriteLine(" Id\t\t Name\t\t Category");
            foreach (var item in categories)
            {
                Console.WriteLine($" {item.Id}\t\t {item.Name}\t\t {item.Category}");
            }
            _ = Console.ReadLine();
            Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    else if (x == 1)
    {
        try
        {
            Console.WriteLine("\tItems");
            Console.Write("Enter Item Name : ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be null.");
                Console.ReadLine();
                InitItem();
            }
            Console.Write("Enter Category Id : ");
            var temp = int.TryParse(Console.ReadLine(), out int categoryId);
            if (!temp)
            {
                Console.WriteLine("Category cannot be null.");
                Console.ReadLine();
                InitItem();
            }
            _itemService.Create(name, categoryId);
            Console.WriteLine("Item Created.");
            Console.ReadLine();
            Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
            InitItem();
        }
    }
    else
    {
        Console.WriteLine("Invalid Choice, Press any key to continue");
        Console.ReadLine();
        Start();
    }
}
