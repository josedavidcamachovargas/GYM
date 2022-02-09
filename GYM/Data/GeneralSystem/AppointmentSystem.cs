using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Data.GeneralSystem
{
    public class AppointmentSystem : SystemFunctions<Appointment>, IAppointment
    {

        private readonly ApplicationDbContext _db;

        public AppointmentSystem(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Appointment appointment)
        {
            var objFromDb = _db.Appointments.FirstOrDefault(s => s.Id == appointment.Id);

            if (objFromDb != null)
            {
                objFromDb.Id = appointment.Id;
                objFromDb.AppointmentDate = appointment.AppointmentDate;
                objFromDb.AppointmentHour = appointment.AppointmentHour;
                objFromDb.CustomerId = appointment.CustomerId;
                _db.SaveChanges();
            }
        }
    }
}

