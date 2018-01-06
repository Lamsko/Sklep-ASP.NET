<%@ Page Title="Szczegóły produktu" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Sklep.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="productDetail" runat="server" ItemType="Sklep.Models.Product"
        SelectMethod="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#: Item.ProductName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Images/Thumbs/<%#: Item.ImagePath %>" 
                            style="border: solid; height="300"; width="300";" 
                            alt="<%#: Item.ProductName %>" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align:left;">
                        <b>Opis:</b><br /><%#: Item.Description %>
                        <br />
                        <span><b>Cena:</b>&nbsp;<%#: String.Format("{0:c}",Item.UnitPrice) %>
                        </span>
                        <br />
                        <span><b>Numer produktu:</b>&nbsp;<%# Item.ProductID %></span>
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
