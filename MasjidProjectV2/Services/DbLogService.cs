using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasjidProjectV2.Models;

namespace MasjidProjectV2.Services
{
    public class DbLogService
    {
        private ApplicationDbContext db;

        public DbLogService()
        {
            db = new ApplicationDbContext();
        }
        public void LogInDb(string email, LogAction logAction)
        {
            var user = db.Users.SingleOrDefault(u => u.Email == email);

            var log = new Log
            {
                Timestamp = DateTime.Now,
                Email = email,
                LogAction = logAction
            };
            if (user != null)
            {
                log.ApplicationUserId = user.Id;
            }

            db.LoginHistories.Add(log);
            db.SaveChanges();

        }

    }
}