using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using kchalupa.Web.HeartMedicalCenter.Models;
using kchalupa.Web.HeartMedicalCenter.Infrastructure;
using System.Web.Security;

namespace kchalupa.Web.HeartMedicalCenter.Controllers
{
  /// <summary>
  /// The home controller.
  /// </summary>
  public class HomeController : Controller
  {

    #region fields

    /// <summary>
    /// The appointments repository.
    /// </summary>
    private IRepository<Appointment> m_appointmentsRepository = null;

    #endregion

    #region construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="apptRepo"></param>
    public HomeController(IRepository<Appointment> apptRepo)
    {
      m_appointmentsRepository = apptRepo;
    } // HomeController( apptRepo )

    #endregion

    #region methods

    /// <summary>
    /// Returns the index view.
    /// </summary>
    /// <returns>The action result.</returns>
    public ActionResult Index()
    {
      return View();
    } // Index()


    /// <summary>
    /// Displays the directions to our locations.
    /// </summary>
    /// <returns></returns>
    public ActionResult Directions()
    {
      return View();
    } // Directions()
    

    /// <summary>
    /// Get view to make the appointment.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult Appointment()
    {
      return View(new Appointment());
    } // Appointment()


    /// <summary>
    /// Handles post of the appointment.
    /// </summary>
    /// <param name="appointment"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult Appointment(Appointment appointment)
    {
      if (ModelState.IsValid)
      {
        // Write the appointment to the database.
        m_appointmentsRepository.Add(appointment);

        return Redirect("Confirmation");
      }
      else
      {
        return View(appointment);
      }
    } // Appointment( appointment )


    /// <summary>
    /// Displays the confirmation screen.
    /// </summary>
    /// <param name="appt"></param>
    /// <returns></returns>
    public ActionResult Confirmation(Appointment appointment)
    {
      return View(appointment);
    } // Confirmation()


    /// <summary>
    /// Gets the view of the physcians.
    /// </summary>
    public ActionResult Physicians()
    {
      return View();
    } // Physicians()


    /// <summary>
    /// Gets the view for contact to the facility.
    /// </summary>
    public ActionResult Contadct()
    {
      return View();
    } // Contact()


    /// <summary>
    /// Handles the post and login.
    /// </summary>
    /// <param name="auth"></param>
    /// <returns></returns>
    public ActionResult Login(Authentication auth, string returnUrl)
    {
      if(Request.HttpMethod == "GET")
      {
        return View(new Authentication());
      }
      else
      {
        // Try to authenticate against the user entered username and password.
        if (DatabaseGateway.Authenticate(auth.Username, auth.Password))
        {
          // Set the authentication cookie.
          FormsAuthentication.SetAuthCookie(auth.Username, true);
          return Redirect(returnUrl);
        }
        else
        {
          return View(auth);
        }
      }
    } // Login( auth, returnUrl )

    #endregion

  } // class HomeController
} // namespace kchalupa.Web.HeartMedicalCenter.Controllers
 