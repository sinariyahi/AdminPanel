using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataInitializer;

public interface IDataInitializer : IScopedDependency
{
    void InitializeData();
}
