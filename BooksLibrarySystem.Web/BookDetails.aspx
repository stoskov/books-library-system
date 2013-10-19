<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="BooksLibrarySystem.Web.BookDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book Details</h1>

    <asp:Repeater runat="server" ID="RepeaterBookDetails" ItemType="BooksLibrarySystem.Models.Book">
        <ItemTemplate>
            <header>
                <p class="book-title"><%#: Item.Title %></p>
                <p class="book-author"><%#: Item.Authors %></p>
                <p class="book-isbn">ISBN <%#: Item.ISBN %></p>
                <p class="book-web-site">
                    <span>Web site:</span>
                    <a href="<%#: Item.WebSite %>"><%#: Item.WebSite %></a>
                </p>
            </header>
            <div class="row-fluid">
                <div class="span12 book-description">
                    <p><%#: Item.Description  %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <div class="back-link">
        <a href="/">Back to books</a>
    </div>
</asp:Content>
