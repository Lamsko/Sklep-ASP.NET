﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="CheckoutError.aspx.cs" Inherits="Sklep.Checkout.CheckoutError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Błąd potwierdzenia zamówienia</h1>
	<p></p>
	<table id="ErrorTable">
		<tr>
			<td class="field"></td>
			<td><%=Request.QueryString.Get("ErrorCode") %></td>
		</tr>
		<tr>
			<td class="field"></td>
			<td><%=Request.QueryString.Get("Desc")%></td>
		</tr>
		<tr>
			<td class="field"></td>
			<td><%=Request.QueryString.Get("Desc2")%></td>
		</tr>
	</table>
</asp:Content>
