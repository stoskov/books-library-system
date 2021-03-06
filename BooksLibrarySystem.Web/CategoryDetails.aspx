﻿<%@ Page Title="Category Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="BooksLibrarySystem.Web.CategoryDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Category Details</h2>

	<header>
		<p class="category-name"><%: this.Category.Name %></p>
		<p>
			<strong>Total Books:</strong>
			<span class="category-info"> <%: this.Category.Books.Count() %></span>
		</p>
	</header>
	<asp:GridView ID="GridViewBooks" runat="server" ItemType="BooksLibrarySystem.Models.Book" CssClass="gridview"
				  AutoGenerateColumns="False" DataKeyNames="BookId" PageSize="20" AllowPaging="true" AllowSorting="true"
				  SelectMethod="GridViewBooks_GetData">
		<Columns>
			<asp:TemplateField SortExpression="Title" HeaderText="Title">
				<ItemTemplate>
					<a class="" href="<%# GetRouteUrl("BookDetails", new {ID = Item.BookId})%>">
					<%#:  Item.Title %>
					</a>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField SortExpression="Authors" HeaderText="Authors">
				<ItemTemplate>
					<asp:Label runat="server" Text='<%#: Item.Authors %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField SortExpression="ISBN" HeaderText="ISBN">
				<ItemTemplate>
					<asp:Label runat="server" Text='<%#: Item.ISBN %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField SortExpression="WebSite" HeaderText="Web Site">
				<ItemTemplate>
					<asp:HyperLink runat="server" NavigateUrl='<%#: Item.WebSite %>' Text='<%#: Item.WebSite%>'></asp:HyperLink>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>

	<div class="back-link">
		<a href="/">Back</a>
	</div>
</asp:Content>
