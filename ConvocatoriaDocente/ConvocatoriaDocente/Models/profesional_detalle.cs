using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class profesional_detalle {
    public int pfdt_idprofesional_detalle { get; set; }
    public string pfdt_institucion { get; set; }
    public string pfdt_area_trabajo { get; set; }
    public string pfdt_cargo { get; set; }
    public DateTime pfdt_fin { get; set; }
    public DateTime pfdt_inicio { get; set; }
    public int pfdt_puntaje { get; set; }
    public int pnal_idprofesional { get; set; }

    Conexion conexion = new Conexion();

    public profesional_detalle() { }

    public DataTable get_profesional_detalle() {
      return conexion.realizarConsulta("PR_SELECT_PROFESIONAL_DET ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(profesional_detalle obj) {
      int i = 0;
      Parametro[] param = new Parametro[6];
      // param[i++] = new Parametro("PFDT_IDPROFESIONAL_DETALLE", obj.pfdt_idprofesional_detalle);
      param[i++] = new Parametro("PFDT_INSTITUCION", obj.pfdt_institucion);
      param[i++] = new Parametro("PFDT_AREA_TRABAJO", obj.pfdt_area_trabajo);
      param[i++] = new Parametro("PFDT_CARGO", obj.pfdt_cargo);
      param[i++] = new Parametro("PFDT_FIN", obj.pfdt_fin);
      param[i++] = new Parametro("PFDT_INICIO", obj.pfdt_inicio);
      // param[i++] = new Parametro("PFDT_PUNTAJE", obj.pfdt_puntaje);
      param[i++] = new Parametro("IDPROFESIONAL", obj.pnal_idprofesional);
      return param;
    }

    public bool insert_profesional_detalle(profesional_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_PROFESIONAL_DET", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool insert_profesional_detalle() {
      return insert_profesional_detalle(this);
    }

    public bool update_profesional_detalle(profesional_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_PROFESIONAL_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
