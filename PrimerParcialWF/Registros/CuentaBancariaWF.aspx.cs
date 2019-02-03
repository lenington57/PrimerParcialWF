using BLL;
using Entities;
using PrimerParcialWF.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialWF.Registros
{
    public partial class CuentaBancariaWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            balanceTextBox.Text = "0";
        }

        private void Limpiar()
        {
            cuentaBancariaIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            nombreTextBox.Text = " ";
            balanceTextBox.Text = "0";
        }

        private CuentaBancaria LlenaClase()
        {
            CuentaBancaria cuenta = new CuentaBancaria();

            cuenta.CuentaBancariaId = Utils.ToInt(cuentaBancariaIdTextBox.Text);
            cuenta.Fecha = Convert.ToDateTime(fechaTextBox.Text).Date;
            cuenta.Nombre = nombreTextBox.Text;
            cuenta.Balance = Utils.ToInt(balanceTextBox.Text);

            return cuenta;

        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            CuentaBancaria cuenta = repositorio.Buscar(Utils.ToInt(cuentaBancariaIdTextBox.Text));
            if (cuenta != null)
            {
                fechaTextBox.Text = cuenta.Fecha.ToString();
                nombreTextBox.Text = cuenta.Nombre;
                balanceTextBox.Text = cuenta.Balance.ToString();
            }
            else
            {
                Response.Write("<script>alert('No se encuentra');</script>");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guadarButton_Click(object sender, EventArgs e)
        {
            BLL.Repositorio<CuentaBancaria> repositorio = new BLL.Repositorio<CuentaBancaria>();
            CuentaBancaria cuenta = new CuentaBancaria();
            bool paso = false;

            //todo: validaciones adicionales
            cuenta = LlenaClase();

            if (cuenta.CuentaBancariaId == 0)
            {
                paso = repositorio.Guardar(cuenta);
                Response.Write("<script>alert('Guardado');</script>");
                Limpiar();
            }
            else
            {
                CuentaBancaria user = new CuentaBancaria();
                int id = Utils.ToInt(cuentaBancariaIdTextBox.Text);
                BLL.Repositorio<CuentaBancaria> repository = new BLL.Repositorio<CuentaBancaria>();
                cuenta = repository.Buscar(id);

                if (user != null)
                {
                    paso = repositorio.Modificar(LlenaClase());
                    Response.Write("<script>alert('Modificado');</script>");
                }
                else
                    Response.Write("<script>alert('Id no existe');</script>");
            }

            if (paso)
            {
                Limpiar();
            }
            else
                Response.Write("<script>alert('No se pudo guardar');</script>");
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            BLL.Repositorio<CuentaBancaria> repositorio = new BLL.Repositorio<CuentaBancaria>();
            int id = Utils.ToInt(cuentaBancariaIdTextBox.Text);

            var cuenta = repositorio.Buscar(id);

            if (cuenta != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Response.Write("<script>alert('Eliminado');</script>");
                    Limpiar();
                }
                else
                    Response.Write("<script>alert('No se pudo eliminar');</script>");
            }
            else
                Response.Write("<script>alert('No existe');</script>");
        }

    }
}