<%@ Page Language="C#" %>

<script runat="server">
  protected void Button1_Click(object sender, DirectEventArgs e) {
    X.Msg.Notify(new NotificationConfig {
      Icon = Icon.Accept,
      Title = "Working",
      Html = this.TextArea1.Text
    }).Show();
  }
</script>

<!DOCTYPE html>

<html>
<head runat="server">
  <title>Convocatoria docente</title>

  <link type="text/css" rel="stylesheet" href="http://speed.ext.net/www/intro/css/main.css" />
  <link href="/resources/css/examples.css" rel="stylesheet" />

  <ext:XScript runat="server">
        <script>
          var addTab = function (tabPanel, id, url, menuItem) {
            var tab = tabPanel.getComponent(id);

            if (!tab) {
              tab = tabPanel.add({
                id       : id,
                title    : url,
                closable : true,
                menuItem : menuItem,
                loader   : {
                  url      : url,
                  renderer : "frame",
                  loadMask : {
                    showMask : true,
                    msg      : "Loading " + url + "..."
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
  <ext:ResourceManager runat="server" Theme="Triton" />

  <form runat="server">
    <ext:Window
      runat="server"
      Title="Convocatoria"
      Width="700"
      Height="500"
      Icon="Link"
      Layout="BorderLayout">
      <Items>
        <ext:TreePanel
          ID="TreePanel1"
          runat="server"
          Width="300"
          Height="450"
          Icon="BookOpen"
          Title="Catalog"
          Shadow="true"
          AutoScroll="true">
          <TopBar>
            <ext:Toolbar runat="server">
              <Items>
                <ext:Button ID="Button2" runat="server" Text="Expandir todo">
                  <Listeners>
                    <Click Handler="#{TreePanel1}.expandAll();" />
                  </Listeners>
                </ext:Button>
                <ext:Button ID="Button3" runat="server" Text="Colapsar todo">
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
                <ext:Node Text="Docente" Icon="UserGray">
                  <Children>
                    <ext:Node NodeID="IdInscribirDocente" EmptyChildren="true" Text="Inscribir docente" Expandable="false" />
                    <ext:Node Text="Quartets" Expandable="false"></ext:Node>
                  </Children>
                </ext:Node>
                <ext:Node Text="Brahms" Icon="UserGray">
                  <Children>
                    <ext:Node Text="Concertos">
                      <Children>
                        <ext:Node Text="Violin Concerto" Icon="Music" Leaf="true" />
                        <ext:Node Text="Double Concerto - A Minor" Icon="Music" Leaf="true" />
                        <ext:Node Text="Piano Concerto No. 1 - D Minor" Icon="Music" Leaf="true" />
                        <ext:Node Text="Piano Concerto No. 2 - B-Flat Major" Icon="Music" Leaf="true" />
                      </Children>
                    </ext:Node>
                    <ext:Node Text="Quartets">
                      <Children>
                        <ext:Node Text="Piano Quartet No. 1 - G Minor" Icon="Music" Leaf="true" />
                        <ext:Node Text="Piano Quartet No. 2 - A Major" Icon="Music" Leaf="true" />
                        <ext:Node Text="Piano Quartet No. 3 - C Minor" Icon="Music" Leaf="true" />
                        <ext:Node Text="Piano Quartet No. 3 - B-Flat Minor" Icon="Music" Leaf="true" />
                      </Children>
                    </ext:Node>
                  </Children>
                </ext:Node>
                <ext:Node Text="Mozart" Icon="UserGray">
                  <Children>
                    <ext:Node Text="Concertos">
                      <Children>
                        <ext:Node Text="Piano Concerto No. 12" Icon="Music" Leaf="true" />
                        <ext:Node Text="Piano Concerto No. 17" Icon="Music" Leaf="true" />
                        <ext:Node Text="Clarinet Concerto" Icon="Music" Leaf="true" />
                        <ext:Node Text="Violin Concerto No. 5" Icon="Music" Leaf="true" />
                        <ext:Node Text="Violin Concerto No. 4" Icon="Music" Leaf="true" />
                      </Children>
                    </ext:Node>
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
              Handler="#{StatusBar1}.setStatus({text: 'Node Selected: <b>' + record.data.text + '<br />', clear: false});" />
            <ItemExpand
              Handler="#{StatusBar1}.setStatus({text: 'Node Expanded: <b>' + item.data.text + '<br />', clear: false});"
              Buffer="30" />
            <ItemCollapse
              Handler="#{StatusBar1}.setStatus({text: 'Node Collapsed: <b>' + item.data.text + '<br />', clear: false});"
              Buffer="30" />
          </Listeners>
        </ext:TreePanel>
        <ext:TabPanel ID="TabPanel1" runat="server" Region="Center" />
      </Items>
    </ext:Window>

    <ext:Panel
      ID="Window1"
      runat="server"
      Title="Welcome to Ext.NET"
      Height="215"
      Width="350"
      Frame="true"
      Collapsible="true"
      Cls="box"
      BodyPadding="5"
      DefaultButton="0"
      Layout="AnchorLayout"
      DefaultAnchor="100%">
      <Items>
        <ext:TextArea
          ID="TextArea1"
          runat="server"
          EmptyText=">> Enter a Test Message Here <<"
          FieldLabel="Message"
          Height="85" />
      </Items>
      <Buttons>
        <ext:Button
          ID="Button1"
          runat="server"
          Text="Submit"
          Icon="Accept"
          OnDirectClick="Button1_Click" />
      </Buttons>
    </ext:Panel>
  </form>

  <footer>
    <p class="last">
      &copy; 2008-<%= DateTime.Today.Year %>
      <a href="http://object.net/">Object.NET</a>, Inc. All Rights Reserved.
    </p>
  </footer>
</body>
</html>
