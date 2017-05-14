using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConvocatoriaDocente.Views.Competencias.Investigacion {
  public partial class CrearDetalle : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void Continuar_DirectClick(object sender, Ext.Net.DirectEventArgs e) {
      Response.Redirect("../Personal/CrearDetalle.aspx");
    }

    protected void AddDetalle_Click(object sender, DirectEventArgs e) {
      X.Msg.Notify(new NotificationConfig {
        Icon = Icon.Accept,
        Title = "Correcto",
        Html = "Se añadió '" + NombreInvestigacion.Text + "' a tus estudios. <br />"
      }).Show();
    }
  }
}