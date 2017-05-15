using ConvocatoriaDocente.Models;
using ConvocatoriaDocente.Models.Generics;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ConvocatoriaDocente.Views.Docente {
  public partial class Crear : Page {

    tipo_documento td = new tipo_documento();
    pais pais = new pais();
    departamento depto = new departamento();
    docente docente = new docente();

    protected void Page_Load(object sender, EventArgs e) {
      if (!X.IsAjaxRequest) {
        LoadTiposDoc();
        LoadPaises();
      }
    }

    public void LoadTiposDoc() {
      TiposDocumento.DataSource = td.get_tipo_documento();
      TiposDocumento.DataBind();
    }

    public void LoadPaises() {
      DataTable dt_paises = pais.get_pais();

      PaisActual.DataSource = dt_paises;
      PaisActual.DataBind();

      PaisExpedicion.DataSource = dt_paises;
      PaisExpedicion.DataBind();

      Nacionalidad.DataSource = dt_paises;
      Nacionalidad.DataBind();
    }

    private void ShowContinueMsg() {
      MessageBoxConfig config = new MessageBoxConfig();
      config.Title = "Inscripcion existente";
      config.Message = "Ya existe una inscripción con este numero de documento. ¿Desea continuar con la inscripción?";
      config.Closable = false;
      config.Icon = MessageBox.Icon.QUESTION;
      config.Buttons = MessageBox.Button.YESNO;
      config.MessageBoxButtonsConfig = new MessageBoxButtonsConfig {
        Yes = new MessageBoxButtonConfig { Handler = "App.direct.ClickedYES()", Text = "Si por favor" },
        No = new MessageBoxButtonConfig { Handler = "App.direct.ClickedNO()", Text = "No gracias" }
      };
      X.Msg.Show(config);
    }

    [DirectMethod]
    public void ClickedYES() {
      X.Msg.Info("Continuando", "Continuando.").Show();
    }

    [DirectMethod]
    public void ClickedNO() {
      X.Msg.Info("No es posible continuar", "No es posible continuar la inscripción.").Show();
    }

    protected void Ciudad_ItemSelected(object sender, EventArgs e) {
      int idPais = Convert.ToInt32(PaisActualSelect.Value);

      Ciudad.RemoveAll();
      Ciudad.DataSource = depto.get_departamento(idPais);
      Ciudad.DataBind();
    }

    protected void CiudadExpedicion_ItemSelected(object sender, EventArgs e) {
      int idPais = Convert.ToInt32(PaisExpedicionSelect.Value);

      CiudadExpedicion.RemoveAll();
      CiudadExpedicion.DataSource = depto.get_departamento(idPais);
      CiudadExpedicion.DataBind();
    }

    protected void Continuar_Click(object sender, DirectEventArgs e) {
      List<docente> d_registrado = (new docente()).get_docente(NumDocumento.Text).DataTableToList<docente>();
      if (d_registrado.Count > 0) {
        // X.Msg.Info("Inscripcion existente", "Ya existe una inscripción con este numero de documento.").Show();
        ShowContinueMsg();
      } else {
        docente d = new docente() {
          dcnt_nombres = Nombres.Text,
          dcnt_apellido1 = Apellido1.Text,
          dcnt_apellido2 = Apellido2.Text,
          dcnt_num_lb_militar = Libreta.Text,
          dcnt_fecha_nac = Convert.ToDateTime(FechaNacimiento.Text),
          dcnt_direccion_resi = Direccion.Text,
          dcnt_num_tel_fijo = TelFijo.Text,
          dcnt_num_tel_movil = TelMovil.Text,
          dcnt_email = Correo.Text,
          tpdc_idtipodocumento = Convert.ToInt32(TipoDocumentoSelect.Value),
          dcnt_num_doc = NumDocumento.Text,
          cidd_idciudad_actual = Convert.ToInt32(CiudadActual.Value),
          pais_idpais_nacionalidad = Convert.ToInt32(NacionalidadSelect.Value),
          cidd_idciudad_exp_doc = Convert.ToInt32(CiudadExpedicionSelect.Value)
        };

        if (d.insert_docente()) {       

          d_registrado = (new docente()).get_docente(NumDocumento.Text).DataTableToList<docente>();
          if (d_registrado.Count > 0) {
            if (PrepararCompetencias(d_registrado[0].dcnt_iddocente)) {
              X.Msg.Info("Datos personales registrados.", "Informacion personal registrada.").Show();

              Session[_CONST.SESSION_INFO_DOCENTE] = d_registrado[0];
              Session[_CONST.SESSION_NUM_DOC] = d_registrado[0].dcnt_num_doc;
              Session[_CONST.SESSION_ID_DOCENTE] = d_registrado[0].dcnt_iddocente;

              Response.Redirect("../Competencias/Personal/CrearDetalle.aspx");
            }
          } else {
            X.Msg.Info("Upps!!", ":( Ha ocurido un error al Consultar tus datos.").Show();
          }
        } else {
          X.Msg.Info("Error", ":( Ha ocurido un error al registrar tus datos.").Show();
        }
      }
    }

    public bool PrepararCompetencias(int id_docente) {
      return (new competencia()).insert_competencia_full(id_docente);
    }
  }
}