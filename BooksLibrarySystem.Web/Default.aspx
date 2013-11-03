<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BooksLibrarySystem.Web.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="span8">
			<h2>Top Categories</h2>
		</div>
		<div class="span4">
			<div class="search-button">
				<div class="form-search">
					<asp:Panel runat="server" CssClass="input-append" DefaultButton="LinkButtonSearch">
						<asp:TextBox runat="server" ID="TextBoxSearch" CssClass="span3 search-query" placeholder="Search by book title / author / description ..."></asp:TextBox>
						<asp:LinkButton runat="server" CssClass="btn" Text="Search" ID="LinkButtonSearch" OnClick="LinkButtonSearch_Click"></asp:LinkButton>
					</asp:Panel>
				</div>
			</div>
		</div>
	</div>

	<asp:ListView runat="server" ID="ListViewCategories" ItemType="BooksLibrarySystem.Web.ViewModels.CategorySummaryViewModel" GroupItemCount="3">
		<LayoutTemplate>
			<div id="groupPlaceholder" runat="server"></div>
		</LayoutTemplate>
		<GroupTemplate>
			<div class="row-fluid">
				<div id="itemPlaceholder" runat="server"></div>
			</div>
		</GroupTemplate>
		<ItemTemplate>

			<div class="span4">

				<h4>
					<a href="<%# GetRouteUrl("CategoryDetails", new {ID = Item.CategoryId})%>">
						<asp:Literal Mode="Encode" runat="server" Text='<%# Item.Name %> '></asp:Literal>
						<asp:Literal Mode="Encode" runat="server" Text='<%# "(" +  Item.TotalBooksCount + " books)" %>'></asp:Literal>
					</a>
				</h4>

				<asp:ListView runat="server" ID="ListViewBooks" ItemType="BooksLibrarySystem.Web.ViewModels.BookSummaryViewModel" DataSource="<%# Item.Books %>">
					<LayoutTemplate>
						<ul>
							<div id="itemPlaceholder" runat="server"></div>
						</ul>
					</LayoutTemplate>
					<ItemTemplate>
						<li>
							<a href="<%# GetRouteUrl("BookDetails", new {ID = Item.BookId})%>">
								<%#: Item.Title %>
							</a>
							<em class="muted block">by <%#: Item.Authors %></em>
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
