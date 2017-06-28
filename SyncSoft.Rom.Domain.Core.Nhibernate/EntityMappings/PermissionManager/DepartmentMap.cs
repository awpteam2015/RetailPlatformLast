using FluentNHibernate.Mapping;
using NHibernate.Id;
using NHibernate.Mapping;
using NHibernate.Type;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;
using SyncSoft.Rom.ProjectConfig.PermissionManager.Enum;
using SyncSoft.Rom.ProjectConfig.SysManager.Config;

namespace SyncSoft.Rom.Domain.Core.Nhibernate.EntityMappings.PermissionManager
{
     

    public sealed class DepartmentMap : OmsBaseMap<Department>
    {
        public DepartmentMap()
        {
            Table("pb_department");
            Id(p => p.DepartmentId).Unique().GeneratedBy
                .Custom<SequenceGenerator>(p =>p.AddParam("SelectKey", "select to_char("+SysConfig.GetDataBaseQz()+"SEQ_DEPARTMENTID.Nextval) as value from dual"));
            Map(p => p.DepartmentCode);
            Map(p => p.Area);
            Map(p => p.CreateTime);
            Map(p => p.CustomerCode);
            Map(p => p.DefaultSellerCode);
            Map(p => p.DepartmentName);
            Map(p => p.DepartmentType).CustomType<EnumStringType<DpartmentTypeEnum>>();
            Map(p => p.Fax);
            Map(p => p.ParentDepartmentCode);
            Map(p => p.Remark);
            Map(p => p.SapCompanyCode);
            Map(p => p.SellChannel);
            Map(p => p.Tel);
            Map(p => p.Province);
            Map(p => p.City);
            Map(p => p.Country);
            Map(p => p.Interchangeplacename);
            Map(p => p.Interchangeplacecode);
            Map(p => p.Address);
            Map(p => p.Xpprintaddress);
            Map(p => p.Xsprintaddress);
            Map(p => p.A4printaddress);
            Map(p => p.JDTel);

            Map(p => p.IsInvalid);
            //Map(p => p.SiteCode).CustomType<EnumStringType<SiteCodeEnum>>();
            Map(p => p.Setcarddiscountemail);
            Map(p => p.Istm);
            Map(p => p.Isprintmeanwhile);
            Map(p => p.Storeuploadlistbuttons);
            Map(p => p.StoreDeliverylocation);
            Map(p => p.IsWarehousetm);
            Map(p => p.Reservoirarea);
            Map(p => p.Deliverystorage);
            Map(p => p.Deliverylocation);
            Map(p => p.Rank);

            //References(p => p.ParentDepartment)
            //    .LazyLoad()
            //    .Not.Insert()
            //    .Not.Update()
            //    .Column("DepartmentCode");

            HasMany(p => p.ChildDepartmentList)
                .AsSet()
                .LazyLoad()
                .Cascade.Delete().Inverse()
                .NotFound.Ignore()
                .KeyColumn("ParentDepartmentCode")
                .PropertyRef("DepartmentCode");

            //HasManyToMany(p => p.Users)
            //    .AsSet()
            //    .LazyLoad()
            //    .NotFound.Ignore()
            //    .ParentKeyColumn("DepartmentCode")
            //    .ChildKeyColumn("LoginId")
            //    .PropertyRef("DepartmentCode")
            //    .Table(DataBaseConfig.GetQZ()+"pb_departmentuser");
        }
    }
}
