using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ShopGroceryBusinessLayer.Models
{
    public class GroceryTypeRepository
    {
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

        public void Add(GroceryType groceryType)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spAddGroceryType", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterGroceryItemTypeName = new SqlParameter();
                sqlParameterGroceryItemTypeName.ParameterName = "@GroceryItemTypeName";
                sqlParameterGroceryItemTypeName.Value = groceryType.GroceryItemTypeName;
                sqlCommand.Parameters.Add(sqlParameterGroceryItemTypeName);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            } 
        }

        public void Edit(GroceryType groceryType)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spEditGroceryType", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterGroceryItemTypeId = new SqlParameter();
                sqlParameterGroceryItemTypeId.ParameterName = "@GroceryItemTypeId";
                sqlParameterGroceryItemTypeId.Value = groceryType.GroceryItemTypeId;
                sqlCommand.Parameters.Add(sqlParameterGroceryItemTypeId);

                SqlParameter sqlParameterGroceryItemTypeName = new SqlParameter();
                sqlParameterGroceryItemTypeName.ParameterName = "@GroceryItemTypeName";
                sqlParameterGroceryItemTypeName.Value = groceryType.GroceryItemTypeName;
                sqlCommand.Parameters.Add(sqlParameterGroceryItemTypeName);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}