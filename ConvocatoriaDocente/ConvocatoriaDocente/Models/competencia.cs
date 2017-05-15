using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;


namespace ConvocatoriaDocente.Models {
  public class competencia {
    public int cmpc_idcompetencia { get; set; }
    public int cmpc_puntaje_total { get; set; }
    public int cmpc_max_puntos { get; set; }
    public int prsl_idpersonal { get; set; }
    public int invn_idinvestigacion { get; set; }
    public int dcca_iddocencia { get; set; }
    public int pnal_idprofesional { get; set; }
    public int prcn_idproduccion { get; set; }
    public int dcnt_iddocente { get; set; }
    public int cnto_idconoc_detalle { get; set; }

    Conexion conexion = new Conexion();

    public competencia() { }

    public DataTable get_competencia() {
      return conexion.realizarConsulta("PR_SELECT_COMPETENCIA ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(competencia obj) {
      int i = 0;
      Parametro[] param = new Parametro[13];
      // param[0] = new Parametro("CMPC_IDCOMPETENCIA", obj.cmpc_idcompetencia);
      param[i++] = new Parametro("CMPC_PUNTAJE_TOTAL", obj.cmpc_puntaje_total);
      param[i++] = new Parametro("CMPC_MAX_PUNTOS", obj.cmpc_max_puntos);
      param[i++] = new Parametro("PRSL_IDPERSONAL", obj.prsl_idpersonal);
      param[i++] = new Parametro("INVN_IDINVESTIGACION", obj.invn_idinvestigacion);
      param[i++] = new Parametro("DCCA_IDDOCENCIA", obj.dcca_iddocencia);
      param[i++] = new Parametro("PNAL_IDPROFESIONAL", obj.pnal_idprofesional);
      param[i++] = new Parametro("DCNT_IDDOCENTE", obj.prcn_idproduccion);
      param[i++] = new Parametro("PRCN_IDPRODUCCION", obj.dcnt_iddocente);
      param[i++] = new Parametro("CNTO_IDCONOC_DETALLE", obj.cnto_idconoc_detalle);
      return param;
    }

    public Parametro[] getParamsProcedureFull(int id_docente) {
      Parametro[] param = new Parametro[1];
      param[0] = new Parametro("DCNT_IDDOCENTE", id_docente);      
      return param;
    }

    public bool insert_competencia(competencia obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_COMPETENCIA", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool insert_competencia() {
      return insert_competencia(this);
    }

    public bool insert_competencia_full(int id_docente) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_COMPETENCIA_FULL", getParamsProcedureFull(id_docente));
      return conexion.realizarTransaccion(list);
    }

    public bool update_competencia(competencia obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_COMPETENCIA", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
