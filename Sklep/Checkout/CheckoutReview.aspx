﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
	CodeBehind="CheckoutReview.aspx.cs" Inherits="Sklep.Checkout.CheckoutReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Podsumowanie zamówienia</h1>
	<p></p>
	<h3 style="padding-left: 33px">Produkty:</h3>
	<asp:GridView ID="OrderItemList" runat="server" AutoGenerateColumns="false"
		GridLines="Both" CellPadding="10" Width="500" BorderColor="#efeeef" BorderWidth="33">
		<Columns>
			<asp:BoundField DataField="ProductId" HeaderText="Kod produktu" />
			<asp:BoundField DataField="Product.ProductName" HeaderText="Nazwa produktu" />
			<asp:BoundField DataField="Product.UnitPrice" HeaderText="Cena jednostkowa"  DataFormatString="{0:c}"/>
			<asp:BoundField DataField="Quantity" HeaderText="Ilość" />
		</Columns>
	</asp:GridView>
	<asp:DetailsView ID="ShipInfo" runat="server" AutoGenerateRows="false" GridLines="None"
		CellPadding="10" BorderStyle="None" CommandRowStyle-BorderStyle="None">
		<Fields>
			<asp:TemplateField>
				<ItemTemplate>
					<h3>Adres dostawy:</h3>
					<br />
					<asp:Label ID="FirstName" runat="server" Text='<%#:Eval("FirstName") %>'></asp:Label>
					<asp:Label ID="LastName" runat="server" Text='<%#:Eval("LastName") %>'></asp:Label>
					<asp:Label ID="Address" runat="server" Text='<%#:Eval("Address") %>'></asp:Label>
					<asp:Label ID="City" runat="server" Text='<%#:Eval("City") %>'></asp:Label>
					<asp:Label ID="State" runat="server" Text='<%#:Eval("State") %>'></asp:Label>
					<asp:Label ID="PostalCode" runat="server" Text='<%#:Eval("PostalCode") %>'></asp:Label>
					<p></p>
					<h3>Łączna cena zamówienia:</h3>
					<br />
					<asp:Label ID="Total" runat="server" Text='<%#:Eval("Total","{0:c}") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
		</Fields>
	</asp:DetailsView>
	<asp:Button ID="CheckoutConfirm" runat="server" Text="Sfinalizuj zamówienie" />
</asp:Content>
