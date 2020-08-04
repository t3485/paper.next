﻿using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Paper.Pages
{
    public class Index_Tests : PaperWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
