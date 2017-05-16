using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class docencia_detalle {

    public int dcdt_iddocencia_detalle { get; set; }
    public string dcdt_institucion { get; set; }
    public string dcdt_area_trabajo { get; set; }
    public string dcdt_cargo { get; set; }
    public DateTime dcdt_inicio { get; set; }
    public DateTime dcdt_fin { get; set; }
    public string dcdt_puntaje { get; set; }
    public int dcca_iddocencia { get; set; }

    Conexion conexion = new Conexion();

    public docencia_detalle() { }

    public DataTable get_docencia_detalle() {
      return conexion.realizarConsulta("PR_SELECT_DOCENCIA_DET ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(docencia_detalle obj) {
      int i = 0;
      Parametro[] param = new Parametro[6];
      // param[i++] = new Parametro("DCDT_IDDOCENCIA_DETALLE", obj.dcdt_iddocencia_detalle);
      param[i++] = new Parametro("DCDT_INSTITUCION", obj.dcdt_institucion);
      param[i++] = new Parametro("DCDT_AREA_TRABAJO", obj.dcdt_area_trabajo);
      param[i++] = new Parametro("DCDT_CARGO", obj.dcdt_cargo);
      param[i++] = new Parametro("DCDT_INICIO", obj.dcdt_inicio);
      param[i++] = new Parametro("DCDT_FIN", obj.dcdt_fin);
      // param[i++] = new Parametro("DCDT_PUNTAJE", obj.dcdt_puntaje);
      param[i++] = new Parametro("IDDOCENCIA", obj.dcca_iddocencia);
      return param;
    }

    public bool insert_docencia_detalle(docencia_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_DOCENCIA_DET", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool insert_docencia_detalle() {
      return insert_docencia_detalle(this);
    }

    public bool update_docencia_detalle(docencia_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_DOCENCIA_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
