/**  版本信息模板在安装目录下，可自行修改。
* C_model.cs
*
* 功 能： N/A
* 类 名： C_model
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/28 10:48:56   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Cms.Model
{
	/// <summary>
	/// C_model:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_model
	{
		public C_model()
		{}
		#region Model
		private int _modelid;
		private string _modelname;
		private string _modelvalue;
		/// <summary>
		/// 
		/// </summary>
		public int modelId
		{
			set{ _modelid=value;}
			get{return _modelid;}
		}
		/// <summary>
		/// 模型名称
		/// </summary>
		public string modelName
		{
			set{ _modelname=value;}
			get{return _modelname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string modelValue
		{
			set{ _modelvalue=value;}
			get{return _modelvalue;}
		}
		#endregion Model

	}
}

