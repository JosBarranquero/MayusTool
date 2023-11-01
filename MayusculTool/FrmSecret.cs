using System.Windows.Forms;

namespace MayusTool
{
    /// <summary>
    /// Easter Egg
    /// </summary>
    /// <remarks>
    /// JABF    21/09/2018  -   First Write
    /// </remarks>
    public partial class FrmSecret : Form
    {
        public FrmSecret()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    21/09/2018  0.1         First write
        /// </remarks>
        private void FrmSecret_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.Shift && e.KeyCode == Keys.L)
            {
                this.BackgroundImage = Properties.Resources.loss;

                string message = "is this loss?";
                Utilities.ConvertText(message, out message, true, true, true, false);
                this.Text = message;
            }
        }

        private void tmrSecret_Tick(object sender, System.EventArgs e)
        {
            tmrSecret.Stop();
            MessageBox.Show("Control Alt Shift L...", "Shhh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
