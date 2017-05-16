<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearDetalle.aspx.cs" Inherits="ConvocatoriaDocente.Views.Competencias.Produccion.CrearDetalle" %>

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
      Title="Producción academica"
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
              ID="Producto"
              FieldLabel="Nombre del producto"
              Editable="true"
              Vtype="text"
              AllowBlank="false"
              BlankText="Nombre del producto">
            </ext:TextField>
            
            <ext:TextField
              runat="server"
              ID="TipoProducto"
              FieldLabel="Tipo de producto"
              Editable="true"
              Vtype="text"
              AllowBlank="false"
              BlankText="Libro, articulo, revista...">
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="Identificador"
              FieldLabel="Indentificador (ISBN/ISSN)"
              Editable="true"
              Vtype="text"
              AllowBlank="false"
              BlankText="Indentificador (ISBN/ISSN)">
            </ext:TextField>

            <ext:TextField
              runat="server"
              ID="Volumen"
              FieldLabel="Volúmen"
              Editable="true"
              Vtype="text"
              AllowBlank="false"
              BlankText="Volúmen">
            </ext:TextField>

            <ext:DateField
              runat="server"
              ID="FechaEdicion"
              Type="Date"
              ValidateBlank="true"
              FieldLabel="Fecha de edición" />

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
                <ext:Store AutoDataBind="true" runat="server" ID="ProduccionDetalle">
                  <Model>
                    <ext:Model runat="server">
                      <Fields>
                        <ext:ModelField Name="PNDT_NOMBRE_PRODUCTO" runat="server"></ext:ModelField>
                        <ext:ModelField Name="PNDT_TIPO_PRODUCTO" runat="server"></ext:ModelField>
                        <ext:ModelField Name="PNDT_IDENTIFICADOR_CERT" runat="server"></ext:ModelField>
                        <ext:ModelField Name="PNDT_VOLUMEN" runat="server"></ext:ModelField>
                        <ext:ModelField Name="PNDT_FECHA_EDICION" runat="server"></ext:ModelField>
                        <ext:ModelField Name="PNDT_PUNTAJE" runat="server"></ext:ModelField>
                      </Fields>
                    </ext:Model>
                  </Model>
                </ext:Store>
              </Store>
              <ColumnModel>
                <Columns>
                  <ext:RowNumbererColumn runat="server"></ext:RowNumbererColumn>
                  <ext:Column runat="server" Flex="3" DataIndex="PNDT_NOMBRE_PRODUCTO" Text="Producto"></ext:Column>
                  <ext:Column runat="server" Flex="2" DataIndex="PNDT_TIPO_PRODUCTO" Text="Tipo"></ext:Column>
                  <ext:Column runat="server" Flex="2" DataIndex="PNDT_IDENTIFICADOR_CERT" Text="Identificador"></ext:Column>
                  <ext:Column runat="server" Flex="1" DataIndex="PNDT_VOLUMEN" Text="Vol"></ext:Column>
                  <ext:Column runat="server" Flex="2" DataIndex="PNDT_FECHA_EDICION" Text="Edicion"></ext:Column>
                  <ext:Column runat="server" Flex="1" DataIndex="PNDT_PUNTAJE" Text="Puntaje"></ext:Column>
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
