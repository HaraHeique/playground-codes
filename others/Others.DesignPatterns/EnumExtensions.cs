namespace Others.DesignPatterns;

public static class EnumExtensions 
{
    public static TEnum[] GetAllOptions<TEnum>() where TEnum : Enum 
        => Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
}