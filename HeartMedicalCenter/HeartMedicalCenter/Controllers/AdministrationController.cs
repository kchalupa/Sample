using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using kchalupa.Web.HeartMedicalCenter.Infrastructure;

namespace kchalupa.Web.HeartMedicalCenter.Controllers
{
  [Authorize]
  public class AdministrationController : Controller
  {

    #region fields

    /// <summary>
    /// The database connection layer.
    /// </summary>
    private HeartMedicalCenterEntities m_entities = new HeartMedicalCenterEntities();

    #endregion

    #region methods

    /// <summary>
    /// Produces a record of all appointments.
    /// </summary>
    /// <returns>Displays the list of appointments.</returns>
    public ActionResult Index()
    {
      return View(m_entities.Appointments.ToArray());
    } // Index()


    /// <summary>
    /// Allows a receptionist to make changes to the appointment or view it.
    /// </summary>
    /// <returns>The view if HTTPGet otherwise we return the user to the index page.</returns>
    public ActionResult EditAppointment(Appointment appointment)
    {
      if (Request.HttpMethod == "GET")
      {
        return View(appointment);
      }
      else
      {
        m_entities.SaveChanges();

        return Redirect("Index");
      }
    } // Edit( appointment )


    /// <summary>
    /// Deletes the appointment, for example if the patient wants to cancel it.
    /// </summary>
    public ActionResult DeleteAppointment(Appointment appointment)
    {
      if(Request.HttpMethod == "GET")
      {
        return View(appointment);
      }
      else
      {
        if(appointment.IsNewPatient)
        {
          // If the appointment has a patient history associated with it, delete it first.
          m_entities.PatientHistories.Remove(m_entities.PatientHistories.Where(p => p.Id == appointment.Id).First());
        }

        m_entities.Appointments.Remove(m_entities.Appointments.Where(p => p.Id == appointment.Id).First());
        m_entities.SaveChanges();

        return Redirect("Index");
      }
    } // Delete( appointment )

    #endregion

  } // class AdministrationController
} // namespace kchalupa.Web.HeartMedicalCenter.Controllers
