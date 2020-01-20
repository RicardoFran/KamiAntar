using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Decorator
{
    public abstract class ContentLayananDecorator : IContentLayanan
    {
        protected IContentLayanan contentlayanan;
        public abstract string GetContents();
    }
}
