using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCusers.Models
{
    public class UserDataAccessLayer
    {
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=usuarios;Data Source=DESKTOP-J71CQGN\\ADAN";

        public IEnumerable<Usuario> GetAllUsers()
        {
            List<Usuario> lstuser = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.CP = Convert.ToInt32(rdr["CP"]);
                    usuario.nombre_usu = rdr["nombre_usu"].ToString();
                    usuario.appaterno = rdr["appaterno"].ToString();
                    usuario.apmaterno = rdr["apmaterno"].ToString();
                    usuario.edad = Convert.ToInt32(rdr["edad"]);
         

                    lstuser.Add(usuario);
                }
                con.Close();
            }
            return lstuser;
        }

        public void AddUser(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CP", usuario.CP);
                cmd.Parameters.AddWithValue("@nombre_usu", usuario.nombre_usu);
                cmd.Parameters.AddWithValue("@appaterno", usuario.appaterno);
                cmd.Parameters.AddWithValue("@apmaterno", usuario.apmaterno);
                cmd.Parameters.AddWithValue("@edad", usuario.edad);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateUser(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CP", usuario.CP);
                cmd.Parameters.AddWithValue("@nombre_usu", usuario.nombre_usu);
                cmd.Parameters.AddWithValue("@appaterno", usuario.appaterno);
                cmd.Parameters.AddWithValue("@apmaterno", usuario.apmaterno);
                cmd.Parameters.AddWithValue("@edad", usuario.edad);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Usuario GetUserData(int? id)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM usuario WHERE CP = " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    usuario.CP = Convert.ToInt32(rdr["CP"]);
                    usuario.nombre_usu = rdr["nombre_usu"].ToString();
                    usuario.appaterno = rdr["appaterno"].ToString();
                    usuario.apmaterno = rdr["apmaterno"].ToString();
                    usuario.edad = Convert.ToInt32(rdr["edad"]);
                }
            }
            return usuario;
        }

        public void DeleteUser(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CP", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
