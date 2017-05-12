﻿using ConvocatoriaDocente.Models.BD;

namespace ConvocatoriaDocente.Models.BD {
  public class Transaction {

    public string Procedure { get; set; }
    public Parametro[] Parameters { get; set; }

    public Transaction(string Procedure, Parametro[] Parameters) {
      this.Procedure = Procedure;
      this.Parameters = Parameters;
    }
  }
}