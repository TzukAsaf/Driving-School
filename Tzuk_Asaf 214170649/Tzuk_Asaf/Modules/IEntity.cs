using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Tzuk_Asaf.Modules
{
    public interface IEntity
    {
        void Populate(DataRow dr);
    }
}
