using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Models;

namespace Infrastructure
{
    public class MockConventionsRepository : IConventionsRepository
    {
        public IEnumerable<Convention> List()
        {
            return new List<Convention>()
            {
                new Convention
                {
                    Id = 1,
                    Date = DateTime.Now.AddDays(50),
                    Location = "Copenhagen"
                },
                new Convention
                {
                    Id = 2,
                    Date = DateTime.Now.AddDays(150),
                    Location = "London"
                }
            };
        }

        public Convention Create(Convention item)
        {
            return new Convention()
            {
                Date = DateTime.Now,
                Id = 3,
                Location = "Paris"
            };
        }

        public Convention Update(Convention item)
        {
            throw new NotImplementedException();
        }

        public Convention Delete(Convention item)
        {
            throw new NotImplementedException();
        }
    }
}
