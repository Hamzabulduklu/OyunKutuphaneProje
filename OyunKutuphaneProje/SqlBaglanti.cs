using System.Data.SqlClient;

namespace OyunKutuphaneProje
{
    public class SqlBaglanti
    {//Encapsulation (Kapsülleme)
        public SqlConnection baglanti()
        {

            SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-B19C3D2;Initial Catalog=OyunKutuphaneDB;Integrated Security=True");
            if (bgl.State == System.Data.ConnectionState.Closed)
                bgl.Open();
            return bgl;
        }
    }
}
