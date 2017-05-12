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
    public string dcdt_inicio { get; set; }
    public string dcdt_fin { get; set; }
    public string dcdt_puntaje { get; set; }
    public int dcca_iddocencia { get; set; }

    Conexion conexion = new Conexion();

    public docencia_detalle() { }

    public docencia_detalle(int dcdt_iddocencia_detalle, string dcdt_institucion, string dcdt_area_trabajo, string dcdt_cargo, string dcdt_inicio, string dcdt_fin, string dcdt_puntaje, int dcca_iddocencia) {
      this.dcdt_iddocencia_detalle = dcdt_iddocencia_detalle;
      this.dcdt_institucion = dcdt_institucion;
      this.dcdt_area_trabajo = dcdt_area_trabajo;
      this.dcdt_cargo = dcdt_cargo;
      this.dcdt_inicio = dcdt_inicio;
      this.dcdt_fin = dcdt_fin;
      this.dcdt_puntaje = dcdt_puntaje;
      this.dcca_iddocencia = dcca_iddocencia;
    }

    public DataTable get_docencia_detalle() {
      return conexion.realizarConsulta("PR_SELECT_DOCENCIA_DETALLE ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(docencia_detalle obj) {
      Parametro[] param = new Parametro[9];
      param[0] = new Parametro("DCDT_IDDOCENCIA_DETALLE", obj.dcdt_iddocencia_detalle);
      param[1] = new Parametro("DCDT_INSTITUCION", obj.dcdt_institucion);
      param[2] = new Parametro("DCDT_AREA_TRABAJO", obj.dcdt_area_trabajo);
      param[3] = new Parametro("DCDT_CARGO", obj.dcdt_cargo);
      param[4] = new Parametro("DCDT_INICIO", obj.dcdt_inicio);
      param[5] = new Parametro("DCDT_FIN", obj.dcdt_fin);
      param[6] = new Parametro("DCDT_PUNTAJE", obj.dcdt_puntaje);
      param[7] = new Parametro("DCCA_IDDOCENCIA", obj.dcca_iddocencia);
      return param;
    }

    public bool insert_docencia_detalle(docencia_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_DOCENCIA_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_docencia_detalle(docencia_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_DOCENCIA_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
