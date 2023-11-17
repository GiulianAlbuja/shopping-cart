﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingCartEntity;
using System.Data.SqlClient;
using System.Data;

namespace ShoppingCartData
{
    public class UsersData
    {
        public List<User> ListUsers()
        {
            List<User> list = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.cn)) {
                    String query = "SELECT IdUser,UserNames, UserLastNames, Email, UserPassword, ResetPassword, Asset FROM Users";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()){
                        while (dr.Read())
                        {
                            list.Add(
                                new User() { 
                                    IdUser = Convert.ToInt32(dr["IdUser"]),
                                    UserNames = dr["UserNames"].ToString(),
                                    UserLastNames = dr["UserLastNames"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    UserPassword = dr["UserPassword"].ToString(),
                                    ResetPassword = Convert.ToBoolean(dr["ResetPassword"]),
                                    Asset = Convert.ToBoolean(dr["Asset"]),
                                }
                                
                                );
                        }
                    }
                }
            }
            catch { 
                list = new List<User>();
            }
            return list;
        }


        public int RegisterUser(User objectUser, out String Message)
        {
            int idAutogenerated = 0;
            Message = String.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegisterUser", connection);
                    cmd.Parameters.AddWithValue("UserNames", objectUser.UserNames);
                    cmd.Parameters.AddWithValue("UserLastNames", objectUser.UserLastNames);
                    cmd.Parameters.AddWithValue("Email", objectUser.Email);
                    cmd.Parameters.AddWithValue("UserPassword", objectUser.UserPassword);
                    cmd.Parameters.AddWithValue("Asset", objectUser.Asset);
                    cmd.Parameters.Add("Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    cmd.ExecuteNonQuery();

                    idAutogenerated = Convert.ToInt32(cmd.Parameters["Result"].Value);
                    Message = cmd.Parameters["Message"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idAutogenerated = 0;
                Message = ex.Message;
            }
            return idAutogenerated;
        }


        public bool EditUser(User objectUser, out String Message)
        {
            bool result = false;
            Message = String.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditUser", connection);
                    cmd.Parameters.AddWithValue("IdUser", objectUser.IdUser);
                    cmd.Parameters.AddWithValue("UserNames", objectUser.UserNames);
                    cmd.Parameters.AddWithValue("UserLastNames", objectUser.UserLastNames);
                    cmd.Parameters.AddWithValue("Email", objectUser.Email);
                    cmd.Parameters.AddWithValue("Asset", objectUser.Asset);
                    cmd.Parameters.Add("Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    cmd.ExecuteNonQuery();

                    result = Convert.ToBoolean(cmd.Parameters["Result"].Value);
                    Message = cmd.Parameters["Message"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                result = false;
                Message = ex.Message;
            }
            return result;
        }


        public bool DeleteUser(int id, out String Message)
        {
            bool result = false;
            Message = String.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.cn))
                {
                    SqlCommand cmd = new SqlCommand("DELETE top (1) FROM users WHERE IdUser = @id", connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    result = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Message = ex.Message;
            }
            return result;
        }

    }
}
