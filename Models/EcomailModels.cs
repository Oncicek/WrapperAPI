using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrapperAPI.Models
{
    public class EcomailModels
    {
        public class Subscriber
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public Lists Lists { get; set; }
        }

        public class Lists
        {
            public int List_id { get; set; }
            public int Status { get; set; }
            public string Subscribed_at { get; set; }
            public object Unsubscribed_at { get; set; }
            public string Last_activity_at { get; set; }
            public Custom_Fields Custom_fields { get; set; }
        }

        public class Custom_Fields
        {
            public string Mmerge5 { get; set; }
        }
    }
}
