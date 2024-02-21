using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public void ShowPythonGreeting()
        {
            var eng = IronPython.Hosting.Python.CreateEngine();

            var scope = eng.CreateScope();

            eng.Execute(@"
def greetings(name):
    return 'Hello ' + name.title() + '!'
", scope);
            dynamic greetings = scope.GetVariable("greetings");

            MessageBox.Show(greetings("world"), "Greeting from IronPython");
        }

        private void UserControl1_MouseClick(object sender, MouseEventArgs e)
        {
            ShowPythonGreeting();
        }
    }
}
