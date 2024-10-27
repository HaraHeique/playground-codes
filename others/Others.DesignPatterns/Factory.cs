// SHAPE FACTORIES:
//     REGULAR FACTORY:
//         - CIRCLE, SQUARE, RECTANGLE
//     ROUNDED FACTORY:
//         - CIRCLE, SQUARE, RECTANGLE
//     FILLED FACTORY:
//         - CIRCLE, SQUARE, RECTANGLE

// Generic and abstract Shape interface. Common abstract object to all concrete object
public abstract class Shape 
{
    public double Height { get; set; }
    public double Width { get; set; }
}

// Concrete objects to construct through method factories
public class CircleRegular : Shape {}
public class SquareRegular : Shape {}
public class RectangleRegular : Shape {}

public class CircleRounded : Shape {}
public class SquareRounded : Shape {}
public class RectangleRounded : Shape {}

public class CircleFilled : Shape {}
public class SquareFilled : Shape {}
public class RectangleFilled : Shape {}

// The absctration generalization of the method factories
// This is also called the factory of factories (The abstract factory itself) 
enum ShapeFormsTypes 
{
    Regular,
    Rounded,
    Filled
}

abstract class ShapeFactory 
{
    /// <summary>
    /// Create the concrete factory method passing the identifier options as argument
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static ShapeFactory Create(ShapeFormsTypes type) => 
        type switch
        {
            type.Regular => new RegularShapeFactory(),
            type.Rounded => new RoundedShapeFactory(),
            type.Filled => new FilledShapeFactory(),
            _ => throw new ArgumentException("Invalid enum value for type factory choosen", nameof(type))
        }; 

    /// <summary>
    /// Create the concrete object passing the identifier option as argument.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public Shape CreateForm(ShapeTypes type) =>
        type switch
        {
            type.Circle => Circle(),
            type.Square => Square(),
            type.Rectangle => Rectangle(),
            _ => throw new ArgumentException("Invalid enum value for type concreate object choosen", nameof(type))
        }; 

    abstract Shape Circle();
    abstract Shape Square();
    abstract Shape Rectangle();
}

// Factory Methods for each group of related concrete objects
enum ShapeTypes 
{
    Circle,
    Square,
    Rectangle
}

class RegularShapeFactory : ShapeFactory
{
    Shape Circle() =>  new CircleRegular();
    Shape Square() => new SquareRegular();
    Shape Rectangle() => new RectangleRegular();
}

class RoundedShapeFactory : ShapeFactory
{
    Shape Circle() => new CircleRounded();
    Shape Square() => new SquareRounded();
    Shape Rectangle() => new RectangleRounded();
}

class FilledShapeFactory : ShapeFactory
{
    Shape Circle() => new CircleFilled();
    Shape Square() => new SquareFilled();
    Shape Rectangle() => new RectangleFilled();
}