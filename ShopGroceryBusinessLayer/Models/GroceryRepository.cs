using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ShopGroceryBusinessLayer.Models
{
    public class GroceryRepository
    {
        public IEnumerable<Grocery> Groceries
        {
            get
            {

                List<Grocery> Groceries = new List<Grocery>();

                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

                using (SqlConnection sqlConnection= new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("Select * from Grocery", sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Grocery grocery = new Grocery();
                        grocery.GroceryItemId = Convert.ToInt32(sqlDataReader["GroceryItem_id"]);
                        grocery.GroceryItemName = sqlDataReader["GroceryItem_name"].ToString();
                        grocery.NoOfGroceryItem = Convert.ToInt32(sqlDataReader["No_Of_GroceryItem"]);
                        grocery.GroceryItemTypeId = Convert.ToInt32(sqlDataReader["GroceryItem_type_id"]);
                        Groceries.Add(grocery);
                    }
                }
                    return Groceries; 
              }
              
          }


        public void Add(Grocery grocery)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spAddGrocery", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                
                SqlParameter sqlParameterItemName = new SqlParameter();
                sqlParameterItemName.ParameterName = "@GroceryItemName";
                sqlParameterItemName.Value = grocery.GroceryItemName;
                sqlCommand.Parameters.Add(sqlParameterItemName);

                SqlParameter sqlparameterNumberOfGroceryItem = new SqlParameter();
                sqlparameterNumberOfGroceryItem.ParameterName = "@NoOfGroceryItem";
                sqlparameterNumberOfGroceryItem.Value = grocery.NoOfGroceryItem;
                sqlCommand.Parameters.Add(sqlparameterNumberOfGroceryItem);

                SqlParameter sqlParameterItemType = new SqlParameter();
                sqlParameterItemType.ParameterName = "@GroceryItemTypeId";
                sqlParameterItemType.Value = grocery.GroceryItemTypeId;
                sqlCommand.Parameters.Add(sqlParameterItemType);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

            }

        }

        public void EditGrocery(Grocery grocery)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

            using (SqlConnection sqlConnection= new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spSaveGrocery", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterGroceryItemId = new SqlParameter();
                sqlParameterGroceryItemId.ParameterName = "@GroceryItemId";
                sqlParameterGroceryItemId.Value = grocery.GroceryItemId;
                sqlCommand.Parameters.Add(sqlParameterGroceryItemId);

                SqlParameter sqlParameterGroceryItemName = new SqlParameter();
                sqlParameterGroceryItemName.ParameterName = "@GroceryItemName";
                sqlParameterGroceryItemName.Value = grocery.GroceryItemName;
                sqlCommand.Parameters.Add(sqlParameterGroceryItemName);

                SqlParameter sqlParameterNoOfGroceryItem = new SqlParameter();
                sqlParameterNoOfGroceryItem.ParameterName = "@NoOfGroceryItem";
                sqlParameterNoOfGroceryItem.Value = grocery.NoOfGroceryItem;
                sqlCommand.Parameters.Add(sqlParameterNoOfGroceryItem);

                SqlParameter sqlParameterGroceryItemTypeId = new SqlParameter();
                sqlParameterGroceryItemTypeId.ParameterName = "@GroceryItemTypeId";
                sqlParameterGroceryItemTypeId.Value = grocery.GroceryItemTypeId;
                sqlCommand.Parameters.Add(sqlParameterGroceryItemTypeId);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

            }
        }

        public IEnumerable<GroceryType> GroceryTypes
        {
            get
            {

                List<GroceryType> GroceryTypes = new List<GroceryType>();

                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("Select * from GroceryType", sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        GroceryType groceryType = new GroceryType();
                        groceryType.GroceryItemTypeId = Convert.ToInt32(sqlDataReader["GroceryItem_Type_Id"]);
                        groceryType.GroceryItemTypeName = sqlDataReader["GroceryItem_Type_Name"].ToString();

                        GroceryTypes.Add(groceryType);
                    }
                }
                return GroceryTypes;
            }

        }
    }
}