using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Ninject;
using Moq;

namespace kchalupa.Web.HeartMedicalCenter.Infrastructure
{
  /// <summary>
  /// Use ninject as default dependency resolver.
  /// </summary>
  public class NinjectDependencyResolver : IDependencyResolver
  {

    #region fields

    /// <summary>
    /// The dependency resolver kernel.
    /// </summary>
    private IKernel m_kernel = null;

    #endregion

    #region construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="kernel"></param>
    public NinjectDependencyResolver(IKernel kernel)
    {
      m_kernel = kernel;
      AddBindings();
    } // NinjectDependencyResolver( kernel )

    #endregion

    #region methods

    /// <summary>
    /// Try to get the server for the client.
    /// </summary>
    /// <param name="selectedType"></param>
    /// <returns></returns>
    public object GetService(Type selectedType)
    {
      return m_kernel.TryGet(selectedType);
    } // GetService( selectedType )


    /// <summary>
    /// Get all possible servers for the specified type.
    /// </summary>
    /// <param name="selectedType"></param>
    /// <returns></returns>
    public IEnumerable<object> GetServices(Type selectedType)
    {
      return m_kernel.GetAll(selectedType);
    } // GetServices( selecedType )


    /// <summary>
    /// Add the bindings.
    /// </summary>
    private void AddBindings()
    {
      // Add the bindings.
    } // AddBindings()

    #endregion

  } // class NinjectDependencyResolver
} // namespace kchalupa.Web.HeartMedicalCenter.Infrastructure
