using SMSAPI1.DBAccess;
using SMSAPI1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessAccessLayer.BLAdmin
{
    public class BLAdmin
    {
        AdminDbAccess adminDb = new AdminDbAccess();
        public string LoginAdmin(AdminLogin admin)
        {
            return adminDb.LoginAdmin(admin);
        }
    }
}
