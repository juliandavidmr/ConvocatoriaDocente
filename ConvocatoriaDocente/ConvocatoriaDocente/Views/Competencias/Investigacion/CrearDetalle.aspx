<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearDetalle.aspx.cs" Inherits="ConvocatoriaDocente.Views.Competencias.Investigacion.CrearDetalle" %>

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
      Title="Competencias en investigación"
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
              ID="Financiadora"
              FieldLabel="Financiadora"
              Editable="true"
              Vtype="text"
              AllowBlank="false"
              BlankText="Entidad financiador o patrocinador">
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="NombreInvestigacion"
              FieldLabel="Nombre de la investigación"
              Editable="true"
              Vtype="text"
              AllowBlank="false"
              BlankText="Descripcion de la investigación">
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
              Text="Añadir investigación"
              Icon="Add"
              OnDirectClick="AddDetalle_Click" />
          </Items>
        </ext:Panel>

        <ext:Panel runat="server" Header="false" Layout="FitLayout">
          <Items>

            <ext:GridPanel runat="server" MarginSpec="0 10 30">
              <Store>
                <ext:Store AutoDataBind="true" runat="server" ID="InvestigacionDetalle">
                  <Model>
                    <ext:Model runat="server">
                      <Fields>
                        <ext:ModelField Name="INVD_FINANCIADORA" runat="server"></ext:ModelField>
                        <ext:ModelField Name="INVD_FECHA_INICIO" runat="server"></ext:ModelField>
                        <ext:ModelField Name="INVD_FECHA_FIN" runat="server"></ext:ModelField>
                        <ext:ModelField Name="INVD_PUNTAJE" runat="server"></ext:ModelField>
                      </Fields>
                    </ext:Model>
                  </Model>
                </ext:Store>
              </Store>
              <ColumnModel>
                <Columns>
                  <ext:RowNumbererColumn runat="server"></ext:RowNumbererColumn>
                  <ext:Column runat="server" Flex="5" DataIndex="INVD_FINANCIADORA" Text="Financiadora/Patrocinador"></ext:Column>
                  <ext:Column runat="server" Flex="3" DataIndex="INVD_FECHA_INICIO" Text="Inicio"></ext:Column>
                  <ext:Column runat="server" Flex="3" DataIndex="INVD_FECHA_FIN" Text="Fin"></ext:Column>
                  <ext:Column runat="server" Flex="1" DataIndex="INVD_PUNTAJE" Text="Puntaje"></ext:Column>
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
