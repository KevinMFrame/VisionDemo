using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace VisionDemo.Models
{
    public class View
    {
        public View(string _name)
        {
            Name = _name;
            Data = "";
            Color = Color.Black;
            BackColor = Color.LightGray;
        }

        public string Name { get; set; }
        public string Data { get; set; }

        public Color Color { get; set; }

        public Color BackColor { get; set; }

        public JObject Json
        {
            get
            {
                dynamic obj = new JObject();
                obj.text = Name;
                obj.icon = "glyphicon glyphicon-eye-open";
                obj.selectedIcon = "glyphicon glyphicon-eye-open";
                obj.color = ColorTranslator.ToHtml(Color);
                obj.backColor = ColorTranslator.ToHtml(BackColor);

                return obj;
            }
        }
    }
}