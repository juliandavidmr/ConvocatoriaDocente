using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConvocatoriaDocente.Models {
  public class perfil {
    public int prfl_idperfil { get; set; }
    public int prfn_idprofesion { get; set; }
    public int dcnt_iddocente { get; set; }

    Conexion conexion = new Conexion();

    public perfil() { }

    public perfil(int prfl_idperfil, int prfn_idprofesion, int dcnt_iddocente) {
      this.prfl_idperfil = prfl_idperfil;
      this.prfn_idprofesion = prfn_idprofesion;
      this.dcnt_iddocente = dcnt_iddocente;
    }

    public DataTable get_perfil() {
      return conexion.realizarConsulta("PR_SELECT_PERFIL ", "CR_RESULT ", null);
    }

    public Parametro[] getParameters(perfil obj) {
      Parametro[] param = new Parametro[5];
      param[0] = new Parametro("PRFL_IDPERFIL", obj.prfl_idperfil);
      param[1] = new Parametro("PRFN_IDPROFESION", obj.prfn_idprofesion);
      param[2] = new Parametro("DCNT_IDDOCENTE", obj.dcnt_iddocente);
      return param;
    }

    public bool insert_perfil(perfil obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_INSERT_PERFIL", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

    public bool update_perfil(perfil obj) {
      Transaction[] list = new Transaction[1];
      list[0] = new Transaction("PR_UPDATE_PERFIL", getParameters(obj));
      return conexion.realizarTransaccion(list);
    }

  }
}
