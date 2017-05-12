using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class departamento {
    public int dpto_iddepartamento { get; set; }
    public string dpto_nombre { get; set; }
    public int dpto_estado { get; set; }
    public int pais_idpais { get; set; }

    Conexion conexion = new Conexion();

    public departamento() { }

    public departamento(int dpto_iddepartamento, string dpto_nombre, int pais_idpais) {
      this.dpto_iddepartamento = dpto_iddepartamento;
      this.dpto_nombre = dpto_nombre;
      this.dpto_estado = dpto_estado;
      this.pais_idpais = pais_idpais;
    }

    public DataTable get_departamento() {
      return conexion.realizarConsulta("PR_SELECT_DEPARTAMENTO ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(departamento obj) {
      Parametro[] param = new Parametro[4];
      param[0] = new Parametro("DPTO_IDDEPARTAMENTO", obj.dpto_iddepartamento);
      param[1] = new Parametro("DPTO_NOMBRE", obj.dpto_nombre);
      param[2] = new Parametro("DPTO_ESTADO", obj.dpto_estado);
      param[3] = new Parametro("PAIS_IDPAIS", obj.pais_idpais);
      return param;
    }

    public bool insert_departamento(departamento obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_DEPARTAMENTO", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_departamento(departamento obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_DEPARTAMENTO", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
