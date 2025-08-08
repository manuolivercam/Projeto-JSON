using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_JSON
{
    public partial class Geral : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logado"] == null)
            {
                Response.Redirect("index.html");
                return;
            }
            if (String.IsNullOrEmpty(Session["logado"].ToString()))
            {
                Response.Redirect("index.html");
                return;
            }
            string login = Session["logado"].ToString();
            litNome.Text = Session["nome"].ToString();
        }
    }
}