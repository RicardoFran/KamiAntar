﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiAntar.Builder
{
    public interface BarangBuilder
    {
        void Additem();
        BarangBuildable getBarang();
    }
}
