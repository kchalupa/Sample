using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using kchalupa.Web.HeartMedicalCenter.Models;

namespace kchalupa.Web.HeartMedicalCenter.Infrastructure
{
  /// <summary>
  /// Appointments repository.
  /// </summary>
  public class AppointmentRepository : IRepository<Appointment>
  {

    #region properties

    /// <summary>
    /// Gets the collection of appointments.
    /// </summary>
    public Appointment[] Items
    {
      get { return DatabaseGateway.GetAppointments().ToArray(); }
    } // Items

    #endregion

    #region methods

    /// <summary>
    /// Adds the appointment to the collection.
    /// </summary>
    /// <param name="appt"></param>
    public void Add(Appointment appt)
    {
      DatabaseGateway.AddAppointment(appt);
      if(appt.IsNewPatient)
      {
        DatabaseGateway.AddPatientHistory(appt.PatientsHistory);
      }
    } // Add( appt )


    /// <summary>
    /// Updates the appointment with the changed element.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="appt"></param>
    public void Update(Appointment appt)
    {
      DatabaseGateway.UpdaeAppointment(appt);
      if (appt.IsNewPatient)
      {
        DatabaseGateway.AddPatientHistory(appt.PatientsHistory);
      }
    } // Update( id, appt )


    /// <summary>
    /// Deletes an item from the collection.
    /// </summary>
    /// <param name="appt"></param>
    public void Delete(Appointment appt)
    {
      if (appt.IsNewPatient)
      {
        DatabaseGateway.AddPatientHistory(appt.PatientsHistory);
      }

      DatabaseGateway.DeleteAppointment(appt);
    } // Delete( appt )

    #endregion

  } // class AppointmentRepository
} // namespace kchalupa.Web.HeartMedicalCenter.Infrastructure