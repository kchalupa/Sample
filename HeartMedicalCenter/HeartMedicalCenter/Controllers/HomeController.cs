using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
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
    /// The database connection layer.
    /// </summary>
    private HeartMedicalCenterEntities m_entities = new HeartMedicalCenterEntities();

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
    /// Get view to make the appointment.
    /// </summary>
    /// <returns></returns>
    public ActionResult Appointment()
    {
      return View(new Appointment());
    } // Appointment()


    /// <summary>
    /// Handles post of the add appointment.
    /// </summary>
    /// <param name="appointment"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult Appointment(Appointment appointment)
    {
      if (ModelState.IsValid)
      {
        // Link the appointment and patient history together.  The id on both coming out of the view is {0000-0000...}.

        Guid guid = Guid.NewGuid();
        appointment.Id = guid;
        if (appointment.IsNewPatient)
        {
          appointment.PatientHistory.Id = guid;
        }


        // Write the appointment to the database.
        if (appointment.IsNewPatient)
        {
          m_entities.PatientHistories.Add(appointment.PatientHistory);
        }

        m_entities.Appointments.Add(appointment);
        m_entities.SaveChanges();

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
    public ActionResult Confirmation(Appointment appointment)
    {
      return View(appointment);
    } // Confirmation()


    /// <summary>
    /// Handles the login.  The database just holds a string and the string is pre-encrypted and sent across the wire for comparison.
    /// </summary>
    /// <param name="auth">Contains the username and password for authentication.</param>
    public ActionResult Login(Authentication auth, string returnUrl)
    {
      if(Request.HttpMethod == "GET")
      {
        return View(new Authentication());
      }
      else
      {
        if(ModelState.IsValid)
        {
          string encrypted = Encrypt(auth.Password);
          foreach (Authentication dbAuth in m_entities.Authentications)
          {
            if(dbAuth.Username == auth.Username && dbAuth.Password == encrypted)
            {
              FormsAuthentication.SetAuthCookie(auth.Username, true);
              return Redirect(returnUrl);
            }
          }
        }

        return View(auth);
      }
    } // Login( auth, returnUrl )


    /// <summary>
    /// Encrypts a string to authenticate into the database.
    /// </summary>
    /// <returns></returns>
    [NonAction]
    private string Encrypt(string authenticate)
    {
      using (SHA384 sha384 = SHA384Managed.Create())
      {
        byte[] bytes = Encoding.UTF8.GetBytes(authenticate);
        byte[] hash = sha384.ComputeHash(bytes);

        return System.Convert.ToBase64String(hash);
      }
    } // Encrypt()

    #endregion

  } // class HomeController
} // namespace kchalupa.Web.HeartMedicalCenter.Controllers
 