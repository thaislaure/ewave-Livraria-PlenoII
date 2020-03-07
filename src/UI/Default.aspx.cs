using BLL.Bussiness;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace UI
{
    public partial class _Default : Page
    {
        private readonly ILivroBLL _livroBLL;

        public _Default(ILivroBLL livroBLL)
        {
            _livroBLL = livroBLL;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
        
            }
        }

        public void CarregarDrop()
        {
            var dados = _livroBLL.GetAll();

            if (dados.Count > 0)
            {
                ddlGeneroId.DataSource = dados;
                ddlGeneroId.DataBind();
            }

            dados = _livroBLL.GetAll();

            if (dados.Count > 0)
            {
                ddlAutorId.DataSource = dados;
                ddlAutorId.DataBind();
            }

            dados = _livroBLL.GetAll();

            if (dados.Count > 0)
            {
                ddlEditoraId.DataSource = dados;
                ddlEditoraId.DataBind();
            }

        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    Livro livro = new Livro
                    {
                        Titulo = txtTitulo.Text,
                        GeneroId = int.Parse(ddlGeneroId.SelectedValue),
                        DataPublicacao = DateTime.Parse(txtDataPublicacao.Text),
                        QtdPaginas = int.Parse(txtQtdPaginas.Text),
                        AutorId = int.Parse(ddlAutorId.SelectedValue),
                        EditoraId = int.Parse(ddlEditoraId.Text),
                        Descricao = txtDescricao.Text,
                        Sinopse = txtSinopse.Text,
                        // ImagemCapa = customFile.,
                        LinksCompra = txtLinksCompra.Text,
                        ISBN = int.Parse(txtISBN.Text),
                    };

                    var result = _livroBLL.Add(livro);

                    if (result.Success)
                    {

                        lblmsg.Text = "Item successfullyy added to category dropdown ";
                        lblmsg.CssClass = "alert alert-success pull-right";
                        string strJsSuccess = new StringBuilder("$('#sample_modal').modal('hide');").ToString();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Hide", "Registro excluído com sucesso!", true);

                    }
                    else if (result.Notifications.Count > 0)
                    {
                        string notifications = string.Empty;
                        foreach (var item in result.Notifications.AsParallel())
                        {
                            if (string.IsNullOrWhiteSpace(notifications))
                                notifications += notifications + "/n";

                            notifications += $"- {item}";
                        }
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "<script>alert(`" + notifications + "`);</script>", false);

                    }
                }
                catch (Exception Ex)
                {
                    throw;
                }
            }

        }

        #region Metodos

        [WebMethod]
        public string BindDatatable()
        {
            var result = _livroBLL.GetAll();
            var jSearializer = new JavaScriptSerializer();
            
            return jSearializer.Serialize(result);
        }

        public class DadosEspecialidade
        {
            public string descricao { get; set; }

            public string id { get; set; }
        }

        [WebMethod]
        public void Delete(string id)
        {
            try
            {
                var result = _livroBLL.Remove(int.Parse(id));

                if (result > 0)
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "<script>alert('Registro excluído com sucesso!');</script>", false);
                else
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "<script>alert('Não foi possível excluir o registro!');</script>", false);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "<script>alert('" + ex.Message + "'); location.href('ConCargo.aspx');</script>", false);
            }
        }

        [WebMethod]
        public string Editar(string id)
        {
            var result = _livroBLL.GetById(int.Parse(id));

            var jSearializer = new JavaScriptSerializer();


            return jSearializer.Serialize(result);
        }

        #endregion Metodos
    }

}