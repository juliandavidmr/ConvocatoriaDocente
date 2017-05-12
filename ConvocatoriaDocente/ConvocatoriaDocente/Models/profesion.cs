using ConvocatoriaDocente.Models;
using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class profesion {
    public int prfn_idprofesion { get; set; }
    public string prfn_titulo { get; set; }
    public int tppr_idtipoprofesion { get; set; }

    Conexion conexion = new Conexion();

    public profesion() { }

    public profesion(int prfn_idprofesion, string prfn_titulo, int tppr_idtipoprofesion) {
      this.prfn_idprofesion = prfn_idprofesion;
      this.prfn_titulo = prfn_titulo;
      this.tppr_idtipoprofesion = tppr_idtipoprofesion;
    }

    public DataTable get_profesion() {
      return conexion.realizarConsulta("PR_SELECT_PROFESION ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(profesion obj) {
      Parametro[] param = new Parametro[4];
      param[0] = new Parametro("PRFN_IDPROFESION", obj.prfn_idprofesion);
      param[1] = new Parametro("PRFN_TITULO", obj.prfn_titulo);
      param[2] = new Parametro("TPPR_IDTIPOPROFESION", obj.tppr_idtipoprofesion);
      return param;
    }

    public bool insert_profesion(profesion obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_PROFESION", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_profesion(profesion obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_PROFESION", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
