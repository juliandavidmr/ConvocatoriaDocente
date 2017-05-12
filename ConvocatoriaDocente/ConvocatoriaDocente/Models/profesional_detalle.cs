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
    public string pfdt_fin { get; set; }
    public string pfdt_inicio { get; set; }
    public int pfdt_puntaje { get; set; }
    public int pnal_idprofesional { get; set; }

    Conexion conexion = new Conexion();

    public profesional_detalle() { }

    public profesional_detalle(int pfdt_idprofesional_detalle, string pfdt_institucion, string pfdt_area_trabajo, string pfdt_cargo, string pfdt_fin, string pfdt_inicio, int pfdt_puntaje, int pnal_idprofesional) {
      this.pfdt_idprofesional_detalle = pfdt_idprofesional_detalle;
      this.pfdt_institucion = pfdt_institucion;
      this.pfdt_area_trabajo = pfdt_area_trabajo;
      this.pfdt_cargo = pfdt_cargo;
      this.pfdt_fin = pfdt_fin;
      this.pfdt_inicio = pfdt_inicio;
      this.pfdt_puntaje = pfdt_puntaje;
      this.pnal_idprofesional = pnal_idprofesional;
    }

    public DataTable get_profesional_detalle() {
      return conexion.realizarConsulta("PR_SELECT_PROFESIONAL_DETALLE ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(profesional_detalle obj) {
      Parametro[] param = new Parametro[9];
      param[0] = new Parametro("PFDT_IDPROFESIONAL_DETALLE", obj.pfdt_idprofesional_detalle);
      param[1] = new Parametro("PFDT_INSTITUCION", obj.pfdt_institucion);
      param[2] = new Parametro("PFDT_AREA_TRABAJO", obj.pfdt_area_trabajo);
      param[3] = new Parametro("PFDT_CARGO", obj.pfdt_cargo);
      param[4] = new Parametro("PFDT_FIN", obj.pfdt_fin);
      param[5] = new Parametro("PFDT_INICIO", obj.pfdt_inicio);
      param[6] = new Parametro("PFDT_PUNTAJE", obj.pfdt_puntaje);
      param[7] = new Parametro("PNAL_IDPROFESIONAL", obj.pnal_idprofesional);
      return param;
    }

    public bool insert_profesional_detalle(profesional_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_PROFESIONAL_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_profesional_detalle(profesional_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_PROFESIONAL_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
