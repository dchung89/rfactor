using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Roslyn.Services.Editor;
using Roslyn.Services;
using Roslyn.Compilers.Common;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;

namespace Rfactor
{
    // Gets all necessary GUI components
    // for the Rename refactoring.
    [ExcludeFromCodeCoverage]
    public class RenameGui
    {
        private string name;
        public string Name
        {
            get { return name; }
        }
        public RenameGui(string name)
        {
            this.name = name;
        }

        public bool GetGui()
        {
            bool cancelAction = true;
            using (RenameForm inputBox = new RenameForm())
            {
                inputBox.ShowDialog();
                Control[] controls = inputBox.Controls.Find("buttonOk", false);
                Control control = controls.First<Control>();
                if (!control.Enabled)
                {
                    controls = inputBox.Controls.Find("textBoxNewName", false);
                    control = controls.First<Control>();
                    cancelAction = false;
                    name = control.Text;
                }
            }

            return cancelAction;
        }
    }
}
