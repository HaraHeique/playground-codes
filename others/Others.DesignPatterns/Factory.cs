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

// Types of possible shapes 
enum ShapeTypes 
{
    Regular,
    Rounded,
    Filled
}

// The absctration generalization of the method factories
// This is also called the factory of factories (The abstract factory itself)
abstract class ShapeFactory 
{
    public static ShapeFactory Create(ShapeTypes type) => 
        type switch
        {
            type.Regular => new RegularShapeFactory(),
            type.Rounded => new RoundedShapeFactory(),
            type.Filled => new FilledShapeFactory(),
            _ => throw new ArgumentException("Invalid enum value for type factory choosen", nameof(type))
        }; 

    abstract Shape Circle();
    abstract Shape Square();
    abstract Shape Rectangle();
}

// Factory Methods for each group of related concrete objects
class RegularShapeFactory : ShapeFactory
{
    Shape Circle() 
    {
        return new CircleRegular();
    }
    
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