using System;
using System.Reflection;
using System.Windows.Forms;

namespace MayusTool
{
    /// <summary>
    /// MayusTool Form
    /// </summary>
    /// <remarks>
    /// JABF    11/09/2018  -   First Write
    /// JABF    12/09/2018  -   R2, UI fixes, improved clipboard functionality
    /// JABF    13/09/2018  -   R3, scrambled uppercasing in words
    /// JABF    14/09/2018  -   R4, reversing of words
    /// JABF    14/09/2018  -   R5, bug fixing
    /// JABF    18/09/2018  -   R6, UI changes, number to letter functionality -> 2 (dos)
    /// JABF    18/09/2018  -   R7, command line arguments
    /// JABF    19/09/2018  -   R8, UI changes, maximize, autofocus when clearing
    /// JABF    20/09/2018  -   R9, force caps with #uwu[]
    /// JABF    21/09/2018  -   R10, force caps of words contained in CSV file
    /// JABF    02/10/2019  -   R11, new icon, rename app, negative numbers fixed
    /// </remarks>
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = String.Format("{0} - R{1}.{2}", Application.ProductName, version.Major, version.Minor);
        }

        /// <summary>
        /// "Dale" (aka GOD button, bless this) button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    11/09/2018  0.1         First write
        /// JABF    12/09/2018  0.2         Clipboard functionality out
        /// JABF    13/09/2018  0.3         Scrambled uppercasing
        /// JABF    14/09/2018  0.4         Reversed words
        /// JABF    14/09/2018  0.5         Bug fixing, \r\n mainly...
        /// JABF    18/09/2018  0.6         Number spelling functionality
        /// JABF    18/09/2018  0.7         Refactoring, all crap is now in Utilities.cs
        /// JABF    19/09/2018  0.8         Output is now done to tbxOutput and not tbxText (renamed to tbxInput), number de-check removed
        /// JABF    20/09/2018  0.9         Exception handling!
        /// JABF    21/09/2018  1.0         Can proceed if the source contains force caps enclosing
        /// </remarks>
        private void btnDale_Click(object sender, EventArgs e)
        {
            string source = tbxInput.Text;
            string output = string.Empty;

            bool wordMayus = cbWordUpper.Checked;
            bool letterMayus = cbLetterUpper.Checked;
            bool reverse = cbReverse.Checked;
            bool numbers = cbNum.Checked;

            if ((!string.IsNullOrEmpty(source) && (wordMayus || reverse || letterMayus || numbers)) || (source.Contains(Utilities.ENCLOSING_START))) {
                try
                {
                    Utilities.ConvertText(source, out output, wordMayus, reverse, letterMayus, numbers);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show(string.Format("Hay algún {0}{1} sin cerrar", Utilities.ENCLOSING_START, Utilities.ENCLOSING_END), "Casi tiro una excepción xd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "A tomar por culo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                output = output.Trim();

                tbxOutput.Text = output;
            }
        }

        /// <summary>
        /// Clear button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    12/09/2018  0.1         First write
        /// JABF    18/09/2018  0.2         Number auto-check
        /// JABF    19/09/2018  0.3         Give focus to the input box, number auto-check removed, tbxOutput clear
        /// </remarks>
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxInput.Clear();
            tbxOutput.Clear();
            tbxInput.Focus();
        }

        /// <summary>
        /// Clipboard button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    12/09/2018  0.1         First write
        /// JABF    19/09/2018  0.2         Copy text from tbxOutput
        /// </remarks>
        private void btnClipboard_Click(object sender, EventArgs e)
        {
            string text = tbxOutput.Text;

            if (!string.IsNullOrEmpty(text))
                Clipboard.SetText(text);
        }

        /// <summary>
        /// txtInput keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    20/09/2018  0.1         First write
        /// JABF    20/09/2018  0.2         Select All
        /// JABF    21/09/2018  0.3         Fix in force cap hotkey, undo
        /// </remarks>
        private void tbxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && tbxInput.SelectedText != string.Empty)
            {
                if (!tbxInput.SelectedText.Contains(Utilities.ENCLOSING_START))
                {
                    string before = tbxInput.Text.Substring(0, tbxInput.SelectionStart);
                    string after = tbxInput.Text.Substring(tbxInput.SelectionStart + tbxInput.SelectedText.Length);
                    string insertText = string.Format("{0}{1}{2}", Utilities.ENCLOSING_START, tbxInput.SelectedText, Utilities.ENCLOSING_END);

                    tbxInput.Text = $"{before}{insertText}{after}";
                    tbxInput.SelectionStart = $"{before}{insertText}".Length;
                    tbxInput.ScrollToCaret();
                }
            }
            if (e.Control && e.KeyCode == Keys.A)
                tbxInput.SelectAll();
            if (e.Control && e.KeyCode == Keys.Z)
                tbxInput.Undo();    // Why the fuck does this not delete the force caps enclosing
        }

        /// <summary>
        /// fiods fsef se fjiess
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// User    Date        Version     Description
        /// JABF    21/09/2018  0.1         First write
        /// </remarks>
        private void miSecret_Click(object sender, EventArgs e)
        {
            new FrmSecret().ShowDialog(this);
        }
    }
}