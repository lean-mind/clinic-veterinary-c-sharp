namespace test.Koans.Common;

public class GeneralKoans
{
    [Test]
    public void named_parameters()
    {
        var car1 = new Car("name", "brand");
        var car2 = new Car(name:"name", brand: "brand");

        car1.Brand.Should().Be("brand");
        car2.Brand.Should().Be("brand");
        car1.Name.Should().Be("name");
        car2.Name.Should().Be("name");
    }
    
}


public class Car
{
    public string Brand { get; set; }

    public string Name { get; set; }

    public Car(string brand, string name)
    {
        Brand = brand;
        Name = name;
    }
}