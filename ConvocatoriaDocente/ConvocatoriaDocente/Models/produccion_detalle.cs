using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class produccion_detalle {

    public int pndt_idproduccion { get; set; }
    public string pndt_nombre_producto { get; set; }
    public string pndt_tipo_producto { get; set; }
    public string pndt_identificador_cert { get; set; }
    public string pndt_volumen { get; set; }
    public DateTime pndt_fecha_edicion { get; set; }
    public int pndt_puntaje { get; set; }
    public int prcn_idproduccion { get; set; }

    Conexion conexion = new Conexion();

    public produccion_detalle() { }

    public DataTable get_produccion_detalle() {
      return conexion.realizarConsulta("PR_SELECT_PRODUCCION_DET ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(produccion_detalle obj) {
      int i = 0;
      Parametro[] param = new Parametro[6];
      // param[0] = new Parametro("PNDT_IDPRODUCCION", obj.pndt_idproduccion);
      param[i++] = new Parametro("PNDT_NOMBRE_PRODUCTO", obj.pndt_nombre_producto);
      param[i++] = new Parametro("PNDT_TIPO_PRODUCTO", obj.pndt_tipo_producto);
      param[i++] = new Parametro("PNDT_IDENTIFICADOR_CERT", obj.pndt_identificador_cert);
      param[i++] = new Parametro("PNDT_VOLUMEN", obj.pndt_volumen);
      param[i++] = new Parametro("PNDT_FECHA_EDICION", obj.pndt_fecha_edicion);
      // param[i++] = new Parametro("PNDT_PUNTAJE", obj.pndt_puntaje);
      param[i++] = new Parametro("IDPRODUCCION", obj.prcn_idproduccion);
      return param;
    }

    public bool insert_produccion_detalle(produccion_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_PRODUCCION_DET", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool insert_produccion_detalle() {
      return insert_produccion_detalle(this);
    }

    public bool update_produccion_detalle(produccion_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_PRODUCCION_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
