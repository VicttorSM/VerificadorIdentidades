using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VerificadorIdentidades.Model;

namespace VerificadorIdentidades
{
    class VerificadorIdentidades
    {
        private List<string> idPuros;
        private List<Identidade> identidades;
        public VerificadorIdentidades(List<string> idPuros)
        {
            this.idPuros = idPuros;
            identidades = new List<Identidade>();
        }

        public void VerificarIdentidades(int n)
        {
            ParallelOptions op = new ParallelOptions();
            op.MaxDegreeOfParallelism = n;
            Parallel.ForEach(idPuros, op, id =>
            {
                Identidade identidade;
                if (id.Length == 9)
                {
                    identidade = new CPF(id);
                }
                else if (id.Length == 12)
                {
                    identidade = new CNPJ(id);
                }
                else
                {
                    return;
                }

                lock (identidades)
                {
                    identidades.Add(identidade);
                }
            });
        }
    }
}
