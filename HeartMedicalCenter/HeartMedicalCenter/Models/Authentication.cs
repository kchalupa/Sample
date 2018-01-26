using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kchalupa.Web.HeartMedicalCenter.Models
{
  public class Authentication
  {

    #region fields

    /// <summary>
    /// The username.
    /// </summary>
    private string m_username = string.Empty;

    /// <summary>
    /// The password.
    /// </summary>
    private string m_password = string.Empty;

    #endregion

    #region properties

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    public string Username
    {
      get { return m_username; }
      set { m_username = value; }
    } // Username


    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    public string Password
    {
      get { return m_password; }
      set { m_password = value; }
    } // Password

    #endregion

  }
}