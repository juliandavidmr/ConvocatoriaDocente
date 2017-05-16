<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resumen.aspx.cs" Inherits="ConvocatoriaDocente.Views.Competencias.Resumen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <ext:ResourceManager runat="server" />

    <ext:Viewport
      runat="server"
      Layout="FitLayout"
      AutoScroll="true">
      <Items>
        <ext:FormPanel
          runat="server"
          Header="true"
          BodyPadding="1"
          MarginSpec="5"
          AutoScroll="true"
          Flex="1">

          <FieldDefaults LabelAlign="Left" MsgTarget="Side" />

          <Items>
            <ext:FieldSet
              runat="server"
              Layout="AnchorLayout"
              ColumnWidth="0.4"
              Title="Resumen de puntos"
              MarginSpec="0 0 0 10"
              ButtonAlign="Right">
              <Defaults>
                <ext:Parameter Name="LabelWidth" Value="115" />
              </Defaults>
              <Items>
                <ext:TextField runat="server" ID="Nombres" FieldLabel="Nombres" Editable="false" />
                <ext:TextField runat="server" ID="Apellido1" FieldLabel="Primero apellido" Editable="false" />
                <ext:TextField runat="server" ID="Apellido2" FieldLabel="Segundo apellido" Editable="false" />
                <ext:TextField runat="server" ID="Nacimiento" FieldLabel="Nacimiento" Editable="false" />
                <ext:TextField runat="server" ID="Fijo" FieldLabel="Fijo" Editable="false" />
                <ext:TextField runat="server" ID="Movil" FieldLabel="Móvil" Editable="false" />
                <ext:TextField runat="server" ID="Email" FieldLabel="Email" Editable="false" />
                <ext:TextField runat="server" ID="Nacionalidad" FieldLabel="Nacionalidad" Editable="false" />

                <ext:TextField runat="server" ID="PuntajeDocencia" FieldLabel="Puntaje en docencia" Editable="false" />
                <ext:TextField runat="server" ID="PuntajeInvestig" FieldLabel="Puntaje en investigación" Editable="false" />
                <ext:TextField runat="server" ID="PuntajePersonal" FieldLabel="Puntaje personal" Editable="false" />
                <ext:TextField runat="server" ID="PuntajeProducci" FieldLabel="Puntaje en producción" Editable="false" />
                <ext:TextField runat="server" ID="PuntajeProfesio" FieldLabel="Puntaje profesional" Editable="false" />
                <ext:TextField runat="server" ID="PuntajeTotal" FieldLabel="Puntaje Total" Editable="false" />

                <ext:ProgressBar runat="server" ID="Progreso" Width="300" UI="Primary"></ext:ProgressBar>

                <ext:Button runat="server" Text="Refrescar"></ext:Button>
              </Items>
            </ext:FieldSet>
          </Items>
        </ext:FormPanel>
      </Items>
    </ext:Viewport>
  </form>
</body>
</html>
