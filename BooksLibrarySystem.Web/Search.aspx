<%@ Page Title="Search Result" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BooksLibrarySystem.Web.Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="span12">
			<h1>
				Search Results for Query <i>"
					<asp:Literal runat="server" Mode="Encode" ID="LiteralQuery"></asp:Literal>" </i>
				<span>:</span>
			</h1>
		</div>

		<div class="span12 search-results">
			<ul>
				<asp:Repeater runat="server" ID="RepeaterSearchResult" ItemType="BooksLibrarySystem.Models.Book">
					<ItemTemplate>
						<li>
							<a href='BookDetails?id=<%#:Item.BookId %>'>
								<%#: Item.Title %>
								<i>by <%#: Item.Authors %></i>
							</a>
							<span>(Category: <%#: Item.Category.Name %>)</span>
						</li>
					</ItemTemplate>
				</asp:Repeater>
			</ul>
		</div>
	</div>

	<div class="back-link">
		<a href="/">Back to books</a>
	</div>
</asp:Content>
