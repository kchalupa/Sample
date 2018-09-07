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
    [HttpGet]
    public ActionResult Appointment()
    {
      // Create appointment and initialize id.
      Appointment appt = new Appointment();
      appt.Id = Guid.NewGuid();

      return View(appt);
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
        using (var entities = new HeartMedicalCenterEntities())
        {
          entities.PatientHistories.Add(appointment.PatientHistory);
          entities.SaveChanges();
        }

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
          using (HeartMedicalCenterEntities entities = new HeartMedicalCenterEntities())
          {
            string encrypted = Encrypt(auth.Password);

            foreach (Authentication dbAuth in entities.Authentications)
            {
              if(dbAuth.Username == auth.Username && dbAuth.Password == encrypted)
              {
                FormsAuthentication.SetAuthCookie(auth.Username, true);
                return Redirect(returnUrl);
              }
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
      SHA512 sha512 = SHA512Managed.Create();
      byte[] bytes = Encoding.UTF8.GetBytes(authenticate);
      byte[] hash = sha512.ComputeHash(bytes);

      StringBuilder builder = new StringBuilder();
      for(int i = 0; i < hash.Length; ++i)
      {
        builder.Append(hash[i].ToString("X2"));
      }

      return builder.ToString();
    } // Encrypt()

    #endregion

  } // class HomeController
} // namespace kchalupa.Web.HeartMedicalCenter.Controllers
 