<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BooksLibrarySystem.Web.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="span8">
            <h1>Top Categories</h1>
        </div>
        <div class="span4">
            <div class="search-button">
                <div class="form-search">
                    <asp:Panel runat="server" CssClass="input-append" DefaultButton="LinkButtonSearch">
                        <asp:TextBox runat="server" ID="TextBoxSearch" CssClass="span3 search-query" placeholder="Search by book title / author..."></asp:TextBox>
                        <asp:LinkButton runat="server" CssClass="btn" Text="Search" ID="LinkButtonSearch" OnClick="LinkButtonSearch_Click"></asp:LinkButton>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

    <asp:ListView runat="server" ID="ListViewCategories" ItemType="BooksLibrarySystem.Web.ViewModels.CategoryViewModel">
        <LayoutTemplate>

            <div id="itemPlaceholder" runat="server"></div>

        </LayoutTemplate>
        <ItemTemplate>
            <div class="span4">
                <h4>
                    <asp:Literal Mode="Encode" runat="server" Text='<%#Item.Name %> '></asp:Literal>
                    (<asp:Literal Mode="Encode" runat="server" Text='<%# Item.TotalBooksCount %>'></asp:Literal> books)
                </h4>

                <asp:ListView runat="server" ID="ListViewBooks" ItemType="BooksLibrarySystem.Web.ViewModels.BookViewModel" DataSource="<%# Item.Books %>">
                    <LayoutTemplate>

                        <ul>
                            <div id="itemPlaceholder" runat="server"></div>
                        </ul>

                    </LayoutTemplate>
                    <ItemTemplate>

                        <li>
                            <a class="block" href='BookDetails?id=<%#:Item.BookId %>'>
                                <%#: Item.Title %>
                            </a>
                            <em class="muted">by <%#: Item.Authors %></em>

                        </li>

                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <i>No books in this category.</i>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <div style="clear: both"></div>
</asp:Content>
