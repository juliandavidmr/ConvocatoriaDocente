using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class tipo_profesion {
    public int tppr_idtipoprofesion { get; set; }
    public string tppr_nombre { get; set; }
    public int ingenieria { get; set; }

    Conexion conexion = new Conexion();

    public tipo_profesion() { }

    public tipo_profesion(int tppr_idtipoprofesion, string tppr_nombre) {
      this.tppr_idtipoprofesion = tppr_idtipoprofesion;
      this.tppr_nombre = tppr_nombre;
    }

    public DataTable get_tipo_profesion() {
      return conexion.realizarConsulta("PR_SELECT_TIPO_PROFESION ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(tipo_profesion obj) {
      Parametro[] param = new Parametro[4];
      param[0] = new Parametro("TPPR_IDTIPOPROFESION", obj.tppr_idtipoprofesion);
      param[1] = new Parametro("TPPR_NOMBRE", obj.tppr_nombre);
      return param;
    }

    public bool insert_tipo_profesion(tipo_profesion obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_TIPO_PROFESION", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_tipo_profesion(tipo_profesion obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_TIPO_PROFESION", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
