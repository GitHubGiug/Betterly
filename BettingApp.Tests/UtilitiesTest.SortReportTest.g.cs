using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using BettingApp;
// <copyright file="UtilitiesTest.SortReportTest.g.cs">Copyright ©  2017</copyright>
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
[PexRaisedException(typeof(ArgumentNullException))]
public void SortReportTestThrowsArgumentNullException569()
{
    IOrderedEnumerable<ReportData> iOrderedEnumerable;
    iOrderedEnumerable =
      this.SortReportTest((IEnumerable<ReportData>)null, (string)null);
}
    }
}
