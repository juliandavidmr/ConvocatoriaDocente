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
          LoadTiposProfesion();
          LoadCompetenciasPersonales();
        } else {
          NumeroIdent.Text = "No se ha detectado el registro docente.";
        }
      }
    }

    protected void Continuar_DirectClick(object sender, Ext.Net.DirectEventArgs e) {
      if (getCompetencia() != null) {
        Response.Redirect("../Profesional/CrearDetalle.aspx");
      } else {
        MsgError();
      }
    }

    public void LoadTiposProfesion() {
      TiposProfesion.DataSource = (new tipo_profesion()).get_tipo_profesion();
      TiposProfesion.DataBind();
    }

    protected void AddDetalle_Click(object sender, DirectEventArgs e) {
      if (getCompetencia() == null) {
        MsgError();
      } else {
        personal_detalle detalle = new personal_detalle();
        detalle.tppr_idtipoprofesion = Convert.ToInt32(TipoProfesionSelect.Value);
        detalle.prdt_universidad = Universidad.Text;
        detalle.prdt_grado = Convert.ToDateTime(FechaGraduacion.Text);
        detalle.prsl_idpersonal = getCompetencia().prsl_idpersonal;
        detalle.prdt_titulo = Titulacion.Text;

        if (detalle.insert_personal_detalle()) {
          X.Msg.Notify(new NotificationConfig {
            Icon = Icon.Accept,
            Title = "Correcto",
            Html = "Se añadió '" + this.Titulacion.Text + "' a tus estudios. <br />. Asociado a '" + NumeroIdent.Text + "'"
          }).Show();
        } else {
          MsgError(
            "Error al añadir estudio",
            "Ha ocurrido un error al añadir el estudio. Por favor verifique sus datos o contartar al administrador para mas información."
          );
        }
        LoadCompetenciasPersonales();
      }      
    }

    void LoadCompetenciasPersonales() {
      PersonalDetalle.DataSource = (new personal_detalle()).get_personal_detalle();
      PersonalDetalle.DataBind();
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