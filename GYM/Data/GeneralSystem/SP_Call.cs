using Dapper;
using GYM.Data.GeneralSystem.IGeneralSystem;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem
{
    public class SP_Call : ISP_Call
    {

        public readonly ApplicationDbContext _db;
        private static string ConnectionString = "";

        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Execute(string procedureName, DynamicParameters param = null)
        {
            SqlConnection conex = new SqlConnection(ConnectionString);
            conex.Open();
            conex.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
        }

        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            SqlConnection conex = new SqlConnection(ConnectionString);
            conex.Open();
            return conex.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null)
        {
            SqlConnection conex = new SqlConnection(ConnectionString);
            conex.Open();
            var result = SqlMapper.QueryMultiple(conex, procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            var item1 = result.Read<T1>().ToList();
            var item2 = result.Read<T2>().ToList();

            if (item1 != null && item2 != null)
            {
                return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
            }
            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }


        //public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> List<T1, T2, T3>(string procedureName, DynamicParameters param = null)
        //{
        //    SqlConnection conex = new SqlConnection(ConnectionString);
        //    conex.Open();
        //    var result = SqlMapper.QueryMultiple(conex, procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
        //    var item1 = result.Read<T1>().ToList();
        //    var item2 = result.Read<T2>().ToList();
        //    var item3 = result.Read<T3>().ToList();

        //    if (item1 != null && item2 != null)
        //    {
        //        return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(item1, item2, item3);
        //    }
        //    return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(new List<T1>(), new List<T2>(), new List<T3>());
        //}


        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            SqlConnection conex = new SqlConnection(ConnectionString);
            conex.Open();
            var value = conex.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));
        }

        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            SqlConnection conex = new SqlConnection(ConnectionString);
            conex.Open();
            return (T)Convert.ChangeType(conex.ExecuteScalar<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
        }

    }
}
