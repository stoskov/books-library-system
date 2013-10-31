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
							<a class="block"href="<%# GetRouteUrl("BookDetails", new {ID = Item.BookId})%>">
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
							<a href="<%# GetRouteUrl("CategoryDetails", new {ID = Item.CategoryId})%>"><%#:  Item.Category.Name %></a>
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

			<asp:FormView runat="server" ID="FormViewBook"
				CssClass="row-fluid"
				Visible="false"
				SelectMethod="FormViewBook_GetItem"
				DeleteMethod="FormViewBook_DeleteItem"
				InsertMethod="FormViewBook_InsertItem"
				UpdateMethod="FormViewBook_UpdateItem"
				DataKeyNames="BookId"
				ItemType="BooksLibrarySystem.Models.Book">
				<InsertItemTemplate>
					<div class="panel span12">
						<h3>Create New Book</h3>

						<label>
							<span>Title</span>
							<asp:TextBox runat="server" ID="TextBoxBookCreateTitle" CssClass="span11"
								placeholder="Enter book title..." Text="<%# BindItem.Title %>"></asp:TextBox>
						</label>
						<label>
							<span>Author(s)</span>
							<asp:TextBox runat="server" ID="TextBoxBookCreateAuthors" CssClass="span11"
								placeholder="Enter book author / authors ..." Text="<%# BindItem.Authors %>"></asp:TextBox>
						</label>
						<label>
							<span>ISBN</span>
							<asp:TextBox runat="server" ID="TextBoxBookCreateISBN" CssClass="span11"
								placeholder="Enter book ISBN ..." Text="<%# BindItem.ISBN %>"></asp:TextBox>
						</label>
						<label>
							<span>Web site</span>
							<asp:TextBox runat="server" ID="TextBoxBookCreateWebSite" CssClass="span11"
								placeholder="Enter book web site ..." Text="<%# BindItem.WebSite %>"></asp:TextBox>
						</label>
						<label>
							<span>Description</span>
							<asp:TextBox runat="server" TextMode="MultiLine" Rows="8" Columns="20" ID="TextTextBoxBookCreateDescription" CssClass="span11"
								placeholder="Enter book description ..." Text="<%# BindItem.Description %>"></asp:TextBox>
						</label>
						<label>
							<span>Category</span>
							<asp:DropDownList runat="server" ID="DropDownListBookCreateCategory" CssClass="span11" SelectedValue="<%# BindItem.CategoryId %>" 
								SelectMethod="GridViewCategories_GetData" DataTextField="Name" DataValueField="CategoryId">
							</asp:DropDownList>
						</label>

						<div class="pull-right">
							<asp:LinkButton ID="LinkButton1" runat="server" CssClass="link-button" Text="Create" CommandName="Insert"></asp:LinkButton>
							<asp:LinkButton ID="LinkButton2" runat="server" CssClass="link-button" Text="Cancel" CommandName="Cancel" OnCommand="FormView_Command"></asp:LinkButton>
						</div>
					</div>
				</InsertItemTemplate>
				<EditItemTemplate>
					<div class="panel span12">
						<h3>Edit Book</h3>
						<label>
							<span>Title</span>
							<asp:TextBox runat="server" ID="TextBoxBookEditTitle" CssClass="span11"
								placeholder="Enter book title..." Text="<%# BindItem.Title %>"></asp:TextBox>
						</label>
						<label>
							<span>Author(s)</span>
							<asp:TextBox runat="server" ID="TextBoxBookEditAuthors" CssClass="span11"
								placeholder="Enter book author / authors ..." Text="<%# BindItem.Authors %>"></asp:TextBox>
						</label>
						<label>
							<span>ISBN</span>
							<asp:TextBox runat="server" ID="TextBoxBookEditISBN" CssClass="span11"
								placeholder="Enter book ISBN ..." Text="<%# BindItem.ISBN %>"></asp:TextBox>
						</label>
						<label>
							<span>Web site</span>
							<asp:TextBox runat="server" ID="TextBoxBookEditWebSite" CssClass="span11"
								placeholder="Enter book web site ..." Text="<%# BindItem.WebSite %>"></asp:TextBox>
						</label>
						<label>
							<span>Description</span>
							<asp:TextBox runat="server" TextMode="MultiLine" Rows="8" Columns="20" ID="TextTextBoxBookEditDescription" CssClass="span11"
								placeholder="Enter book description ..." Text="<%# BindItem.Description %>"></asp:TextBox>
						</label>
						<label>
							<span>Category</span>
							<asp:DropDownList runat="server" ID="DropDownListBookEditCategory" CssClass="span11" SelectedValue="<%# BindItem.CategoryId %>" 
								SelectMethod="GridViewCategories_GetData" DataTextField="Name" DataValueField="CategoryId">
							</asp:DropDownList>
						</label>
						<div class="pull-right">
							<asp:LinkButton ID="LinkButton3" runat="server" CssClass="link-button" Text="Save" CommandName="Update"></asp:LinkButton>
							<asp:LinkButton ID="LinkButton4" runat="server" CssClass="link-button" Text="Cancel" CommandName="Cancel" OnCommand="FormView_Command"></asp:LinkButton>
						</div>
					</div>
				</EditItemTemplate>
				<ItemTemplate>
					<div class="panel span12">
						<h3>Confirm Book Deletion?</h3>
						<label>
							<span>Title</span>
							<asp:TextBox runat="server" ID="TextBoxBookEditTitle" CssClass="span11"
								placeholder="Enter book title..." Text="<%# BindItem.Title %>" Enabled="false"></asp:TextBox>
						</label>
						<label>
							<span>Author(s)</span>
							<asp:TextBox runat="server" ID="TextBoxBookEditAuthors" CssClass="span11"
								placeholder="Enter book author / authors ..." Text="<%# BindItem.Authors %>" Enabled="false"></asp:TextBox>
						</label>
						<label>
							<span>ISBN</span>
							<asp:TextBox runat="server" ID="TextBoxBookEditISBN" CssClass="span11"
								placeholder="Enter book ISBN ..." Text="<%# BindItem.ISBN %>" Enabled="false"></asp:TextBox>
						</label>
						<label>
							<span>Web site</span>
							<asp:TextBox runat="server" ID="TextBoxBookEditWebSite" CssClass="span11"
								placeholder="Enter book web site ..." Text="<%# BindItem.WebSite %>" Enabled="false"></asp:TextBox>
						</label>
						<label>
							<span>Description</span>
							<asp:TextBox runat="server" TextMode="MultiLine" Rows="8" Columns="20" ID="TextTextBoxBookEditDescription" CssClass="span11"
								placeholder="Enter book description ..." Text="<%# BindItem.Description %>" Enabled="false"></asp:TextBox>
						</label>
						<label>
							<span>Category</span>
							<asp:DropDownList runat="server" ID="DropDownListBookEditCategory" CssClass="span11" SelectedValue="<%# BindItem.CategoryId %>" 
								SelectMethod="GridViewCategories_GetData" DataTextField="Name" DataValueField="CategoryId" Enabled="false">
							</asp:DropDownList>
						</label>
						<div class="pull-right">
							<asp:LinkButton ID="LinkButton5" runat="server" CssClass="link-button" Text="Yes" CommandName="Delete"></asp:LinkButton>
							<asp:LinkButton ID="LinkButton6" runat="server" CssClass="link-button" Text="Cancel" CommandName="Cancel" OnCommand="FormView_Command"></asp:LinkButton>
						</div>
					</div>
				</ItemTemplate>
			</asp:FormView>

		</div>
	</div>

	<div class="back-link">
		<a href="/">Back to books</a>
	</div>
</asp:Content>
