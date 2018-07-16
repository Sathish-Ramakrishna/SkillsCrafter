using SkillsCrafter.SCProxy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KMSkillsDefinitions : System.Web.UI.Page
{
    private ActionContext _actionContext = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1_SelectedIndexChanged(sender, e);
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            _actionContext = new ActionContext();
            DataTable dtbl = Service.MainService.getSkillsDefinitions(ref _actionContext, "CRM_Product1");//TODO:Pass profuct from filter value

            if (dtbl.Rows.Count > 0)
            {
                gvSkillsDefinition.DataSource = dtbl;
                gvSkillsDefinition.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvSkillsDefinition.DataSource = dtbl;
                gvSkillsDefinition.DataBind();
                gvSkillsDefinition.Rows[0].Cells.Clear();
                gvSkillsDefinition.Rows[0].Cells.Add(new TableCell());
                gvSkillsDefinition.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvSkillsDefinition.Rows[0].Cells[0].Text = "No Data Found..!";
                gvSkillsDefinition.Rows[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}