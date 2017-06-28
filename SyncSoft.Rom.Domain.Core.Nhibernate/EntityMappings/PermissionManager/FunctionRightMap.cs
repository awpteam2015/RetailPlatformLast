using FluentNHibernate.Mapping;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;
using SyncSoft.Rom.ProjectConfig.SysManager.Config;

namespace SyncSoft.Rom.Domain.Core.Nhibernate.EntityMappings.PermissionManager
{
    public sealed class FunctionRightMap : ClassMap<FunctionRight>
    {
        public FunctionRightMap()
        {
            Table("pb_functionright");
            Id(p => p.FunctionRightId).GeneratedBy
                .Custom<SequenceGenerator>(p =>p.AddParam("SelectKey", "select to_char("+ SysConfig.GetDataBaseQz() + "SEQ_FUNCTIONRIGHTID.Nextval) as value from dual")); 
            Map(p => p.CreateDateTime);
            Map(p => p.RightTag);
            Map(p => p.RightTagId);
            Map(p => p.FunctionId);
            Map(p => p.OrderId);
            Map(p => p.FunctinoRightUrl);
            References(p => p.ModuleFunction)
                .LazyLoad()
                .Not.Insert()
                .Not.Update()
                .Column("FunctionId");

            //HasMany(p => p.UserPopedoms)
            //    .AsSet()
            //    .LazyLoad()
            //    .Fetch.Join()
            //    .Cascade.Delete().Inverse()
            //    .KeyColumn("FunctionRightId");

            //HasMany(p => p.RolePopedoms)
            //    .AsSet()
            //    .LazyLoad()
            //    .Fetch.Join()
            //    .Cascade.Delete().Inverse()
            //    .KeyColumn("FunctionRightId");
        }
    }
}
