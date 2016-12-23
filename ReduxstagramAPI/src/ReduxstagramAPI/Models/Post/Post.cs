using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReduxstagramAPI.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string PostCode { get; set; }
        public string Caption { get; set; }
        public int Likes { get; set; }
        public string ID { get; set; }
        public string DisplaySource { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
