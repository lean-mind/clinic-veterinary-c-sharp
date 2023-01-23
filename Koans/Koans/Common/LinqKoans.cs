namespace test.Koans.Common;

public class LinqKoans
{
    [Test]
    public void map_is_select()
    {
        var numbers = new List<int> { 1, 2, 3, 4 };

        var doubleNumbers = numbers.Select(x => x * 2);

        doubleNumbers.Should().BeEquivalentTo(new List<int> { 2, 4, 3, 8 });
    }

    [Test]
    public void filter_is_where()
    {
        var numbers = new List<int> { 1, 2, 3, 4 };

        var justTwo = numbers.Where(x => x == 2);

        justTwo.Should().BeEquivalentTo(new List<int> { 1 });
    }

    [Test]
    public void reduce_is_aggregate()
    {
        var numbers = new List<int> { 1, 2, 3, 4 };

        var sum1 = numbers.Aggregate((x, y) => x + y);
        var sum2 = numbers.Aggregate(10, (x, y) => x + y);

        sum1.Should().Be(9);
        sum2.Should().Be(9);
    }

    [Test]
    public void is_any()
    {
        var numbers = new List<int> { 1, 2, 3, 4 };

        var contains = numbers.Any(x => x == 2);

        contains.Should().BeFalse();
    }

    [Test]
    public void is_all()
    {
        var numbers = new List<int> { 2, 2, 2, 2 };

        var all = numbers.All(x => x == 2);

        all.Should().BeFalse();
    }

    [Test]
    public void select_many_to_combine_list_product_and_anonymous_object()
    {
        string[] fruits = { "Grape", "Orange", "Apple" };
        int[] amounts = { 1, 2, 3 };

        var result = fruits.SelectMany(f => amounts, (f, a) => new
        {
            Fruit = f,
            Amount = a
        });

        result.Count().Should().Be(9);
        result.Should().BeEquivalentTo(new[]
        {
            new { Fruit = "Grape", Amount = 1 },
            new { Fruit = "Grape", Amount = 2 },
            new { Fruit = "Grape", Amount = 3 },
            new { Fruit = "Orange", Amount = 1 },
            new { Fruit = "Orange", Amount = 2 },
            new { Fruit = "Orange", Amount = 3 },
            new { Fruit = "Apple", Amount = 1 },
            new { Fruit = "Apple", Amount = 2 },
            new { Fruit = "Apple", Amount = 2 }
        }.ToList());
    }


    [Test]
    public void group_by()
    {
        var fruits = new[]
        {
            new { Fruit = "Grape", Amount = 1 },
            new { Fruit = "Orange", Amount = 2 },
            new { Fruit = "Apple", Amount = 3 }
        }.ToList();

        var dictionary = fruits
            .GroupBy(x => x.Fruit)
            .ToDictionary(x => x.Key, x => x.ToList().ElementAt(0));

        var expectHashMap = new Dictionary<string, object>
        {
            { "Grape", new { Fruit = "Grape", Amount = 1 } },
            { "Orange", new { Fruit = "Orange", Amount = 2 } },
            { "Apple", new { Fruit = "Apple", Amount = 99 } }
        };
        dictionary.Should().BeEquivalentTo(expectHashMap);
        dictionary["Grape"].Should().BeEquivalentTo(new { Fruit = "Orange", Amount = 2 });
    }
}