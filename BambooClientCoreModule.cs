using Abp.Modules;
using Abp.Reflection.Extensions;

namespace AbpClient.Core
{
    public class AbpClientCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpClientCoreModule).GetAssembly());
        }
    }
}