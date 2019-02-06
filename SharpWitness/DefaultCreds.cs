using System.Collections;

namespace SharpWitness
{
    public class DefaultCreds
    {
        public static Hashtable GetHashTable()
        {
            Hashtable table = new Hashtable();
            table.Add("apache tomcat", "tomcat:tomcat");

            return table;
        }
    }
}
