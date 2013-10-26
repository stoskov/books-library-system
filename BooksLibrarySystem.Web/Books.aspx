<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="BooksLibrarySystem.Web.Admin.Books" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="span12">
			<h2>Books</h2>
		</div>

		<div class="span12">

			<asp:GridView ID="GridViewBooks" runat="server" ItemType="BooksLibrarySystem.Models.Book" CssClass="gridview"
						  AutoGenerateColumns="False" DataKeyNames="BookId" PageSize="10" AllowPaging="true" AllowSorting="true"
						  SelectMethod="GridViewBooks_GetData">
				<Columns>
					<asp:TemplateField SortExpression="Title" HeaderText="Title">
						<ItemTemplate>
							<a class="block" href='BookDetails?id=<%#:Item.BookId %>'>
							<%#:  Item.Title%>
							</a>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField SortExpression="Authors" HeaderText="Author">
						<ItemTemplate>
							<asp:Label runat="server" Text='<%#: Item.Authors %>'></asp:Label>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Category">
						<ItemTemplate>
							<a href='CategoryDetails?id=<%#: Item.Category.CategoryId %>'><%#:  Item.Category.Name %></a>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Action">
						<ItemStyle CssClass="actions-column" />
						<ItemTemplate>
							<asp:LinkButton ID="LinkButtonEditBook" runat="server" Text="Edit" CssClass="link-button"
											OnCommand="LinkButtonEditBook_Command" CommandName="EditBook" CommandArgument="<%# Item.BookId %>" />
							<asp:LinkButton ID="LinkButtonDeleteBook" runat="server" Text="Delete" CssClass="link-button"
											OnCommand="LinkButtonDeleteBook_Command" CommandName="DeleteBook" CommandArgument="<%# Item.BookId %>" />
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
			</asp:GridView>

			<div class="create-link">
				<asp:LinkButton runat="server" CssClass="link-button" ID="LinkButtonCreateNew" Text="Create New" OnClick="LinkButtonCreateNew_Click"></asp:LinkButton>
			</div>

			<asp:Panel runat="server" ID="PanelCreate" CssClass="panel" Visible="false">
				<h2>Create New Book</h2>

				<label>
					<span>Title:</span>
					<asp:TextBox runat="server" ID="TextBoxBookCreateTitle" placeholder="Enter book title..."></asp:TextBox>
				</label>
				<label>
					<span>Author(s):</span>
					<asp:TextBox runat="server" ID="TextBoxBookCreateAuthors" placeholder="Enter book author / authors ..."></asp:TextBox>
				</label>
				<label>
					<span>ISBN:</span>
					<asp:TextBox runat="server" ID="TextBoxBookCreateISBN" placeholder="Enter book ISBN ..."></asp:TextBox>
				</label>
				<label>
					<span>Web site:</span>
					<asp:TextBox runat="server" ID="TextBoxBookCreateWebSite" placeholder="Enter book web site ..."></asp:TextBox>
				</label>
				<label>
					<span>Description:</span>
					<asp:TextBox runat="server" TextMode="MultiLine" Rows="8" Columns="20" ID="TextTextBoxBookCreateDescription" placeholder="Enter book description ..."></asp:TextBox>
				</label>
				<label>
					<span>Category:</span>
					<asp:DropDownList runat="server" ID="DropDownListBookCreateCategory" SelectMethod="GridViewCategories_GetData" DataTextField="Name" DataValueField="CategoryId"></asp:DropDownList>
				</label>

				<asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="link-button" Text="Create" OnClick="LinkButtonCreate_Click"></asp:LinkButton>
				<asp:LinkButton runat="server" ID="LinkButtonCancelCreate" CssClass="link-button" Text="Cancel" OnClick="LinkButtonCancel_Click"></asp:LinkButton>
			</asp:Panel>

			<asp:Panel runat="server" ID="PanelEdit" CssClass="panel" Visible="false">
				<h2>Edit Book</h2>

				<label>
					<span>Title:</span>
					<asp:TextBox runat="server" ID="TextBoxBookEditTitle" placeholder="Enter book title..."></asp:TextBox>
				</label>
				<label>
					<span>Author(s):</span>
					<asp:TextBox runat="server" ID="TextBoxBookEditAuthors" placeholder="Enter book author / authors ..."></asp:TextBox>
				</label>
				<label>
					<span>ISBN:</span>
					<asp:TextBox runat="server" ID="TextBoxBookEditISBN" placeholder="Enter book ISBN ..."></asp:TextBox>
				</label>
				<label>
					<span>Web site:</span>
					<asp:TextBox runat="server" ID="TextBoxBookEditWebSite" placeholder="Enter book web site ..."></asp:TextBox>
				</label>
				<label>
					<span>Description:</span>
					<asp:TextBox runat="server" TextMode="MultiLine" Rows="8" Columns="20" ID="TextTextBoxBookEditDescription" placeholder="Enter book description ..."></asp:TextBox>
				</label>
				<label>
					<span>Category:</span>
					<asp:DropDownList runat="server" ID="DropDownListBookEditCategory" SelectMethod="GridViewCategories_GetData" DataTextField="Name" DataValueField="CategoryId"></asp:DropDownList>
				</label>

				<asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="link-button" Text="Save" OnClick="LinkButtonEdit_Click"></asp:LinkButton>
				<asp:LinkButton runat="server" ID="LinkButtonCancelEdit" CssClass="link-button" Text="Cancel" OnClick="LinkButtonCancel_Click"></asp:LinkButton>

			</asp:Panel>
			<asp:Panel runat="server" ID="PanelDelete" CssClass="panel" Visible="false">

				<h2>Confirm Book Deletion?</h2>

				<label>
					<span>Title:</span>
					<asp:TextBox runat="server" TextMode="MultiLine" Rows="2" Columns="20" ID="TextTextBoxBookDeleteTitle" ReadOnly="true"></asp:TextBox>
				</label>

				<asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="link-button" Text="Yes" OnClick="LinkButtonDelete_Click"></asp:LinkButton>
				<asp:LinkButton runat="server" ID="LinkButtonCancelDelete" CssClass="link-button" Text="No" OnClick="LinkButtonCancel_Click"></asp:LinkButton>
			</asp:Panel>

		</div>
	</div>

	<div class="back-link">
		<a href="/">Back to books</a>
	</div>
</asp:Content>
