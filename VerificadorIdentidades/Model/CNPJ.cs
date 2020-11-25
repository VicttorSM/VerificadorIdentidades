using System;
using System.Collections.Generic;
using System.Text;

namespace VerificadorIdentidades.Model
{
    class CNPJ : Identidade
    {
        public CNPJ(string Id)
        {
            if (Id.Length != 12)
                throw new Exception($"Tamanho de CNPJ [{Id.Length}] inválido!");
            this.Id = Id;
            PreencherDigitosVerificadores();
        }

        public override void PreencherDigitosVerificadores()
        {
            V1 = 5 * int.Parse(Id[0].ToString()) 
                + 4 * int.Parse(Id[1].ToString())
                + 3 * int.Parse(Id[2].ToString())
                + 2 * int.Parse(Id[3].ToString());
            V1 += 9 * int.Parse(Id[4].ToString())
                + 8 * int.Parse(Id[5].ToString())
                + 7 * int.Parse(Id[6].ToString())
                + 6 * int.Parse(Id[7].ToString());
            V1 += 5 * int.Parse(Id[8].ToString())
                + 4 * int.Parse(Id[9].ToString())
                + 3 * int.Parse(Id[10].ToString())
                + 2 * int.Parse(Id[11].ToString());
            V1 = 11 - V1 % 11;
            if (V1 >= 10)
                V1 = 0;

            V2 = 6 * int.Parse(Id[0].ToString())
                + 5 * int.Parse(Id[1].ToString())
                + 4 * int.Parse(Id[2].ToString())
                + 3 * int.Parse(Id[3].ToString());
            V2 += 2 * int.Parse(Id[4].ToString())
                + 9 * int.Parse(Id[5].ToString())
                + 8 * int.Parse(Id[6].ToString())
                + 7 * int.Parse(Id[7].ToString());
            V2 += 6 * int.Parse(Id[8].ToString())
                + 5 * int.Parse(Id[9].ToString())
                + 4 * int.Parse(Id[10].ToString())
                + 3 * int.Parse(Id[11].ToString());
            V2 += 2 * V1;
            V2 = 11 - V2 % 11;
            if (V2 >= 10)
                V2 = 0;

            //Console.WriteLine($"V1: {V1}");
            //Console.WriteLine($"V2: {V2}");
        }
    }
}
