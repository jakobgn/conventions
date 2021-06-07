using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Models;

namespace Infrastructure
{
    public class MockTalksRepository : ITalksRepository
    {
        public IEnumerable<Talk> List()
        {
            throw new NotImplementedException();
        }

        public Talk Create(Talk item)
        {
            throw new NotImplementedException();
        }

        public Talk Update(Talk item)
        {
            throw new NotImplementedException();
        }

        public Talk Delete(Talk item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Talk> ListByConventionId(int conventionId)
        {
            if (conventionId == 1)
            {
                return new List<Talk>()
                {
                    new Talk()
                    {
                        Id = 1,
                        Speaker = "Dan Abramov",
                        Topic = "Beyond React 16",
                        Description =
                            "React 16 was released several months ago. Even though this update was largely API-compatible, the rewritten internal engine included new long-requested features and opened the door for exciting future possibilities."
                    }
                };
            }

            return new List<Talk>()
            {
                new Talk()
                {
                    Id = 1,
                    Speaker = "Dan Abramov",
                    Topic = "Beyond React 16",
                    Description =
                        "React 16 was released several months ago. Even though this update was largely API-compatible, the rewritten internal engine included new long-requested features and opened the door for exciting future possibilities."
                },
                new Talk()
                {
                    Id = 2,
                    Speaker = "Simon Brown",
                    Topic = "Visualising software architecture with the C4 model",
                    Description =
                        "In Simon Brown's talk at AOTB 2019 he explores the visual communication of software architecture based upon a decade of Simon’s experiences working with software development teams large and small across the globe."
                }
            };
        }

        public Talk Reserve(Talk talk)
        {
            return talk;
        }
    }
}
