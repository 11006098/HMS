using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using ProductMvvm;
using ProductMvvm.ViewModels;

namespace ProductMvvm.Model
{
    public class StoreDB
    {
        public bool hasError = false;
        public string errorMessage;
        /*
                private string conString = Properties.Settings.Default.StoreDBConnString;
         
                public MyObservableCollection<Product> GetProducts()
                {
                    hasError = false;
                    SqlConnection con = new SqlConnection(conString);
                    SqlCommand cmd = new SqlCommand("GetProducts", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    MyObservableCollection<Product> products = new MyObservableCollection<Product>();
                    try
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            //create a Product object for the row
                            SqlProduct sqlProduct = new SqlProduct(
                                (int) reader["ProductId"],
                                (string)reader["ModelNumber"],
                                (string)reader["ModelName"],
                                (decimal)reader["UnitCost"],
                                GetStringOrNull(reader, "Description"),
                                (String)reader["CategoryName"]);
                            products.Add(sqlProduct.SqlProduct2Product());
                        } //while
                    } //try
                    catch (SqlException ex)
                    {
                        errorMessage = "GetProducts SQL error, " + ex.Message;
                        hasError = true;
                    }
                    catch (Exception ex)
                    {
                        errorMessage = "GetProducts error, " + ex.Message;
                        hasError = true;
                    }
                    finally
                    {
                        con.Close();
                    }
                    return products;
                } //GetProducts()
        */
        public MyObservableCollection<Product> GetProducts()
        {
            hasError = false;
            MyObservableCollection<Product> products = new MyObservableCollection<Product>();
            try
            {
                LinqDataContext dc = new LinqDataContext();
                var query = from q in dc.LinqProducts
                    select new SqlProduct{
                        ProductId = q.ProductID, ModelNumber = q.ModelNumber,
                        ModelName=q.ModelName, UnitCost = (decimal)q.UnitCost,
                        Description = q.Description, CategoryName = q.LinqCategory.CategoryName
                    };
                foreach (SqlProduct sp in query)
                    products.Add(sp.SqlProduct2Product());
            } //try
            catch(Exception ex)
            {
                errorMessage = "GetProducts() error, " + ex.Message;
                hasError = true;
            }
            return products;
        } //GetProducts()

/*
        private string GetStringOrNull(SqlDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? "" : (string)reader[columnName]; 
        }
*/

        /*
        private const int prodStringLen = 50;
        public bool UpdateProduct(Product displayP)
        {
            SqlProduct p = new SqlProduct( displayP);
            hasError = false;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("UpdateProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4);
            cmd.Parameters["@ProductId"].Value = p.ProductId;
            cmd.Parameters.Add("@ModelNumber", SqlDbType.VarChar, prodStringLen);
            cmd.Parameters["@ModelNumber"].Value = p.ModelNumber;
            cmd.Parameters.Add("@ModelName", SqlDbType.VarChar, prodStringLen);
            cmd.Parameters["@ModelName"].Value = p.ModelName;
            cmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
            cmd.Parameters["@UnitCost"].Value = p.UnitCost;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200);
            cmd.Parameters["@Description"].Value = p.Description;
            cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar, prodStringLen);
            cmd.Parameters["@CategoryName"].Value = p.CategoryName;
            int rows = 0;
            try
            {
                con.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                errorMessage = "Update SQL error, " + ex.Message;
                hasError = true;
            }
            catch (Exception ex)
            {
                errorMessage = "Update error, " + ex.Message;
                hasError = true;
            }
            finally
            {
                con.Close();
            }
            return (!hasError);
        } //UpdateProduct()
*/
        public bool UpdateProduct(Product displayP)
        {
            try
            {
                SqlProduct p = new SqlProduct(displayP);
                LinqDataContext dc = new LinqDataContext();
                dc.UpdateProduct(p.ProductId, p.CategoryName, p.ModelNumber, p.ModelName, p.UnitCost, p.Description);
            }
            catch (Exception ex)
            {
                errorMessage = "Update error, " + ex.Message;
                hasError = true;
            }
            return (!hasError);
        } //UpdateProduct()



/*
        public bool DeleteProduct(int productId)
        {
            hasError = false;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("DeleteProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4);
            cmd.Parameters["@ProductId"].Value = productId;
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                errorMessage = "DELETE SQL error, " + ex.Message;
                hasError = true;
            }
            catch (Exception ex)
            {
                errorMessage = "DELETE error, " + ex.Message;
                hasError = true;
            }
            finally
            {
                con.Close();
            }
            return !hasError;
        }// DeleteProduct()
*/
        public bool DeleteProduct(int productId)
        {
            hasError = false;
            try
            {
                LinqDataContext dc = new LinqDataContext();
                dc.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                errorMessage = "Delete error, " + ex.Message;
                hasError = true;
            }
            return !hasError;
        }// DeleteProduct()


/*
        public bool AddProduct(Product displayP)
        {
            SqlProduct p = new SqlProduct(displayP);
            hasError = false;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("AddProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ModelNumber", SqlDbType.VarChar, prodStringLen);
            cmd.Parameters["@ModelNumber"].Value = p.ModelNumber;
            cmd.Parameters.Add("@ModelName", SqlDbType.VarChar, prodStringLen);
            cmd.Parameters["@ModelName"].Value = p.ModelName;
            cmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
            cmd.Parameters["@UnitCost"].Value = p.UnitCost;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200);
            cmd.Parameters["@Description"].Value = p.Description;
            if (p.Description==null)  cmd.Parameters["@Description"].Value = DBNull.Value;
            cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar, prodStringLen);
            cmd.Parameters["@CategoryName"].Value = p.CategoryName;
            cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4);
            cmd.Parameters["@ProductId"].Value = p.ProductId;
            cmd.Parameters["@ProductId"].Direction = ParameterDirection.Output;
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();                       //create the new product in DB
                p.ProductId = (int)cmd.Parameters["@ProductId"].Value;  //set the returned ProductId in the SqlProduct object
                displayP.ProductAdded2DB(p);                            //update corresponding Product ProductId using SqlProduct
            }
            catch (SqlException ex)
            {
                errorMessage = "Add SQL error, " + ex.Message;
                hasError = true;
            }
            catch (Exception ex)
            {
                errorMessage = "ADD error, " + ex.Message;
                hasError = true;
            }
            finally
            {
                con.Close();
            }
            return !hasError;
        } //AddProduct()
 */ 
        public bool AddProduct(Product displayP)
        {
            hasError = false;
            try
            {
                SqlProduct p = new SqlProduct(displayP);
                LinqDataContext dc = new LinqDataContext();
                int? newProductId = 0;
                dc.AddProduct(p.CategoryName, p.ModelNumber, p.ModelName, p.UnitCost, p.Description, ref newProductId);
                p.ProductId = (int)newProductId;
                displayP.ProductAdded2DB(p);    //update corresponding Product ProductId using SqlProduct
            }
            catch (Exception ex)
            {
                errorMessage = "Add error, " + ex.Message;
                hasError = true;
            }
            return !hasError;
        } //AddProduct()
    } //class StoreDB
}
