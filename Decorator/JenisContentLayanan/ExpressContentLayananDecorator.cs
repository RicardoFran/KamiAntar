using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Decorator.JenisContentLayanan
{
    public class ExpressContentLayananDecorator : ContentLayananDecorator
    {
        public string _content;
        public ExpressContentLayananDecorator(IContentLayanan original)
        {
            contentlayanan = original;
        }
        public string Express(string message)
        {
            return message+ " menggunakan jasa express";
        }
        public override string GetContents()
        {
            _content = Express(contentlayanan.GetContents());
            return _content;
        }
    }
}
