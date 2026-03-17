using Drinks_Go.Interfaces;
using Drinks_Go.Models;


namespace Drinks_Go.Data
{
    public class CategoryRep:ICategoryRepository
    {
        private readonly Appdbcontext appdbcontext;
        public CategoryRep(Appdbcontext appdbcontext) {
            this.appdbcontext =    appdbcontext;
        
        }
        public IEnumerable<category> Categories => appdbcontext.Categories;

    }
}
