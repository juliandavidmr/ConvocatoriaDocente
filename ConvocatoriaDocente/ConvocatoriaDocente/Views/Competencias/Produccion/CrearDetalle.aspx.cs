using ConvocatoriaDocente.Models;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConvocatoriaDocente.Views.Competencias.Produccion {
  public partial class CrearDetalle : Page {
    protected void Page_Load(object sender, EventArgs e) {
      if (!X.IsAjaxRequest) {

        if (Session[_CONST.SESSION_NUM_DOC] != null) {
          NumeroIdent.Text = Session[_CONST.SESSION_NUM_DOC].ToString();
          LoadProduccionDetalle();
        } else {
          NumeroIdent.Text = "No se ha detectado el registro docente.";
        }
      }
    }

    protected void Continuar_DirectClick(object sender, Ext.Net.DirectEventArgs e) {
      Response.Redirect("../Investigacion/CrearDetalle.aspx");
    }

    protected void AddDetalle_Click(object sender, DirectEventArgs e) {
      if (getCompetencia() == null) {
        MsgError();
      } else {
        produccion_detalle perdt = new produccion_detalle() {
          pndt_nombre_producto = Producto.Text,
          pndt_tipo_producto = TipoProducto.Text,
          pndt_identificador_cert = Identificador.Text,
          pndt_volumen = Volumen.Text,
          pndt_fecha_edicion = Convert.ToDateTime(FechaEdicion.Text),
          prcn_idproduccion = getCompetencia().prcn_idproduccion
        };

        if (perdt.insert_produccion_detalle()) {
          X.Msg.Notify(new NotificationConfig {
            Icon = Icon.Accept,
            Title = "Correcto",
            Html = "Se añadió '" + Producto.Text + "' a tus estudios. <br />. Asociado a '" + NumeroIdent.Text + "'"
          }).Show();
          LoadProduccionDetalle();
        } else {
          MsgError();
        }
      }
    }

    private competencia getCompetencia() {
      return Session[_CONST.SESSION_INFO_COMPETENCIA] as competencia;
    }

    void LoadProduccionDetalle() {
      ProduccionDetalle.DataSource = (new produccion_detalle()).get_produccion_detalle();
      ProduccionDetalle.DataBind();
    }

    private void MsgError(string title = "Error", string content = "Ha ocurrido un error.") {
      X.Msg.Notify(new NotificationConfig {
        Icon = Icon.Error,
        Title = title,
        Html = content
      }).Show();
      return;
    }
  }
}