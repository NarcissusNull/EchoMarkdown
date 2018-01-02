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
            textBox.Text = "\r\n\r\n是否保存当前文档到:\r\n\r\n" + currentFileName;
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
