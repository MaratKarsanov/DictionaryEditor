using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
//using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "Редактор словаря";
            Name = "MainForm";
            Size = new Size(800, 600);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            var list = new ListBox()
            {
                Name = "MainList",
                Location = new Point(0, 0),
                Size = new Size(Width / 3, Height - 37),
                ItemHeight = 100
            };

            var phrasesList = new ListBox()
            {
                Name = "PhrasesList",
                Location = new Point(Width / 3, Height / 2 + 15),
                Size = new Size(Width / 2 + 107, Height / 2 - 39),
                ItemHeight = 100
            };

            var currentHeight = 0;

            var labelDictionaryWord = new Label()
            {
                Location = new Point(list.Width, 0),
                Text = "Input new word:",
                AutoSize = true,
                Font = new Font(Font.FontFamily, 11)
            };
            currentHeight += labelDictionaryWord.Height;

            var inputDictionaryWord = new TextBox()
            {
                Location = new Point(list.Width, currentHeight),
                Size = new Size(labelDictionaryWord.Width * 2, 10)
            };
            currentHeight += inputDictionaryWord.Height;
            list.Items.Add("First item");
            list.Items.Add("Second item");

            var radioNoun = new RadioButton()
            {
                Location = new Point(list.Width, currentHeight),
                Name = "RadioNoun",
                Text = "Noun",
            };
            var radioAdj = new RadioButton()
            {
                Location = new Point(list.Width + radioNoun.Width, currentHeight),
                Text = "Adjective",
            };
            currentHeight += radioNoun.Height;

            radioNoun.CheckedChanged += radioNoun_CheckedChanged;
            radioAdj.CheckedChanged += radioAdj_CheckedChanged;

            Controls.Add(list);
            Controls.Add(phrasesList);
            Controls.Add(labelDictionaryWord);
            Controls.Add(inputDictionaryWord);
            Controls.Add(radioNoun);
            Controls.Add(radioAdj);

            SizeChanged += (sender, args) =>
            {
                list.Size = new Size(Width / 3, Height - 30);
            };
        }

        void radioNoun_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                if (Controls.ContainsKey("PluralText"))
                {
                    Controls.Find("PluralText", true).First().Show();
                    Controls.Find("InputPluralForm", true).First().Show();
                    Controls.Find("GenetiveText", true).First().Show();
                    Controls.Find("InputGenetiveCase", true).First().Show();
                    Controls.Find("InputPhrase", true).First().Show();
                    Controls.Find("PhraseText", true).First().Show();
                }
                else
                {
                    var currentHeight = 70;
                    var pluralText = new Label()
                    {
                        Name = "PluralText",
                        Location = new Point(Width / 3, currentHeight),
                        Text = "Input plural form: ",
                        AutoSize = true,
                        Font = new Font(Font.FontFamily, 11)
                    };

                    var inputPluralForm = new TextBox()
                    {
                        Name = "InputPluralForm",
                        Location = new Point(Width / 3 + 180, currentHeight),
                        Size = new Size(200, 10)
                    };
                    currentHeight += inputPluralForm.Height;

                    var genetiveText = new Label()
                    {
                        Name = "GenetiveText",
                        Location = new Point(Width / 3, currentHeight),
                        Text = "Input genetive case form: ",
                        AutoSize = true,
                        Font = new Font(Font.FontFamily, 11)
                    };
                    var inputGenetiveCase = new TextBox()
                    {
                        Name = "InputGenetiveCase",
                        Location = new Point(Width / 3 + 180, currentHeight),
                        Size = new Size(200, 10)
                    };
                    currentHeight += inputGenetiveCase.Height;

                    var phraseText = new Label()
                    {
                        Name = "PhraseText",
                        Location = new Point(Width / 3, currentHeight),
                        Text = "Input phrase: ",
                        AutoSize = true,
                        Font = new Font(Font.FontFamily, 11)
                    };
                    var inputPhrase = new TextBox()
                    {
                        Name = "InputPhrase",
                        Location = new Point(Width / 3 + 180, currentHeight),
                        Size = new Size(200, 10)
                    };

                    Controls.Add(pluralText);
                    Controls.Add(inputPluralForm);
                    Controls.Add(genetiveText);
                    Controls.Add(inputGenetiveCase);
                    Controls.Add(phraseText);
                    Controls.Add(inputPhrase);
                }
            }
        }

        void radioAdj_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Controls.Find("PluralText", true).First().Hide();
                Controls.Find("InputPluralForm", true).First().Hide();
                Controls.Find("GenetiveText", true).First().Hide();
                Controls.Find("InputGenetiveCase", true).First().Hide();
                Controls.Find("InputPhrase", true).First().Hide();
                Controls.Find("PhraseText", true).First().Hide();
            }
            
        }
    }
}
