﻿#region License
// ListTests.cs
// Copyright (c) 2013, Simon Williams
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provide
// d that the following conditions are met:
// 
// Redistributions of source code must retain the above copyright notice, this list of conditions and the
// following disclaimer.
// 
// Redistributions in binary form must reproduce the above copyright notice, this list of conditions and
// the following disclaimer in the documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED 
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
// TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE.
#endregion

using System.Collections.Generic;
using Fclp.Tests.FluentCommandLineParser;
using Fclp.Tests.Internals;
using Xunit;

namespace Fclp.Tests.Integration
{
	public class ListTests
	{
		[Theory]
		[InlineData("--list file1.txt file2.txt file3.txt", new[] { "file1.txt", "file2.txt", "file3.txt" })]
		[InlineData("-list file1.txt file2.txt file3.txt", new[] { "file1.txt", "file2.txt", "file3.txt" })]
		[InlineData("/list file1.txt file2.txt file3.txt", new[] { "file1.txt", "file2.txt", "file3.txt" })]
		[InlineData("--list 'file 1.txt' file2.txt 'file 3.txt'", new[] { "file 1.txt", "file2.txt", "file 3.txt" })]
		[InlineData("-list 'file 1.txt' file2.txt 'file 3.txt'", new[] { "file 1.txt", "file2.txt", "file 3.txt" })]
		[InlineData("/list 'file 1.txt' file2.txt 'file 3.txt'", new[] { "file 1.txt", "file2.txt", "file 3.txt" })]
		[InlineData("/list='file 1.txt' file2.txt 'file 3.txt'", new[] { "file 1.txt", "file2.txt", "file 3.txt" })]
		[InlineData("/list:'file 1.txt' file2.txt 'file 3.txt'", new[] { "file 1.txt", "file2.txt", "file 3.txt" })]
		[InlineData("--list:'file 1.txt' file2.txt 'file 3.txt'", new[] { "file 1.txt", "file2.txt", "file 3.txt" })]
		[InlineData("--list='file 1.txt' file2.txt 'file 3.txt'", new[] { "file 1.txt", "file2.txt", "file 3.txt" })]
		public void should_create_list_with_expected_strings(string arguments, IEnumerable<string> expectedItems)
		{
			should_contain_list_with_expected_items(arguments, expectedItems);
		}

        [Theory]
		[InlineData("--list 123 321 098", new[] { 123, 321, 098 })]
		[InlineData("-list 123 321 098", new[] { 123, 321, 098 })]
		[InlineData("/list 123 321 098", new[] { 123, 321, 098 })]
		[InlineData("/list:123 321 098", new[] { 123, 321, 098 })]
		[InlineData("/list=123 321 098", new[] { 123, 321, 098 })]
		[InlineData("--list:123 321 098", new[] { 123, 321, 098 })]
		[InlineData("--list=123 321 098", new[] { 123, 321, 098 })]
		public void should_create_list_with_expected_int32_items(string arguments, IEnumerable<int> expectedItems)
		{
			should_contain_list_with_expected_items(arguments, expectedItems);
		}

        [Theory]
        [InlineData("--list 2147483650 3147483651 4147483652", new [] { 2147483650L, 3147483651, 4147483652 })]
        [InlineData("-list 2147483650 3147483651 4147483652", new[] { 2147483650L, 3147483651, 4147483652 })]
        [InlineData("/list 2147483650 3147483651 4147483652", new[] { 2147483650L, 3147483651, 4147483652 })]
        [InlineData("/list:2147483650 3147483651 4147483652", new[] { 2147483650L, 3147483651, 4147483652 })]
        [InlineData("/list=2147483650 3147483651 4147483652", new[] { 2147483650L, 3147483651, 4147483652 })]
        [InlineData("--list:2147483650 3147483651 4147483652", new[] { 2147483650L, 3147483651, 4147483652 })]
        [InlineData("--list=2147483650 3147483651 4147483652", new[] { 2147483650L, 3147483651, 4147483652 })]
        public void should_create_list_with_expected_int64_items(string arguments, IEnumerable<long> expectedItems)
        {
            should_contain_list_with_expected_items(arguments, expectedItems);
        }

		[Theory]
		[InlineData("--list 123.456 321.987 098.123465", new[] { 123.456, 321.987, 098.123465 })]
		[InlineData("-list 123.456 321.987 098.123465", new[] { 123.456, 321.987, 098.123465 })]
		[InlineData("/list 123.456 321.987 098.123465", new[] { 123.456, 321.987, 098.123465 })]
		[InlineData("/list:123.456 321.987 098.123465", new[] { 123.456, 321.987, 098.123465 })]
		[InlineData("/list=123.456 321.987 098.123465", new[] { 123.456, 321.987, 098.123465 })]
		[InlineData("--list:123.456 321.987 098.123465", new[] { 123.456, 321.987, 098.123465 })]
		[InlineData("--list=123.456 321.987 098.123465", new[] { 123.456, 321.987, 098.123465 })]
		public void should_create_list_with_expected_double_items(string arguments, IEnumerable<double> expectedItems)
		{
			should_contain_list_with_expected_items(arguments, expectedItems);
		}

		[Theory]
		[InlineData("--list true false true", new[] { true, false, true })]
		[InlineData("-l true false true", new[] { true, false, true })]
		[InlineData("/list true false true", new[] { true, false, true })]
		[InlineData("/list:true false true", new[] { true, false, true })]
		[InlineData("/list=true false true", new[] { true, false, true })]
		[InlineData("--list:true false true", new[] { true, false, true })]
		[InlineData("--list=true false true", new[] { true, false, true })]
		public void should_create_list_with_expected_bool_items(string arguments, IEnumerable<bool> expectedItems)
		{
			should_contain_list_with_expected_items(arguments, expectedItems);
		}

		[Theory]
		[InlineData("--list Value0 Value1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("-l Value0 Value1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("/list Value0 Value1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("/list:Value0 Value1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("/list=Value0 Value1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("--list:Value0 Value1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("--list=Value0 Value1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("--list 0 1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("-l 0 1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("/list 0 1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("/list:0 1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("/list=0 1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("--list:0 1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		[InlineData("--list=0 1", new[] { TestEnum.Value0, TestEnum.Value1 })]
		public void should_create_list_with_expected_enum_items(string arguments, IEnumerable<TestEnum> expectedItems)
		{
			should_contain_list_with_expected_items(arguments, expectedItems);
		}

        private void should_contain_list_with_expected_items<T>(string arguments, IEnumerable<T> expectedItems)
        {
            var sut = new Fclp.FluentCommandLineParser();

            List<T> actualItems = null;

            sut.Setup<List<T>>('l', "list").Callback(items => actualItems = items).Required();

            var args = arguments.ParseArguments();

            var results = sut.Parse(args);

            Assert.False(results.HasErrors);
            Assert.Equal(actualItems, expectedItems);
        }
	}
}