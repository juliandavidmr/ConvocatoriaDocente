using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class profesional {
    public int pnal_idprofesional { get; set; }
    public int pnal_puntaje_total { get; set; }
    public int pnal_puntaje_max { get; set; }

    Conexion conexion = new Conexion();

    public profesional() { }

    public profesional(int pnal_idprofesional, int pnal_puntaje_total, int pnal_puntaje_max) {
      this.pnal_idprofesional = pnal_idprofesional;
      this.pnal_puntaje_total = pnal_puntaje_total;
      this.pnal_puntaje_max = pnal_puntaje_max;
    }

    public DataTable get_profesional() {
      return conexion.realizarConsulta("PR_SELECT_PROFESIONAL ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(profesional obj) {
      Parametro[] param = new Parametro[3];
      param[0] = new Parametro("PNAL_IDPROFESIONAL", obj.pnal_idprofesional);
      param[1] = new Parametro("PNAL_PUNTAJE_TOTAL", obj.pnal_puntaje_total);
      param[2] = new Parametro("PNAL_PUNTAJE_MAX", obj.pnal_puntaje_max);
      return param;
    }

    public bool insert_profesional(profesional obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_PROFESIONAL", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_profesional(profesional obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_PROFESIONAL", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
