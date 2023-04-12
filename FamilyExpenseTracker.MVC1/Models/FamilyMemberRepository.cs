using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FamilyExpenseTracker.MVC1.Models
{
    public class FamilyMemberRepository
    {
        public int AddFamilyMember(FamilyMember familyMember)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("AddFamilyMember", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", familyMember.Name);
                    command.Parameters.AddWithValue("@cell", familyMember.Cell);
                    command.Parameters.AddWithValue("@work", familyMember.Work);
                    command.Parameters.AddWithValue("@income", familyMember.Income);
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                            int status = command.ExecuteNonQuery();
                            return status;
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            return 0;
        }

        public FamilyMember GetFamilyMember(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("DisplayAllFamilyMember", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                            using (SqlDataReader dr = command.ExecuteReader())
                            {
                                List<FamilyMember> familyMembers = new List<FamilyMember>();
                                while (dr.Read())
                                {
                                    FamilyMember familyMember = new FamilyMember()
                                    {
                                        FamilyMemberId = Convert.ToInt32(dr["FamilyMemberId"]),
                                        Name = dr["Name"].ToString(),
                                        Cell = Convert.ToInt64(dr["Cell"]),
                                        Work = dr["Work"].ToString(),
                                        Income = Convert.ToInt32(dr["Income"])
                                    };
                                    familyMembers.Add(familyMember);
                                }
                                dr.Close();
                                FamilyMember familyMemberResult = familyMembers.Find(x => x.FamilyMemberId == id);
                                return familyMemberResult;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            return null;
        }

        public int EditFamilyMember(FamilyMember familyMember)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("EditFamilyMember", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@familyMemberId", familyMember.FamilyMemberId);
                    command.Parameters.AddWithValue("@name", familyMember.Name);
                    command.Parameters.AddWithValue("@cell", familyMember.Cell);
                    command.Parameters.AddWithValue("@work", familyMember.Work);
                    command.Parameters.AddWithValue("@income", familyMember.Income);
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                            int status = command.ExecuteNonQuery();
                            return status;
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            return 0;
        }

        public int DeleteFamilyMember(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("DeleteFamilyMember", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fmailyMemberId", id);
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                            int status = command.ExecuteNonQuery();
                            return status;
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            return 0;
        }

        public List<FamilyMember> GetAllFamilyMembers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("DisplayAllFamilyMember", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                            using (SqlDataReader dr = command.ExecuteReader())
                            {
                                List<FamilyMember> familyMembers = new List<FamilyMember>();
                                while (dr.Read())
                                {
                                    FamilyMember familyMember = new FamilyMember()
                                    {
                                        FamilyMemberId = Convert.ToInt32(dr["FamilyMemberId"]),
                                        Name = dr["Name"].ToString(),
                                        Cell = Convert.ToInt64(dr["Cell"]),
                                        Work = dr["Work"].ToString(),
                                        Income = Convert.ToInt32(dr["Income"])
                                    };
                                    familyMembers.Add(familyMember);
                                }
                                dr.Close();
                                return familyMembers;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            return null;
        }

    }
}