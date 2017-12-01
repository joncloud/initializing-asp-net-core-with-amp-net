using Amp;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace initializing_asp_net_core_with_amp_net
{
    class EntityFrameworkWarmUp : IWarmUp
    {
        readonly ApplicationDbContext _context;
        public EntityFrameworkWarmUp(ApplicationDbContext context) =>
            _context = context;
        public Task InvokeAsync() =>
            _context.EmploymentPositions.AnyAsync();
    }
}