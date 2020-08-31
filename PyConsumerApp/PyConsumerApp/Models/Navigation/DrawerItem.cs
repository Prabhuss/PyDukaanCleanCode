using System;
using System.Collections.Generic;
using System.Text;

namespace PyConsumerApp.Models.Navigation
{
    public class DrawerItem
    {
        public string Id;
        public string Name;
        public string Icon;
        public DrawerItem(string id, string name, string icon)
        {
            Id = id;
            Name = name;
            Icon = icon;
        }
    }
}
