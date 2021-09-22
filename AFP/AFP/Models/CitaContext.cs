using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace AFP.Models
{
    public class CitaContext
    {
        private string con;

        public CitaContext()
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
        public List<Cita> GetAll()
        {
            var ls = new List<Cita>();
            try
            {
                using (IDbConnection cn = GetConnection)
                {
                    var query = @"SELECT * from CITA ";
                    cn.Open();
                    ls = cn.Query<Cita>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ls;
        }

        public void Add(Cita prod)
        {
            try
            {
                using (IDbConnection cn = GetConnection)
                {
                    var query = @"INSERT INTO CITA(FechaCita,Descripcion,Paciente,Doctor) VALUES(@FechaCita,@Descripcion,@Paciente,@Doctor)";
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
                var query = @"DELETE FROM CITA WHERE Id=@Id";
                cn.Open();
                cn.Execute(query, new { Id = id });
            }
        }
        public void Update(Cita prod)
        {
            using (IDbConnection cn = GetConnection)
            {
                var query = @"UPDATE CITA SET FechaCita=@FechaCita,Descripcion=@Descripcion,Paciente=@Paciente,Doctor=@Doctor WHERE Id=@Id";
                cn.Open();
                cn.Execute(query, prod);
            }
        }
    }
}
