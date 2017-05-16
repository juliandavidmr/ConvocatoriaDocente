using ConvocatoriaDocente.Models;
using Ext.Net;
using System;

namespace ConvocatoriaDocente.Views.Competencias.Docencia {
  public partial class CrearDetalle : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
      if (!X.IsAjaxRequest) {
        if (Session[_CONST.SESSION_NUM_DOC] != null) {
          NumeroIdent.Text = Session[_CONST.SESSION_NUM_DOC].ToString();
          LoadDocenciaDetalle();
        } else {
          NumeroIdent.Text = "No se ha detectado el registro docente.";
        }
      }
    }

    protected void Continuar_DirectClick(object sender, Ext.Net.DirectEventArgs e) {
      Response.Redirect("../Resumen.aspx");
    }

    protected void AddDetalle_Click(object sender, DirectEventArgs e) {
      if (getCompetencia() == null) {
        MsgError();
      } else {
        docencia_detalle docdet = new docencia_detalle() {
          dcdt_institucion = Institucion.Text,
          dcdt_area_trabajo = AreaTrabajo.Text,
          dcdt_cargo = Cargo.Text,
          dcdt_inicio = Convert.ToDateTime(FechaInicio.Text),
          dcdt_fin = Convert.ToDateTime(FechaFinal.Text),
          dcca_iddocencia = getCompetencia().dcca_iddocencia
        };

        if (docdet.insert_docencia_detalle()) {
          X.Msg.Notify(new NotificationConfig {
            Icon = Icon.Accept,
            Title = "Correcto",
            Html = "Se añadió '" + AreaTrabajo.Text + "' a tus estudios. <br />. Asociado a '" + NumeroIdent.Text + "'"
          }).Show();
          LoadDocenciaDetalle();
        } else {
          MsgError();
        }
      }
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

    /**
     * <summary>Consulta los detalles de docencia registrados</summary>
     */
    void LoadDocenciaDetalle() {
      DocenciaDetalle.DataSource = (new docencia_detalle()).get_docencia_detalle();
      DocenciaDetalle.DataBind();
    }
  }
}