
namespace NumberSystemConverter.abstraction
{
    public interface INumberConverter
    {
        string Name { get; }
        string Conversion(string text);
    }
}
