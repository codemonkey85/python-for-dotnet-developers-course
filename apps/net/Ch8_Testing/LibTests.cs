using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ch8_Testing;

[TestClass]
public class LibTests
{
    //[TestMethod]
    //public void TestRunMeWrong()
    //{
    //    string style = "electric";

    //    Lib db = new Lib();
    //    Guitar[] guitars = db.AllGuitars(style);

    //    Assert.IsTrue(guitars.Length > 0);
    //    // Sweet little LINQ expression
    //    Assert.AreEqual(0, guitars.Count(g => g.Style != style));
    //}


    [TestMethod]
    public void TestElectricGuitars()
    {
        var style = "electric";

        var db = new Lib(TestData.GetMockDb(), TestData.GetMockLogger());
        var guitars = db.AllGuitars(style);

        // Sweet little LINQ expression
        var set = guitars.Select(g => g.Style).ToHashSet();
        Assert.AreEqual(1, set.Count);
        CollectionAssert.Contains(set.ToArray(), style);
    }


    [TestMethod]
    public void TestAllGuitars()
    {
        var db = new Lib(TestData.GetMockDb(), TestData.GetMockLogger());
        var guitars = db.AllGuitars("all");

        var set = guitars.Select(g => g.Style).ToHashSet();
        Assert.AreEqual(2, set.Count);
    }


    [TestMethod, ExpectedException(typeof(ArgumentException))]
    public void TestInputValidation()
    {
        var db = new Lib(TestData.GetMockDb(), TestData.GetMockLogger());
        db.AllGuitars(null);
    }
}
