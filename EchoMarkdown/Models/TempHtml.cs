using System;
using System.Configuration;
using MarkdownSharp;

namespace EchoMarkdown.Models
{
    class TempHtml
    {
        ////定义的委托 
        public delegate void delValueChange(object sender, EventArgs e);
        //委托相关联的事件 
        public event delValueChange OnValueChanged;

        private MarkdownSharp.Markdown markdown;
        private string header;
        private string html;
        private string css;

        public TempHtml()
        {
            css = ConfigurationManager.AppSettings["Css"];
            header = "<!DOCTYPE html><head><meta charset=\"utf-8\"><link href=\"" + System.Environment.CurrentDirectory + "\\css\\"+css+"\" rel=\"stylesheet\"></link></head>";
        }

        public string Html
        {
            get => html;
            set
            {
                html = header+value;
                this.WhenValueChange();
            }
        }

        public string Header { get => header; }
        public Markdown Markdown { get => markdown; set => markdown = value; }

        public void WhenValueChange()
        {
            if (OnValueChanged != null)
            {
                OnValueChanged(this, null);
            }
        }
    }
}
