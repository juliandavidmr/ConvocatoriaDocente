using ConvocatoriaDocente.Models;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConvocatoriaDocente.Views.Docente {
  public partial class Crear : System.Web.UI.Page {

    tipo_documento td = new tipo_documento();

    protected void Page_Load(object sender, EventArgs e) {
      if (!X.IsAjaxRequest) {
        LoadTiposDoc();
      }
    }

    public void LoadTiposDoc() {
      TiposDocumento.DataSource = td.get_tipo_documento();
      TiposDocumento.DataBind();
    }
    
  }
}