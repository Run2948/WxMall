using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cms.Common;

namespace Cms.BLL
{
    public partial class siteconfig
    {

        private readonly SQLServerDAL.siteconfig dal=new SQLServerDAL.siteconfig();
        /// <summary>
        ///  读取配置文件
        /// </summary>
        public Model.siteconfig loadConfig()
        {
            Model.siteconfig model = CacheHelper.Get<Model.siteconfig>(CKeys.CACHE_SITE_CONFIG);
            if (model == null)
            {
                CacheHelper.Insert(CKeys.CACHE_SITE_CONFIG, dal.loadConfig(Utils.GetXmlMapPath(CKeys.FILE_SITE_XML_CONFING)),
                    Utils.GetXmlMapPath(CKeys.FILE_SITE_XML_CONFING));
                model = CacheHelper.Get<Model.siteconfig>(CKeys.CACHE_SITE_CONFIG);
            }
            return model;
        }

        /// <summary>
        ///  保存配置文件
        /// </summary>
        public Model.siteconfig saveConifg(Model.siteconfig model)
        {
            return dal.saveConifg(model, Utils.GetXmlMapPath(CKeys.FILE_SITE_XML_CONFING));
        }

    }
}
