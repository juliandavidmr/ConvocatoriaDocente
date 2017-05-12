using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class inscripcion {
    public int incn_idinscripcion { get; set; }
    public int dcnt_iddocente { get; set; }
    public string incn_manifestacion { get; set; }
    public string incn_desde { get; set; }
    public string incn_hasta { get; set; }
    public string incn_lugar { get; set; }
    public string incn_descripcion { get; set; }
    public string incn_atencion1 { get; set; }
    public string incn_atencion2 { get; set; }

    Conexion conexion = new Conexion();

    public inscripcion() { }

    public inscripcion(int incn_idinscripcion, int dcnt_iddocente, string incn_manifestacion, string incn_desde, string incn_hasta, string incn_lugar, string incn_descripcion, string incn_atencion1, string incn_atencion2) {
      this.incn_idinscripcion = incn_idinscripcion;
      this.dcnt_iddocente = dcnt_iddocente;
      this.incn_manifestacion = incn_manifestacion;
      this.incn_desde = incn_desde;
      this.incn_hasta = incn_hasta;
      this.incn_lugar = incn_lugar;
      this.incn_descripcion = incn_descripcion;
      this.incn_atencion1 = incn_atencion1;
      this.incn_atencion2 = incn_atencion2;
    }

    public DataTable get_inscripcion() {
      return conexion.realizarConsulta("PR_SELECT_INSCRIPCION ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(inscripcion obj) {
      Parametro[] param = new Parametro[10];
      param[0] = new Parametro("INCN_IDINSCRIPCION", obj.incn_idinscripcion);
      param[1] = new Parametro("DCNT_IDDOCENTE", obj.dcnt_iddocente);
      param[2] = new Parametro("INCN_MANIFESTACION", obj.incn_manifestacion);
      param[3] = new Parametro("INCN_DESDE", obj.incn_desde);
      param[4] = new Parametro("INCN_HASTA", obj.incn_hasta);
      param[5] = new Parametro("INCN_LUGAR", obj.incn_lugar);
      param[6] = new Parametro("INCN_DESCRIPCION", obj.incn_descripcion);
      param[7] = new Parametro("INCN_ATENCION1", obj.incn_atencion1);
      param[8] = new Parametro("INCN_ATENCION2", obj.incn_atencion2);
      return param;
    }

    public bool insert_inscripcion(inscripcion obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_INSCRIPCION", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_inscripcion(inscripcion obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_INSCRIPCION", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
