<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearDetalle.aspx.cs" Inherits="ConvocatoriaDocente.Views.Competencias.Personal.CrearDetalle" %>

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
      Title="Competencias personales"
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
              ValidateBlank="false">
            </ext:TextField>

            <ext:SelectBox
              runat="server"
              ID="TipoProfesionSelect"
              DisplayField="TPPR_NOMBRE"
              ValueField="TPPR_IDTIPOPROFESION"
              FieldLabel="Estudio realizado"
              EmptyText="Seleccione el tipo de estudio realizado.">
              <Store>
                <ext:Store ID="TiposProfesion" runat="server">
                  <Model>
                    <ext:Model runat="server">
                      <Fields>
                        <ext:ModelField Name="TPPR_IDTIPOPROFESION" />
                        <ext:ModelField Name="TPPR_NOMBRE" />
                      </Fields>
                    </ext:Model>
                  </Model>
                </ext:Store>
              </Store>
            </ext:SelectBox>

            <ext:TextField
              runat="server"
              ID="Universidad"
              FieldLabel="Universidad"
              Editable="true"
              Vtype="text"
              AllowBlank="false"
              ValidateBlank="true"
              MinLength="3"
              MaxLength="45"
              BlankText="Nombre completo de la Universidad">
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="Titulacion"
              FieldLabel="Titulación"
              Editable="true"
              Vtype="text"
              AllowBlank="false"
              ValidateBlank="true"
              MinLength="10"
              BlankText="Nombre completo del titulo obtenido">
            </ext:TextField>

            <ext:DateField
              runat="server"
              ID="FechaGraduacion"
              Type="Date"
              ValidateBlank="true"
              FieldLabel="Fecha de graduación" />

            <ext:Button
              ID="Button1"
              runat="server"
              Text="Añadir estudio"
              Icon="Add"
              OnDirectClick="AddDetalle_Click" />
          </Items>
        </ext:Panel>

        <ext:Panel runat="server" Header="false" Layout="FitLayout">
          <Items>
            <ext:GridPanel runat="server" MarginSpec="0 10 30">
              <Store>
                <ext:Store AutoDataBind="true" runat="server" ID="PersonalDetalle">
                  <Model>
                    <ext:Model runat="server">
                      <Fields>
                        <ext:ModelField Name="PRDT_UNIVERSIDAD" runat="server"></ext:ModelField>
                        <ext:ModelField Name="PRDT_GRADO" runat="server"></ext:ModelField>
                        <ext:ModelField Name="PRDT_TITULO" runat="server"></ext:ModelField>
                        <ext:ModelField Name="PRDT_PUNTAJE" runat="server"></ext:ModelField>
                      </Fields>
                    </ext:Model>
                  </Model>
                </ext:Store>
              </Store>
              <ColumnModel>
                <Columns>
                  <ext:RowNumbererColumn runat="server"></ext:RowNumbererColumn>
                  <ext:Column runat="server" Flex="3" DataIndex="PRDT_UNIVERSIDAD" Text="Universidad/Instituto"></ext:Column>
                  <ext:Column runat="server" Flex="4" DataIndex="PRDT_TITULO" Text="Titulo"></ext:Column>
                  <ext:Column runat="server" Flex="2" DataIndex="PRDT_GRADO" Text="Fecha"></ext:Column>
                  <ext:Column runat="server" Flex="2" DataIndex="PRDT_PUNTAJE" Text="Puntaje"></ext:Column>
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
