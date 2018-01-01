using System.Windows;

namespace EchoMarkdown.Views
{
    /// <summary>
    /// NotSaved.xaml 的交互逻辑
    /// </summary>
    public partial class NotSaved : Window
    {
        private string choose;

        public string Choose { get => choose; set => choose = value; }

        public NotSaved(string currentFileName)
        {
            InitializeComponent();
            textBox.Text = "是否保存当前文档到:" + currentFileName;
        }

        private void MenuYes_Click(object sender, RoutedEventArgs e)
        {
            Choose = "yes";
            this.Hide();
        }

        private void MenuNo_Click(object sender, RoutedEventArgs e)
        {
            Choose = "no";
            this.Hide();
        }

        private void MenuCancel_Click(object sender, RoutedEventArgs e)
        {
            Choose = "cancel";
            this.Hide();
        }
    }
}
