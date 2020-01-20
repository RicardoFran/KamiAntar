using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Decorator
{
    public class ContentLayanan : IContentLayanan
    {
        private string _content;

        public ContentLayanan(String content)
        {
            _content = content;
        }

        public string GetContents()
        {
            return _content;
        }
    }
}
