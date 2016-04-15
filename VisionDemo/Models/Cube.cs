using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VisionDemo.Models
{
    public class Cube
    {

        public Cube()
        {
            Name = "";
            Views = new List<View>();
        }

        public Cube(string _name)
        {
            Name = _name;
            Views = new List<View>();
            Expanded = false;
            Color = Color.White;
            BackColor = Color.DarkSlateGray;
        }

        public string Name { get; set; }
        public List<View> Views { get; set; }

        public bool Expanded { get; set; }

        public Color Color { get; set; }

        public Color BackColor { get; set; }

        public JObject Json()
        {
            dynamic obj = new JObject();
            obj.text = Name;
            obj.icon = "glyphicon glyphicon-unchecked";
            obj.selectedIcon = "glyphicon glyphicon-unchecked";
            obj.color = ColorTranslator.ToHtml(Color);
            obj.backColor = ColorTranslator.ToHtml(BackColor);
            obj.selectable = false;


            dynamic state = new JArray();

            dynamic expanded = new JObject();
            expanded.expanded = Expanded;          

            state.Add(expanded);
            obj.state = state;

            dynamic views = new JArray();
            foreach(View v in Views)
            {               
                views.Add(v.Json);
            }

            if (Views.Count > 0)
                obj.nodes = views;

            return obj;
        }
    }
}
