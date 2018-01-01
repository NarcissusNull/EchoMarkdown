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
