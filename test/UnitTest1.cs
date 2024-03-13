namespace test;
using NUnit.Framework;
using Algrorithm;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.IsTrue(Algrorithm.process("aaa") == "aaaaaa");
        Assert.IsTrue(Algrorithm.process("aaab") == "aaba");
        Assert.IsTrue(Algrorithm.process("") == "");
    }

    public void Test2()
    {
        Assert.IsTrue(Algrorithm.count("aaa")[0] == 3);
        Assert.IsTrue(Algrorithm.count("aaab")[1] == 1);
    }

    public void Test3()
    {
        Assert.IsTrue(Algrorithm.getMaxSubstring("aaa") == "aaa");
        Assert.IsTrue(Algrorithm.getMaxSubstring("aaab") == "aaa");
        Assert.IsTrue(Algrorithm.getMaxSubstring("") == "");
    }

    public void Test3()
    {
        Assert.IsTrue(Algrorithm.quickSort("aabab") == "aaabb");
        Assert.IsTrue(Algrorithm.treeSort("aabab") == "aaabb");
    }
}