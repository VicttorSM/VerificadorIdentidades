using System;
using System.Collections.Generic;
using System.Text;

namespace VerificadorIdentidades.Model
{
    abstract class Identidade
    {
        protected string Id { get; set; }
        protected int V1 { get; set; }
        protected int V2 { get; set; }

        public abstract void PreencherDigitosVerificadores();
    }
}
