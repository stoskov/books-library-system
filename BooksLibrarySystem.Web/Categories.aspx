<%@ Page Title="Edit Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="BooksLibrarySystem.Web.Categories" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="span12">
			<h1>Edit Categories</h1>
		</div>

		<div class="span12">

			<asp:GridView ID="GridViewCategories" runat="server" ItemType="BooksLibrarySystem.Models.Category" CssClass="gridview"
						  AutoGenerateColumns="False" DataKeyNames="CategoryId" PageSize="15" AllowPaging="true" AllowSorting="true"
						  SelectMethod="GridViewCategories_GetData">
				<Columns>
					<asp:TemplateField HeaderText="Category Name">
						<ItemTemplate>
							<a href='CategoryDetails?id=<%#: Item.CategoryId %>'><%#: Item.Name %></a>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Action">
						<ItemStyle CssClass="actions" />
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

			<asp:Panel runat="server" ID="PanelCreate" CssClass="panel" Visible="false">
				<h2>Create New Category</h2>
				<label>
					Category:
					<asp:TextBox runat="server" ID="TextBoxCategoryCreate" placeholder="Enter category name..."></asp:TextBox>
				</label>
				<asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="link-button" Text="Create" OnClick="LinkButtonCreate_Click"></asp:LinkButton>
				<asp:LinkButton runat="server" ID="LinkButtonCancelCreate" CssClass="link-button" Text="Cancel" OnClick="LinkButtonCancel_Click"></asp:LinkButton>
			</asp:Panel>

			<asp:Panel runat="server" ID="PanelDelete" CssClass="panel" Visible="false">
				<h2>Confirm Category Deletion?</h2>
				<label>
					Category:
					<asp:TextBox runat="server" ID="TextBoxCategoryDelete" ReadOnly="true"></asp:TextBox>
				</label>
				<asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="link-button" Text="Yes" OnClick="LinkButtonDelete_Click"></asp:LinkButton>
				<asp:LinkButton runat="server" ID="LinkButtonCancelDelete" CssClass="link-button" Text="No" OnClick="LinkButtonCancel_Click"></asp:LinkButton>
			</asp:Panel>

			<asp:Panel runat="server" ID="PanelEdit" CssClass="panel" Visible="false">
				<h2>Edit Category</h2>
				<label>
					Category:
					<asp:TextBox runat="server" ID="TextBoxCategoryEdit" placeholder="Enter category name..."></asp:TextBox>
				</label>
				<asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="link-button" Text="Save" OnClick="LinkButtonEdit_Click"></asp:LinkButton>
				<asp:LinkButton runat="server" ID="LinkButtonCancelEdit" CssClass="link-button" Text="Cancel" OnClick="LinkButtonCancel_Click"></asp:LinkButton>
			</asp:Panel>

		</div>
	</div>

	<div class="back-link">
		<a href="/">Back to books</a>
	</div>
</asp:Content>
