using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kchalupa.Web.HeartMedicalCenter.Models
{

  #region enum InsuranceProviders

  /// <summary>
  /// The list of insurance providers.
  /// </summary>
  public enum InsuranceProviders
  {
    NotSpecified,
    Aetna,
    BlueCrossBlueShield,
    SeniorHealth,
    UnitedHealthCare
  } // enum InsuranceProviders

  #endregion

  /// <summary>
  /// The appointment.
  /// </summary>
  public class Appointment
  {

    #region PatientHistory class

    /// <summary>
    /// The patient history.
    /// </summary>
    public class PatientHistory
    {

      #region fields

      /// <summary>
      /// The id to link the appointment with the patient history.
      /// </summary>
      private Guid m_id = Guid.Empty;

      /// <summary>
      /// Previous conditions.
      /// </summary>
      private string m_conditions = string.Empty;

      /// <summary>
      /// Medications that the patient is taking.
      /// </summary>
      private string m_medications = string.Empty;

      /// <summary>
      /// Allergies that the patient might suffer from.
      /// </summary>
      private string m_allergies = string.Empty;

      /// <summary>
      /// The physicians the patient is/has visited.
      /// </summary>
      private string m_physicians = string.Empty;

      #endregion

      #region properties

      /// <summary>
      /// Gets or sets the id.
      /// </summary>
      public Guid Id
      {
        get { return m_id; }
        set { m_id = value; }
      } // Id


      /// <summary>
      /// Gets or sets the pre-existing conditions.
      /// </summary>
      public string Conditions
      {
        get { return m_conditions; }
        set { m_conditions = value; }
      } // Conditions


      /// <summary>
      /// Gets or sets the medications.
      /// </summary>
      public string Medications
      {
        get { return m_medications; }
        set { m_medications = value; }
      } // Medications


      /// <summary>
      /// Gets or sets the Allergies.
      /// </summary>
      public string Allergies
      {
        get { return m_allergies; }
        set { m_allergies = value; }
      } // Allergies


      /// <summary>
      /// Gets or sets the physicians the patient is/has seen.
      /// </summary>
      public string Physicians
      {
        get { return m_physicians; }
        set { m_physicians = value; }
      } // Physicians

      #endregion

    } // class PatientHistory

    #endregion

    #region fields

    /// <summary>
    /// The patient history attached to the appointment.
    /// </summary>
    private PatientHistory m_patientHistory = new PatientHistory();

    /// <summary>
    /// The appointment id.
    /// </summary>
    private Guid m_id = Guid.Empty;

    /// <summary>
    /// The name.
    /// </summary>
    private string m_name = string.Empty;

    /// <summary>
    /// The address.
    /// </summary>
    private string m_addess = string.Empty;

    /// <summary>
    /// The city.
    /// </summary>
    private string m_city = string.Empty;

    /// <summary>
    /// The state.
    /// </summary>
    private string m_state = string.Empty;

    /// <summary>
    /// The zip code.
    /// </summary>
    private string m_zipCode = string.Empty;

    /// <summary>
    /// The patient's birthdate.
    /// </summary>
    private DateTimeOffset m_birthdate = DateTimeOffset.Now;

    /// <summary>
    /// Is this the patient's first visit?
    /// </summary>
    private bool m_isNewPatient = true;

    /// <summary>
    /// The insurance provider.
    /// </summary>
    private string m_insuranceProvider = string.Empty;

    /// <summary>
    /// The member number.
    /// </summary>
    private string m_memberNumber = string.Empty;

    /// <summary>
    /// The appointment date.
    /// </summary>
    private DateTimeOffset m_appointmentDate = DateTimeOffset.Now;

    /// <summary>
    /// The reason for the appointment.
    /// </summary>
    private string m_reasonForAppointment = string.Empty;

    #endregion

    #region construction

    /// <summary>
    /// Constructor.
    /// </summary>
    public Appointment()
    {
      // Both the appointment and it's child needs to have the same id to link in the database.
      Guid myId = Guid.NewGuid();

      Id = myId;
      m_patientHistory.Id = myId;
    }

    #endregion

    #region properties

    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    public Guid Id
    {
      get { return m_id; }
      set { m_id = value; }
    } // Id


    /// <summary>
    /// Gets the patient's history.
    /// </summary>
    public PatientHistory PatientsHistory
    {
      get { return m_patientHistory; }
      set { m_patientHistory = value; }
    } // PatientsHistory


    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    [Required]
    public string Name
    {
      get { return m_name; }
      set { m_name = value; }
    } // Name 


    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    [Required]
    public string Address
    {
      get { return m_addess; }
      set { m_addess = value; }
    } // Address
    

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    [Required]
    public string City
    {
      get { return m_city; }
      set { m_city = value; }
    } // City


    /// <summary>
    /// Gets or sets the state.
    /// </summary>
    [Required]
    public string State
    {
      get { return m_state; }
      set {m_state = value; }
    } // State


    /// <summary>
    /// Gets or sets the zip code.
    /// </summary>
    [Required]
    public string ZipCode
    {
      get { return m_zipCode; }
      set { m_zipCode = value; }
    } // ZipCode


    /// <summary>
    /// Is this a new patient.
    /// </summary>
    public bool IsNewPatient
    {
      get { return m_isNewPatient; }
      set { m_isNewPatient = value; }
    } // IsNewPatient


    /// <summary>
    /// Gets a string representation of if this is a new patient.
    /// </summary>
    public string NewPatient
    {
      get
      {
        if (IsNewPatient) return "Yes";
        else return "No";
      }
    } // NewPatient


    /// <summary>
    /// Gets or sets the birthdate.
    /// </summary>
    public DateTimeOffset Birthdate
    {
      get { return m_birthdate; }
      set { m_birthdate = value; }
    } // Birthdate


    /// <summary>
    /// Gets or sets the insurance provider.
    /// </summary>
    public string InsuranceProvider
    {
      get { return m_insuranceProvider; }
      set { m_insuranceProvider = value; }
    } // InsuranceProvider


    /// <summary>
    /// Gets or sets the member number
    /// </summary>
    [Required]
    public string MemberNumber
    {
      get { return m_memberNumber; }
      set { m_memberNumber = value; }
    } // MemberNumber


    /// <summary>
    /// Gets or sets the appointment date.
    /// </summary>
    public DateTimeOffset AppointmentDate
    {
      get { return m_appointmentDate; }
      set { m_appointmentDate = value; }
    } // AppointmentDate


    /// <summary>
    /// Gets or sets the reason for the appointment.
    /// </summary>
    [Required]
    public string ReasonForAppointment
    {
      get { return m_reasonForAppointment; }
      set { m_reasonForAppointment = value; }
    } // ReasonForAppointment

    #endregion

    #region methods

    /// <summary>
    /// Get the list of insurance providers.
    /// </summary>
    /// <returns></returns>
    public static SelectListItem[] GetInsuranceProviders()
    {
      List<SelectListItem> items = new List<SelectListItem>();
      foreach(string name in Enum.GetNames(typeof(InsuranceProviders)))
      {
        items.Add(new SelectListItem() { Text = name, Value = name });
      }

      return items.ToArray();
    } // GetInsuranceProviders()

    #endregion

  } // class Appointment
} // namespace kchalupa.Web.HeartMedicalCenter.Models
