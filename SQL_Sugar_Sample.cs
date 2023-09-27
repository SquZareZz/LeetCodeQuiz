using MathNet.Numerics.Distributions;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace QuizSolution
{
    public class SQL_Sugar_Sample
    {
        public string GetString()
        {
            var database = new SqlSugarClient(new List<ConnectionConfig>()
            {
                // setup connection
                new ConnectionConfig()
                {
                    ConfigId="VIS_AUTODEVICE",
                    ConnectionString = "Data Source=172.28.128.197;Initial Catalog=CPDB;User ID=sa;Password=Psi#5915;TrustServerCertificate=true;",
                    DbType = DbType.SqlServer,
                    LanguageType = LanguageType.English,
                    IsAutoCloseConnection = true
                }
            });   
            var ResList = database.Queryable<VIS_AUTODEVICE>()
                .Where(x => x.DEVICE.Contains("VP55"))
                .ToList();
            return ResList.FirstOrDefault().DEVICE.ToString().Trim();
        }
        public class VIS_AUTODEVICE
        {
            public string DEVICE { get; set; }
        }
    }
}
