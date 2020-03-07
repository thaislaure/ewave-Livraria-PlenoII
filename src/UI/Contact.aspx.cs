using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Contact : Page
    {
        private readonly ILivroBLL _livroBLL;

        public Contact(ILivroBLL livroBLL)
        {
            _livroBLL = livroBLL;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgBtn_salvar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                Livro livro = new Livro
                {
                    Titulo = "",
                };

                var result = _livroBLL.Add(livro);

                if (result.Success)
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "<script>alert('Registro excluído com sucesso!');</script>", false);
                else if(result.Notifications.Count >  0)
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
}