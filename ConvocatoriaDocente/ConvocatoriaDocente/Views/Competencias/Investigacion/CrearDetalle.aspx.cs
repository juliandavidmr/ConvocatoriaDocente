using ConvocatoriaDocente.Models;
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
      if (!X.IsAjaxRequest) {
        if (Session[_CONST.SESSION_NUM_DOC] != null) {
          NumeroIdent.Text = Session[_CONST.SESSION_NUM_DOC].ToString();
          LoadInvestigacionesDetalle();
        } else {
          NumeroIdent.Text = "No se ha detectado el registro docente.";
        }
      }
    }

    protected void Continuar_DirectClick(object sender, Ext.Net.DirectEventArgs e) {
      Response.Redirect("../Docencia/CrearDetalle.aspx");
    }

    protected void AddDetalle_Click(object sender, DirectEventArgs e) {
      if (getCompetencia() == null) {
        MsgError();
      } else {
        investigacion_detalle inv_dt = new investigacion_detalle() {
          invd_financiadora = Financiadora.Text,
          invd_fecha_inicio = Convert.ToDateTime(FechaInicio.Text),
          invd_fecha_fin = Convert.ToDateTime(FechaFinal.Text),
          invd_nombre = NombreInvestigacion.Text,
          invn_idinvestigacion = getCompetencia().invn_idinvestigacion
        };

        if(inv_dt.insert_investigacion_detalle()) {          
          X.Msg.Notify(new NotificationConfig {
            Icon = Icon.Accept,
            Title = "Correcto",
            Html = "Se añadió '" + NombreInvestigacion.Text + "' a tus estudios. <br />"
          }).Show();
        } else {
          MsgError();
        }

        LoadInvestigacionesDetalle();
      }

    }

    private competencia getCompetencia() {
      return Session[_CONST.SESSION_INFO_COMPETENCIA] as competencia;
    }

    void LoadInvestigacionesDetalle() {
      InvestigacionDetalle.DataSource = (new investigacion_detalle()).get_investigacion_detalle();
      InvestigacionDetalle.DataBind();
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