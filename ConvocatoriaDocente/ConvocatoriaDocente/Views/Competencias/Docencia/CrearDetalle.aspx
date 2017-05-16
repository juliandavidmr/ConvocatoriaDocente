<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearDetalle.aspx.cs" Inherits="ConvocatoriaDocente.Views.Competencias.Docencia.CrearDetalle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <ext:ResourceManager runat="server" />

    <ext:Window
      ID="Window1"
      runat="server"
      Width="700"
      Floatable="false"
      Height="800"
      Title="Competencias en docencia universitaria"
      Closable="false"
      Layout="Form"
      AutoScroll="true"
      Header="true"
      BodyPadding="5">
      <Defaults>
        <ext:Parameter Name="LabelWidth" Value="200" />
      </Defaults>
      <Items>
        <ext:Panel runat="server" Header="false" Layout="FormLayout">
          <Items>
            <ext:TextField
              runat="server"
              ID="NumeroIdent"
              FieldLabel="Numero de identficación"
              Editable="false"
              Enabled="false"
              Vtype="text"
              ValidateBlank="false"
              BlankText="Numero de identficación">
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="Institucion"
              FieldLabel="Institución"
              Editable="true"
              Vtype="text"
              AllowBlank="false"
              BlankText="Institucion">
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="AreaTrabajo"
              FieldLabel="Area de trabajo"
              Editable="true"
              Vtype="text"
              AllowBlank="false"
              BlankText="Area de trabajo">
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="Cargo"
              FieldLabel="Cargo"
              Editable="true"
              Vtype="text"
              AllowBlank="false"
              BlankText="Cargo desarrollado">
            </ext:TextField>

            <ext:DateField
              runat="server"
              ID="FechaInicio"
              Type="Date"
              ValidateBlank="true"
              FieldLabel="Fecha de inicio" />

            <ext:DateField
              runat="server"
              ID="FechaFinal"
              Type="Date"
              ValidateBlank="true"
              FieldLabel="Fecha de finalización" />

            <ext:Button
              ID="Button1"
              runat="server"
              Text="Añadir"
              Icon="Add"
              OnDirectClick="AddDetalle_Click" />
          </Items>
        </ext:Panel>

        <ext:Panel runat="server" Header="false" Layout="FitLayout">
          <Items>

            <ext:GridPanel runat="server" MarginSpec="0 10 30">
              <Store>
                <ext:Store AutoDataBind="true" runat="server" ID="DocenciaDetalle">
                  <Model>
                    <ext:Model runat="server">
                      <Fields>
                        <ext:ModelField Name="DCDT_INSTITUCION" runat="server"></ext:ModelField>
                        <ext:ModelField Name="DCDT_AREA_TRABAJO" runat="server"></ext:ModelField>
                        <ext:ModelField Name="DCDT_CARGO" runat="server"></ext:ModelField>
                        <ext:ModelField Name="DCDT_INICIO" runat="server"></ext:ModelField>
                        <ext:ModelField Name="DCDT_FIN" runat="server"></ext:ModelField>
                        <ext:ModelField Name="DCDT_PUNTAJE" runat="server"></ext:ModelField>
                      </Fields>
                    </ext:Model>
                  </Model>
                </ext:Store>
              </Store>
              <ColumnModel>
                <Columns>
                  <ext:RowNumbererColumn runat="server"></ext:RowNumbererColumn>
                  <ext:Column runat="server" Flex="4" DataIndex="DCDT_INSTITUCION" Text="Institución"></ext:Column>
                  <ext:Column runat="server" Flex="5" DataIndex="DCDT_AREA_TRABAJO" Text="Area"></ext:Column>
                  <ext:Column runat="server" Flex="5" DataIndex="DCDT_CARGO" Text="Cargo"></ext:Column>
                  <ext:Column runat="server" Flex="3" DataIndex="DCDT_INICIO" Text="Inicio"></ext:Column>
                  <ext:Column runat="server" Flex="3" DataIndex="DCDT_FIN" Text="Fin"></ext:Column>
                  <ext:Column runat="server" Flex="2" DataIndex="DCDT_PUNTAJE" Text="Puntaje"></ext:Column>
                </Columns>
              </ColumnModel>
            </ext:GridPanel>
          </Items>
        </ext:Panel>

        <ext:Button
          runat="server"
          Text="Continuar"
          AutoLoadingState="true"
          OnDirectClick="Continuar_DirectClick" />
      </Items>
    </ext:Window>
  </form>
</body>
</html>
