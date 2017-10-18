<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>

<asp:Label ID="titleLabel" runat="server" CssClass="sfTxtLbl" Visible="false" />
<div class="imgField">
    <asp:HiddenField ID="fieldBox" runat="server" />
    <img src="" style="width: 400px; margin: 0 auto 1rem;" />
</div>
<sf:SitefinityLabel id="descriptionLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfDescription" />
<sf:SitefinityLabel id="exampleLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfExample" />

