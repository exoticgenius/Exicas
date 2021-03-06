using EGO.SolidUI;

using Fractal.Extensions;

using System;
using System.Drawing;
using System.Drawing.IconLib;
using System.IO;
using System.Windows.Forms;

namespace EGO.EXICAS
{
    public partial class Main : IForm
    {
        MenuManager MenuManager;
        Core Core;
        public Main(Core core)
        {
            InitializeComponent();
            Core = core;
            MenuManager = new MenuManager(Core);

            lbl_head.MouseDown += MouseKeyDown;

            MenuManager.About += MenuManager_About;
            MenuManager.AddImage += MenuManager_AddImage;
            MenuManager.NewCollection += MenuManager_NewCollection;
            MenuManager.OpenCollection += MenuManager_OpenCollection;
            MenuManager.CloseCurrentCollection += MenuManager_CloseCurrentCollection;
            MenuManager.SaveCollection += MenuManager_SaveCollection;
            MenuManager.SaveAsCollection += MenuManager_SaveAsCollection;
            MenuManager.Exit += MenuManager_Exit;
            Core.ImageAdded += Core_ImageAdded;
            Core.ImageRemoved += Core_ImageRemoved;
            ReNewCollection();
            btn_menu_file.Tag = MenuID.File;
            btn_menu_coll.Tag = MenuID.Collection;
            btn_menu_about.Tag = MenuID.About;
            Sync();
        }

        private void Core_ImageRemoved(Fractal.INode sender, Fractal.INode parameter1)
        {
            foreach (IconImageControl item in pnl_items.Controls)
            {
                if (item.Image != parameter1) continue;

                pnl_items.Controls.Remove(item);
                (parameter1 as IconImage).Image.Dispose();
                (parameter1 as IconImage).Features.Clear();
                break;
            }
        }

        private void Core_ImageAdded(Fractal.INode sender, Fractal.INode parameter1)
        {
            IconImageControl iic = new IconImageControl((IconImage)parameter1);
            iic.ShowThumbnail += Iic_ShowThumbnail;
            iic.RemoveCurrent += Iic_RemoveCurrent;
            pnl_items.Controls.Add(iic);
        }

        private void Iic_RemoveCurrent(object sender, EventArgs e)
        {
            Core.CurrentCollection.RemoveChild(((sender as Control).Parent as IconImageControl).Image);
        }

        private void Iic_ShowThumbnail(object sender, EventArgs e)
        {
            pic_preview.Image = API.ResizeImage(((sender as Control).Parent as IconImageControl).Image.Image, pic_preview.Width, pic_preview.Height);
        }

        private void MenuManager_SaveAsCollection(object sender, EventArgs e)
        {
            Core.SaveCollection(true);
        }

        private void MenuManager_SaveCollection(object sender, EventArgs e)
        {
            Core.SaveCollection();
        }

        private void MenuManager_CloseCurrentCollection(object sender, EventArgs e)
        {
            ReNewCollection();
        }

        private void MenuManager_OpenCollection(object sender, EventArgs e)
        {
            Core.OpenCollection();
            LoadControls();
        }

        private void LoadControls()
        {
            foreach (var item in Core.CurrentCollection.PullChildren())
            {
                Core.CurrentCollection.OnAddedChild(Core.CurrentCollection, item);
            }
        }

        private void MenuManager_NewCollection(object sender, EventArgs e)
        {
            if (Core.CurrentCollection.ChildrenCount == 0) return;

            if (Core.SaveState)
                ReNewCollection();

            var res = MessageBox.Show("save changes to current collection?", "exicas", MessageBoxButtons.YesNoCancel);
            switch (res)
            {
                case DialogResult.Yes:
                    {
                        Core.SaveCollection();
                    }
                    break;
                case DialogResult.No:
                    ReNewCollection();
                    break;
            }
        }

        private void ReNewCollection()
        {
            Core.ReNewCollection();
            pic_preview.Image = null;
        }
        
       

        private void MenuManager_AddImage(object sender, EventArgs e)
        {
            Core.AddImage();
        }

        private void MenuManager_About(object sender, EventArgs e)
        {
            MessageBox.Show("created by exotic genius\r\nfarshad sadeghi");
        }

        private void MenuManager_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            if (MenuManager.Menu is null)
            {
                MenuManager.CreateMenu(sender as Control);
            }
            else
            {
                MenuManager.ReCreateMenu(sender as Control);
            }
        }

        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            if (MenuManager.Menu is null) return;
            if (MenuManager.Menu.Tag == (sender as Control).Tag) return;
            MenuManager.ReCreateMenu(sender as Control);
        }

        private void btn_close_Click(object sender, EventArgs e) => Close();

        private void btnTheme_Click(object sender, EventArgs e)
        {
            if (SolidSettings.DarkTheme)
            {
                SolidSettings.DarkTheme_NoTrigger = false;
                SolidSettings.ThemeColor_NoTrigger = Color.MidnightBlue;
            }
            else
            {
                SolidSettings.DarkTheme_NoTrigger = true;
                SolidSettings.ThemeColor_NoTrigger = Color.LightSteelBlue;
            }
            SolidSettings.SetStyle();
        }

        private void btn_assemble_Click(object sender, EventArgs e)
        {
            Core.Assemble();
        }
    }
}
