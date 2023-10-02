using Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    interface IGenerator
    {
        void GenerateFiles(IEnumerable<Data> datas);
    }
}
