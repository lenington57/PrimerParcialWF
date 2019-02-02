using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class CuentaBancaria
    {
        [Key]
        public int CuentaBancariaId { get; set; }

        public DateTime Fecha { get; set; }

        public string Nombre { get; set; }

        public int Balance { get; set; }

        public virtual List<Deposito> Detalle { get; set; }


        public CuentaBancaria()
        {
            this.Detalle = new List<Deposito>();
        }

        public void AgregarDetalle(int DepositoId, DateTime Fecha, int CuentaId, string Concepto, int Monto)
        {
            this.Detalle.Add(new Deposito(DepositoId, Fecha, CuentaId, Concepto, Monto));
        }
        
    }
}
