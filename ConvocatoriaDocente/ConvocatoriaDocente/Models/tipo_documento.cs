using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class tipo_documento {
    public int tpdc_idtipodocumento { get; set; }
    public string tpdc_nombre { get; set; }
    public int tpdc_estado { get; set; }

    Conexion conexion = new Conexion();

    public tipo_documento() { }

    public tipo_documento(int tpdc_idtipodocumento, string tpdc_nombre, int tpdc_estado) {
      this.tpdc_idtipodocumento = tpdc_idtipodocumento;
      this.tpdc_nombre = tpdc_nombre;
      this.tpdc_estado = tpdc_estado;
    }

    public DataTable get_tipo_documento() {
      return conexion.realizarConsulta("PR_SELECT_TIPO_DOCUMENTO ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(tipo_documento obj) {
      Parametro[] param = new Parametro[3];
      param[0] = new Parametro("TPDC_IDTIPODOCUMENTO", obj.tpdc_idtipodocumento);
      param[1] = new Parametro("TPDC_NOMBRE", obj.tpdc_nombre);
      param[2] = new Parametro("TPDC_ESTADO", obj.tpdc_estado);
      return param;
    }

    public bool insert_tipo_documento(tipo_documento obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_TIPO_DOCUMENTO", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_tipo_documento(tipo_documento obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_TIPO_DOCUMENTO", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
