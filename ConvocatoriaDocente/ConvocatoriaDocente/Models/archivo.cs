using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class archivo {
    public int arcv_idarchivo { get; set; }
    public string arcv_descripcion { get; set; }
    public string arcv_dirname { get; set; }

    Conexion conexion = new Conexion();

    public archivo() { }

    public archivo(int arcv_idarchivo, string arcv_descripcion, string arcv_dirname) {
      this.arcv_idarchivo = arcv_idarchivo;
      this.arcv_descripcion = arcv_descripcion;
      this.arcv_dirname = arcv_dirname;
    }

    public DataTable get_archivo() {
      return conexion.realizarConsulta("PR_SELECT_ARCHIVO ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(archivo obj) {
      Parametro[] param = new Parametro[3];
      param[0] = new Parametro("ARCV_IDARCHIVO", obj.arcv_idarchivo);
      param[1] = new Parametro("ARCV_DESCRIPCION", obj.arcv_descripcion);
      param[2] = new Parametro("ARCV_DIRNAME", obj.arcv_dirname);
      return param;
    }

    public bool insert_archivo(archivo obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_ARCHIVO", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_archivo(archivo obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_ARCHIVO", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
