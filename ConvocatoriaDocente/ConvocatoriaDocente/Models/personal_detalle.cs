using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class personal_detalle {
    public int tppr_idtipoprofesion { get; set; }
    public string prdt_universidad { get; set; }
    public DateTime prdt_grado { get; set; }
    public int prdt_puntaje { get; set; }
    public int prdt_puntaje_max { get; set; }
    public string prdt_titulo { get; set; }
    public int prsl_idpersonal { get; set; }

    Conexion conexion = new Conexion();

    public personal_detalle() { }

    public DataTable get_personal_detalle() {
      return conexion.realizarConsulta("PR_SELECT_PERSONAL_DET", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(personal_detalle obj) {
      int i = 0;
      Parametro[] param = new Parametro[5];
      param[i++] = new Parametro("IDTIPOPROFESION", obj.tppr_idtipoprofesion);
      param[i++] = new Parametro("PRDT_UNIVERSIDAD", obj.prdt_universidad);
      param[i++] = new Parametro("PRDT_GRADO", obj.prdt_grado);
      param[i++] = new Parametro("IDPERSONAL", obj.prsl_idpersonal);
      param[i++] = new Parametro("PRDT_TITULO", obj.prdt_titulo);
      return param;
    }

    public bool insert_personal_detalle(personal_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_PERSONAL_DET", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool insert_personal_detalle() {
      return insert_personal_detalle(this);
    }

    public bool update_personal_detalle(personal_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_PERSONAL_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
