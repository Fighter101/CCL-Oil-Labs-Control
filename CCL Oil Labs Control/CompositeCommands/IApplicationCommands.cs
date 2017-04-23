using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
namespace CCL_Oil_Labs_Control.CompositeCommands
{
    public interface IApplicationCommands
    {
        CompositeCommand fillDataAndNavigateCommand { get; }
    }
}
