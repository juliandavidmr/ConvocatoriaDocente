using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class investigacion_detalle {
    public int invd_idinvestigacion_detalle { get; set; }
    public string invd_financiadora { get; set; }
    public string invd_nombre { get; set; }
    public DateTime invd_fecha_inicio { get; set; }
    public DateTime invd_fecha_fin { get; set; }
    public int invd_puntaje { get; set; }
    public int invn_idinvestigacion { get; set; }

    Conexion conexion = new Conexion();

    public investigacion_detalle() { }

    public DataTable get_investigacion_detalle() {
      return conexion.realizarConsulta("PR_SELECT_INVESTIGACION_DET ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(investigacion_detalle obj) {
      Parametro[] param = new Parametro[5];
      param[0] = new Parametro("FINANCIADORA", obj.invd_financiadora);
      param[1] = new Parametro("FECHA_INICIO", obj.invd_fecha_inicio);
      param[2] = new Parametro("FECHA_FIN", obj.invd_fecha_fin);
      param[3] = new Parametro("IDINVESTIGACION", obj.invn_idinvestigacion);
      param[4] = new Parametro("INVD_NOMBRE", obj.invd_nombre);
      return param;
    }

    public bool insert_investigacion_detalle(investigacion_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_INVESTIGACION_DET", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool insert_investigacion_detalle() {
      return insert_investigacion_detalle(this);
    }


    public bool update_investigacion_detalle(investigacion_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_INVESTIGACION_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
