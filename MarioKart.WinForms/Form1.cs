using System;
using System.Windows.Forms;
using MarioKart.Core;

namespace MarioKart.WinForms
{
    public partial class Form1 : Form
    {
        private readonly Logic _logic = new();
        private ListBox listBoxRacers = new();
        private Button btnAdd = new();
        private Button btnEdit = new();
        private Button btnDelete = new();
        private Button btnFastest = new();

        public Form1()
        {
            Text = "Гараж Mario Kart (WinForms)";
            Width = 600;
            Height = 420;
            StartPosition = FormStartPosition.CenterScreen;

            listBoxRacers.SetBounds(20, 20, 540, 240);

            btnAdd.SetBounds(20, 280, 120, 35);
            btnAdd.Text = "Добавить...";
            btnAdd.Click += BtnAdd_Click;

            btnEdit.SetBounds(150, 280, 120, 35);
            btnEdit.Text = "Изменить...";
            btnEdit.Click += BtnEdit_Click;

            btnDelete.SetBounds(280, 280, 120, 35);
            btnDelete.Text = "Удалить";
            btnDelete.Click += BtnDelete_Click;

            btnFastest.SetBounds(410, 280, 150, 35);
            btnFastest.Text = "Самый быстрый";
            btnFastest.Click += BtnFastest_Click;

            Controls.AddRange(new Control[] { listBoxRacers, btnAdd, btnEdit, btnDelete, btnFastest });

            // Заполняем начальными персонажами
            _logic.AddRacer("Mario", "Средний", 7, 10);
            _logic.AddRacer("Peach", "Легкий", 6, 25);
            _logic.AddRacer("Donkey Kong", "Тяжелый", 8, 4);

            UpdateList();
        }

        private void UpdateList()
        {
            listBoxRacers.Items.Clear();
            foreach (var r in _logic.GetAllRacers())
            {
                listBoxRacers.Items.Add(r);
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            using var dialog = new RacerDialogForm();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _logic.AddRacer(dialog.RacerName, dialog.WeightClass, dialog.Speed, dialog.Coins);
                UpdateList();
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (listBoxRacers.SelectedItem is not Racer selected)
            {
                MessageBox.Show("Сначала выберите персонажа из списка!");
                return;
            }

            using var dialog = new RacerDialogForm(selected.Name, selected.WeightClass, selected.Speed, selected.Coins);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _logic.UpdateRacer(selected.Id, dialog.RacerName, dialog.WeightClass, dialog.Speed, dialog.Coins);
                UpdateList();
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (listBoxRacers.SelectedItem is not Racer selected)
            {
                MessageBox.Show("Сначала выберите персонажа для удаления!");
                return;
            }

            _logic.DeleteRacer(selected.Id);
            UpdateList();
        }

        private void BtnFastest_Click(object? sender, EventArgs e)
        {
            var fastest = _logic.GetFastestRacer();
            if (fastest != null)
                MessageBox.Show($"Самый быстрый на трассе: {fastest.Name} (Скорость: {fastest.Speed}/10)!", "Результат");
            else
                MessageBox.Show("Список пуст.");
        }
    }
}