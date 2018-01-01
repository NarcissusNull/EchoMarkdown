using EchoMarkdown.ViewModels;
using System.Windows;
using System.Configuration;
using MarkdownSharp;
using EchoMarkdown.Models;

namespace EchoMarkdown
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        private TempHtml tempHtml                       = new TempHtml();

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
            if(mainWindowViewModel.IsSaved)
            {
                mainWindowViewModel.CurrentFileName = "new.md";
                mainWindowViewModel.IsSaved = false;
                textBox.Clear();
            }
            else
            {
                //TODO[未保存界面]
            }
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuSaveAs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuUndo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuRedo_Click(object sender, RoutedEventArgs e)
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

        }

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            this.web.NavigateToString(tempHtml.Header + tempHtml.Markdown.Transform(textBox.Text));
        }
    }
}
