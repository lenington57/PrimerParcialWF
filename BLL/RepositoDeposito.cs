using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositoDeposito : Repositorio<Deposito>
    {
        public override bool Guardar(Deposito deposito)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Deposito.Add(deposito);
                contexto.CuentaBancaria.Find(deposito.CuentaId).Balance += deposito.Monto;
                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Deposito deposito = contexto.Deposito.Find(id);
                contexto.CuentaBancaria.Find(deposito.CuentaId).Balance -= deposito.Monto;
                contexto.Deposito.Remove(deposito);
                contexto.SaveChanges();
                paso = true;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public override Deposito Buscar(int id)
        {
            Deposito deposito = new Deposito();
            try
            {
                CuentaBancaria cuenta = new CuentaBancaria();
                deposito = _contexto.Deposito.Find(id);
                cuenta.Detalle.Count();

                foreach (var item in cuenta.Detalle)
                {
                    string s = item.CuentaBancaria.Nombre;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return deposito;
        }

        public override bool Modificar(Deposito deposito)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(deposito).State = EntityState.Modified;

                Deposito DepAnt = contexto.Deposito.Find(deposito.DepositoId);
                var cuenta = contexto.CuentaBancaria.Find(deposito.CuentaId);
                var cuentaAnt = contexto.CuentaBancaria.Find(DepAnt.CuentaId);

                if (deposito.CuentaId != DepAnt.CuentaId)
                {
                    cuenta.Balance += deposito.Monto;
                    cuentaAnt.Balance -= DepAnt.Monto;
                }
                else
                {
                    int diferencia = deposito.Monto - DepAnt.Monto;
                    cuenta.Balance += diferencia;
                }

                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

    }
}
