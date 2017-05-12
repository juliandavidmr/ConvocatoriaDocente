using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class pais {
    public int pais_idpais { get; set; }
    public string pais_nombre { get; set; }
    public int pais_estado { get; set; }

    Conexion conexion = new Conexion();

    public pais() { }

    public pais(int pais_idpais, string pais_nombre, int pais_estado) {
      this.pais_idpais = pais_idpais;
      this.pais_nombre = pais_nombre;
      this.pais_estado = pais_estado;
    }

    public DataTable get_pais() {
      return conexion.realizarConsulta("PR_SELECT_PAIS ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(pais obj) {
      Parametro[] param = new Parametro[3];
      param[0] = new Parametro("PAIS_IDPAIS", obj.pais_idpais);
      param[1] = new Parametro("PAIS_NOMBRE", obj.pais_nombre);
      param[2] = new Parametro("PAIS_ESTADO", obj.pais_estado);
      return param;
    }

    public bool insert_pais(pais obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_PAIS", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_pais(pais obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_PAIS", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
