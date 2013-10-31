<%@ Page Title="Search Result" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BooksLibrarySystem.Web.Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="span12">
			<asp:Panel runat="server" CssClass="input-append" DefaultButton="LinkButtonSearch">
				<asp:TextBox runat="server" ID="TextBoxSearch" CssClass="span11" placeholder="Search by book title / author / description..."></asp:TextBox>
				<asp:LinkButton runat="server" CssClass="btn" Text="Search" ID="LinkButtonSearch" OnClick="LinkButtonSearch_Click"></asp:LinkButton>
			</asp:Panel>
		</div>
		<h4 class="span12">Result (<%: this.ResultCount %>):
		</h4>
		<div class="span12 search-result">

			<asp:ListView runat="server" ID="ResultView" ItemType="BooksLibrarySystem.Web.ViewModels.BookSearchViewModel">
				<LayoutTemplate>
					<ul>
						<div runat="server" id="itemPlaceHolder"></div>
					</ul>
				</LayoutTemplate>
				<ItemTemplate>
					<li class="search-result result-item">
						<div>
							<a class="search main-link" href="<%# GetRouteUrl("BookDetails", new {ID = Item.BookId})%>">Title: <%#: Item.Title %>
							</a>
						</div>
						<div>
							<a class="search sub-link" href="<%# GetRouteUrl("CategoryDetails", new {ID = Item.CategoryId})%>">Category: <%#: Item.CategoryName %>
							</a>
						</div>
						<div class="block muted">Authors: <%#: Item.Authors %></div>
						<div class="block muted">Description: <%#: this.ShortenText(Item.Description, 100)%></div>
					</li>
				</ItemTemplate>
			</asp:ListView>

		</div>

	</div>

	<hr />

	<div class="btn-group">
		<asp:DataPager runat="server" PagedControlID="ResultView" PageSize="10" QueryStringField="page">
			<Fields>
				<asp:NextPreviousPagerField
					FirstPageText="<<"
					LastPageText=">>"
					PreviousPageText="<"
					NextPageText=">"
					ButtonCssClass="btn"
					ButtonType="Button"
					ShowFirstPageButton="true"
					ShowLastPageButton="true"
					ShowPreviousPageButton="true"
					ShowNextPageButton="true" />

			</Fields>
		</asp:DataPager>
	</div>
	<div class="back-link">
		<a href="/">Back</a>
	</div>
</asp:Content>
