using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection service);
    }
}
