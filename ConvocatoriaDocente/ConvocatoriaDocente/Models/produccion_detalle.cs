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
    public string pndt_fecha_edicion { get; set; }
    public int pndt_puntaje { get; set; }
    public int prcn_idproduccion { get; set; }

    Conexion conexion = new Conexion();

    public produccion_detalle() { }

    public produccion_detalle(int pndt_idproduccion, string pndt_nombre_producto, string pndt_tipo_producto, string pndt_identificador_cert, string pndt_volumen, string pndt_fecha_edicion, int pndt_puntaje, int prcn_idproduccion) {
      this.pndt_idproduccion = pndt_idproduccion;
      this.pndt_nombre_producto = pndt_nombre_producto;
      this.pndt_tipo_producto = pndt_tipo_producto;
      this.pndt_identificador_cert = pndt_identificador_cert;
      this.pndt_volumen = pndt_volumen;
      this.pndt_fecha_edicion = pndt_fecha_edicion;
      this.pndt_puntaje = pndt_puntaje;
      this.prcn_idproduccion = prcn_idproduccion;
    }

    public DataTable get_produccion_detalle() {
      return conexion.realizarConsulta("PR_SELECT_PRODUCCION_DETALLE ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(produccion_detalle obj) {
      Parametro[] param = new Parametro[9];
      param[0] = new Parametro("PNDT_IDPRODUCCION", obj.pndt_idproduccion);
      param[1] = new Parametro("PNDT_NOMBRE_PRODUCTO", obj.pndt_nombre_producto);
      param[2] = new Parametro("PNDT_TIPO_PRODUCTO", obj.pndt_tipo_producto);
      param[3] = new Parametro("PNDT_IDENTIFICADOR_CERT", obj.pndt_identificador_cert);
      param[4] = new Parametro("PNDT_VOLUMEN", obj.pndt_volumen);
      param[5] = new Parametro("PNDT_FECHA_EDICION", obj.pndt_fecha_edicion);
      param[6] = new Parametro("PNDT_PUNTAJE", obj.pndt_puntaje);
      param[7] = new Parametro("PRCN_IDPRODUCCION", obj.prcn_idproduccion);
      return param;
    }

    public bool insert_produccion_detalle(produccion_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_PRODUCCION_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_produccion_detalle(produccion_detalle obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_PRODUCCION_DETALLE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
