namespace test.Koans.JoseAngelKoans;
using static JonayExtensions;

public class GeneralKoans
{
    [Test]
    public void named_parameters()
    {
        var car1 = new Car("brand", "name");
        var car2 = new Car(name:"name", brand: "brand");

        car1.Brand.Should().Be("brand");
        car2.Brand.Should().Be("brand");
        car1.Name.Should().Be("name");
        car2.Name.Should().Be("name");
    }
    
    [Test]
    public void extensions_methods()
    {
        var text = "Las extensiones de metodos son utiles " +
                        "para crear pequeños metodos de utilidad, en este archivo " +
                        "tienes un ejemplo llamado JonayExtensions";

        text.WordCount().Should().Be(20);
        true.IsJonayCool().Should().Be(true);
        false.IsJonayCool().Should().Be(true);
    }
    
}

public static class JonayExtensions
{
    public static bool IsJonayCool(this bool boolean)
    {
        return true;
    }
    
    public static int WordCount(this string str)
    {
        return str.Split(new char[] { ' ', '.', '?' },
            StringSplitOptions.RemoveEmptyEntries).Length;
    }
}

public class Car
{
    public string Brand { get; }

    public string Name { get; }

    public Car(string brand, string name)
    {
        Brand = brand;
        Name = name;
    }
}