using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningBreakAPI.ImdbLogic
{
    public static class ImdbQueries
    {
        public static string GetSearchQuery(IConfiguration config, string queryValue)
        {
            return config["ImdbUrl"] + "find?q=" + queryValue;
        }
    }
}
