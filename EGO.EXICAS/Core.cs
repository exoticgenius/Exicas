using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.IconLib;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Fractal;
using Fractal.Extensions;

namespace EGO.EXICAS
{
    public class Core
    {
        Collection _collection = new Collection();
        public bool SaveState { get; private set; }
        public event Node_INode_EventHandler ImageAdded;
        public event Node_INode_EventHandler ImageRemoved;
        public Collection CurrentCollection
        {
            get => _collection;
            set
            {
                _collection = value;
                _collection.AddedChild += ImageAdded;
                _collection.RemovedChild += ImageRemoved;
                _collection.AddedChild += _collectionSaveStateIndicator;
                _collection.RemovedChild += _collectionSaveStateIndicator;
                SaveState = true;
            }
        }
        private void _collectionSaveStateIndicator(INode sender, INode parameter1)
        {
            SaveState = false;
        }

        public void SaveCollection(bool getNewPath = false)
        {
            string path;
            if (getNewPath || string.IsNullOrWhiteSpace(CurrentCollection.LastSaveLocation) || !File.Exists(CurrentCollection.LastSaveLocation))
            {
                path = GetNewSavePath();
                if (path is null) return;
                CurrentCollection.LastSaveLocation = path;
            }
            else path = CurrentCollection.LastSaveLocation;

            using StreamWriter writer = new StreamWriter(File.OpenWrite(path));
            CurrentCollection.Collector(writer);
        }
        public void ReNewCollection()
        {
            CurrentCollection.RemoveAll();
            CurrentCollection = new Collection();
        }

        private string GetNewSavePath()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.DefaultExt = ".eec";
            fileDialog.FileName = CurrentCollection.LastSaveLocation;
            if (fileDialog.ShowDialog() != DialogResult.OK) return null;
            return fileDialog.FileName;
        }
        public void OpenCollection()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".eec";
            fileDialog.ShowDialog();
            if (string.IsNullOrWhiteSpace(fileDialog.FileName)) return;

            using StreamReader reader = new StreamReader(File.OpenRead(fileDialog.FileName));
            string data = reader.ReadToEnd();
            LoadCollection(data);
        }

        private void LoadCollection(string data)
        {
            ReNewCollection();
            CurrentCollection.SuspendState = true;
            CurrentCollection.Emitter(ref data);
            CurrentCollection.SuspendState = false;

        }

        public void AddImage()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var item in ofd.FileNames)
                    {
                        Image image = Image.FromFile(item);
                        IconImage iconImage = new IconImage();
                        iconImage.Image = image;
                        CurrentCollection.AddChild(iconImage);
                    }
                }
            }
        }

        internal void Assemble()
        {
            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "untitled.ico";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MultiIcon icons = new MultiIcon();
                SingleIcon si = icons.Add("pack");
                icons.SelectedName = "pack";
                foreach (IconImage item in CurrentCollection.PullChildren<IconImage>())
                {
                    var newImage = new Bitmap(item.Image);
                    if (newImage.Width > 256 || newImage.Height > 256)
                    {
                        MessageBox.Show($"icon with size larger than 256px width or 256px height cannot be added");
                        continue;
                    }
                    bool notExist = true;
                    foreach (var ei in si)
                    {
                        if (ei.Size.Width == newImage.Width && ei.Size.Height == newImage.Height) notExist = false;
                    }
                    if (notExist)
                    {
                        si.Add(newImage);
                    }
                    else
                    {
                        MessageBox.Show($"icon with same size cannot be added\r\nkeep one of images with size{newImage.Width}*{newImage.Height}");
                    }
                }


                icons.Save(sfd.FileName, MultiIconFormat.ICO);
            }
        }
    }
}
