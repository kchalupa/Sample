using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Ninject;
using kchalupa.Web.HeartMedicalCenter;

namespace kchalupa.Web.HeartMedicalCenter
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      RouteConfig.RegisterRoutes(RouteTable.Routes);

      NinjectWebCommon.RegisterService(new StandardKernel());
    }
  }
}
