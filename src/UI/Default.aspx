<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI._Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src='<%=ResolveClientUrl("~/assets/pages/livro.js")+ "?hash=" + DateTime.Now.Ticks.ToString()%>'></script>
    <script>
        $(document).ready(function () {
            $("#btn_open_modal").click(function (event) {
                $(".modal-dialog").css({ position: "center" });
                $('#livroModal').modal('show');
            })
        });

    </script>
    <div class="jumbotron">
        <h1>Livraria Laure</h1>
        <p class="lead">Consulta de Livro</p>

    </div>

    <div class="row">
        <div class="col-lg-12"></div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>

                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="form-group ">
        <div class="col-sm-3">
            <button type="button" id="btn_open_modal" class="btn btn-primary btn-lg ">Adcionar Livro</button>
        </div>
    </div>

         <div class="panel panel-white">
            <div class="panel-body">
                <asp:HiddenField ID="hdd_ACAO" runat="server" />
                <asp:HiddenField ID="hdd_ID" runat="server" />
                <div class="row">u
                    <div class="form-group col-md-12">
                        <table class="display table table-striped table-bordered" id="grdResultados" cellspacing="0">
                            <thead>
                                <tr>
                                    <th style="width: 40px;">Alterar</th>
                                    <th style="width: 40px;">Excluir</th>
                                    <th data-orderable="false" style="width: 40px;">Codigo</th>
                                    <th data-orderable="false">Descrição</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>


    <div class="modal" id="livroModal" role="dialog" tabindex="-1">
        <div class="modal-dialog animated zoomIn ">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" EnableViewState="true">
                <ContentTemplate>
                    <div class=" modal-content">
                        <div class="modal-header">Cadastrar Livro</div>
                        <div class="modal-body col-sm-12">
                            <div class="form-group col-md-12">
                                <label class="control-label">Titulo</label>                                
                                    <asp:TextBox ID="txtTitulo" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv1" CssClass="alert-danger" ControlToValidate="txtTitulo" ValidationGroup="save-modal" SetFocusOnError="true" Display="Dynamic" runat="server" ErrorMessage="Campo Obrigatório!"></asp:RequiredFieldValidator>                                
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 control-label">Genero</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlGeneroId" CssClass="form-control " runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 control-label">Data Publicação</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtDataPublicacao" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-4 control-label">Quantidade de Paginas</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtQtdPaginas" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 control-label">Autor</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlAutorId" CssClass="form-control " runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 control-label">Editora</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlEditoraId" CssClass="form-control " runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 control-label">Descrição</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtDescricao" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 control-label">Sinopse</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtSinopse" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 control-label">Imagem Capa</label>
                                <div class="col-sm-8">
                                    <input type="file" class="custom-file-input" id="customFileLang" lang="es">
                                    <label class="custom-file-label" for="customFileLang">Seleccionar Imagem de Capa</label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 control-label">Links Compras</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtLinksCompra" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 control-label">ISBN</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtISBN" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    <i>LOADING ....</i>
                                </ProgressTemplate>

                            </asp:UpdateProgress>
                            <%--    <div class="col-sm-2 ">Mandetory fields are *</div>--%>
                            <asp:Button ID="btn_save" runat="server" CssClass="btn btn-primary" Text="Add" OnClick="btn_save_Click" ValidationGroup="save-modal" />
                            <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>

                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>








</asp:Content>
