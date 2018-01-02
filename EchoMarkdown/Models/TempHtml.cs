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
using System.Configuration;
using MarkdownSharp;

namespace EchoMarkdown.Models
{
    class TempHtml
    {
        private Markdown markdown;
        private string header;
        private string css;

        public TempHtml()
        {
            markdown = new Markdown();
            css = ConfigurationManager.AppSettings["Css"];
            header = "<!DOCTYPE html><head><meta charset=\"utf-8\"><link href=\"" + System.Environment.CurrentDirectory + "\\css\\"+css+"\" rel=\"stylesheet\"></link></head>";
        }

        public string Header { get => header; }
        public Markdown Markdown { get => markdown; set => markdown = value; }
    }
}
