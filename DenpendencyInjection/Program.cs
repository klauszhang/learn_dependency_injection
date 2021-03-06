﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DenpendencyInjection
{
  class Program
  {
    static void Main(string[] args)
    {
      using (var kernel=new StandardKernel())
      {
        kernel.Bind<ILogger>().To<ConsoleLogger>().InSingletonScope();
        // when bind to multiple class use:
        // kernel.Bind<IService1,IService2>().To<MyService>();
        kernel.Bind<MailServerConfig>().ToSelf().InSingletonScope();
        var mailService = kernel.Get<MailService>();
        mailService.SendEmail("someone@domain.com", "Hi", null);
      }
    }
  }
}