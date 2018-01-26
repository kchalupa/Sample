using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Ninject;

using kchalupa.Web.HeartMedicalCenter.Infrastructure;

namespace kchalupa.Web.HeartMedicalCenter
{
  public class NinjectWebCommon
  {

    #region methods

    /// <summary>
    /// Register servies.
    /// </summary>
    public static void RegisterService(IKernel kernel)
    {
      DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
    }

    #endregion

  }
}