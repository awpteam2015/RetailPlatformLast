using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoft.Rom.Application.Dto.PermissionManager
{
    /// <summary>
    /// 功能菜单列表
    /// </summary>
    public class MenuDto
    {
        public MenuDto()
        {
            ChildMenuList = new List<MenuDto>();
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 菜单Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int RankId { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public IList<MenuDto> ChildMenuList { get; set; }
    }
}
