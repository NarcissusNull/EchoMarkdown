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

using System;
using System.Reflection;
using System.Windows;

namespace EchoMarkdown.Views
{
    /// <summary>
    /// About.xaml 的交互逻辑
    /// </summary>
    public partial class About : Window
    {
        private string Version;
        private string Title;
        private string Description;
        private string Copyright;
        public About()
        {
            InitializeComponent();
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0];
            Title = assemblyTitleAttribute.Title;
            AssemblyCopyrightAttribute assemblyCopyrightAttribute = (AssemblyCopyrightAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0];
            Copyright = assemblyCopyrightAttribute.Copyright;
            textBox.Text = Title + "\r\n\r\n" + "Lience GPL v3.0" + "\r\n\r\n" + "版本 " + Version + "\r\n\r\n" + Copyright;
        }

        private void MenuOK_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
