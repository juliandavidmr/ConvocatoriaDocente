<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="ConvocatoriaDocente.Views.TipoDocumento.Listar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <ext:ResourceManager runat="server" />

    <ext:Viewport runat="server" Layout="FitLayout">
      <Items>
        <ext:FormPanel
          runat="server"
          Flex="1"
          ID="FormGeneral"
          Frame="false"
          Collapsible="true"
          MarginSpec="5"
          Title="<b>Listado de tipos de documento</b>">
          <Items>

            <ext:Panel runat="server" Header="false" Layout="FitLayout">
              <Items>

                <ext:GridPanel runat="server" MarginSpec="0 10" ID="GridGruposInvestigacion">
                  <Store>
                    <ext:Store AutoDataBind="true" runat="server" ID="StoreTiposDoc">
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

          </Items>

        </ext:FormPanel>
      </Items>
    </ext:Viewport>
  </form>
</body>
</html>
