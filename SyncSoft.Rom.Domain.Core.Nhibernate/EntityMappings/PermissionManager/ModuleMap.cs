using FluentNHibernate.Mapping;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;
using SyncSoft.Rom.ProjectConfig.SysManager.Config;

namespace SyncSoft.Rom.Domain.Core.Nhibernate.EntityMappings.PermissionManager
{
    public sealed class ModuleMap: OmsBaseMap<Module>
    {
        public ModuleMap()
        {
            Table("pb_module");
            Id(p => p.ModuleId).Unique().GeneratedBy
                .Custom<SequenceGenerator>(p =>p.AddParam("SelectKey", "select to_char("+ SysConfig.GetDataBaseQz() + "SEQ_MODULEID.Nextval) as value from dual")); 
            Map(p => p.ModuleLevel);
            Map(p => p.ModuleName);
            Map(p => p.OrderId);
            Map(p => p.ParentId);
            Map(p => p.Remark);
         //   Map(p => p.SiteCodes);

            HasMany(p => p.ModuleFunctions)
                .AsSet()
                .LazyLoad()
                .Fetch.Join()
                .Cascade.Delete().Inverse()
                .KeyColumn("ModuleId");
        }
    }
}
