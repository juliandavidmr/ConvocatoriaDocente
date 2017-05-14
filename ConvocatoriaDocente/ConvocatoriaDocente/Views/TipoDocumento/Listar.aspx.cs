using ConvocatoriaDocente.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace ConvocatoriaDocente.Views.TipoDocumento {
  public partial class Listar : System.Web.UI.Page {

    tipo_documento td = new tipo_documento();

    protected void Page_Load(object sender, EventArgs e) {
      if (!X.IsAjaxRequest) {
        StoreTiposDoc.DataSource = this.GetDataTable();
        StoreTiposDoc.DataBind();
      }
    }

    public DataTable GetDataTable() {
      return td.get_tipo_documento();
    }
  }
}