using System.Collections.Generic;
using Core.Models;

namespace Core.Interfaces
{
    public interface ITalksRepository : IRepository<Talk>
    {
        IEnumerable<Talk> ListByConventionId(int conventionId);

        Talk Reserve(Talk talk);
    }
}