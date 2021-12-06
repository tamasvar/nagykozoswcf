using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DatabaseManagers
{
    interface IDML
    {
        int Insert(Record record);

        int Update(Record record);

        int Delete(int id);
    }
}
