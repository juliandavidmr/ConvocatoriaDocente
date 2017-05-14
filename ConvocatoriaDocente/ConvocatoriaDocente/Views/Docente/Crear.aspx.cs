using ConvocatoriaDocente.Models;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConvocatoriaDocente.Views.Docente {
  public partial class Crear : System.Web.UI.Page {

    tipo_documento td = new tipo_documento();
    pais pais = new pais();
    departamento depto = new departamento();

    protected void Page_Load(object sender, EventArgs e) {
      if (!X.IsAjaxRequest) {
        LoadTiposDoc();
        LoadPaises();
      }
    }

    public void LoadTiposDoc() {
      TiposDocumento.DataSource = td.get_tipo_documento();
      TiposDocumento.DataBind();
    }

    public void LoadPaises() {
      DataTable dt_paises = pais.get_pais();

      PaisActual.DataSource = dt_paises;
      PaisActual.DataBind();

      Nacionalidad.DataSource = dt_paises;
      Nacionalidad.DataBind();
    }

    protected void Ciudad_ItemSelected(object sender, EventArgs e) {
      int idPais = Convert.ToInt32(PaisActualSelect.Value);

      Ciudad.DataSource = depto.get_departamento(idPais);
      Ciudad.DataBind();
    }

    protected void Continuar_Click(object sender, DirectEventArgs e) {  
      X.Msg.Info("Datos personales registrados.", "").Show();
      System.Threading.Thread.Sleep(1500);

      Session[_CONST.SESSION_NUM_DOC_USER] = NumDocumento.Text;
      Response.Redirect("../Competencias/Personal/CrearDetalle.aspx");
    }
  }
}