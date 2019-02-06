using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using DAL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimerParcialWF.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Guardar()
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            CuentaBancaria cuenta = new CuentaBancaria();
            bool paso = false;

            cuenta.CuentaBancariaId = 4;
            cuenta.Fecha = DateTime.Now;
            cuenta.Nombre = "Juan";
            cuenta.Balance = 0;

            paso = repositorio.Guardar(cuenta);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            var cuenta = BuscarM();
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();

            bool paso = false;
            cuenta.Nombre = "Alfredo";
            paso = repositorio.Modificar(cuenta);
            Assert.AreEqual(true, paso);
        }

        public CuentaBancaria BuscarM()
        {
            int id = 3;
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            CuentaBancaria cuenta = new CuentaBancaria();
            cuenta = repositorio.Buscar(id);
            return cuenta;
        }

        [TestMethod]
        public void Eliminar()
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            int id = 4;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 3;
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            CuentaBancaria cuenta = new CuentaBancaria();
            cuenta = repositorio.Buscar(id);
            Assert.IsNotNull(cuenta);
        }

        [TestMethod()]
        public void GetList()
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            List<CuentaBancaria> lista = new List<CuentaBancaria>();
            Expression<Func<CuentaBancaria, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }

        //Test de Depósitos.
        [TestMethod]
        public void GuardarD()
        {
            RepositoDeposito repositorio = new RepositoDeposito();
            Deposito deposito = new Deposito();
            bool paso = false;

            deposito.DepositoId = 3;
            deposito.Fecha = DateTime.Now;
            deposito.CuentaId = 3;
            deposito.Concepto = "Pago de Lenington";
            deposito.Monto = 200;

            paso = repositorio.Guardar(deposito);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void ModificarD()
        {
            var deposito = BuscarMD();
            RepositoDeposito repositorio = new RepositoDeposito();

            bool paso = false;
            deposito.Concepto = "Pago de Alfredo";
            paso = repositorio.Modificar(deposito);
            Assert.AreEqual(true, paso);
        }

        public Deposito BuscarMD()
        {
            int id = 2;
            RepositoDeposito repositorio = new RepositoDeposito();
            Deposito deposito = new Deposito();
            deposito = repositorio.Buscar(id);
            return deposito;
        }

        [TestMethod]
        public void EliminarD()
        {
            RepositoDeposito repositorio = new RepositoDeposito();
            int id = 3;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void BuscarD()
        {
            int id = 1;
            Repositorio<Deposito> repositorio = new Repositorio<Deposito>();
            Deposito deposito = new Deposito();
            deposito = repositorio.Buscar(id);
            Assert.IsNotNull(deposito);
        }

        [TestMethod()]
        public void GetListD()
        {
            Repositorio<Deposito> repositorio = new Repositorio<Deposito>();
            List<Deposito> lista = new List<Deposito>();
            Expression<Func<Deposito, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }
    }
}
