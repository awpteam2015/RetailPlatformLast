using FluentNHibernate.Mapping;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;
using SyncSoft.Rom.ProjectConfig.SysManager.Config;

namespace SyncSoft.Rom.Domain.Core.Nhibernate.EntityMappings.PermissionManager
{
    public sealed class ModuleFunctionMap : ClassMap<ModuleFunction>
    {
        public ModuleFunctionMap()
        {
            Table("pb_module_function");
            Id(p => p.FunctionId).Unique().GeneratedBy
                .Custom<SequenceGenerator>(p => p.AddParam("SelectKey", "select to_char("+ SysConfig.GetDataBaseQz() + "SEQ_FUNCTIONID.Nextval) as value from dual")); 
            Map(p => p.Disabled);
            Map(p => p.FunctionName);
            Map(p => p.FunctionUrl);
            Map(p => p.OrderId);
            Map(p => p.Remark);
            Map(p => p.ModuleId);

            Map(p => p.Area);
            Map(p => p.Controller);
            Map(p => p.Action);
            Map(p => p.FunctionUrl2);
            // Map(p => p.SiteCodes);

            References(p => p.Module)
                .LazyLoad()
                .Not.Insert()
                .Not.Update()
                .Column("ModuleId");

            HasMany(p => p.FunctionRights)
                .AsSet()
                .LazyLoad()
                .Fetch.Join()
                .Cascade.Delete().Inverse()
                .KeyColumn("FunctionId");
        }
    }
}
