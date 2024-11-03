using Others.DesignPatterns;
using Sharprompt;

Console.WriteLine("Criação das fábricas!");

var factoryOption = Prompt.Select("Select the factory to work with", EnumExtensions.GetAllOptions<ShapeFormsTypes>());
var shapeOption = Prompt.Select("Select the shape type to work with", EnumExtensions.GetAllOptions<ShapeTypes>());

var shape = ShapeFactory.Create(factoryOption) // Cria a fábrica
    .CreateForm(shapeOption); // Cria o objeto em si

Console.WriteLine("\nObjeto criado: " + shape);