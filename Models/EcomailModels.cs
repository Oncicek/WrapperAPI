namespace WrapperAPI.Models
{
    public class EcomailModels
    {
        public class Ecomail_Subscriber
        {
            public Subscriber_data Subscriber_data { get; set; }
        }

        public class Subscriber_data
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
        }
    }
}
