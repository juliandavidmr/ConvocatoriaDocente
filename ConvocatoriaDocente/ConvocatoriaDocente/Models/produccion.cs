using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class produccion {
    public int prcn_idproduccion { get; set; }
    public int prcn_puntaje_total { get; set; }
    public int prcn_puntaje_max { get; set; }

    Conexion conexion = new Conexion();

    public produccion() { }

    public produccion(int prcn_idproduccion, int prcn_puntaje_total, int prcn_puntaje_max) {
      this.prcn_idproduccion = prcn_idproduccion;
      this.prcn_puntaje_total = prcn_puntaje_total;
      this.prcn_puntaje_max = prcn_puntaje_max;
    }

    public DataTable get_produccion() {
      return conexion.realizarConsulta("PR_SELECT_PRODUCCION ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(produccion obj) {
      Parametro[] param = new Parametro[3];
      param[0] = new Parametro("PRCN_IDPRODUCCION", obj.prcn_idproduccion);
      param[1] = new Parametro("PRCN_PUNTAJE_TOTAL", obj.prcn_puntaje_total);
      param[2] = new Parametro("PRCN_PUNTAJE_MAX", obj.prcn_puntaje_max);
      return param;
    }

    public bool insert_produccion(produccion obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_PRODUCCION", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_produccion(produccion obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_PRODUCCION", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
