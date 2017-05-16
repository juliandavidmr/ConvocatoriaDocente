using ConvocatoriaDocente.Models;
using Ext.Net;
using System;

namespace ConvocatoriaDocente.Views.Competencias.Profesional {
  public partial class CrearDetalle : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
      if (!X.IsAjaxRequest) {
        if (Session[_CONST.SESSION_NUM_DOC] != null) {
          NumeroIdent.Text = Session[_CONST.SESSION_NUM_DOC].ToString();
          LoadProfesionalDetalle();
        } else {
          NumeroIdent.Text = "No se ha detectado el registro docente.";
        }
      }
    }

    protected void Continuar_DirectClick(object sender, Ext.Net.DirectEventArgs e) {
      Response.Redirect("../Produccion/CrearDetalle.aspx");
    }

    protected void AddDetalle_Click(object sender, DirectEventArgs e) {
      if (getCompetencia() == null) {
        MsgError();
      } else {
        profesional_detalle prdet = new profesional_detalle();
        prdet.pfdt_institucion = Institucion.Text;
        prdet.pfdt_area_trabajo = AreaTrabajo.Text;
        prdet.pfdt_cargo = Cargo.Text;
        prdet.pfdt_fin = Convert.ToDateTime(FechaFinal.Text);
        prdet.pfdt_inicio = Convert.ToDateTime(FechaInicio.Text);
        prdet.pnal_idprofesional = getCompetencia().pnal_idprofesional;

        if (prdet.insert_profesional_detalle()) {
          X.Msg.Notify(new NotificationConfig {
            Icon = Icon.Accept,
            Title = "Correcto",
            Html = "Se añadió '" + AreaTrabajo.Text + "' a tus estudios. <br />. Asociado a '" + NumeroIdent.Text + "'"
          }).Show();
          LoadProfesionalDetalle();
        } else {
          MsgError();
        }
      
      }
    }

    private void LoadProfesionalDetalle() {
      ProfesionalDetalle.DataSource = (new profesional_detalle()).get_profesional_detalle();
      ProfesionalDetalle.DataBind();
    }

    private competencia getCompetencia() {
      return Session[_CONST.SESSION_INFO_COMPETENCIA] as competencia;
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