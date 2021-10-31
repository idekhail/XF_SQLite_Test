using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XF_SQLiteDB_Test
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string  Username { get; set; }
        public string Password { get; set; }
    }
}
