using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F15Team26.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region 批量导入
        public ActionResult StationImport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StationImport(HttpPostedFileBase filebase)
        {
            HttpPostedFileBase file = Request.Files["files"];
            string FileName;
            string savePath;
            if (file == null || file.ContentLength <= 0) { ViewBag.error = "文件不能为空"; return View(); }

            string filename = System.IO.Path.GetFileName(file.FileName);
            int filesize = file.ContentLength;//获取上传文件的大小单位为字节byte
            string fileEx = System.IO.Path.GetExtension(filename);//获取上传文件的扩展名
            string NoFileName = System.IO.Path.GetFileNameWithoutExtension(filename);//获取无扩展名的文件名
            int Maxsize = 4000 * 1024;//定义上传文件的最大空间大小为4M
            string FileType = ".xls,.xlsx";//定义上传文件的类型字符串

            FileName = NoFileName + DateTime.Now.ToString("yyyyMMddhhmmss") + fileEx;
            if (!FileType.Contains(fileEx)) { ViewBag.error = "文件类型不对，只能导入xls和xlsx格式的文件"; return View(); }
            if (filesize >= Maxsize) { ViewBag.error = "上传文件超过4M，不能上传"; return View(); }
            string path = AppDomain.CurrentDomain.BaseDirectory + "uploads/";
            savePath = System.IO.Path.Combine(path, FileName);
            file.SaveAs(savePath);
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + savePath + ";" + "Extended Properties=Excel 8.0";
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + savePath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            OleDbDataAdapter myCommand1 = new OleDbDataAdapter("select * from [Customers$]", strConn);
            OleDbDataAdapter myCommand2 = new OleDbDataAdapter("select * from [Employees$]", strConn);
            OleDbDataAdapter myCommand3 = new OleDbDataAdapter("select * from [Books$]", strConn);
            DataSet myDataSet = new DataSet();
            try
            {
                myCommand1.Fill(myDataSet, "Customers");
                myCommand2.Fill(myDataSet, "Employees");
                myCommand3.Fill(myDataSet, "Books");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
            DataTable dtCustomers = myDataSet.Tables["Customers"].DefaultView.ToTable();
            DataTable dtEmployees = myDataSet.Tables["Employees"].DefaultView.ToTable();
            DataTable dtBooks = myDataSet.Tables["Books"].DefaultView.ToTable();

            this.ImportCustomer(dtCustomers);
            this.ImportEmployees(dtEmployees);
            this.ImportBooks(dtBooks);

            ViewBag.error = "导入成功";
            //System.Threading.Thread.Sleep(2000);
            //return RedirectToAction("StationImport");
            return View();
        }

        private ModelsSQL.ExcelImportDataContext db = new ModelsSQL.ExcelImportDataContext();
        private int ConvertToInt(string str)
        {
            int result = 0;
            if (int.TryParse(str, out result))
                return result;
            return result;
        }
        private decimal ConvertToDecimal(string str)
        {
            decimal result = 0;
            if (decimal.TryParse(str, out result)) return result;
            return result;
        }
        private DateTime ConvertToDateTime(string str)
        {
            DateTime result = DateTime.Now;
            if (DateTime.TryParse(str, out result)) return result;
            return result;
        }

        #region 导入 Customer 数据
        private void ImportCustomer(DataTable dt)
        {
            List<ModelsSQL.Customers> list = new List<ModelsSQL.Customers>();
            int UpdateCount = 0, InsertCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Email"].ToString()))
                {
                    var entity = db.Customers.Where(t => t.Email == dr["Email"].ToString()).FirstOrDefault();
                    if (entity != null)
                    {
                        #region  更 新
                        entity.Email = dr["Email"].ToString();
                        entity.Password = dr["Password"].ToString();
                        entity.LName = dr["LName"].ToString();
                        entity.FName = dr["FName"].ToString();
                        entity.MI = dr["MI"].ToString();
                        entity.Address = dr["Address"].ToString();
                        entity.Zipcode = dr["Zipcode"].ToString();
                        entity.Phone = dr["Phone"].ToString();
                        entity.CreditCard1 = dr["Credit Card #1 Number"].ToString();
                        entity.CreditCard1Type = dr["Credit Card #1 Type"].ToString();
                        entity.CreditCard2 = dr["Credit Card #2 Number"].ToString();
                        entity.CreditCard2Type = dr["Credit Card #2 Type"].ToString();
                        #endregion
                        UpdateCount++;
                    }
                    else  //数据新增
                    {
                        #region  新 增
                        ModelsSQL.Customers c = new ModelsSQL.Customers
                        {
                            Email = dr["Email"].ToString(),
                            Password = dr["Password"].ToString(),
                            LName = dr["LName"].ToString(),
                            FName = dr["FName"].ToString(),
                            MI = dr["MI"].ToString(),
                            Address = dr["Address"].ToString(),
                            Zipcode = dr["Zipcode"].ToString(),
                            Phone = dr["Phone"].ToString(),
                            CreditCard1 = dr["Credit Card #1 Number"].ToString(),
                            CreditCard1Type = dr["Credit Card #1 Type"].ToString(),
                            CreditCard2 = dr["Credit Card #2 Number"].ToString(),
                            CreditCard2Type = dr["Credit Card #2 Type"].ToString()
                        };
                        #endregion
                        InsertCount++;
                        list.Add(c);
                    }
                }
            }
            db.Customers.InsertAllOnSubmit(list);
            db.SubmitChanges();
        }
        #endregion

        #region 导入 Employees 数据
        private void ImportEmployees(DataTable dt)
        {
            List<ModelsSQL.Employees> list = new List<ModelsSQL.Employees>();
            int UpdateCount = 0, InsertCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["Email"].ToString()))
                {
                    var entity = db.Employees.Where(t => t.Email == dr["Email"].ToString()).FirstOrDefault();
                    if (entity != null)
                    {
                        #region  更 新
                        entity.EmployeesID = this.ConvertToInt(dr["EmpNumber"].ToString());
                        entity.Email = dr["Email"].ToString();
                        entity.FName = dr["FName"].ToString();
                        entity.MI = dr["MI"].ToString();
                        entity.LName = dr["LName"].ToString();
                        entity.Password = dr["Password"].ToString();
                        entity.Address = dr["Address"].ToString();
                        entity.Zipcode = dr["Zipcode"].ToString();
                        entity.Phone = dr["Phone"].ToString();
                        entity.EmployeeTypes = this.ConvertToInt(dr["Employee Type"].ToString());
                        #endregion
                        UpdateCount++;
                    }
                    else  //数据新增
                    {
                        #region  新 增
                        ModelsSQL.Employees c = new ModelsSQL.Employees
                        {
                            EmployeesID = this.ConvertToInt(dr["EmpNumber"].ToString()),
                            Email = dr["Email"].ToString(),
                            FName = dr["FName"].ToString(),
                            MI = dr["MI"].ToString(),
                            LName = dr["LName"].ToString(),
                            Password = dr["Password"].ToString(),
                            Address = dr["Address"].ToString(),
                            Zipcode = dr["Zipcode"].ToString(),
                            Phone = dr["Phone"].ToString(),
                            EmployeeTypes = this.ConvertToInt(dr["Employee Type"].ToString())
                        };
                        #endregion
                        InsertCount++;
                        list.Add(c);
                    }
                }
            }
            db.Employees.InsertAllOnSubmit(list);
            db.SubmitChanges();
        }
        #endregion

        #region 导入 Books 数据
        private void ImportBooks(DataTable dt)
        {
            List<ModelsSQL.Books> list = new List<ModelsSQL.Books>();
            int UpdateCount = 0, InsertCount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["UniqueNumber"].ToString()))
                {
                    var entity = db.Books.Where(t => t.UniqueNumber == dr["UniqueNumber"].ToString()).FirstOrDefault();
                    if (entity != null)
                    {
                        #region  更 新
                        entity.UniqueNumber = dr["UniqueNumber"].ToString();
                        entity.Title = dr["Title"].ToString();
                        entity.Genre = dr["Genre"].ToString();
                        entity.AuthorFirst = dr["AuthorFirst"].ToString();
                        entity.AuthorLast = dr["AuthorLast"].ToString();
                        entity.Price = this.ConvertToDecimal(dr["Price"].ToString());
                        entity.PublicationDate = this.ConvertToDateTime(dr["PublicationDate"].ToString());
                        entity.PriceLastPaid = this.ConvertToDecimal(dr["PriceLastPaid"].ToString());
                        entity.Inventory = this.ConvertToInt(dr["Inventory"].ToString());
                        entity.ReorderPoint = this.ConvertToInt(dr["Reorder Point"].ToString());
                        #endregion
                        UpdateCount++;
                    }
                    else  //数据新增
                    {
                        #region  新 增
                        ModelsSQL.Books c = new ModelsSQL.Books
                        {
                            UniqueNumber = dr["UniqueNumber"].ToString(),
                            Title = dr["Title"].ToString(),
                            Genre = dr["Genre"].ToString(),
                            AuthorFirst = dr["AuthorFirst"].ToString(),
                            AuthorLast = dr["AuthorLast"].ToString(),
                            Price = this.ConvertToDecimal(dr["Price"].ToString()),
                            PublicationDate = this.ConvertToDateTime(dr["PublicationDate"].ToString()),
                            PriceLastPaid = this.ConvertToDecimal(dr["PriceLastPaid"].ToString()),
                            Inventory = this.ConvertToInt(dr["Inventory"].ToString()),
                            ReorderPoint = this.ConvertToInt(dr["Reorder Point"].ToString()),
                            Reviews = string.Empty,
                            Ratings = 0
                        };
                        #endregion
                        InsertCount++;
                        list.Add(c);
                    }
                }
            }
            db.Books.InsertAllOnSubmit(list);
            db.SubmitChanges();
        }
        #endregion

        #endregion

        
            
   

    }
}