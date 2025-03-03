using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiWindowsForm
{
   public static class Validators
    {
        public static bool IsEmptyText(Control control)
        {
            return control.Text == "";
           
        }

        public static bool IsTextNull(Control control)
        {
            return control.Text == null;
        }
    }
}
