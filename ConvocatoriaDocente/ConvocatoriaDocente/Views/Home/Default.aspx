<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConvocatoriaDocente.Views.Home.Default" %>

<script runat="server">
  protected void Button1_Click(object sender, DirectEventArgs e) {
    X.Msg.Notify(new NotificationConfig {
      Icon = Icon.Accept,
      Title = "Working",
    }).Show();
  }

  protected void cargarFormulario(object sender, DirectEventArgs e) {
    string id = e.ExtraParams["id_item"];
    if (!id.StartsWith("ROOT")) {
      switch (id) {
        case "IdInscribirDocente":
          Window1.Loader.Url = "../Docente/Crear.aspx";
          TabPanel1.UpdateContent();
          break;
        case "IdCrearConvocatoria":
          Window1.Loader.Url = "../Convocatoria/Crear.aspx";
          TabPanel1.UpdateContent();
          break;
        case "IdListarTiposDoc":
          Window1.Loader.Url = "../TipoDocumento/Listar.aspx";
          TabPanel1.UpdateContent();
          break;
      }     
    }
  }
</script>

<!DOCTYPE html>

<html>
<head runat="server">
  <title>Convocatoria docente</title>

  <link href="/resources/css/examples.css" rel="stylesheet" />

  <ext:XScript runat="server">
        <script>
          var addTab = function (tabPanel, id, url, menuItem) {
            var tab = tabPanel.getComponent(id);

            if (!tab) {
              tab = tabPanel.add({
                id       : id,
                title    : url,
                closable : false,                
                menuItem : menuItem,
                loader   : {
                  url      : url,
                  renderer : "frame",
                  loadMask : {
                    showMask : true,
                    msg      : "Cargando " + url + "..."
                  }
                }
              });

              tab.on("activate", function (tab) {
                  #{MenuPanel1}.setSelection(tab.menuItem);
              });
            }

            tabPanel.setActiveTab(tab);
          }
        </script>
  </ext:XScript>
</head>
<body>


  <ext:ResourceManager runat="server" />

  <ext:Viewport runat="server" Layout="BorderLayout">
    <Items>

      <ext:Panel
        ID="West"
        runat="server"
        Title="West"
        Region="West"
        Frame="true"
        Width="300"
        Collapsible="true">
        <Items>
          <ext:TreePanel
            ID="TreePanel1"
            runat="server"
            Flex="2"
            Icon="BookOpen"
            Title="Convocatoria"
            Shadow="true"
            AutoScroll="true">
            <TopBar>
              <ext:Toolbar runat="server">
                <Items>
                  <ext:Button ID="Button2" runat="server" Text="Expandir">
                    <Listeners>
                      <Click Handler="#{TreePanel1}.expandAll();" />
                    </Listeners>
                  </ext:Button>
                  <ext:Button ID="Button3" runat="server" Text="Colapsar">
                    <Listeners>
                      <Click Handler="#{TreePanel1}.collapseAll();" />
                    </Listeners>
                  </ext:Button>
                </Items>
              </ext:Toolbar>
            </TopBar>
            <Root>
              <ext:Node Text="Menú principal" Expanded="true">

                <Children>
                  <ext:Node Text="Docente" NodeID="ROOT1" Icon="UserGray">
                    <Children>
                      <ext:Node 
                        NodeID="IdInscribirDocente" 
                        EmptyChildren="true" 
                        Text="Inscribir docente" 
                        Expandable="false" />
                    </Children>
                  </ext:Node>
                  <ext:Node 
                    Text="Convocatoria" 
                    NodeID="ROOT2" 
                    Icon="UserGray">
                    <Children>
                      <ext:Node 
                        NodeID="IdCrearConvocatoria" 
                        EmptyChildren="true" 
                        Text="Convocatoria" 
                        Expandable="false"
                        Icon="None"></ext:Node>
                    </Children>
                  </ext:Node>
                  <ext:Node
                    Text="Tipo de documento" Icon="BookAddresses">
                    <Children>
                      <ext:Node
                        NodeID="IdListarTiposDoc"
                        Text="Listar tipos de documentos"
                        Expandable="false"
                        EmptyChildren="true"></ext:Node>
                    </Children>
                  </ext:Node>
                </Children>

              </ext:Node>
            </Root>
            <BottomBar>
              <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
            </BottomBar>
            <Listeners>
              <ItemClick
                Handler="addTab(#{IdInscribirDocente}, 'idClt', 'http://ext.net', this);">
              </ItemClick>
              <ItemClick
                Handler="#{StatusBar1}.setStatus({text: 'Selección actual: <b>' + record.data.text + '<br />', clear: false});" />
              <ItemExpand
                Handler="#{StatusBar1}.setStatus({text: 'Selección actual: <b>' + item.data.text + '<br />', clear: false});"
                Buffer="30" />
              <ItemCollapse
                Handler="#{StatusBar1}.setStatus({text: 'Selección actual: <b>' + item.data.text + '<br />', clear: false});"
                Buffer="30" />
            </Listeners>
            <DirectEvents>
              <ItemClick OnEvent="cargarFormulario">
                <EventMask ShowMask="true" Msg="Cargando..." MinDelay="500"></EventMask>
                <ExtraParams>
                  <ext:Parameter Name="id_item" Mode="Raw" Value="record.data.id"></ext:Parameter>
                </ExtraParams>
              </ItemClick>
            </DirectEvents>
          </ext:TreePanel>
        </Items>
      </ext:Panel>

      <ext:Panel 
        runat="server" 
        Region="Center" 
        BodyPadding="5">
        <Items>

          <ext:Panel runat="server" Layout="HBoxLayout">
            <Items>
              <ext:TabPanel
                ID="TabPanel1" 
                runat="server" 
                Flex="7"
                Header="false"
                Region="Center">
                <Items>
                  <ext:Panel
                    ID="Window1"
                    runat="server"
                    Title="Tab"
                    Height="600"
                    Width="900"
                    Frame="true"
                    Collapsible="true"
                    Cls="box"
                    BodyPadding="5"
                    DefaultButton="0"
                    AutoRender="true"
                    Layout="FitLayout"
                    DefaultAnchor="100%">
                    <Loader runat="server" AutoLoad="true" Mode="Frame" Url="Home.aspx"></Loader>
                    <Items>
                    </Items>
                  </ext:Panel>
                </Items>
              </ext:TabPanel>
            </Items>
          </ext:Panel>

        </Items>
      </ext:Panel>

    </Items>
  </ext:Viewport>

</body>
</html>
