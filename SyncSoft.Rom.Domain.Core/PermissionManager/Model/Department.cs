using System;
using System.Collections.Generic;
using CommonFrameWork.Domain.Entities;
using SyncSoft.Rom.ProjectConfig.PermissionManager.Enum;


namespace SyncSoft.Rom.Domain.Core.PermissionManager.Model
{
    /// <summary>
    /// 部门
    /// </summary>
    [Serializable]
    public class Department : IAggregateRoot<String>
    {
        public virtual string PkId
        {
            get { return DepartmentId;  }
            set { DepartmentId = value; }
        }

        ///<sumary>
        /// 部门Id
        ///</sumary>
        public virtual string DepartmentId { get; set; }

        ///<sumary>
        /// 部门代码
        ///</sumary>
        public virtual string DepartmentCode { get; set; }

        ///<sumary>
        /// 部门名称
        ///</sumary>
        public virtual string DepartmentName { get; set; }

        ///<sumary>
        /// 默认的一次性客户代码
        ///</sumary>
        public virtual string CustomerCode { get; set; }

        ///<sumary>
        /// 创建时间
        ///</sumary>
        public virtual DateTime? CreateTime { get; set; }

        ///<sumary>
        /// 备注
        ///</sumary>
        public virtual string Remark { get; set; }

        ///<sumary>
        /// 默认销售顾问代码
        ///</sumary>
        public virtual string DefaultSellerCode { get; set; }

        /// <summary>
        /// 公司代码 分公司
        /// </summary>
        public virtual string SapCompanyCode { get; set; }

        /// <summary>
        /// 销售渠道类型，H1表示零售，H2表示渠道
        /// </summary>
        public virtual string SellChannel { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public virtual string Area { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual string Tel { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public virtual string Fax { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public virtual string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public virtual string City { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public virtual string Country { get; set; }

        /// <summary>
        /// 部门类型
        /// </summary>
        public virtual DpartmentTypeEnum DepartmentType { get; set; }

        /// <summary>
        /// 上级部门编号
        /// </summary>
        public virtual string ParentDepartmentCode { get; set; }

        /// <summary>
        /// 上级部门
        /// </summary>
        public virtual Department ParentDepartment { get; set; }

        /// <summary>
        /// 子部门
        /// </summary>
        public virtual ISet<Department> ChildDepartmentList { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual ISet<User> Users { get; set; }

        /// <summary>
        /// 门店对应中转仓
        /// </summary>
        public virtual String Interchangeplacecode { get; set; }

        public virtual String Interchangeplacename { get; set; }

        /// <summary>
        /// 小票打印机地址
        /// </summary>
        public virtual String Xpprintaddress { get; set; }

        /// <summary>
        /// 销售单打印地址
        /// </summary>
        public virtual String Xsprintaddress { get; set; }

        /// <summary>
        /// A4打印地址
        /// </summary>
        public virtual String A4printaddress { get; set; }

        /// <summary>
        /// 是否作废
        /// </summary>  
        public virtual int IsInvalid { get; set; }

        /// <summary>
        /// 监督电话
        /// </summary>
        public virtual String JDTel { get; set; }

        /// <summary>
        /// 是否特卖
        /// </summary>
        public virtual int Istm { get; set; }



        /// <summary>
        /// 开卡邮箱
        /// </summary>
        public virtual String Setcarddiscountemail { get; set; }


        /// <summary>
        /// 打印销售单同时打印小票
        /// </summary>
        public virtual int Isprintmeanwhile { get; set; }

        /// <summary>
        /// 1,2,3(1 text 2 excel 3 webservice )
        /// </summary>
        public virtual String Storeuploadlistbuttons { get; set; }

        /// <summary>
        /// 门店库存地点
        /// </summary>
        public virtual string StoreDeliverylocation { get; set; }

        /// <summary>
        /// 是否中转仓特卖
        /// </summary>
        public virtual int IsWarehousetm { get; set; }


        /// <summary>
        /// 中转仓特卖库存地点
        /// </summary>
        /// 
        public virtual string Deliverylocation { get; set; }
        /// <summary>
        /// 中转仓特卖库位
        /// </summary>
        public virtual string Reservoirarea { get; set; }

        /// <summary>
        /// 中转仓特卖发货地点
        /// </summary>
        public virtual string Deliverystorage { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public virtual int? Rank { get; set; }

    }

   

    public class DepartmentTree
    {
        ///<sumary>
        /// 部门代码
        ///</sumary>
        public virtual string DepartmentCode { get; set; }

        ///<sumary>
        /// 部门名称
        ///</sumary>
        public virtual string DepartmentName { get; set; }

        /// <summary>
        /// 部门类型
        /// </summary>
        public virtual DpartmentTypeEnum DepartmentType { get; set; }

        /// <summary>
        /// 上级部门编号
        /// </summary>
        public virtual string ParentDepartmentCode { get; set; }
        /// <summary>
        /// 层级
        /// </summary>
        public virtual int Level { get; set; }

        /// <summary>
        /// 是否作废
        /// </summary>  
        public virtual int IsInvalid { get; set; }
    }

    public static class DpartmentTypeClass
    {
        private static readonly IDictionary<DpartmentTypeEnum, string> dic = new Dictionary<DpartmentTypeEnum, string>();

        static DpartmentTypeClass()
        {
            dic.Add(DpartmentTypeEnum.Company, "公司");
            dic.Add(DpartmentTypeEnum.Area, "地区");
            dic.Add(DpartmentTypeEnum.Channel, "渠道");
            dic.Add(DpartmentTypeEnum.Store, "门店");
            dic.Add(DpartmentTypeEnum.Shop, "网店");
            dic.Add(DpartmentTypeEnum.CustomerService, "客服");
            dic.Add(DpartmentTypeEnum.HeadOffice, "总部");
        }

        /// <summary>
        /// 获取门店类型中文名
        /// </summary>
        /// <param name="dte"></param>
        /// <returns></returns>
        public static string GetDpartmentType(this DpartmentTypeEnum dte)
        {
            if (!dic.ContainsKey(dte)) return "";
            return dic[dte];
        }
    }
}
