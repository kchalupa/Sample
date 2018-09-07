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

    #region methods

    /// <summary>
    /// Produces a record of all appointments.
    /// </summary>
    /// <returns></returns>
    public ActionResult Index()
    {
      using (var entities = new HeartMedicalCenterEntities())
      {
        return View(entities.Appointments);
      }
    } // Index()


    /// <summary>
    /// Display the editing view and commit the results.
    /// </summary>
    /// <param name="appointment">The appointment to edit.</param>
    /// <returns></returns>
    public ActionResult Appointment(Appointment appointment, string returnUrl)
    {
      if(Request.HttpMethod == "GET")
      {
        return View(appointment);
      }
      else
      {
        if (ModelState.IsValid)
        {
          using (var entities = new HeartMedicalCenterEntities())
          {
            // The object was updated, so we simply tell the object to persist the changge.
            entities.SaveChanges();
          }

          return Redirect(returnUrl);
        }
        else
        {
          return View(appointment);
        }
      }
    } // Appointment( appointment, returnUrl )


    /// <summary>
    /// Deletes the appointment.
    /// </summary>
    /// <param name="appointment"></param>
    public ActionResult Delete(Appointment appointment)
    {
      if(Request.HttpMethod == "GET")
      {
        return View(appointment);
      }
      else
      {
        using (var entities = new HeartMedicalCenterEntities())
        {
          entities.Appointments.Remove(appointment);
        }


          //m_appointmentsRepository.Delete(appointment);
          return Redirect("Index");
      }
    } // Delete( appointment )

    #endregion

  } // class AdministrationController
} // namespace kchalupa.Web.HeartMedicalCenter.Controllers
