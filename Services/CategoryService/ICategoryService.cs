using M223PunchclockBlazor.Poco.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Services.CategoryService
{
    interface ICategoryService
    {
        public Task<List<Category>> GetCategoriesAsync();
    }
}
