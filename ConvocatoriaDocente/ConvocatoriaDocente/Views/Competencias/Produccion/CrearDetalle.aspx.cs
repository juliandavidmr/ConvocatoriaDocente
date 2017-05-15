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

    }

    protected void Continuar_DirectClick(object sender, Ext.Net.DirectEventArgs e) {
      Response.Redirect("../Investigacion/CrearDetalle.aspx");
    }

    protected void AddDetalle_Click(object sender, DirectEventArgs e) {
      X.Msg.Notify(new NotificationConfig {
        Icon = Icon.Accept,
        Title = "Correcto",
        Html = "Se añadió '" + Producto.Text + "' a tus estudios. <br />. Asociado a '" + NumeroIdent.Text + "'"
      }).Show();
    }
  }
}