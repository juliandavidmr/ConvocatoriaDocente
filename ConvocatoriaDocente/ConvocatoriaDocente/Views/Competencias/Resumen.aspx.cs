using ConvocatoriaDocente.Models;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConvocatoriaDocente.Views.Competencias {
  public partial class Resumen : Page {
    protected void Page_Load(object sender, EventArgs e) {
      if (!X.IsAjaxRequest) {
        LoadResumen();
      }
    }

    private void LoadResumen() {
      if (getCompetencia() != null) {
        DataTable resu = (new resumen()).get_resumen(getCompetencia().dcnt_iddocente);
        if(resu.Rows.Count > 0) {
          DataRow row = resu.Rows[0];
          Nombres.Text = row["DCNT_NOMBRES"].ToString();
          Apellido1.Text = row["DCNT_APELLIDO1"].ToString();
          Apellido2.Text = row["DCNT_APELLIDO2"].ToString();
          Nacimiento.Text = row["DCNT_FECHA_NAC"].ToString();
          Fijo.Text = row["DCNT_NUM_TEL_FIJO"].ToString();
          Movil.Text = row["DCNT_NUM_TEL_MOVIL"].ToString();
          Email.Text = row["DCNT_EMAIL"].ToString();
          Nacionalidad.Text = row["NACIONALIDAD"].ToString();
          PuntajeDocencia.Text = row["DCCA_PUNTAJE_TOTAL"].ToString();
          PuntajeInvestig.Text = row["INVN_PUNTAJE_TOTAL"].ToString();
          PuntajePersonal.Text = row["PRSL_PUNTAJE_TOTAL"].ToString();
          PuntajeProducci.Text = row["PRCN_PUNTAJE_TOTAL"].ToString();
          PuntajeProfesio.Text = row["PNAL_PUNTAJE_TOTAL"].ToString();
          PuntajeTotal.Text = row["PUNTAJE_TOTAL"].ToString();
        } else {
          MsgError();
        }
      } else {
        MsgError();
      }
    }

    private competencia getCompetencia() {
      return Session[_CONST.SESSION_INFO_COMPETENCIA] as competencia;
    }

    protected void Unnamed_Click(object sender, EventArgs e) {

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