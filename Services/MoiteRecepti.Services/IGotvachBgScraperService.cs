using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoiteRecepti.Services
{

    public interface IGotvachBgScraperService
    {
        Task ImportRecipesAsync(int fromId = 1, int toId = 10000);
    }
}
