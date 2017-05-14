﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearDetalle.aspx.cs" Inherits="ConvocatoriaDocente.Views.Competencias.Investigacion.CrearDetalle" %>

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
      ID="Window2"
      runat="server"
      Width="500"
      Height="470"
      Title="Example">
      <Loader
        runat="server"
        Url="http://ext.net/"
        Mode="Frame">
        <LoadMask ShowMask="true" Msg="Custom Loading Message..." />
      </Loader>
      <TopBar>
        <ext:Toolbar runat="server">
          <Items>
            <ext:ToolbarFill />
            <ext:Button runat="server" Text="Load Ext.NET forums" Icon="Application">
              <Listeners>
                <Click Handler="#{Window1}.load('http://forums.ext.net/');" />
              </Listeners>
            </ext:Button>

            <ext:Button runat="server" Text="Refresh" Icon="ArrowRotateClockwise">
              <Listeners>
                <Click Handler="#{Window1}.reload();" />
              </Listeners>
            </ext:Button>
          </Items>
        </ext:Toolbar>
      </TopBar>
    </ext:Window>

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
                        <ext:ModelField Name="TPDC_IDTIPODOCUMENTO" runat="server"></ext:ModelField>
                        <ext:ModelField Name="TPDC_NOMBRE" runat="server"></ext:ModelField>
                      </Fields>
                    </ext:Model>
                  </Model>
                </ext:Store>
              </Store>
              <ColumnModel>
                <Columns>
                  <ext:RowNumbererColumn runat="server"></ext:RowNumbererColumn>
                  <ext:Column runat="server" Flex="2" DataIndex="TPDC_IDTIPODOCUMENTO" Text="Id">
                  </ext:Column>
                  <ext:Column runat="server" Flex="5" DataIndex="TPDC_NOMBRE" Text="Nombre">
                  </ext:Column>
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
