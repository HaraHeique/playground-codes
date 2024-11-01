// SHAPE FACTORIES:
//     REGULAR FACTORY:
//         - CIRCLE, SQUARE, RECTANGLE
//     ROUNDED FACTORY:
//         - CIRCLE, SQUARE, RECTANGLE
//     FILLED FACTORY:
//         - CIRCLE, SQUARE, RECTANGLE

namespace Others.DesignPatterns;

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
            ShapeFormsTypes.Regular => new RegularShapeFactory(),
            ShapeFormsTypes.Rounded => new RoundedShapeFactory(),
            ShapeFormsTypes.Filled => new FilledShapeFactory(),
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
            ShapeTypes.Circle => Circle(),
            ShapeTypes.Square => Square(),
            ShapeTypes.Rectangle => Rectangle(),
            _ => throw new ArgumentException("Invalid enum value for type concreate object choosen", nameof(type))
        }; 

    public abstract Shape Circle();
    public abstract Shape Square();
    public abstract Shape Rectangle();
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
    public override Shape Circle() =>  new CircleRegular();
    public override Shape Square() => new SquareRegular();
    public override Shape Rectangle() => new RectangleRegular();
}

class RoundedShapeFactory : ShapeFactory
{
    public override Shape Circle() => new CircleRounded();
    public override Shape Square() => new SquareRounded();
    public override Shape Rectangle() => new RectangleRounded();
}

class FilledShapeFactory : ShapeFactory
{
    public override Shape Circle() => new CircleFilled();
    public override Shape Square() => new SquareFilled();
    public override Shape Rectangle() => new RectangleFilled();
}