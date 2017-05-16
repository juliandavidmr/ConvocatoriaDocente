using ConvocatoriaDocente.Models.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ConvocatoriaDocente.Models {
  public class resumen {

    Conexion conexion = new Conexion();

    public resumen() { }

    public DataTable get_resumen(int id_docente) {
      Parametro[] p = new Parametro[1];
      p[0] = new Parametro("ID_DOCENTE", id_docente);
      return conexion.realizarConsulta("PR_RESUMEN_BY_DOCENTE", "CR_RESULT", p);
    }
  }
}