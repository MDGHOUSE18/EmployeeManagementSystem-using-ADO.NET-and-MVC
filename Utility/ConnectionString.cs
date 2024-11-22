namespace EmployeeManagementMVC.Utility
{
    public class ConnectionString
    {
        private static string cs = "Server = GHOUSE\\SQLEXPRESS; Database = EmployeeManagementSystem;Integrated Security=True;";
        public static string dbcs { get => cs; }
    }
}
