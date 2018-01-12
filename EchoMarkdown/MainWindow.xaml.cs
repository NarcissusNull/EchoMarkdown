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

        //private void MenuSearch_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void MenuCount_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void MenuNo_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void MenuExport_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void MenuUpdate_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void MenuConfig_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void MenuFeedback_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/NarcissusNull/EchoMarkdown/issues");
        }

        private void MenuGetcode_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/NarcissusNull/EchoMarkdown");
        }

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Owner = this;
            about.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            about.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            mainWindowViewModel.IsSaved = false;
            this.web.NavigateToString(tempHtml.Header + tempHtml.Markdown.Transform(textBox.Text));
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Max_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState==WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if (!mainWindowViewModel.IsSaved)
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
            this.Close();
        }
    }
}