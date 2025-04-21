namespace TMom.Infrastructure.Helper
{
    /// <summary>
    /// 泛型递归求树形结构
    /// </summary>
    public static class RecursionHelper
    {
        public static void LoopToAppendChildren(List<PermissionTree> all, PermissionTree curItem, int pid, bool needbtn)
        {
            var subItems = all.Where(ee => ee.Pid == curItem.value).ToList();

            var btnItems = subItems.Where(ss => ss.isbtn == true).ToList();
            if (subItems.Count > 0)
            {
                curItem.btns = new List<PermissionTree>();
                curItem.btns.AddRange(btnItems);
            }
            else
            {
                curItem.btns = null;
            }

            if (!needbtn)
            {
                subItems = subItems.Where(ss => ss.isbtn == false).ToList();
            }
            if (subItems.Count > 0)
            {
                curItem.children = new List<PermissionTree>();
                curItem.children.AddRange(subItems);
            }
            else
            {
                curItem.children = null;
            }

            if (curItem.isbtn)
            {
                //curItem.label += "按钮";
            }

            foreach (var subItem in subItems)
            {
                if (subItem.value == pid && pid > 0)
                {
                    //subItem.disabled = true;//禁用当前节点
                }
                LoopToAppendChildren(all, subItem, pid, needbtn);
            }
        }

        public static void LoopRouteMenuAppendChildren(List<SideBarRouteTree> all, SideBarRouteTree curItem)
        {
            var subItems = all.Where(ee => ee.pid == curItem.id).ToList();

            if (subItems.Count > 0)
            {
                curItem.children = new List<SideBarRouteTree>();
                curItem.children.AddRange(subItems);
            }
            else
            {
                curItem.children = null;
            }

            foreach (var subItem in subItems)
            {
                LoopRouteMenuAppendChildren(all, subItem);
            }
        }

        public static void LoopNaviBarAppendChildren(List<NavigationBar> all, NavigationBar curItem)
        {
            var subItems = all.Where(ee => ee.pid == curItem.id).ToList();

            if (subItems.Count > 0)
            {
                curItem.children = new List<NavigationBar>();
                curItem.children.AddRange(subItems);
            }
            else
            {
                curItem.children = null;
            }

            foreach (var subItem in subItems)
            {
                LoopNaviBarAppendChildren(all, subItem);
            }
        }

        /// <summary>
        /// 泛型递归计算树形结构(注意: Children字段属性不要有{ get; set; })
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="all">源数据</param>
        /// <param name="curItem">根(最后的结果值)</param>
        /// <param name="topParentIsNull">顶级父元素是否为null</param>
        /// <param name="parentIdName">父元素字段, 默认：ParentId</param>
        /// <param name="idName">子元素字段, 默认：Id</param>
        /// <param name="childrenName">子元素集合名称, 默认：children</param>
        public static void LoopToAppendChildrenT<T>(List<T> all, T curItem, bool topParentIsNull = true, string parentIdName = "ParentId", string idName = "Id"
            , string childrenName = "Children")
        {
            var subItems = new List<T>();
            if (topParentIsNull)
            {
                subItems = all.Where(x => x.GetType().GetProperty(parentIdName).GetValue(x, null) == null).ToList();
            }
            else
            {
                subItems = all.Where(ee => ee.GetType().GetProperty(parentIdName).GetValue(ee, null)?.ToString()
                == curItem.GetType().GetProperty(idName).GetValue(curItem, null)?.ToString())
                    .ToList();
            }

            if (subItems.Count > 0)
            {
                var children = typeof(T).GetField(childrenName);
                if (children == null) throw new Exception($"类: {typeof(T).Name} 中没有字段: {childrenName}, 请添加! eg: public int Id");
                children.SetValue(curItem, subItems);
            }
            foreach (var subItem in subItems)
            {
                LoopToAppendChildrenT(all, subItem, false);
            }
        }

        /// <summary>
        /// 获取父Id下的所有子Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="all">源数据</param>
        /// <param name="curId">父Id</param>
        /// <param name="allIds">返回的所有子Id列表</param>
        /// <param name="parentIdName">父元素字段, 默认：ParentId</param>
        /// <param name="idName">子元素字段, 默认：Id</param>
        public static void LoopIdToList<T>(List<T> all, int curId, List<int> allIds, string parentIdName = "ParentId", string idName = "Id")
        {
            var subItems = all.Where(x => x.GetType().GetProperty(parentIdName).GetValue(x, null).ObjToInt() == curId)
                              .ToList();
            if (subItems != null && subItems.Any())
            {
                var subIds = subItems.Select(x => x.GetType().GetProperty(idName).GetValue(x, null).ObjToInt());
                allIds.AddRange(subIds);

                foreach (var item in subItems)
                {
                    LoopIdToList(subItems, item.GetType().GetProperty(idName).GetValue(item, null).ObjToInt(), allIds);
                }
            }
        }
    }

    #region 类

    public class PermissionTree
    {
        public int value { get; set; }
        public int Pid { get; set; }
        public string label { get; set; }
        public int order { get; set; }
        public bool isbtn { get; set; }
        public bool disabled { get; set; }
        public List<PermissionTree> children { get; set; }
        public List<PermissionTree> btns { get; set; }
    }

    public class NavigationBar
    {
        public int id { get; set; }
        public int pid { get; set; }
        public int order { get; set; }
        public string name { get; set; }
        public bool IsHide { get; set; } = false;
        public bool IsButton { get; set; } = false;
        public string path { get; set; }
        public string Func { get; set; }
        public string iconCls { get; set; }
        public NavigationBarMeta meta { get; set; }
        public List<NavigationBar> children { get; set; }
    }

    public class NavigationBarMeta
    {
        public string title { get; set; }
        public bool requireAuth { get; set; } = true;
        public bool NoTabPage { get; set; } = false;
        public bool keepAlive { get; set; } = false;
    }

    public class SideBarRouteTree
    {
        public int id { get; set; }

        /// <summary>
        /// 父元素Id
        /// </summary>
        public int? pid { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// 路由跳转路径
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 其他信息
        /// </summary>
        public MetaInfo meta { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int orderSort { get; set; }

        /// <summary>
        /// 子菜单数据
        /// </summary>
        public List<SideBarRouteTree> children { get; set; }
    }

    public class MetaInfo
    {
        /// <summary>
        /// 菜单标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 页面权限列表
        /// </summary>
        public List<string> perms { get; set; } = new List<string>();

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 保持激活状态
        /// </summary>
        public bool keepAlive { get; set; }

        public List<string> keyPath { get; set; } = new List<string>();
    }

    #endregion 类
}