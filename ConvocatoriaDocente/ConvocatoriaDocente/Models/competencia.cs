using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;


namespace ConvocatoriaDocente.Models {
  public class competencia {
    public int cmpc_idcompetencia { get; set; }
    public string cmpc_puntaje_total { get; set; }
    public int cmpc_max_puntos { get; set; }
    public int prsl_idpersonal { get; set; }
    public int invn_idinvestigacion { get; set; }
    public int dcca_iddocencia { get; set; }
    public int pnal_idprofesional { get; set; }
    public int prcn_idproduccion { get; set; }

    Conexion conexion = new Conexion();

    public competencia() { }

    public competencia(int cmpc_idcompetencia, string cmpc_puntaje_total, int cmpc_max_puntos, int prsl_idpersonal, int invn_idinvestigacion, int dcca_iddocencia, int pnal_idprofesional, int prcn_idproduccion) {
      this.cmpc_idcompetencia = cmpc_idcompetencia;
      this.cmpc_puntaje_total = cmpc_puntaje_total;
      this.cmpc_max_puntos = cmpc_max_puntos;
      this.prsl_idpersonal = prsl_idpersonal;
      this.invn_idinvestigacion = invn_idinvestigacion;
      this.dcca_iddocencia = dcca_iddocencia;
      this.pnal_idprofesional = pnal_idprofesional;
      this.prcn_idproduccion = prcn_idproduccion;
    }

    public DataTable get_competencia() {
      return conexion.realizarConsulta("PR_SELECT_COMPETENCIA ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(competencia obj) {
      Parametro[] param = new Parametro[13];
      param[0] = new Parametro("CMPC_IDCOMPETENCIA", obj.cmpc_idcompetencia);
      param[1] = new Parametro("CMPC_PUNTAJE_TOTAL", obj.cmpc_puntaje_total);
      param[2] = new Parametro("CMPC_MAX_PUNTOS", obj.cmpc_max_puntos);
      param[3] = new Parametro("PRSL_IDPERSONAL", obj.prsl_idpersonal);
      param[4] = new Parametro("INVN_IDINVESTIGACION", obj.invn_idinvestigacion);
      param[5] = new Parametro("DCCA_IDDOCENCIA", obj.dcca_iddocencia);
      param[6] = new Parametro("PNAL_IDPROFESIONAL", obj.pnal_idprofesional);
      param[7] = new Parametro("PRCN_IDPRODUCCION", obj.prcn_idproduccion);
      return param;
    }

    public bool insert_competencia(competencia obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_COMPETENCIA", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_competencia(competencia obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_COMPETENCIA", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
