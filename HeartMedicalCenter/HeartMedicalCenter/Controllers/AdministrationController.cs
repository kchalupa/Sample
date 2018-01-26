using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using kchalupa.Web.HeartMedicalCenter.Infrastructure;
using kchalupa.Web.HeartMedicalCenter.Models;

namespace kchalupa.Web.HeartMedicalCenter.Controllers
{
  [Authorize]
  public class AdministrationController : Controller
  {

    #region fields

    /// <summary>
    /// The appointment repository.
    /// </summary>
    private IRepository<Appointment> m_appointmentsRepository = null;

    #endregion

    #region construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="appointmentsRepository">The appointments repository.</param>
    public AdministrationController(IRepository<Appointment> appointmentsRepository)
    {
      m_appointmentsRepository = appointmentsRepository;
    } // AdministrationController( appointmentsRepository )

    #endregion

    #region methods

    /// <summary>
    /// Produces a record of all appointments.
    /// </summary>
    /// <returns></returns>
    public ActionResult Index()
    {
      return View(m_appointmentsRepository.Items);
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
          m_appointmentsRepository.Update(appointment);
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
        m_appointmentsRepository.Delete(appointment);
        return Redirect("Index");
      }
    } // Delete( appointment )

    #endregion

  } // class AdministrationController
} // namespace kchalupa.Web.HeartMedicalCenter.Controllers
