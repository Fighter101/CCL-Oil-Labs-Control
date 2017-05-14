using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.CompositeCommands
{
    public class AddingCodesNavigateCommand
    {
        private CompositeCommand _addingCodesNavigateCommand = new CompositeCommand();

        public CompositeCommand addingCodesNavigateCommand
        {
            get { return _addingCodesNavigateCommand; }
        }

    }
}
