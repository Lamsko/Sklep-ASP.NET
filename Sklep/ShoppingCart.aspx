<%@ Page Title="Koszyk" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="ShoppingCart.aspx.cs" Inherits="Sklep.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ShoppingCartTitle" runat="server" class="ContentHead">
        <h1><%: Page.Title %></h1>
    </div>
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="false" ShowFooter="true"
        GridLines="Vertical" CellPadding="4" ItemType="Sklep.Models.CartItem"
        SelectMethod="GetShoppingCartItems" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID" />
            <asp:BoundField DataField="Product.ProductName" HeaderText="Nazwa" />
            <asp:BoundField DataField="Product.UnitPrice" HeaderText="Cena (sztuka)" DataFormatString="{0;c}"/>
            <asp:TemplateField HeaderText="Ilość">
                <ItemTemplate>
                    <asp:TextBox ID="PurchaseQuantity" Width="40" runat="server" 
                        Text="<%#: Item.Quantity %>"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ilość łącznie">
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *
    Convert.ToDouble(Item.Product.UnitPrice)))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usuń produkt">
                <ItemTemplate>
                    <asp:CheckBox ID="Remove" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Łączna cena zamówienia:"></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong>
    </div>
    <br />
</asp:Content>
