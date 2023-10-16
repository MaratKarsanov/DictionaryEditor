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
            Size = new Size(750, 500);
            MaximizeBox = false;

            var list = new ListBox()
            {
                Location = new Point(0, 0),
                Size = new Size(Width / 3, Height - 30),
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
                Name = "radioNoun",
                Text = "Noun",
            };
            var radioAdj = new RadioButton()
            {
                Location = new Point(list.Width + radioNoun.Width, currentHeight),
                Text = "Adjective",
            };
            currentHeight += radioNoun.Height;
            //radioNoun.Checked = true;

            if (radioNoun.Checked)
            {
                //var pluralText = new Label()
                //{
                //    Location = new Point(list.Width, currentHeight),
                //    Text = "Input plural form: ",
                //    AutoSize = true,
                //    Font = new Font(Font.FontFamily, 11)
                //};

                //var inputPluralForm = new TextBox()
                //{
                //    Location = new Point(list.Width + 150, currentHeight),
                //    Size = new Size(labelDictionaryWord.Width * 2, 10)
                //};
                //currentHeight += pluralText.Height;

                //var genetiveText = new Label()
                //{
                //    Location = new Point(list.Width, currentHeight),
                //    Text = "Input genetive case form: ",
                //    AutoSize = true,
                //    Font = new Font(Font.FontFamily, 11)
                //};
                //var inputGenetiveCase = new TextBox()
                //{
                //    Location = new Point(list.Width + 180, currentHeight),
                //    Size = new Size(labelDictionaryWord.Width * 2, 10)
                //};
                //currentHeight += inputGenetiveCase.Height;

                //Controls.Add(pluralText);
                //Controls.Add(inputPluralForm);
                //Controls.Add(genetiveText);
                //Controls.Add(inputGenetiveCase);
            }
            radioNoun.Checked += radioNoun_CheckedChanged;

            Controls.Add(list);
            Controls.Add(labelDictionaryWord);
            Controls.Add(inputDictionaryWord);
            Controls.Add(radioNoun);
            Controls.Add(radioAdj);

            SizeChanged += (sender, args) =>
            {
                list.Size = new Size(Width / 3, Height - 30);
                //label.Location = new Point(0, (ClientSize.Height - height * 3) / 2);
                //label.Size = new Size(ClientSize.Width, height);
                //input.Location = new Point(0, label.Bottom);
                //input.Size = label.Size;
                //button.Location = new Point(0, input.Bottom);
                //button.Size = label.Size;
            };
        }

        void radioNoun_CheckedChanged(object sender, EventArgs e)
        {
            var currentHeight = 120;
            var pluralText = new Label()
            {
                Location = new Point(Width / 3, currentHeight),
                Text = "Input plural form: ",
                AutoSize = true,
                Font = new Font(Font.FontFamily, 11)
            };

            var inputPluralForm = new TextBox()
            {
                Location = new Point(Width / 3 + 150, currentHeight),
                Size = new Size(100, 10)
            };
            currentHeight += pluralText.Height;

            var genetiveText = new Label()
            {
                Location = new Point(Width / 3, currentHeight),
                Text = "Input genetive case form: ",
                AutoSize = true,
                Font = new Font(Font.FontFamily, 11)
            };
            var inputGenetiveCase = new TextBox()
            {
                Location = new Point(Width / 3 + 180, currentHeight),
                Size = new Size(100, 10)
            };
            currentHeight += inputGenetiveCase.Height;

            Controls.Add(pluralText);
            Controls.Add(inputPluralForm);
            Controls.Add(genetiveText);
            Controls.Add(inputGenetiveCase);
        }
    }
}
