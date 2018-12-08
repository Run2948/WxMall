using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cms.Common
{
    public class DTEnums
    {
        /// <summary>
        /// 统一管理操作枚举
        /// </summary>
        public enum ActionEnum
        {
            /// <summary>
            /// 所有
            /// </summary>
            All,
            /// <summary>
            /// 显示
            /// </summary>
            Show,
            /// <summary>
            /// 查看
            /// </summary>
            View,
            /// <summary>
            /// 添加
            /// </summary>
            Add,
            /// <summary>
            /// 修改
            /// </summary>
            Edit,
            /// <summary>
            /// 删除
            /// </summary>
            Delete,
            /// <summary>
            /// 审核
            /// </summary>
            Audit,
            /// <summary>
            /// 回复
            /// </summary>
            Reply,
            /// <summary>
            /// 确认
            /// </summary>
            Confirm,
            /// <summary>
            /// 取消
            /// </summary>
            Cancel,
            /// <summary>
            /// 作废
            /// </summary>
            Invalid,
            /// <summary>
            /// 生成
            /// </summary>
            Build,
            /// <summary>
            /// 安装
            /// </summary>
            Instal,
            /// <summary>
            /// 卸载
            /// </summary>
            UnLoad,
            /// <summary>
            /// 登录
            /// </summary>
            Login,
            /// <summary>
            /// 备份
            /// </summary>
            Back,
            /// <summary>
            /// 还原
            /// </summary>
            Restore,
            /// <summary>
            /// 替换
            /// </summary>
            Replace
        }

        /// <summary>
        /// 系统导航菜单类别枚举
        /// </summary>
        public enum NavigationEnum
        {
            /// <summary>
            /// 系统后台菜单
            /// </summary>
            System,
            /// <summary>
            /// 会员中心导航
            /// </summary>
            Users,
            /// <summary>
            /// 网站主导航
            /// </summary>
            WebSite
        }

        /// <summary>
        /// 用户生成码枚举
        /// </summary>
        public enum CodeEnum
        {
            /// <summary>
            /// 注册验证
            /// </summary>
            RegVerify,
            /// <summary>
            /// 邀请注册
            /// </summary>
            Register,
            /// <summary>
            /// 取回密码
            /// </summary>
            Password
        }

        /// <summary>
        /// 金额类型枚举
        /// </summary>
        public enum AmountTypeEnum
        {
            /// <summary>
            /// 系统赠送
            /// </summary>
            SysGive,
            /// <summary>
            /// 在线充值
            /// </summary>
            Recharge,
            /// <summary>
            /// 用户消费
            /// </summary>
            Consumption,
            /// <summary>
            /// 购买商品
            /// </summary>
            BuyGoods,
            /// <summary>
            /// 积分兑换
            /// </summary>
            Convert
        }
    }
}
