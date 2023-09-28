using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Impuesto
    {

        //número de liquidación, identificación o Nit del contribuyente, nombre o razón social del contribuyente, base gravable, tarifa y valor liquidado.
        public int NumLiquidacion { get; set; }
        public int Nit { get; set; }
        public string RazonSocial { get; set; }
        public double Valor { get; set; }
        public double BaseGravable { get; set; }
    }
}
