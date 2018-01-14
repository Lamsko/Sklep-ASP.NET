<%@ Page Title="Kontakt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Sklep.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Dane kontaktowe:</h3>
    <address>
        Chorwacka 88/33<br />
        51-107 Wrocław<br />
        <abbr title="Phone">Tel:</abbr>
        +48 555 555 555 <br />
		 NIP: 1234567890 <br />
		 KRS: 1234567890 <br />
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
