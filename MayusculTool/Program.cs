using System;
using System.Windows.Forms;
using System.IO;

namespace MayusTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">Command line parameters</param>
        /// <remarks>
        /// JABF    11/09/2018  -   First Write
        /// JABF    18/09/2018  -   Command Line input
        /// </remarks>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMain());
            }
            else
            {
                if (args.Length != 6)   // If you fuck up the paramaters, it won't work
                    MessageBox.Show("Usage: input.txt output.txt 1(caps words) 1(caps letters) 1(reversed) 1(numbers)\r\n1 turns on a feature, 0 turns it off\r\nAlso, I overwrite existing files, because fuck you!");
                else
                {
                    try
                    {
                        string inputFileName = args[0];
                        string outputFileName = args[1];
                        bool wordCaps = (args[2] == "1") ? true : false;
                        bool letterCaps = (args[3] == "1") ? true : false;
                        bool reversed = (args[4] == "1") ? true : false;
                        bool numbers = (args[5] == "1") ? true : false;

                        string inputContents = File.ReadAllText(inputFileName);
                        string outputContents = string.Empty;

                        Utilities.ConvertText(inputContents, out outputContents, wordCaps, reversed, letterCaps, numbers);

                        File.WriteAllText(outputFileName, outputContents);
                    }
                    catch (Exception e) // More likely, the file was not found
                    {
                        MessageBox.Show(e.Message, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
