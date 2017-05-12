using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class investigacion {
    public int invn_idinvestigacion { get; set; }
    public int invn_puntaje_total { get; set; }
    public int invn_puntaje_max { get; set; }

    Conexion conexion = new Conexion();

    public investigacion() { }

    public investigacion(int invn_idinvestigacion, int invn_puntaje_total, int invn_puntaje_max) {
      this.invn_idinvestigacion = invn_idinvestigacion;
      this.invn_puntaje_total = invn_puntaje_total;
      this.invn_puntaje_max = invn_puntaje_max;
    }

    public DataTable get_investigacion() {
      return conexion.realizarConsulta("PR_SELECT_INVESTIGACION ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(investigacion obj) {
      Parametro[] param = new Parametro[3];
      param[0] = new Parametro("INVN_IDINVESTIGACION", obj.invn_idinvestigacion);
      param[1] = new Parametro("INVN_PUNTAJE_TOTAL", obj.invn_puntaje_total);
      param[2] = new Parametro("INVN_PUNTAJE_MAX", obj.invn_puntaje_max);
      return param;
    }

    public bool insert_investigacion(investigacion obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_INVESTIGACION", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_investigacion(investigacion obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_INVESTIGACION", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
