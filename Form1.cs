using WinFormsFinal.Controller;

namespace WinFormsFinal
{
    public partial class Form1 : Form
    {
        private readonly PrestamoController _controller;

        public Form1(PrestamoController controller)
        {
            InitializeComponent();
            _controller = controller;
        }
    }
}
