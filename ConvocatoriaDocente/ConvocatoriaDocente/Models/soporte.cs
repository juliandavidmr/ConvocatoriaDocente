using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class soporte {
    public string spte_fecharegistro { get; set; }
    public int arcv_idarchivo { get; set; }
    public int dcnt_iddocente { get; set; }

    Conexion conexion = new Conexion();

    public soporte() { }

    public soporte(string spte_fecharegistro, int arcv_idarchivo, int dcnt_iddocente) {
      this.spte_fecharegistro = spte_fecharegistro;
      this.arcv_idarchivo = arcv_idarchivo;
      this.dcnt_iddocente = dcnt_iddocente;
    }

    public DataTable get_soporte() {
      return conexion.realizarConsulta("PR_SELECT_SOPORTE ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(soporte obj) {
      Parametro[] param = new Parametro[4];
      param[0] = new Parametro("SPTE_FECHAREGISTRO", obj.spte_fecharegistro);
      param[1] = new Parametro("ARCV_IDARCHIVO", obj.arcv_idarchivo);
      param[2] = new Parametro("DCNT_IDDOCENTE", obj.dcnt_iddocente);
      return param;
    }

    public bool insert_soporte(soporte obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_SOPORTE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_soporte(soporte obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_SOPORTE", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
