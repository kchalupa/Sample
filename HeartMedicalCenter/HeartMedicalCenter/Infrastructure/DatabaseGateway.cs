using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using kchalupa.Web.HeartMedicalCenter.Models;
using System.Data.Entity.Infrastructure;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace kchalupa.Web.HeartMedicalCenter.Infrastructure
{
  public static class DatabaseGateway
  {

    #region fields

    /// <summary>
    /// The database to execute queries against.
    /// </summary>
    private static Database m_database = new DbContext(ConfigurationManager.AppSettings["HeartMedicalConnectionString"]).Database;

    #endregion
    
    #region methods

    /// <summary>
    /// Get the list of appointments.
    /// </summary>
    /// <returns></returns>
    public static Appointment[] GetAppointments()
    {
      List<Appointment> items = new List<Appointment>();

      DbRawSqlQuery<Appointment> appointments = m_database.SqlQuery<Appointment>("SELECT * FROM [APPOINTMENTS]");
      foreach(Appointment appt in appointments)
      {
        if(appt.IsNewPatient)
        {
          DbRawSqlQuery<Appointment.PatientHistory> patientHistories = m_database.SqlQuery<Appointment.PatientHistory>("SELECT * FROM [PATIENTHISTORIES] WHERE [Id] = " + appt.Id);
          appt.PatientsHistory = patientHistories.First();
        }

        items.Add(appt);
      }

      return items.ToArray();
    } // GetAppointments()


    /// <summary>
    /// Authenticates against the database.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns>True, if username and password match, false otherwise.</returns>
    public static bool Authenticate(string username, string password)
    {
      try
      {
        var result = new SqlParameter("@RESULT", System.Data.SqlDbType.Bit);
        result.Direction = ParameterDirection.Output;

        var data = m_database.SqlQuery<object>("EXEC [sp_authenticate] @USERNAME, @PASSWORD, @RESULT OUTPUT",
          new SqlParameter("@USERNAME", username),
          new SqlParameter("@PASSWORD", password),
          result);

        // Read the results so that the output params will be populated.
        var item = data.FirstOrDefault();

        return (bool)result.Value;
      }
      catch(SqlException)
      {
        return false;
      }
    } // Authenticate( username, password )



    /// <summary>
    /// Adds an appointment.
    /// </summary>
    /// <param name="appt"></param>
    public static void AddAppointment(Appointment appt)
    {
      m_database.ExecuteSqlCommand("EXEC [sp_addAppointment] @ID={0}, @NAME={1}, @ADDRESS={2}, @CITY={3}, @STATE={4}, @ZIPCODE={5}, @BIRTHDATE={6}, @ISNEWPATIENT={7}, @INSURANCEPROVIDER={8}, @MEMBERNUMBER={9}, @APPOINTMENTDATE={10}, @REASONFORAPPOINTMENT={11}", appt.Id, appt.Name, appt.Address, appt.City, appt.State, appt.ZipCode, appt.Birthdate, appt.IsNewPatient, appt.InsuranceProvider, appt.MemberNumber, appt.AppointmentDate, appt.ReasonForAppointment);
    } // AddAppointment( appt )


    /// <summary>
    /// Add the patient history.
    /// </summary>
    /// <param name="history"></param>
    public static void AddPatientHistory(Appointment.PatientHistory history)
    {
      m_database.ExecuteSqlCommand("EXEC [sp_addPatientHistory] @ID={0}, @CONDITIONS={1}, @MEDICATIONS={2}, @ALLERGIES={3}, @PHYSICIANS={4}", history.Id, history.Conditions, history.Medications, history.Allergies, history.Physicians);
    } // AddPatientHistory( history )


    /// <summary>
    /// Adds an appointment.
    /// </summary>
    /// <param name="appt"></param>
    public static void UpdaeAppointment(Appointment appt)
    {
      m_database.ExecuteSqlCommand("EXEC [sp_updateAppointment] @ID={0}, @NAME={1}, @ADDRESS={2}, @CITY={3}, @STATE={4}, @ZIPCODE={5}, @BIRTHDATE={6}, @ISNEWPATIENT={7}, @INSURANCEPROVIDER={8}, @MEMBERNUMBER={9}, @APPOINTMENTDATE={10}, @REASONFORAPPOINTMENT={11}", appt.Id, appt.Name, appt.Address, appt.City, appt.State, appt.ZipCode, appt.Birthdate, appt.IsNewPatient, appt.InsuranceProvider, appt.MemberNumber, appt.AppointmentDate, appt.ReasonForAppointment);
    } // AddAppointment( appt )


    /// <summary>
    /// Update the patient history.
    /// </summary>
    /// <param name="history"></param>
    public static void UpdatePatientHistory(Appointment.PatientHistory history)
    {
      m_database.ExecuteSqlCommand("EXEC [sp_updatePatientHistory] @ID={0}, @CONDITIONS={1}, @MEDICATIONS={2}, @ALLERGIES={3}, @PHYSICIANS={4}", history.Id, history.Conditions, history.Medications, history.Allergies, history.Physicians);
    } // AddPatientHistory( history )


    /// <summary>
    /// Adds an appointment.
    /// </summary>
    /// <param name="appt"></param>
    public static void DeleteAppointment(Appointment appt)
    {
      m_database.ExecuteSqlCommand("EXEC [sp_deleteAppointment] @ID={0}", appt.Id);
    } // AddAppointment( appt )


    /// <summary>
    /// Deletes the patient history.
    /// </summary>
    /// <param name="history"></param>
    public static void DeletePatientHistory(Appointment.PatientHistory history)
    {
      m_database.ExecuteSqlCommand("EXEC [sp_deletePatientHistory] @ID={0}", history.Id);
    } // DeletePatientHistory( history )

    #endregion

  } // class DatabaseGateway
} // namespace kchalupa.Web.HeartMedicalCenter.Infrastructure