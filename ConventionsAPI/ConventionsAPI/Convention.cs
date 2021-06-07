using System;

namespace ConventionsAPI
{
    public class Convention
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string Location { get; set; }

    }
    public class Talk
    {
        public int Id { get; set; }
        public string Speaker { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
    }
}
