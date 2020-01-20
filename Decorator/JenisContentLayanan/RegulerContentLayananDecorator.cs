using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Decorator.JenisContentLayanan
{
    public class RegulerContentLayananDecorator : ContentLayananDecorator
    {
        public string _content;
        public RegulerContentLayananDecorator(IContentLayanan original)
        {
            contentlayanan = original;
        }
        public string Reguler(string message)
        {
            return message+ " menggunakan jasa reguler";
        }
        public override string GetContents()
        {
            _content = Reguler(contentlayanan.GetContents());
            return _content;
        }
    }
}
