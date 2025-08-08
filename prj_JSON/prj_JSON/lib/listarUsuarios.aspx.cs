using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_JSON.lib
{
    public partial class listarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            try
            {
                Usuarios usuarios = new Usuarios();
                List<Usuario> listaUsuarios = usuarios.Listar();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string json = serializer.Serialize(listaUsuarios);

                Response.Write(json);
        
            }
            catch (Exception)
            {
                string resposta = "{'situacao':'false'}";
                Response.Write(resposta.Replace("'","\""));
            }

        }
    }
}