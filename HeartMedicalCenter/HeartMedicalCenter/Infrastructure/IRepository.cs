using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using kchalupa.Web.HeartMedicalCenter.Models;

namespace kchalupa.Web.HeartMedicalCenter.Infrastructure
{
  /// <summary>
  /// An appointments repository.
  /// </summary>
  public interface IRepository<Value>
  {

    #region properties

    /// <summary>
    /// Gets the list of appointments.
    /// </summary>
    Value[] Items
    {
      get;
    } // Appointments

    #endregion

    #region methods

    /// <summary>
    /// Add a new item to the collection.
    /// </summary>
    /// <param name="item"></param>
    void Add(Value item);

    /// <summary>
    /// Updates the collection with new information.
    /// </summary>
    /// <param name="item"></param>
    void Update(Value item);

    /// <summary>
    /// Deletes an item from the collection.
    /// </summary>
    /// <param name="item"></param>
    void Delete(Value item);

    #endregion

  } // interface IRepository
} // namespace kchalupa.Web.HeartMedicalCenter.Infrastructure