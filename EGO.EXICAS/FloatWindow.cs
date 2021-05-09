using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EGO.SolidUI;

using Hook;

namespace EGO.EXICAS
{
    public partial class FloatWindow : IForm
    {
        public Point LocationMargin { get; set; } = Point.Empty;
        public Point StartLocation { get; set; } = Point.Empty;
        HookManager GlobalEventProvider;
        public FloatWindow()
        {
            InitializeComponent();
            GlobalEventProvider = new HookManager();
            HandleDestroyed += SelectorPopup_HandleDestroyed;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            TopMost = true;
            ReverseInvertAction = true;
            ManualThemeColor = true;
        }
        private void SelectorPopup_HandleDestroyed(object sender, EventArgs e)
        {
            GlobalEventProvider.MouseClickExt -= GlobalEventProvider_MouseClickExt;
            GlobalEventProvider.TryUnsubscribeFromGlobalMouseEvents();
        }

        private void GlobalEventProvider_MouseClickExt(object sender, MouseEventExtArgs e)
        {
            if (!this.Bounds.Contains(Cursor.Position))
            {
                e.Handled = true;
                DialogResult = DialogResult.Cancel;
                Close();
            }
            else
            {
                SelectorPopup_HandleDestroyed(sender, e);
            }
        }

        public DialogResult ShowDialog(params Control[] Buttons)
        {
            foreach (var item in Buttons)
            {
                AddItem(item);
            }
            return ShowDialog();
        }
        public void Show(params Control[] Buttons)
        {
            foreach (var item in Buttons)
            {
                AddItem(item);
            }
            Show();
        }

        public new DialogResult ShowDialog()
        {
            API.FixScroll(lst);

            this.Location = GetPosition(StartLocation);

            Sync();
            GlobalEventProvider.MouseClickExt += GlobalEventProvider_MouseClickExt;
            return base.ShowDialog();
        }
        public new void Show()
        {
            API.FixScroll(lst);

            this.Location = GetPosition(StartLocation);

            Sync();
            SetMenuThemeColor();
            GlobalEventProvider.MouseClickExt += GlobalEventProvider_MouseClickExt;
            base.Show();
        }
        private void SetMenuThemeColor()
        {
            if (DarkTheme)
            {
                ThemeColor = Color.LightSteelBlue;
            }
            else
            {
                ThemeColor = Color.MidnightBlue;
            }
        }
        public void AddItem(Control item)
        {
            item.Click += Button_Click;
            lst.Controls.Add(item);
        }
        private Point GetPosition(Point p)
        {
            var screen = Screen.GetBounds(p);
            Point widthOverFlow = new Point(p.X + Width, p.Y);
            Point HeightOverFlow = new Point(p.X, p.Y + Height);

            if (!screen.Contains(widthOverFlow)) p.X = screen.Width - Width - LocationMargin.X + screen.X;
            if (!screen.Contains(HeightOverFlow)) p.Y = screen.Height - Height - LocationMargin.Y + screen.Y;

            return p;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Tag = ((ThirdButton)sender).Tag;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
