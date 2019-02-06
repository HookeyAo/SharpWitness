using System.Collections;

namespace SharpWitness
{
    public class DefaultCreds
    {
        public static Hashtable GetHashTable()
        {
            Hashtable table = new Hashtable();
            table.Add("apache tomcat", "tomcat:tomcat, apache:apache, apache:password, manager:manager, role1:tomcat, tomcat:s3cret, qcc:QLogic66, admin:admin");
            table.Add("jboss", "admin:admin, admin:password");
            table.Add("phpmyadmin", "root:, root:root, root:password");

            return table;
        }
    }
}
