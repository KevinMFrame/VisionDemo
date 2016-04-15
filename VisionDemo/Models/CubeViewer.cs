using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VisionDemo.Models
{
    public class CubeViewer
    {
        public List<Cube> Cubes { get; set; }
        public CubeViewer(List<Cube> _cubes)
        {
            Cubes = _cubes;
        }

        public string Json
        {
            get
            {
                dynamic master = new JArray();

                foreach (Cube c in Cubes)
                {
                    master.Add(c.Json());
                }

                return master.ToString();
            }
        }

    }
}