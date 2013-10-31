<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="BooksLibrarySystem.Web.BookDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Book Details</h2>

	<header>
		<p class="book-title"><%: this.Book.Title %></p>
		<p>
			<strong>Category:</strong>
			<% if (this.Book.Category != null)
			{%>
				<span class="book-info">
					<a href="<%= this.GetRouteUrl("CategoryDetails", new { ID = this.Book.Category.CategoryId })%>"><%: this.Book.Category.Name %></a>
				</span>
			<%}%>
		</p>
		<p>
			<strong>Authors:</strong>
			<span class="book-info"><%: this.Book.Authors %></span>
		</p>
		<p>
			<strong>ISBN:</strong>
			<span class="book-info"><%: this.Book.ISBN %></span>
		</p>
		<p>
			<strong>Web site:</strong>
			<span class="book-info">
				<a href="<%# Book.WebSite %>"><%: this.Book.WebSite %></a>
			</span>
		</p>
	</header>
	<div class="row-fluid">
		<div class="span12 book-description">
			<p><%: this.Book.Description  %></p>
		</div>
	</div>

	<div class="back-link">
		<a href="/">Back</a>
	</div>
</asp:Content>
