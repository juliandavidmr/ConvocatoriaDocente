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
    public string dcnt_fecha_nac { get; set; }
    public string dcnt_direccion_resi { get; set; }
    public string dcnt_num_tel_fijo { get; set; }
    public string dcnt_num_tel_movil { get; set; }
    public string dcnt_email { get; set; }
    public string dcnt_fecha_registr { get; set; }
    public int cidd_idciudad_actual { get; set; }
    public int pais_idpais_nacionalidad { get; set; }
    public int tpdc_idtipodocumento { get; set; }
    public int cidd_idciudad_exp_doc { get; set; }

    Conexion conexion = new Conexion();

    public docente() { }

    public docente(int dcnt_iddocente, string dcnt_apellido1, string dcnt_apellido2, string dcnt_nombres, string dcnt_num_lb_militar, string dcnt_fecha_nac, string dcnt_direccion_resi, string dcnt_num_tel_fijo, string dcnt_num_tel_movil, string dcnt_email, string dcnt_fecha_registr, int cidd_idciudad_actual, int pais_idpais_nacionalidad, int tpdc_idtipodocumento, int cidd_idciudad_exp_doc) {
      this.dcnt_iddocente = dcnt_iddocente;
      this.dcnt_apellido1 = dcnt_apellido1;
      this.dcnt_apellido2 = dcnt_apellido2;
      this.dcnt_nombres = dcnt_nombres;
      this.dcnt_num_lb_militar = dcnt_num_lb_militar;
      this.dcnt_fecha_nac = dcnt_fecha_nac;
      this.dcnt_direccion_resi = dcnt_direccion_resi;
      this.dcnt_num_tel_fijo = dcnt_num_tel_fijo;
      this.dcnt_num_tel_movil = dcnt_num_tel_movil;
      this.dcnt_email = dcnt_email;
      this.dcnt_fecha_registr = dcnt_fecha_registr;
      this.cidd_idciudad_actual = cidd_idciudad_actual;
      this.pais_idpais_nacionalidad = pais_idpais_nacionalidad;
      this.tpdc_idtipodocumento = tpdc_idtipodocumento;
      this.cidd_idciudad_exp_doc = cidd_idciudad_exp_doc;
    }

    public DataTable get_docente() {
      return conexion.realizarConsulta("PR_SELECT_DOCENTE ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(docente obj) {
      Parametro[] param = new Parametro[19];
      param[0] = new Parametro("DCNT_IDDOCENTE", obj.dcnt_iddocente);
      param[1] = new Parametro("DCNT_APELLIDO1", obj.dcnt_apellido1);
      param[2] = new Parametro("DCNT_APELLIDO2", obj.dcnt_apellido2);
      param[3] = new Parametro("DCNT_NOMBRES", obj.dcnt_nombres);
      param[4] = new Parametro("DCNT_NUM_LB_MILITAR", obj.dcnt_num_lb_militar);
      param[5] = new Parametro("DCNT_FECHA_NAC", obj.dcnt_fecha_nac);
      param[6] = new Parametro("DCNT_DIRECCION_RESI", obj.dcnt_direccion_resi);
      param[7] = new Parametro("DCNT_NUM_TEL_FIJO", obj.dcnt_num_tel_fijo);
      param[8] = new Parametro("DCNT_NUM_TEL_MOVIL", obj.dcnt_num_tel_movil);
      param[9] = new Parametro("DCNT_EMAIL", obj.dcnt_email);
      param[10] = new Parametro("DCNT_FECHA_REGISTR", obj.dcnt_fecha_registr);
      param[11] = new Parametro("CIDD_IDCIUDAD_ACTUAL", obj.cidd_idciudad_actual);
      param[12] = new Parametro("PAIS_IDPAIS_NACIONALIDAD", obj.pais_idpais_nacionalidad);
      param[13] = new Parametro("TPDC_IDTIPODOCUMENTO", obj.tpdc_idtipodocumento);
      param[14] = new Parametro("CIDD_IDCIUDAD_EXP_DOC", obj.cidd_idciudad_exp_doc);
      return param;
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
