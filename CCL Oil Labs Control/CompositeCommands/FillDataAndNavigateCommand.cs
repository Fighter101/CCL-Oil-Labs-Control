using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
namespace CCL_Oil_Labs_Control.CompositeCommands
{
    public class FillDataAndNavigateCommand : IApplicationCommands
    {
        private CompositeCommand _fillDataAndNavigateCommand = new CompositeCommand();
        public CompositeCommand fillDataAndNavigateCommand
        {
            get { return _fillDataAndNavigateCommand; }
        }
    }
}
