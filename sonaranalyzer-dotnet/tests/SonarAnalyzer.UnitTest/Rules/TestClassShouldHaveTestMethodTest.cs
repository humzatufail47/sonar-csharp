﻿/*
 * SonarAnalyzer for .NET
 * Copyright (C) 2015-2018 SonarSource SA
 * mailto: contact AT sonarsource DOT com
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

extern alias csharp;
using csharp::SonarAnalyzer.Rules.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SonarAnalyzer.UnitTest.Rules
{
    [TestClass]
    public class TestClassShouldHaveTestMethodTest
    {
        [DataTestMethod]
        [DataRow("2.5.7.10213")]
        [DataRow(AssemblyReference.NuGetInfo.LatestVersion)]
        [TestCategory("Rule")]
        public void TestClassShouldHaveTestMethod_NUnit(string testFwkVersion)
        {
            Verifier.VerifyAnalyzer(@"TestCases\TestClassShouldHaveTestMethod.NUnit.cs",
                new TestClassShouldHaveTestMethod(),
                null,
                AssemblyReference.FromNuGet("nunit.framework.dll", "NUnit", testFwkVersion));
        }

        [DataTestMethod]
        [DataRow("1.1.11")]
        [DataRow(AssemblyReference.NuGetInfo.LatestVersion)]
        [TestCategory("Rule")]
        public void TestClassShouldHaveTestMethod_MSTest(string testFwkVersion)
        {
            Verifier.VerifyAnalyzer(@"TestCases\TestClassShouldHaveTestMethod.MsTest.cs",
                new TestClassShouldHaveTestMethod(),
                null,
                AssemblyReference.FromNuGet("Microsoft.VisualStudio.TestPlatform.TestFramework.dll", "MSTest.TestFramework", testFwkVersion));
        }
    }
}
