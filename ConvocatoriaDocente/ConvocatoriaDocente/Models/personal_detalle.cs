using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class personal_detalle {
    public int tppr_idtipoprofesion { get; set; }
    public string prdt_universidad { get; set; }
    public string prdt_grado { get; set; }
    public int prdt_puntaje { get; set; }
    public int prdt_puntaje_max { get; set; }
    public int personal_prsl_idpersonal { get; set; }

    Conexion conexion = new Conexion();

    public personal_detalle() { }

    public personal_detalle(int tppr_idtipoprofesion, string prdt_universidad, string prdt_grado, int prdt_puntaje, int prdt_puntaje_max, int personal_prsl_idpersonal) {
      this.tppr_idtipoprofesion = tppr_idtipoprofesion;
      this.prdt_universidad = prdt_universidad;
      this.prdt_grado = prdt_grado;
      this.prdt_puntaje = prdt_puntaje;
      this.prdt_puntaje_max = prdt_puntaje_max;
      this.personal_prsl_idpersonal = personal_prsl_idpersonal;
    }

    public DataTable get_personal_detalle() {
      return conexion.realizarConsulta("PR_SELECT_PERSONAL_DETALLE ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(personal_detalle obj) {
      Parametro[] param = new Parametro[7];
      param[0] = new Parametro("TPPR_IDTIPOPROFESION", obj.tppr_idtipoprofesion);
      param[1] = new Parametro("PRDT_UNIVERSIDAD", obj.prdt_universidad);
      param[2] = new Parametro("PRDT_GRADO", obj.prdt_grado);
      param[3] = new Parametro("PRDT_PUNTAJE", obj.prdt_puntaje);
      param[4] = new Parametro("PRDT_PUNTAJE_MAX", obj.prdt_puntaje_max);
      param[5] = new Parametro("PERSONAL_PRSL_IDPERSONAL", obj.personal_prsl_idpersonal);
      return param;
    }

    public bool insert_personal_detalle(personal_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_PERSONAL_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_personal_detalle(personal_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_PERSONAL_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
