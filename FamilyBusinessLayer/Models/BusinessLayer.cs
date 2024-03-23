using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace FamilyBusinessLayer.Models
{
    public class BusinessLayer
    {
        public IEnumerable<FamilyMemberDetails> FamilyMembersDetails
        {
            get
            {
                List<FamilyMemberDetails> familyMembers = new List<FamilyMemberDetails>();

               string connectionString = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetAllFamilymembers",sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        FamilyMemberDetails familyMember = new FamilyMemberDetails();
                        familyMember.FamilyMemberId = Convert.ToInt32(sqlDataReader["FamilyMemberId"]);
                        familyMember.Name = sqlDataReader["Name"].ToString();
                        familyMember.Gender = sqlDataReader["Gender"].ToString();
                        familyMember.Job = sqlDataReader["Job"].ToString();
                        familyMember.City = sqlDataReader["City"].ToString();
                        familyMember.FamilyMemberTypeId = Convert.ToInt32(sqlDataReader["FamilyMemberTypeId"]);
                        familyMembers.Add(familyMember);
                    }
                }
                    return familyMembers;

            }
              
         }


        public void AddFamilyMember(FamilyMemberDetails familyMemberDetails)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

            using (SqlConnection sqlConnection= new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spAddFamilyMember", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterName = new SqlParameter();
                sqlParameterName.ParameterName = "@Name";
                sqlParameterName.Value = familyMemberDetails.Name;
                sqlCommand.Parameters.Add(sqlParameterName);


                SqlParameter sqlParameterGender = new SqlParameter();
                sqlParameterGender.ParameterName = "@Gender";
                sqlParameterGender.Value = familyMemberDetails.Gender;
                sqlCommand.Parameters.Add(sqlParameterGender);

                SqlParameter sqlParameterCity = new SqlParameter();
                sqlParameterCity.ParameterName = "@City";
                sqlParameterCity.Value = familyMemberDetails.City;
                sqlCommand.Parameters.Add(sqlParameterCity);

                SqlParameter sqlParameterJob = new SqlParameter();
                sqlParameterJob.ParameterName = "@Job";
                sqlParameterJob.Value = familyMemberDetails.Job;
                sqlCommand.Parameters.Add(sqlParameterJob);


                SqlParameter sqlParameterFamilyMemberTypeId = new SqlParameter();
                sqlParameterFamilyMemberTypeId.ParameterName = "@FamilyMemberTypeId";
                sqlParameterFamilyMemberTypeId.Value = familyMemberDetails.FamilyMemberTypeId;
                sqlCommand.Parameters.Add(sqlParameterFamilyMemberTypeId);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

            }
        }


        public void SaveFamilymember(FamilyMemberDetails familyMemberDetails)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

            using (SqlConnection connection= new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spSaveFamilyMember", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterFamilyMemberId = new SqlParameter();
                sqlParameterFamilyMemberId.ParameterName = "@FamilyMemberId";
                sqlParameterFamilyMemberId.Value = familyMemberDetails.FamilyMemberId;
                sqlCommand.Parameters.Add(sqlParameterFamilyMemberId);

                SqlParameter sqlParameterName = new SqlParameter();
                sqlParameterName.ParameterName = "@Name";
                sqlParameterName.Value = familyMemberDetails.Name;
                sqlCommand.Parameters.Add(sqlParameterName);

                SqlParameter sqlParameterGender = new SqlParameter();
                sqlParameterGender.ParameterName = "@Gender";
                sqlParameterGender.Value = familyMemberDetails.Gender;
                sqlCommand.Parameters.Add(sqlParameterGender);

                SqlParameter sqlParameterCity = new SqlParameter();
                sqlParameterCity.ParameterName = "@City";
                sqlParameterCity.Value = familyMemberDetails.City;
                sqlCommand.Parameters.Add(sqlParameterCity);

                SqlParameter sqlParameterJob = new SqlParameter();
                sqlParameterJob.ParameterName = "@Job";
                sqlParameterJob.Value = familyMemberDetails.Job;
                sqlCommand.Parameters.Add(sqlParameterJob);

                SqlParameter sqlParameterFamilyMemberTypeId = new SqlParameter();
                sqlParameterFamilyMemberTypeId.ParameterName = "@FamilyMemberTypeId";
                sqlParameterFamilyMemberTypeId.Value = familyMemberDetails.FamilyMemberTypeId;
                sqlCommand.Parameters.Add(sqlParameterFamilyMemberTypeId);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                
            }
        }
    }
}