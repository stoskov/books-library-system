<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="BooksLibrarySystem.Web.Categories" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="span12">
			<h2>Categories</h2>
		</div>

		<div class="span12">
			<asp:GridView ID="GridViewCategories" runat="server" ItemType="BooksLibrarySystem.Models.Category" CssClass="gridview"
				AutoGenerateColumns="False" DataKeyNames="CategoryId" PageSize="10" AllowPaging="true" AllowSorting="true"
				SelectMethod="GridViewCategories_GetData">
				<Columns>
					<asp:TemplateField HeaderText="Category Name">
						<ItemTemplate>
							<a href="<%# GetRouteUrl("CategoryDetails", new {ID = Item.CategoryId})%>"><%#: Item.Name %></a>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Action">
						<ItemStyle CssClass="actions-column" />
						<ItemTemplate>
							<asp:LinkButton ID="LinkButtonEditCategory" runat="server" Text="Edit" CssClass="link-button"
								OnCommand="LinkButtonEditCategory_Command" CommandName="EditCategory" CommandArgument="<%# Item.CategoryId %>" />
							<asp:LinkButton ID="LinkButtonDeleteCategory" runat="server" Text="Delete" CssClass="link-button"
								OnCommand="LinkButtonDeleteCategory_Command" CommandName="DeleteCategory" CommandArgument="<%# Item.CategoryId %>" />
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
			</asp:GridView>

			<div class="create-link">
				<asp:LinkButton runat="server" CssClass="link-button" ID="LinkButtonCreateNew" Text="Create New" OnClick="LinkButtonCreateNew_Click"></asp:LinkButton>
			</div>

			<asp:FormView runat="server" ID="FormViewCategory"
				CssClass="row-fluid"
				Visible="false"
				SelectMethod="FormViewCategory_GetItem"
				DeleteMethod="FormViewCategory_DeleteItem"
				InsertMethod="FormViewCategory_InsertItem"
				UpdateMethod="FormViewCategory_UpdateItem"
				DataKeyNames="CategoryId"
				ItemType="BooksLibrarySystem.Models.Category">
				<InsertItemTemplate>
					<div class="panel span12">
						<h3>Create New Category</h3>
						<label>
							<span>Name</span>
							<asp:TextBox ID="CategoryNameNew" runat="server" CssClass="span11" placeholder="Enter category name..." Text="<%# BindItem.Name %>"></asp:TextBox>
						</label>
						<div class="pull-right">
							<asp:LinkButton runat="server" CssClass="link-button" Text="Create" CommandName="Insert"></asp:LinkButton>
							<asp:LinkButton runat="server" CssClass="link-button" Text="Cancel" CommandName="Cancel" OnCommand="FormView_Command"></asp:LinkButton>
						</div>
					</div>
				</InsertItemTemplate>
				<EditItemTemplate>
					<div class="panel span12">
						<h3>Edit Category</h3>
						<label>
							<span>Name</span>
							<asp:TextBox ID="CategoryNameEdit" runat="server" CssClass="span11" placeholder="Enter category name..." Text="<%# BindItem.Name %>"></asp:TextBox>
						</label>
						<div class="pull-right">
							<asp:LinkButton runat="server" CssClass="link-button" Text="Save" CommandName="Update"></asp:LinkButton>
							<asp:LinkButton runat="server" CssClass="link-button" Text="Cancel" CommandName="Cancel" OnCommand="FormView_Command"></asp:LinkButton>
						</div>
					</div>
				</EditItemTemplate>
				<ItemTemplate>
					<div class="panel span12">
						<h3>Confirm Category Deletion?</h3>
						<label>
							<span>Name</span>
							<asp:TextBox ID="CategoryNameDelete" runat="server" CssClass="span11" placeholder="Enter category name..." Text="<%# BindItem.Name %>" Enabled="False"></asp:TextBox>
						</label>
						<div class="pull-right">
							<asp:LinkButton runat="server" CssClass="link-button" Text="Yes" CommandName="Delete"></asp:LinkButton>
							<asp:LinkButton runat="server" CssClass="link-button" Text="Cancel" CommandName="Cancel" OnCommand="FormView_Command"></asp:LinkButton>
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
