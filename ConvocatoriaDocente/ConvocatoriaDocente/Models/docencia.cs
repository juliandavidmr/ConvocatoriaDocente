using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class docencia {
    public int dcca_iddocencia { get; set; }
    public int dcca_puntaje_total { get; set; }
    public int dcca_puntaje_max { get; set; }

    Conexion conexion = new Conexion();

    public docencia() { }

    public docencia(int dcca_iddocencia, int dcca_puntaje_total, int dcca_puntaje_max) {
      this.dcca_iddocencia = dcca_iddocencia;
      this.dcca_puntaje_total = dcca_puntaje_total;
      this.dcca_puntaje_max = dcca_puntaje_max;
    }

    public DataTable get_docencia() {
      return conexion.realizarConsulta("PR_SELECT_DOCENCIA ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(docencia obj) {
      Parametro[] param = new Parametro[3];
      param[0] = new Parametro("DCCA_IDDOCENCIA", obj.dcca_iddocencia);
      param[1] = new Parametro("DCCA_PUNTAJE_TOTAL", obj.dcca_puntaje_total);
      param[2] = new Parametro("DCCA_PUNTAJE_MAX", obj.dcca_puntaje_max);
      return param;
    }

    public bool insert_docencia(docencia obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_DOCENCIA", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_docencia(docencia obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_DOCENCIA", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
