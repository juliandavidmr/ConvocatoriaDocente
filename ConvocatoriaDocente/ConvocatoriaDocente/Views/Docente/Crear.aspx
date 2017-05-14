﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="ConvocatoriaDocente.Views.Docente.Crear" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <link href="/resources/css/examples.css" rel="stylesheet" />
</head>
<body>
  <form runat="server">
    <ext:ResourceManager runat="server" />

    <ext:Window
      ID="Window1"
      runat="server"
      Width="700"
      Floatable="false"
      Height="800"
      Title="Docente"
      Closable="false"
      Layout="Form"
      AutoScroll="true"
      Header="false"
      BodyPadding="5">
      <Defaults>
        <ext:Parameter Name="LabelWidth" Value="200" />
      </Defaults>
      <Items>
        <ext:TextField
          runat="server"
          Note="John Due"
          FieldLabel="Todos los nombres"
          Editable="true"
          Vtype="text"
          AllowBlank="false"
          BlankText="Tu nombre es requerido.">
        </ext:TextField>
        <ext:TextField runat="server" FieldLabel="Primer apellido" Editable="true"></ext:TextField>
        <ext:TextField runat="server" FieldLabel="Segundo apellido" Editable="true"></ext:TextField>

        <ext:TextField runat="server" Note="9999999999" FieldLabel="Libreta militar">
          <Plugins>
            <ext:InputMask runat="server" Mask="9999999999" />
          </Plugins>
        </ext:TextField>

        <ext:DateField runat="server" Type="Date" FieldLabel="Fecha de nacimiento" />

        <ext:TextField runat="server" FieldLabel="Dirección" Editable="true"></ext:TextField>

        <ext:TextField runat="server" Note="(99) (99) 9999999" MaskRe="/[0-9]/" FieldLabel="Telefono fijo">
          <Plugins>
            <ext:InputMask runat="server" Mask="(99) (99) 9999999" />
          </Plugins>
        </ext:TextField>

        <ext:TextField runat="server" Note="(999) 9999999" FieldLabel="Telefono móvil">
          <Plugins>
            <ext:InputMask runat="server" Mask="(999) 9999999" />
          </Plugins>
        </ext:TextField>

        <ext:TextField
          runat="server"
          FieldLabel="Correo electronico"
          InputType="Email"
          ValidateRequestMode="Enabled"
          Note="nombre@dominio.com">
        </ext:TextField>

        <ext:SelectBox
          runat="server"
          DisplayField="TPDC_NOMBRE"
          ValueField="TPDC_IDTIPODOCUMENTO"
          FieldLabel="Tipo de documento"
          EmptyText="Tipo de documento.">
          <Store>
            <ext:Store ID="TiposDocumento" runat="server">
              <Model>
                <ext:Model runat="server">
                  <Fields>
                    <ext:ModelField Name="TPDC_IDTIPODOCUMENTO" />
                    <ext:ModelField Name="TPDC_NOMBRE" />
                  </Fields>
                </ext:Model>
              </Model>
            </ext:Store>
          </Store>
        </ext:SelectBox>

        <ext:TextField
          runat="server"
          ID="NumDocumento"
          FieldLabel="Documento de identidad"
          InputType="Number"
          Note="Documento de identidad">
        </ext:TextField>

        <ext:SelectBox
          runat="server"
          ID="PaisActualSelect"
          OnDirectChange="Ciudad_ItemSelected"
          DisplayField="PAIS_NOMBRE"
          ValueField="PAIS_IDPAIS"
          FieldLabel="Pais"
          EmptyText="Pais actual">
          <Store>
            <ext:Store ID="PaisActual" runat="server">
              <Model>
                <ext:Model runat="server">
                  <Fields>
                    <ext:ModelField Name="PAIS_IDPAIS" />
                    <ext:ModelField Name="PAIS_NOMBRE" />
                  </Fields>
                </ext:Model>
              </Model>
            </ext:Store>
          </Store>
        </ext:SelectBox>

        <ext:SelectBox
          runat="server"
          DisplayField="DPTO_NOMBRE"
          ValueField="DPTO_IDDEPARTAMENTO"
          FieldLabel="Ciudad actual"
          EmptyText="Ciudad de residencia">
          <Store>
            <ext:Store ID="Ciudad" runat="server">
              <Model>
                <ext:Model runat="server">
                  <Fields>
                    <ext:ModelField Name="DPTO_IDDEPARTAMENTO" />
                    <ext:ModelField Name="DPTO_NOMBRE" />
                  </Fields>
                </ext:Model>
              </Model>
            </ext:Store>
          </Store>
        </ext:SelectBox>

        <ext:SelectBox
          runat="server"
          DisplayField="PAIS_NOMBRE"
          ValueField="PAIS_IDPAIS"
          FieldLabel="Nacionalidad"
          EmptyText="Nacionalidad">
          <Store>
            <ext:Store ID="Nacionalidad" runat="server">
              <Model>
                <ext:Model runat="server">
                  <Fields>
                    <ext:ModelField Name="PAIS_IDPAIS" />
                    <ext:ModelField Name="PAIS_NOMBRE" />
                  </Fields>
                </ext:Model>
              </Model>
            </ext:Store>
          </Store>
        </ext:SelectBox>

        <ext:Button
          runat="server"
          Text="Continuar"
          AutoLoadingState="true"
          Region="East"
          OnDirectClick="Continuar_Click" />
      </Items>
    </ext:Window>
  </form>
</body>
</html>