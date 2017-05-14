using ConvocatoriaDocente.Models.BD;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.Linq;

namespace ConvocatoriaDocente.Models {
  public class Conexion {
    private static string stringConnection = ConfigurationManager.ConnectionStrings["oracleConexion"].ConnectionString;
    OracleConnection Conn = new OracleConnection(stringConnection);

    /**
     * <summary>Abre la conexión con la base de datos Oracle</summary>
     */
    public OracleConnection ConexionOracle() {
      try {
        if (Conn.State == ConnectionState.Closed) {
          Conn.Open();
        }
      } catch (Exception ex) {
        throw new Exception("No se realizó la conexión a la base de datos: " + ex.Message);
      }
      return Conn;
    }

    /**
     * <summary>Ejecuta un procedimiento almacenado de consulta</summary>
     * <param name="Procedure">Nombre del procedimiento</param>
     * <param name="Cursor">Nombre cursor</param>
     * <param name="Parameters">Parametros</param>
     */
    public DataTable realizarConsulta(string Procedure, string Cursor, Parametro[] Parameters) {
      DataTable data = new DataTable();
      OracleConnection conn = new OracleConnection();
      conn = ConexionOracle();
      OracleCommand cmd = new OracleCommand();
      cmd.Connection = conn;
      cmd.CommandText = Procedure;
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.Add(Cursor, OracleDbType.RefCursor).Direction = ParameterDirection.Output;

      if (Parameters != null) {
        for (int i = 0; i < Parameters.Length; i++) {
          if (Parameters[i] != null) {
            cmd.Parameters.Add(Parameters[i].Nombre, Parameters[i].Value).Direction = ParameterDirection.Input;
          }
        }
      }

      try {
        OracleDataAdapter da = new OracleDataAdapter(cmd);
        da.Fill(data);
        return data;
      } catch (Exception e) {
        throw new Exception("Sentencia de consulta invalida " + e.Message);
      }
    }

    public bool realizarTransaccion(Transaction[] list) {
      bool state = false;
      OracleConnection conn = new OracleConnection();
      OracleCommand cmd = null;
      conn = ConexionOracle();

      OracleTransaction Transa = conn.BeginTransaction();

      try {
        for (int i = 0; i < list.Length; i++) {
          if (list[i] == null) continue;

          cmd = new OracleCommand(list[i].Procedure, conn);
          cmd.CommandType = CommandType.StoredProcedure;
          foreach (Parametro obj in list[i].Parameters) {
            if (obj != null) {
              cmd.Parameters.Add(obj.Nombre, obj.Value);
            }
          }
          cmd.Transaction = Transa;
          cmd.ExecuteNonQuery();
        }
        Transa.Commit();
        // conn.Close();
        // conn.Dispose();
        Transa.Dispose();
        state = true;
      } catch (Exception ex) {
        Transa.Rollback();
        // conn.Close();
        // conn.Dispose();
        state = false;
      } finally {
        if (cmd != null) {
          cmd.Dispose();
        }
      }
      return state;
    }
  }
}