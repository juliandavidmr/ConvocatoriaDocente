<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="ConvocatoriaDocente.Views.Inscripcion.Crear" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title></title>
</head>
<body>
  <form runat="server">
    <ext:ResourceManager runat="server" />

    <ext:Window
      ID="Window1"
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
  </form>
</body>
</html>
