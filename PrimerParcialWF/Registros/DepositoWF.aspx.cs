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
    public partial class DepositoWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CuentaBancaria cuenta = new CuentaBancaria();

            if (!Page.IsPostBack)
            {
                LlenarCombo();
                ViewState["Deposito"] = new Deposito();
            }
        }

        private void LlenarCombo()
        {
            Repositorio<CuentaBancaria> repositorio = new Repositorio<CuentaBancaria>();
            cuentaDropDownList.DataSource = repositorio.GetList(c => true);
            cuentaDropDownList.DataValueField = "CuentaBancariaId";
            cuentaDropDownList.DataTextField = "Nombre";
            cuentaDropDownList.DataBind();
            cuentaDropDownList.Items.Insert(0, new ListItem("", ""));
        }

        protected void BindGrid()
        {
            depositoGridView.DataSource = ((Deposito)ViewState["Deposito"]).CuentaBancaria.Detalle;
            depositoGridView.DataBind();
        }

        public Deposito LlenarClase()
        {
            Deposito deposito = new Deposito();

            deposito = (Deposito)ViewState["Deposito"];

            deposito.DepositoId = Utils.ToInt(depositoIdTextBox.Text);
            deposito.Fecha = Utils.ToDateTime(fechaTextBox.Text).Date;
            deposito.CuentaId = Utils.ToInt(cuentaDropDownList.SelectedValue);
            deposito.Concepto = conceptoTextBox.Text;
            deposito.Monto = Utils.ToInt(totalTextBox.Text);

            return deposito;
        }

        protected void Limpiar()
        {
            depositoIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cuentaDropDownList.SelectedIndex = 0;
            montoTextBox.Text = "0";
            totalTextBox.Text = "0";
            ViewState["Deposito"] = new Deposito();
            this.BindGrid();
        }

        public void LlenarCampos(Deposito deposito)
        {
            Limpiar();
            depositoIdTextBox.Text = deposito.DepositoId.ToString();
            fechaTextBox.Text = deposito.Fecha.ToString("yyyy-MM-dd");
            cuentaDropDownList.SelectedIndex = deposito.CuentaId;
            montoTextBox.Text = deposito.Monto.ToString();
            this.BindGrid();
            totalTextBox.Text = deposito.Monto.ToString();
        }

        private void LlenarValores()
        {
            List<Deposito> detalle = new List<Deposito>();

            if (depositoGridView.DataSource != null)
            {
                detalle = (List<Deposito>)depositoGridView.DataSource;
            }
            double Total = 0;
            foreach (var item in detalle)
            {
                Total += item.Monto;
            }
            totalTextBox.Text = Total.ToString();
        }

        protected void agregarButton_Click(object sender, EventArgs e)
        {
            //Deposito deposito = new Deposito();

            //deposito = (Deposito)ViewState["Deposito"];
            //deposito.AgregarDetalle(0, egreso.EgresoId,
            //        ToInt(categoriaDropDownList.SelectedValue), conceptoTextBox.Text, ToInt(montoTextBox.Text));

            //ViewState["Deposito"] = cuen;

            //this.BindGrid();
            //LlenarValores();
        }
    }
}