//Austin Henley
//azh321@gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CopyCodePasta
{
    public partial class Form1 : Form
    {
        GlobalKeyboardHook hook = new GlobalKeyboardHook();
        Dictionary<string, Tuple<int, int, string>> variables;
        string originalText;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hook.HookedKeys.Add(Keys.V);
            hook.KeyDown += new KeyEventHandler(PasteEvent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            variables = new Dictionary<string, Tuple<int, int, string>>();
            originalText = textBox1.Text;

            MatchCollection matches = Regex.Matches(originalText, @"\$\$[^$$\r\n]*\$\$");
            foreach (Match match in matches)
            {
                string result = match.Value.Replace("$$", "").Replace(" ", "");
                String[] csv = result.Split(',');
                if(!variables.ContainsKey(csv[0]))
                    variables.Add(csv[0], new Tuple<int, int, string>(int.Parse(csv[1]), int.Parse(csv[2]), match.Value));
            }
        }

        private void PasteEvent(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                string changedText = originalText;

                MatchCollection matches = Regex.Matches(originalText, @"\$\$[^$$\r\n]*\$\$");
                foreach (Match match in matches)
                {
                    string result = match.Value.Replace("$$", "").Replace(" ", "");
                    String[] csv = result.Split(',');
                    var variable = variables[csv[0]];
                    changedText = changedText.Replace(match.Value, variable.Item1.ToString());
                    
                }
                List<string> keys = new List<string>(variables.Keys);
                foreach (var key in keys)
                {
                    var variable = variables[key];
                    variables[key] = new Tuple<int, int, string>(variable.Item1 + variable.Item2, variable.Item2, variable.Item3);
                }


                //List<string> keys = new List<string>(variables.Keys);
                //foreach (var key in keys)
                //{
                //    var variable = variables[key];
                //    changedText = changedText.Replace(variable.Item3, "!!!");
                //    changedText = changedText.Replace("!!!", variable.Item1.ToString());
                //    variables[key] = new Tuple<int, int, string>(variable.Item1 + variable.Item2, variable.Item2, variable.Item3);
                //}
                //changedText = changedText.Replace("$$", "");

                Clipboard.SetDataObject(changedText, true, 10, 50);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hook.HookedKeys.Clear();
        }
    }
}
