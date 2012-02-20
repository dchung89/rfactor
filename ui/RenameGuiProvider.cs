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

namespace rfactor
{
    [ExcludeFromCodeCoverage]
    public class GuiProvider
    {
        private string name;
        public string Name
        {
            get { return name; }
        }
        public GuiProvider(string name)
        {
            this.name = name;
        }

        public bool GetGUI()
        {
            bool cancelAction = true;
            using (InputBox inputBox = new InputBox())
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
