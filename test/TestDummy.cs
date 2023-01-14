namespace clinicVeterinary;

public class TestDummy
{
    [Test]
    public void test_name()
    {
        string actual = "ABCDEFGHI";
        actual.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);
    }
}