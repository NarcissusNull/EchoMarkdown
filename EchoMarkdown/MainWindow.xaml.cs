using EchoMarkdown.ViewModels;
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Configuration;
using EchoMarkdown.Models;
using MarkdownSharp;

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
            tempHtml.OnValueChanged += new TempHtml.delValueChange(P_OnValueChanged);
            tempHtml.Markdown = new Markdown();
        }

        private void P_OnValueChanged(object sender, EventArgs e)
        {
            string s = (sender as TempHtml).Html;
            this.web.NavigateToString(tempHtml.Header + s);
        }

        private void RichTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            tempHtml.Html = tempHtml.Markdown.Transform(textRange.Text);
        }

        private void MenuNew_Click(object sender, RoutedEventArgs e)
        {
            if(mainWindowViewModel.IsSaved)
            {
                mainWindowViewModel.CurrentFileName = "new.md";
                mainWindowViewModel.IsSaved = false;
                this.richTextBox.Document.Blocks.Clear();
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
    }
}
