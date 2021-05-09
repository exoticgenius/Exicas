using EGO.SolidUI;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGO.EXICAS
{
    public class MenuManager
    {
        public event EventHandler About;

        public event EventHandler AddImage;

        public event EventHandler NewCollection;
        public event EventHandler OpenCollection;
        public event EventHandler CloseCurrentCollection;
        public event EventHandler SaveCollection;
        public event EventHandler SaveAsCollection;
        public event EventHandler Exit;

        public FloatWindow Menu { get; set; } = null;
        Core Core;
        public MenuManager(Core core)
        {
            Core = core;
        }
        [STAThread]
        public async void CreateMenu(Control sender)
        {
            Menu = new FloatWindow();
            Menu.ManualThemeColor = true;
            Menu.FormClosed += Menu_FormClosed;
            var bounds = sender.RectangleToScreen(sender.ClientRectangle);
            Menu.StartLocation = new Point(bounds.X, bounds.Y + bounds.Height);
            Menu.LocationMargin = new Point(0, bounds.Height);
            MenuID id = (MenuID)sender.Tag;
            Menu.Tag = id;
            List<ThirdButton> buttons = await GenerateMenuButtons(id);
            Menu.Show(buttons.ToArray());
        }

        public void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu.Dispose();
            Menu = null;
        }

        public void ReCreateMenu(Control sender)
        {
            Menu.Dispose();
            Menu = null;
            CreateMenu(sender);
        }

        public Task<List<ThirdButton>> GenerateMenuButtons(MenuID menuID)
        {
            List<ThirdButton> buttons = new List<ThirdButton>();
            switch (menuID)
            {
                case MenuID.File:
                    CreateFileMenu(buttons);
                    break;
                case MenuID.Collection:
                    CreateCollectionMenu(buttons);
                    break;
                case MenuID.About:
                    CreateAboutMenu(buttons);
                    break;
                default:
                    break;
            }
            return Task.FromResult(buttons);
        }

        public void CreateAboutMenu(List<ThirdButton> buttons)
        {
            //About

            var bAbout = PrepareButton("About", MenuButton.About); bAbout.Click += About;

            buttons.Add(bAbout);
        }

        public void CreateCollectionMenu(List<ThirdButton> buttons)
        {
            //AddImage
            //SortCollection

            var bAddImage = PrepareButton("Add Image", MenuButton.AddImage); bAddImage.Click += AddImage;

            buttons.Add(bAddImage);
        }

        public void CreateFileMenu(List<ThirdButton> buttons)
        {
            //OpenCollection
            //NewCollection
            //CloseCurrentCollection
            //SaveCollection
            //SaveAsCollection
            //Exit

            var bNewCollection = PrepareButton("New", MenuButton.OpenCollection); bNewCollection.Click += NewCollection;
            var bOpenCollection = PrepareButton("Open", MenuButton.OpenCollection); bOpenCollection.Click += OpenCollection;
            var bCloseCurrentCollection = PrepareButton("Discard", MenuButton.CloseCurrentCollection); bCloseCurrentCollection.Click += CloseCurrentCollection;
            var bSaveCollection = PrepareButton("Save", MenuButton.SaveCollection); bSaveCollection.Click += SaveCollection;
            var bSaveAsCollection = PrepareButton("Save As", MenuButton.SaveAsCollection); bSaveAsCollection.Click += SaveAsCollection;
            var bExit = PrepareButton("Exit", MenuButton.Exit); bExit.Click += Exit;

            buttons.Add(bNewCollection);
            buttons.Add(bOpenCollection);
            buttons.Add(bCloseCurrentCollection);
            buttons.Add(bSaveCollection);
            buttons.Add(bSaveAsCollection);
            buttons.Add(bExit);
        }

        public static ThirdButton PrepareButton(string text, MenuButton tag, bool reverseInvertAction = true)
        {
            ThirdButton btn = new ThirdButton();
            btn.Text = text;
            btn.Tag = tag;
            btn.Size = new Size(150, 30);
            btn.AutoSize = true;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.ReverseInvertAction = reverseInvertAction;
            btn.UseCompatibleTextRendering = true;
            return btn;
        }
    }
    public enum MenuID
    {
        File,
        Collection,
        About
    }
    public enum MenuButton
    {
        OpenCollection,
        NewCollection,
        CloseCurrentCollection,
        AddImage,
        SortCollection,
        SaveCollection,
        SaveAsCollection,
        Exit,
        About
    }
}
