using System.ComponentModel;

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