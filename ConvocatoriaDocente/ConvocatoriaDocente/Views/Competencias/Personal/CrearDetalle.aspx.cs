using ConvocatoriaDocente.Models;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ConvocatoriaDocente.Views.Competencias.Personal {
  public partial class CrearDetalle : Page {
    protected void Page_Load(object sender, EventArgs e) {
      if (!X.IsAjaxRequest) {

        if (Session[_CONST.SESSION_NUM_DOC] != null) {
          NumeroIdent.Text = Session[_CONST.SESSION_NUM_DOC].ToString();
        } else {
          NumeroIdent.Text = "No se ha detectado el registro docente.";
        }
      }
    }

    protected void Continuar_DirectClick(object sender, Ext.Net.DirectEventArgs e) {
      Response.Redirect("../Profesional/CrearDetalle.aspx");
    }

    protected void AddDetalle_Click(object sender, DirectEventArgs e) {
      X.Msg.Notify(new NotificationConfig {
        Icon = Icon.Accept,
        Title = "Correcto",
        Html = "Se añadió '" + this.Titulacion.Text + "' a tus estudios. <br />. Asociado a '" + NumeroIdent.Text + "'"
      }).Show();
    }
  }
}