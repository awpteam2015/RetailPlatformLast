using FluentNHibernate.Mapping;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;
using SyncSoft.Rom.ProjectConfig.SysManager.Config;

namespace SyncSoft.Rom.Domain.Core.Nhibernate.EntityMappings.PermissionManager
{
    public sealed class UserMap : OmsBaseMap<User>
    {
        public UserMap()
        {
            Table("pb_user");
            Id(p => p.LoginId).Unique().UnsavedValue(null);
            Map(p => p.Password);
            Map(p => p.UserName);
            Map(p => p.NickName);
            Map(p => p.ExtPhoneNo);
            Map(p => p.Email);
            Map(p => p.Remark);
            Map(p => p.Disabled);
            Map(p => p.SellerCode);
            Map(p => p.LoginIp).Column("RegisterIp");
            Map(p => p.CardId);
            Map(p => p.CreateTime);
            Map(p => p.DepartmentCodeDefault).Column("DepartmentCode");
            Map(p => p.JobNumber).Not.Update().Not.Insert();
            Map(p => p.CostCenterCode).Not.Update().Not.Insert();
            Map(p => p.Position);
            Map(p => p.PositionCode);
        }
    }
}
