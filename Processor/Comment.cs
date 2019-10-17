using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    public class Comment
    {
        public int id { get; set; }
        public string commentText { get; set; }
        public Comment(int id, string commentText)
        {
            this.id = id;
            this.commentText = commentText;
        }
    }
}
