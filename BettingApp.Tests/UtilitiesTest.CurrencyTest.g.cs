using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// <copyright file="UtilitiesTest.CurrencyTest.g.cs">Copyright ©  2017</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace BettingApp.BettingApp.Core.Tests
{
    public partial class UtilitiesTest
    {

[TestMethod]
[PexGeneratedBy(typeof(UtilitiesTest))]
public void CurrencyTest280()
{
    string s;
    s = this.CurrencyTest((string)null);
    Assert.AreEqual<string>("?", s);
}

[TestMethod]
[PexGeneratedBy(typeof(UtilitiesTest))]
public void CurrencyTest681()
{
    string s;
    s = this.CurrencyTest("GBP");
    Assert.AreEqual<string>("£", s);
}

[TestMethod]
[PexGeneratedBy(typeof(UtilitiesTest))]
public void CurrencyTest555()
{
    string s;
    s = this.CurrencyTest("EUR");
    Assert.AreEqual<string>("E", s);
}
    }
}
