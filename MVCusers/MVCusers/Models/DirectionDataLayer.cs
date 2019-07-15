using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCusers.Models
{
    public class DirectionDataLayer
    {
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=usuarios;Data Source=LAPTOP-1UAOC5JP\\SQLEXPRESS";

        public IEnumerable<Direccion> GetAllDirections()
        {
            List<Direccion> lstDir = new List<Direccion>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllDirections", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Direccion direccion = new Direccion();

                    direccion.id_direccion = Convert.ToInt32(rdr["id_direccion"]);
                    direccion.calle = rdr["calle"].ToString();
                    direccion.colonia = rdr["colonia"].ToString();
                    direccion.delegacion = rdr["delegacion"].ToString();
                    direccion.numero = Convert.ToInt32(rdr["numero"]);
                    direccion.codigopostal = Convert.ToInt32(rdr["codigopostal"]);

                    lstDir.Add(direccion);
                }
                con.Close();
            }
            return lstDir;
        }

        public void AddDirection(Direccion direccion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddDirection", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_direccion", direccion.id_direccion);
                cmd.Parameters.AddWithValue("@calle", direccion.calle);
                cmd.Parameters.AddWithValue("@colonia", direccion.colonia);
                cmd.Parameters.AddWithValue("@delegacion", direccion.delegacion);
                cmd.Parameters.AddWithValue("@numero", direccion.numero);
                cmd.Parameters.AddWithValue("@codigopostal", direccion.codigopostal);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateDirection(Direccion direccion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateDirection", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_direccion", direccion.id_direccion);
                cmd.Parameters.AddWithValue("@calle", direccion.calle);
                cmd.Parameters.AddWithValue("@colonia", direccion.colonia);
                cmd.Parameters.AddWithValue("@delegacion", direccion.delegacion);
                cmd.Parameters.AddWithValue("@numero", direccion.numero);
                cmd.Parameters.AddWithValue("@codigopostal", direccion.codigopostal);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Direccion GetDirectionData(int? id)
        {
            Direccion direccion = new Direccion();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM direccion WHERE id_direccion= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    direccion.codigopostal = Convert.ToInt32(rdr["id_direccion"]);
                    direccion.calle = rdr["calle"].ToString();
                    direccion.colonia = rdr["colonia"].ToString();
                    direccion.delegacion = rdr["delegacion"].ToString();
                    direccion.numero = Convert.ToInt32(rdr["numero"]);
                    direccion.codigopostal = Convert.ToInt32(rdr["codigopostal"]);
                }
            }
            return direccion;
        }

        public void DeleteDirection(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteDirection", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_direccion", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
