using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class investigacion_detalle {
    public int invd_idinvestigacion_detalle { get; set; }
    public string invd_financiadora { get; set; }
    public string invd_fecha_inicio { get; set; }
    public string invd_fecha_fin { get; set; }
    public int invd_puntaje { get; set; }
    public int invn_idinvestigacion { get; set; }

    Conexion conexion = new Conexion();

    public investigacion_detalle() { }

    public investigacion_detalle(int invd_idinvestigacion_detalle, string invd_financiadora, string invd_fecha_inicio, string invd_fecha_fin, int invd_puntaje, int invn_idinvestigacion) {
      this.invd_idinvestigacion_detalle = invd_idinvestigacion_detalle;
      this.invd_financiadora = invd_financiadora;
      this.invd_fecha_inicio = invd_fecha_inicio;
      this.invd_fecha_fin = invd_fecha_fin;
      this.invd_puntaje = invd_puntaje;
      this.invn_idinvestigacion = invn_idinvestigacion;
    }

    public DataTable get_investigacion_detalle() {
      return conexion.realizarConsulta("PR_SELECT_INVESTIGACION_DETALLE ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(investigacion_detalle obj) {
      Parametro[] param = new Parametro[7];
      param[0] = new Parametro("INVD_IDINVESTIGACION_DETALLE", obj.invd_idinvestigacion_detalle);
      param[1] = new Parametro("INVD_FINANCIADORA", obj.invd_financiadora);
      param[2] = new Parametro("INVD_FECHA_INICIO", obj.invd_fecha_inicio);
      param[3] = new Parametro("INVD_FECHA_FIN", obj.invd_fecha_fin);
      param[4] = new Parametro("INVD_PUNTAJE", obj.invd_puntaje);
      param[5] = new Parametro("INVN_IDINVESTIGACION", obj.invn_idinvestigacion);
      return param;
    }

    public bool insert_investigacion_detalle(investigacion_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_INVESTIGACION_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_investigacion_detalle(investigacion_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_INVESTIGACION_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
