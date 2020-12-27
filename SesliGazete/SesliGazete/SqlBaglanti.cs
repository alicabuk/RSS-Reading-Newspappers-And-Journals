using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SesliGazete
{
    class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-L46D9TA\\SQLEXPRESS;Initial Catalog=Sesli_Okuma;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
