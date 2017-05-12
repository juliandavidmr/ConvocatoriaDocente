using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class personal {
    public int prsl_idpersonal { get; set; }
    public int prsl_puntaje_total { get; set; }
    public int prsl_puntaje_max { get; set; }

    Conexion conexion = new Conexion();

    public personal() { }

    public personal(int prsl_idpersonal, int prsl_puntaje_total, int prsl_puntaje_max) {
      this.prsl_idpersonal = prsl_idpersonal;
      this.prsl_puntaje_total = prsl_puntaje_total;
      this.prsl_puntaje_max = prsl_puntaje_max;
    }

    public DataTable get_personal() {
      return conexion.realizarConsulta("PR_SELECT_PERSONAL ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(personal obj) {
      Parametro[] param = new Parametro[3];
      param[0] = new Parametro("PRSL_IDPERSONAL", obj.prsl_idpersonal);
      param[1] = new Parametro("PRSL_PUNTAJE_TOTAL", obj.prsl_puntaje_total);
      param[2] = new Parametro("PRSL_PUNTAJE_MAX", obj.prsl_puntaje_max);
      return param;
    }

    public bool insert_personal(personal obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_PERSONAL", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_personal(personal obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_PERSONAL", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
