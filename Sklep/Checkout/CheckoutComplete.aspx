<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
	CodeBehind="CheckoutComplete.aspx.cs" Inherits="Sklep.Checkout.CheckoutComplete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Zamówienie zakończone</h1>
	<p></p>
	<h3>ID transakcji płatności:</h3>
	<asp:Label ID="TransactionId" runat="server"></asp:Label>
	<p></p>
	<h3>Dziękujemy!</h3>
	<p></p>
	<hr />
	<asp:Button ID="Continue" runat="server" Text="Kontynuuj zakupy" OnClick="Continue_Click" />
</asp:Content>
