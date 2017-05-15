<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="ConvocatoriaDocente.Views.Docente.Crear" %>

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
      runat="server"
      Width="700"
      Closable="false"
      Header="false"
      Resizable="false">
      <Items>
        <ext:FormPanel
          ID="Window1"
          runat="server"
          Width="700"
          Floatable="false"
          Height="800"
          Title="Docente"
          Closable="false"
          Layout="FormLayout"
          AutoScroll="true"
          Header="true"
          BodyPadding="5">
          <Defaults>
            <ext:Parameter Name="LabelWidth" Value="200" />
          </Defaults>
          <Items>
            <ext:TextField
              runat="server"
              ID="Nombres"
              Note="John Due"
              FieldLabel="Todos los nombres"
              Editable="true"
              Vtype="text"
              AllowBlank="false"
              BlankText="Tu nombre es requerido.">
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="Apellido1"
              FieldLabel="Primer apellido"
              Editable="true">
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="Apellido2"
              FieldLabel="Segundo apellido"
              Editable="true">
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="Libreta"
              Note="9999999999"
              AllowBlank="true"
              FieldLabel="Libreta militar">
              <Plugins>
                <ext:InputMask runat="server" Mask="9999999999" />
              </Plugins>
            </ext:TextField>

            <ext:DateField
              runat="server"
              ID="FechaNacimiento"
              Type="Date"
              FieldLabel="Fecha de nacimiento" />

            <ext:TextField
              runat="server"
              ID="Direccion"
              FieldLabel="Dirección"
              Editable="true">
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="TelFijo"
              Note="(99) (99) 9999999"
              MaskRe="/[0-9]/"
              AllowBlank="true"
              FieldLabel="Telefono fijo">
              <Plugins>
                <ext:InputMask runat="server" Mask="(99) (99) 9999999" />
              </Plugins>
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="TelMovil"
              Note="(999) 9999999"
              FieldLabel="Telefono móvil">
              <Plugins>
                <ext:InputMask runat="server" Mask="(999) 9999999" />
              </Plugins>
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="Correo"
              FieldLabel="Correo electronico"
              InputType="Email"
              AllowBlank="false"
              ValidateRequestMode="Enabled"
              Note="nombre@dominio.com">
            </ext:TextField>

            <ext:SelectBox
              runat="server"
              ID="TipoDocumentoSelect"
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
              AllowBlank="false"
              Note="Documento de identidad">
            </ext:TextField>

            <ext:SelectBox
              runat="server"
              ID="PaisExpedicionSelect"
              OnDirectChange="CiudadExpedicion_ItemSelected"
              DisplayField="PAIS_NOMBRE"
              ValueField="PAIS_IDPAIS"
              FieldLabel="Pais de expedición"
              EmptyText="Seleccione el pais de expedicion de su documento.">
              <Store>
                <ext:Store ID="PaisExpedicion" runat="server">
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
              ID="CiudadExpedicionSelect"
              DisplayField="DPTO_NOMBRE"
              ValueField="DPTO_IDDEPARTAMENTO"
              FieldLabel="Expedición documento"
              EmptyText="Expedición documento">
              <Store>
                <ext:Store ID="CiudadExpedicion" runat="server">
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
              ID="PaisActualSelect"
              OnDirectChange="Ciudad_ItemSelected"
              DisplayField="PAIS_NOMBRE"
              ValueField="PAIS_IDPAIS"
              FieldLabel="Pais de residencia"
              EmptyText="Pais en el que vive">
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
              ID="CiudadActual"
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
              ID="NacionalidadSelect"
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
              Text="Continuar">
              <DirectEvents>
                <Click
                  OnEvent="Continuar_Click">
                  <EventMask ShowMask="true" Msg="Registrando docente. Espere para continuar..."></EventMask>
                </Click>
              </DirectEvents>
            </ext:Button>
          </Items>
        </ext:FormPanel>
      </Items>
    </ext:Window>

  </form>
</body>
</html>
