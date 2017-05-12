using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class ciudad {
    public int cidd_idciudad { get; set; }
    public string cidd_nombre { get; set; }
    public int cidd_estado { get; set; }
    public int dpto_iddepartamento { get; set; }

    Conexion conexion = new Conexion();

    public ciudad() { }

    public ciudad(int cidd_idciudad, string cidd_nombre, int cidd_estado, int dpto_iddepartamento) {
      this.cidd_idciudad = cidd_idciudad;
      this.cidd_nombre = cidd_nombre;
      this.cidd_estado = cidd_estado;
      this.dpto_iddepartamento = dpto_iddepartamento;
    }

    public DataTable get_ciudad() {
      return conexion.realizarConsulta("PR_SELECT_CIUDAD ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(ciudad obj) {
      Parametro[] param = new Parametro[4];
      param[0] = new Parametro("CIDD_IDCIUDAD", obj.cidd_idciudad);
      param[1] = new Parametro("CIDD_NOMBRE", obj.cidd_nombre);
      param[2] = new Parametro("CIDD_ESTADO", obj.cidd_estado);
      param[3] = new Parametro("DPTO_IDDEPARTAMENTO", obj.dpto_iddepartamento);
      return param;
    }

    public bool insert_ciudad(ciudad obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_CIUDAD", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_ciudad(ciudad obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_CIUDAD", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
