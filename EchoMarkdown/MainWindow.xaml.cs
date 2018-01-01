using EchoMarkdown.ViewModels;
using System.Windows;
using System.Configuration;
using EchoMarkdown.Models;
using Microsoft.Win32;
using System.IO;
using EchoMarkdown.Views;

namespace EchoMarkdown
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        private TempHtml tempHtml                       = new TempHtml();
        private string choose;

        public MainWindow()
        {
            Init();
            InitializeComponent();
        }

        private void Init()
        {
            this.DataContext = mainWindowViewModel;
            mainWindowViewModel.Height = System.Convert.ToDouble(ConfigurationManager.AppSettings["Height"]);
            mainWindowViewModel.Width  = System.Convert.ToDouble(ConfigurationManager.AppSettings["Width"]);
            mainWindowViewModel.CurrentFileName = "new.md";
            mainWindowViewModel.IsSaved = true;
        }

        private void MenuNew_Click(object sender, RoutedEventArgs e)
        {
            if(!mainWindowViewModel.IsSaved)
            {
                NotSaved notSaved = new NotSaved(mainWindowViewModel.CurrentFileName);
                notSaved.Owner = this;
                notSaved.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                notSaved.ShowDialog();
                choose = notSaved.Choose;
                if (choose.Equals("cancel"))
                {
                    return;
                }
                if (choose.Equals("yes"))
                {
                    StreamWriter stream = new StreamWriter(mainWindowViewModel.CurrentFileName);
                    stream.Write(textBox.Text);
                    stream.Flush();
                    stream.Close();
                }
            }
            mainWindowViewModel.CurrentFileName = "new.md";
            textBox.Clear();
            mainWindowViewModel.IsSaved = true;
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            if(!mainWindowViewModel.IsSaved)
            {
                NotSaved notSaved = new NotSaved(mainWindowViewModel.CurrentFileName);
                notSaved.Owner = this;
                notSaved.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                notSaved.ShowDialog();
                choose = notSaved.Choose;
                if (choose.Equals("cancel"))
                {
                    return;
                }
                if (choose.Equals("yes"))
                {
                    StreamWriter stream = new StreamWriter(mainWindowViewModel.CurrentFileName);
                    stream.Write(textBox.Text);
                    stream.Flush();
                    stream.Close();
                }
            }
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = "选择文件",
                Filter = "Markdown文件(*.md)|*.md"
            };
            if (dialog.ShowDialog() == true)
            {
                mainWindowViewModel.CurrentFileName = dialog.FileName;
                textBox.Text = File.ReadAllText(mainWindowViewModel.CurrentFileName);
                mainWindowViewModel.IsSaved = true;
            }
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            if(!mainWindowViewModel.IsSaved)
            {
                StreamWriter stream = new StreamWriter(mainWindowViewModel.CurrentFileName);
                stream.Write(textBox.Text);
                stream.Flush();
                stream.Close();
                mainWindowViewModel.IsSaved = true;
            }
        }

        private void MenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "保存文件",
                Filter = "Markdown文件(*.md)|*.md",
                FileName = "Markdown.md"
             };

             if (dialog.ShowDialog() == true)
             {
                 StreamWriter stream = new StreamWriter(dialog.FileName);
                 stream.Write(textBox.Text);
                 stream.Flush();
                 stream.Close();
                 mainWindowViewModel.IsSaved = true;
             }
        }

        private void MenuSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuCount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuNo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuConfig_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFeedback_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuGetcode_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/NarcissusNull/EchoMarkdown");
        }

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            mainWindowViewModel.IsSaved = false;
            this.web.NavigateToString(tempHtml.Header + tempHtml.Markdown.Transform(textBox.Text));
        }
    }
}
