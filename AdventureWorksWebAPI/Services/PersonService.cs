using AdventureWorksWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksWebAPI.Services
{
    public class PersonService : IPersonService
    {
        public async Task<IEnumerable<Person>> TestScalarFunction(int id)
        {
            try
            {
                using (var db = new AdventureWorks2016CTP3Context())
                {
                    //select
                    //  p.BusinessEntityID,
                    //	p.FirstName,
                    //	p.LastName,
                    //	p.ModifiedDate as PersonModifiedDate,
                    //	a.AddressLine1,
                    //	[dbo].[fn_AddDayPeriod](a.ModifiedDate, 100, 'DayPeriod_day') as ThresholdDate
                    //from[Person].[Person] p
                    //join[Person].[BusinessEntityAddress] bea on p.BusinessEntityID = bea.BusinessEntityID
                    //join[Person].[Address] a on bea.AddressID = a.AddressID
                    //where p.ModifiedDate > [dbo].[fn_AddDayPeriod] (a.ModifiedDate, 100, 'DayPeriod_day')

                    var persons = await
                        (from p in db.Person.AsNoTracking()
                         join bea in db.BusinessEntityAddress on p.BusinessEntityId equals bea.BusinessEntityId
                         join a in db.Address on bea.AddressId equals a.AddressId
                         where p.ModifiedDate > AdventureWorks2016CTP3ContextFunctions.AddDayPeriod(a.ModifiedDate, 100, "DayPeriod_day")
                         select p).ToListAsync();

                    //var persons = await db.Person.AsNoTracking().Where(x => x.BusinessEntityId < 10).ToListAsync();

                    return persons;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка: "  + ex.Message, ex);
            }
        }
    }
}
