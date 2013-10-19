<%@ Page Title="Search Result" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BooksLibrarySystem.Web.Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="span12">
			<asp:Panel  runat="server" CssClass="input-append" DefaultButton="LinkButtonSearch">
				<asp:TextBox runat="server" ID="TextBoxSearch" CssClass="span11" placeholder="Search by book title / author / description..."></asp:TextBox>
				<asp:LinkButton runat="server" CssClass="btn" Text="Search" ID="LinkButtonSearch" OnClick="LinkButtonSearch_Click"></asp:LinkButton>
			</asp:Panel>
		</div>
		<h4 class="span12">
			Result:
		</h4>
		<div class="span12 search-result">
			<ul>
				<asp:Repeater runat="server" ID="RepeaterSearchResult" ItemType="BooksLibrarySystem.Web.ViewModels.BookSearchViewModel">
					<ItemTemplate>
						<li class="search-result result-item">
							<div>
								<a class="block" href='BookDetails?id=<%#:Item.BookId %>'>
									Title: <%#: Item.Title %>
								</a>
								<a class="block" href='CategoryDetails?id=<%#:Item.CategoryId %>'>
									Category: <%#: Item.CategoryName %>
								</a>
							</div>
							<span class="muted">Authors: <%#: Item.Authors %></span>
						</li>
					</ItemTemplate>
				</asp:Repeater>
			</ul>
		</div>
	</div>

	<div class="back-link">
		<a href="/">Back</a>
	</div>
</asp:Content>
