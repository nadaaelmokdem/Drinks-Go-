using Drinks_Go.Models;

namespace Drinks_Go.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<category> Categories { get; }
    }
}
