using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Decorator.JenisContentLayanan
{
    public class AddBarangContentLayananDecorator : ContentLayananDecorator
    {
        public string _content;
        public AddBarangContentLayananDecorator(IContentLayanan original)
        {
            contentlayanan = original;
        }
        public string AddBarang(string message)
        {
            return message+ "tambah barang ";
        }
        public override string GetContents()
        {
            _content = AddBarang(contentlayanan.GetContents());
            return _content;
        }
    }
}
