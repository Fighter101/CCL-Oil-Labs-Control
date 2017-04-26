using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
namespace CCL_Oil_Labs_Control.Utils
{
    public class ResultWrapper : BindableBase
    {
        private Double _result;
        public Double result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }


        public ResultWrapper (Double value)
        {
            result = value;
        }
    }
}
