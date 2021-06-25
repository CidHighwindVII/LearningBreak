using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningBreakAPI.Dtos
{
    public class SearchResultToReturnDto
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _link;
        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        private string _ImageLink;
        public string ImageLink
        {
            get { return _ImageLink; }
            set { _ImageLink = value; }
        }
    }
}
