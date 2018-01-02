#region the GNU General Public License
/*
 *  Echomarkdown - An editor for Markdown
 *  ------------
 *  Copyright(C) 2017-2018  Narcissus Null
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.If not, see<http://www.gnu.org/licenses/>.
 */
#endregion

using MarkdownSharp;
using System.ComponentModel;
using System.Configuration;

namespace EchoMarkdown.ViewModels
{
    class MainWindowViewModel : NotificationObject
    { 
        private double height;
        private double width;
        private string title;
        private string currentFileName;
        private bool isSaved;

        public double Height
        {
            get { return height; }
            set
            {
                height = value;
                this.RaisePropertyChange("Height");
            }
        }
        
        public double Width
        {
            get { return width; }
            set
            {
                width = value;
                this.RaisePropertyChange("Width");
            }
        }
        
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                this.RaisePropertyChange("Title");
            }
        }


        public string CurrentFileName
        {
            get => currentFileName;
            set
            {
                currentFileName = value;
                Title = "EchoMarkdown - " + currentFileName;
            }
        }

        public bool IsSaved { get => isSaved; set => isSaved = value; }
    }

    class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChange(string propertyName)
        {
            if(this.PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}