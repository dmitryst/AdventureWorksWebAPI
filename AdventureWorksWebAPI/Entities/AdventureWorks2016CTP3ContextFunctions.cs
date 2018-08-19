using Microsoft.EntityFrameworkCore;
using System;

namespace AdventureWorksWebAPI.Entities
{
    public static class AdventureWorks2016CTP3ContextFunctions
    {
        [DbFunction("fn_AddDayPeriod")]
        public static DateTime? AddDayPeriod(DateTime dateTime, int days, string periodName) =>
            throw new NotSupportedException();
    }
}
