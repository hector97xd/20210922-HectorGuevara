using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace AFP.Models
{
    public class PacienteContext
    {
        private string con;

        public PacienteContext()
        {
            con = @"Server=localhost,1433\\Catalog=AFP;Database=AFP;User=sa;Password=MyPass@word;";

        }
        public IDbConnection GetConnection
        {
            get
            {
                return new SqlConnection(con);
            }
        }
        public List<Paciente> GetAll()
        {
            var ls = new List<Paciente>();
            try
            {
                using (IDbConnection cn = GetConnection)
                {
                    var query = @"SELECT * from Paciente";
                    cn.Open();
                    ls = cn.Query<Paciente>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ls;
        }

        public void Add(Paciente prod)
        {
            try
            {
                using (IDbConnection cn = GetConnection)
                {
                    var query = @"INSERT INTO PACIENTE(Nombre,fechaNacimiento,sexo) VALUES(@Nombre,@fechaNacimiento,@fechaNacimiento)";
                    cn.Open();
                    cn.Execute(query, prod);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection cn = GetConnection)
            {
                var query = @"DELETE FROM Paciente WHERE Id=@Id";
                cn.Open();
                cn.Execute(query, new { Id = id });
            }
        }
        public void Update(Paciente p)
        {
            using (IDbConnection cn = GetConnection)
            {
                var query = @"UPDATE Paciente SET Nombre=@Nombre,fechaNacimiento=@fechaNacimiento,sexo=@sexo WHERE Id=@Id";
                cn.Open();
                cn.Execute(query, p);
            }
        }
    }
}
