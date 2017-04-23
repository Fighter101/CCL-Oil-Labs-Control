using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.CompositeCommands
{
    public class CloseCommand
    {
        private CompositeCommand _closeCommand = new CompositeCommand();

        public CompositeCommand closeCommand
        {
            get { return _closeCommand; }
        }

    }
}
