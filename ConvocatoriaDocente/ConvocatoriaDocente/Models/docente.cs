using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class docente {
    public int dcnt_iddocente { get; set; }
    public string dcnt_apellido1 { get; set; }
    public string dcnt_apellido2 { get; set; }
    public string dcnt_nombres { get; set; }
    public string dcnt_num_lb_militar { get; set; }
    public DateTime dcnt_fecha_nac { get; set; }
    public string dcnt_direccion_resi { get; set; }
    public string dcnt_num_tel_fijo { get; set; }
    public string dcnt_num_tel_movil { get; set; }
    public string dcnt_email { get; set; }
    public string dcnt_fecha_registr { get; set; }
    public string dcnt_num_doc { get; set; }
    public int cidd_idciudad_actual { get; set; }
    public int pais_idpais_nacionalidad { get; set; }
    public int tpdc_idtipodocumento { get; set; }
    public int cidd_idciudad_exp_doc { get; set; }

    Conexion conexion = new Conexion();

    public docente() { }

    public DataTable get_docente() {
      return conexion.realizarConsulta("PR_SELECT_DOCENTE ", "CR_RESULT ", null);
    }

    public DataTable get_docente(string numero_documento) {
      Parametro[] p = new Parametro[1];
      p[0] = new Parametro("NUM_DOC", numero_documento);
      return conexion.realizarConsulta("PR_SELECT_DOCENTE_BY_DOCU ", "CR_RESULT ", p);
    }

    public Parametro[] getParameters(docente obj) {
      int i = 0;
      Parametro[] param = new Parametro[14];
      // param[0] = new Parametro("DCNT_IDDOCENTE", obj.dcnt_iddocente);
      param[i++] = new Parametro("DCNT_APELLIDO1", obj.dcnt_apellido1);
      param[i++] = new Parametro("DCNT_APELLIDO2", obj.dcnt_apellido2);
      param[i++] = new Parametro("DCNT_NOMBRES", obj.dcnt_nombres);
      param[i++] = new Parametro("DCNT_NUM_LB_MILITAR", obj.dcnt_num_lb_militar);
      param[i++] = new Parametro("DCNT_FECHA_NAC", obj.dcnt_fecha_nac);
      param[i++] = new Parametro("DCNT_DIRECCION_RESI", obj.dcnt_direccion_resi);
      param[i++] = new Parametro("DCNT_NUM_TEL_FIJO", obj.dcnt_num_tel_fijo);
      param[i++] = new Parametro("DCNT_NUM_TEL_MOVIL", obj.dcnt_num_tel_movil);
      param[i++] = new Parametro("DCNT_NUM_DOC", obj.dcnt_num_doc);
      param[i++] = new Parametro("DCNT_EMAIL", obj.dcnt_email);
      // param[i++] = new Parametro("DCNT_FECHA_REGISTR", obj.dcnt_fecha_registr);
      param[i++] = new Parametro("CIDD_IDCIUDAD_ACTUAL", obj.cidd_idciudad_actual);
      param[i++] = new Parametro("PAIS_IDPAIS_NACIONALIDAD", obj.pais_idpais_nacionalidad);
      param[i++] = new Parametro("TPDC_IDTIPODOCUMENTO", obj.tpdc_idtipodocumento);
      param[i++] = new Parametro("CIDD_IDCIUDAD_EXP_DOC", obj.cidd_idciudad_exp_doc);
      return param;
    }

    public bool insert_docente() {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_DOCENTE", getParameters(this));
      return conexion.realizarTransaccion(list);
    }

    public bool insert_docente(docente obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_DOCENTE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_docente(docente obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_DOCENTE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
