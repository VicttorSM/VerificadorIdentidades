using System;
using System.Collections.Generic;
using System.Text;

namespace VerificadorIdentidades.Model
{
    class CPF : Identidade
    {
        public CPF(string Id)
        {
            if (Id.Length != 9)
                throw new Exception($"Tamanho de CPF [{Id.Length}] inválido!");
            this.Id = Id;
            PreencherDigitosVerificadores();
        }

        public override void PreencherDigitosVerificadores()
        {
            V1 = 0;
            V2 = 0;
            for (int i = 0; i < Id.Length; i++)
            {
                V1 = V1 + int.Parse(Id[i].ToString()) * (9 - (i % 10));
                V2 = V2 + int.Parse(Id[i].ToString()) * (9 - ((i + 1) % 10));
            }
            V1 = (V1 % 11) % 10;
            V2 = V2 + V1 * 9;
            V2 = (V2 % 11) % 10;

            //Console.WriteLine($"V1: {V1}");
            //Console.WriteLine($"V2: {V2}");
        }
    }
}
