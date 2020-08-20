 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class template2_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string ncode = Request.QueryString.ToString();

            //if (ncode != "")
            //{
            slide.InnerHtml = Getslide("VW_ProjectDetails");
            info.InnerHtml = GetInfo("VW_ProjectDetails");
            pgwSlideshow.InnerHtml = GetSlides("VW_GetGallerywithproject");
            specifications.InnerHtml = Getspecifications("VW_GetSpecification");
            amenities1.InnerHtml = Getamenities("VW_GetAmenities");
            about_project.InnerHtml = Getabout_project("VW_ProjectDetails");
            about_developer.InnerHtml = Getabout_builder("VW_ProjectDetails");
                //CMSGetAllTable();
            //}
            
        }
    }

    public string Getslide(string table)
    {
        common cmn = new common();
        StringBuilder sb = new StringBuilder();
        string parameters = "TableName";
        string Parametervalues = "" + table;
        int i = 0;
        DataSet ds = cmn.GetAllData("USP_GetAllTableData", parameters, Parametervalues);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<div class='item parallax-window' data-parallax='scroll' data-image-src='../admin-panel/TempUpload/" + dr["imagepath"].ToString() + "'></div>");

            }
        }
        return sb.ToString();
    }

    public string GetInfo(string table)
    {
        common cmn = new common();
        StringBuilder sb = new StringBuilder();
        string parameters = "TableName";
        string Parametervalues = "" + table;
        int i = 0;
        DataSet ds = cmn.GetAllData("USP_GetAllTableData", parameters, Parametervalues);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<p class='s_heading rera'>RERA Regd. No.: <span>P52100000977</span></p>");
                sb.Append("<h1>"+dr["projectname"].ToString()+"</h1>");
                sb.Append("<p class='address'>By <span>"+dr["buildername"].ToString()+"</span></p>");
                sb.Append("<div class='property_info'>");
                sb.Append("<p>");
                sb.Append("<span><i class='fa fa-rupee'></i>" + dr["areadetails"].ToString() + "</span> onwards");
                sb.Append("</p>");
                sb.Append("<div class='innr_pro'>");
                sb.Append("<p>	<span> 2 BHK</span> Flats </p> <span class='saprator'>.</span> <p><span>" + dr["latitude"].ToString() + " - " + dr["longitude"].ToString() + "</span> sqft</p>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<div class='authority'>");
                sb.Append("<ul class='col-xs-12 nopadding'>");
                sb.Append("<li>Approved by: <span>PMRDA</span></li>");
                sb.Append("<li>Project Area: <span>"+dr["projectarea"].ToString()+"</span></li>");
                sb.Append("<li>Total No. of Floors: <span>" + dr["floors"].ToString() + "<!-- A-11 : B-04 --></span></li>");
                sb.Append("<li>Total No. of Towers: <span>"+dr["towers"].ToString()+"</span></li>");
                sb.Append("</ul>");
                sb.Append("</div>");
            }
        }
        return sb.ToString();
    }

    public string GetSlides(string table)
    { 
        common cmn = new common();
        StringBuilder sb = new StringBuilder();
        string parameters = "TableName";
        string Parametervalues = "" + table;
        int i = 0;
        DataSet ds = cmn.GetAllData("USP_GetAllTableData", parameters, Parametervalues);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<li><a href='../admin-panel/TempUpload/" + dr["image"].ToString() + "' ><img src='../admin-panel/TempUpload/" + dr["image"].ToString() + "' alt='" + dr["GalleryText"].ToString() + "' /></a></li>");
            }
        }
        return sb.ToString();
    }

    public string Getspecifications(string table)
    { 
        common cmn = new common();
        StringBuilder sb = new StringBuilder();
        string parameters = "TableName";
        string Parametervalues = "" + table;
        int i = 0;
        DataSet ds = cmn.GetAllData("USP_GetAllTableData", parameters, Parametervalues);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<article class='owl-item box clearfix'>");
                sb.Append("<h3>"+dr["SpecificationsHeading"].ToString()+"</h3>");
                sb.Append("<ul class='Spec'>");
                sb.Append("<li>"+dr["Specificationstext"].ToString()+"</li>");
                //sb.Append("<li>Aluminium sliding shutter with mosquito net for terrace attached to living room.</li>");
                //sb.Append("<li>Aluminum windows with Mosquito net & M.S. safety grills.</li>");
                //sb.Append("<li>Granite Jams to Windows.</li>");
                sb.Append("</ul>");
                sb.Append("</article>");
                //sb.Append("<li><a href='../admin-panel/TempUpload/" + dr["image"].ToString() + "' ><img src='../admin-panel/TempUpload/" + dr["image"].ToString() + "' alt='" + dr["GalleryText"].ToString() + "' /></a></li>");
            }
        }
        return sb.ToString();
    }

    public string Getamenities(string table)
    {
        common cmn = new common();
        StringBuilder sb = new StringBuilder();
        string parameters = "TableName";
        string Parametervalues = "" + table;
        int i = 0;
        DataSet ds = cmn.GetAllData("USP_GetAllTableData", parameters, Parametervalues);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<li class='owl-item clearfix'>");
                sb.Append("<div id='' class=''>");
                sb.Append("<ul class='clearfix'>");
                sb.Append("<li>Generator backup for lifts parking and common areas</li>");
                sb.Append("<li>Well designed entrance gate</li>");
                sb.Append("<li>Gymnasium </li>");
                sb.Append("</ul>");
                sb.Append("</div>");
                sb.Append("</li>");
            }
        }
        return sb.ToString();
    }

    public string Getabout_project(string table)
    {
        common cmn = new common();
        StringBuilder sb = new StringBuilder();
        string parameters = "TableName";
        string Parametervalues = "" + table;
        int i = 0;
        DataSet ds = cmn.GetAllData("USP_GetAllTableData", parameters, Parametervalues);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<div class='hd'>");
                sb.Append("<p class='s_heading'>About Us</p>");
                sb.Append("<h2>All about " + dr["projectname"].ToString() + "</h2>");
                sb.Append("</div>");
                sb.Append("<div class='row'>");
                sb.Append("<div class='col-xs-12 col-md-12 col-sm-12 col-lg-12 nopadding '>");
                sb.Append("<div class='aboutus'>");
                sb.Append("<div class='row'>");
                sb.Append("<div class='col-xs-12 col-md-5 col-sm-5 col-lg-5 nopadding'>");
                sb.Append("<img data-src='../admin-panel/TempUpload/" + dr["imagepath"].ToString() + "'");
                sb.Append("src='./images/imgs.png?w=800&h=600&fit=crop&crop=entropy&px=16&blur=200&fm=webp' class='b_img' width='90%' height=''>");
                sb.Append("<div class='plogo'>");
                sb.Append("<img src='./images/project_logo.jpg' alt='Venkatesh Lake Orchid'>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<div class='col-xs-12 col-md-7 col-sm-7 col-lg-7 inner_sec'>");
                sb.Append("<div class='scroll4'>");
                sb.Append("<ul class='clearfix'>");
                sb.Append("<li>Approved by: <b> PMRDA </b></li>");
                sb.Append("<li>Project Area:  <b>" + dr["projectarea"].ToString() + "</b></li>");
                sb.Append("<li>Total No. of Floors: <b> " + dr["floors"].ToString() + "</b></li>");
                sb.Append("<li>Total No. of Towers: <b> " + dr["towers"].ToString() + "</b></li>");
                sb.Append("<li>Commencement Certificate: <b> Yes</b></li>");
                sb.Append("<li>Occupancy Certificate:  <b> Yes</b></li>");
                sb.Append("<li>Status: <b> Ready to Move</b></li>");
                sb.Append("</ul>");
                sb.Append("<div class='more'>Close on heels of the success of Venkatesh Lake Vista, comes another opportunity for buyers to experience the Venkatesh signature lifestyle, though our next offering, Venkatesh Lake Orchid.");
                sb.Append("<p class='morecontent'>Located in Ambegaon Kh., Venkatesh Lake Orchid is a picturesque campus of 1 and 2 BHK apartments along with shops, all overlooking the serene rolling hills that bracket Pune. There are a total of 118 homes, all designed to bring luxury into your life at affordable costs.");
                sb.Append("<br><br>Venkatesh Lake Orchid is a celebration of nature, where we have taken great pains to preserve the very scenic beauty of the nature that we enjoy around us. To this end, we have numerous eco-friendly solutions that make your life at Lake Orchid an holistic experience. From beautifully landscaped gardens to designated areas for your children to play, from vermiculture to rainwater harvesting, every step that we take is keeping you and Mother Nature in our minds and hearts.");
                sb.Append("<br><br>Venkatesh Lake Orchid, is without doubt, the perfect home to build your memories that will last a lifetime.");
                sb.Append("</p>");
                sb.Append("<a class='more_data'><i class='more_ic'>Read more</i></a>");
                sb.Append("</div>");
                sb.Append("<div class=' bank_sec col-xs-12 nopadding'>");
                sb.Append("<p>Approved by Banks: </p>");
                sb.Append("<div id='bank_icon' class='bank col-md-10 col-xs-12 nopadding'>");
                sb.Append("<div class='item bank_ic'><img src='./images/sbi.jpg' alt='bank name'></div>");
                sb.Append("<div class='item bank_ic'><img src='./images/axis.jpg' alt='bank name'></div>");
                sb.Append("<div class='item bank_ic'><img src='./images/lic.jpg' alt='bank name'></div>");
                sb.Append("<div class='item bank_ic'><img src='./images/icici.jpg' alt='bank name'></div>");
                sb.Append("<div class='item bank_ic'><img src='./images/idbi.jpg' alt='bank name'></div>");
                sb.Append("<div class='item bank_ic'><img src='./images/pnb.jpg' alt='bank name'></div>");
                sb.Append("<div class='item bank_ic'><img src='./images/hdfc.jpg' alt='bank name'></div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<div class='download clearfix col-xs-12 nopadding'>");
                sb.Append("<h5>Downloads:</h5>");
                sb.Append("<ul class='col-xs-12 nopadding'>");
                sb.Append("<li><a href='pdf/brochure.pdf'  target='_blank'>Download Brochure</a></li>");
                sb.Append("</ul>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
            }
        }
        return sb.ToString();
    }

    public string Getabout_builder(string table)
    {
        common cmn = new common();
        StringBuilder sb = new StringBuilder();
        string parameters = "TableName";
        string Parametervalues = "" + table;
        int i = 0;
        DataSet ds = cmn.GetAllData("USP_GetAllTableData", parameters, Parametervalues);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<div class='hd'>");
                sb.Append("<p class='s_heading'>About Us</p>");
                sb.Append("<h2>About Shree "+dr["buildername"].ToString()+"</h2>");
                sb.Append("</div>");
                sb.Append("<div class='row'>");
                sb.Append("<div class='col-xs-12 col-md-12 col-sm-12 col-lg-12 nopadding'>");
                sb.Append("<div class='whiteBx aboutus'>");
                sb.Append("<div class='row'>");
                sb.Append("<div class='col-xs-12 col-md-3 col-sm-3 col-lg-3 nopadding'>");
                sb.Append("<div class='clogo'><div class='logo'> <img src='../admin-panel/TempUpload/" + dr["image"].ToString() + "'></div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<div class='col-xs-12 col-md-9 col-sm-9 col-lg-9 xs-nopadding'>");
                sb.Append("<div class='about_content'>");
                sb.Append("<p>" + dr["builderdescription"].ToString() + "");
                sb.Append("</p>");
                sb.Append("<a class='more_data2'><i class='more_ic2'>Read more</i></a>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
            }
        }
        return sb.ToString();
    }
    
}