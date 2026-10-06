using System;
using System.Windows.Forms;

namespace MarioKart.WinForms
{
    public partial class RacerDialogForm : Form
    {
        public string RacerName => txtName.Text;
        public string WeightClass => cmbWeight.SelectedItem?.ToString() ?? "Средний";
        public int Speed => (int)numSpeed.Value;
        public int Coins => (int)numCoins.Value;

        private TextBox txtName = new();
        private ComboBox cmbWeight = new();
        private NumericUpDown numSpeed = new();
        private NumericUpDown numCoins = new();
        private Button btnSave = new();

        public RacerDialogForm(string name = "", string weight = "Средний", int speed = 5, int coins = 0)
        {
            Text = "Параметры гонщика Mario Kart";
            Width = 320;
            Height = 240;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;

            var lbl1 = new Label { Text = "Имя:", Top = 15, Left = 15, Width = 80 };
            txtName.SetBounds(100, 12, 180, 20);
            txtName.Text = name;

            var lbl2 = new Label { Text = "Вес:", Top = 45, Left = 15, Width = 80 };
            cmbWeight.SetBounds(100, 42, 180, 20);
            cmbWeight.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWeight.Items.AddRange(new[] { "Легкий", "Средний", "Тяжелый" });
            cmbWeight.SelectedItem = weight;

            var lbl3 = new Label { Text = "Скорость:", Top = 75, Left = 15, Width = 80 };
            numSpeed.SetBounds(100, 72, 180, 20);
            numSpeed.Minimum = 1;
            numSpeed.Maximum = 10;
            numSpeed.Value = speed >= 1 && speed <= 10 ? speed : 5;

            var lbl4 = new Label { Text = "Монеты:", Top = 105, Left = 15, Width = 80 };
            numCoins.SetBounds(100, 102, 180, 20);
            numCoins.Maximum = 999;
            numCoins.Value = coins;

            btnSave.Text = "Сохранить";
            btnSave.SetBounds(100, 145, 100, 30);
            btnSave.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };

            Controls.AddRange(new Control[] { lbl1, txtName, lbl2, cmbWeight, lbl3, numSpeed, lbl4, numCoins, btnSave });
        }
    }
}