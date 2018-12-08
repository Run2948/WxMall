using Cms.API.Payment.wxpay.comm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Cms.API.Payment.wxpay
{
    public class MD5SignUtil
    {
        public static String Sign(String content, String key)
        {
            String signStr = "";

            if ("" == key)
            {
                throw new SDKRuntimeException("财付通签名key不能为空！");
            }
            if ("" == content)
            {
                throw new SDKRuntimeException("财付通签名内容不能为空");
            }
            signStr = content + "&key=" + key;

            return MD5Util.MD5(signStr).ToUpper();

        }

        public static bool VerifySignature(String content, String sign,
                String md5Key)
        {
            String signStr = content + "&key=" + md5Key;
            String calculateSign = MD5Util.MD5(signStr).ToUpper();
            String tenpaySign = sign.ToUpper();
            return (calculateSign == tenpaySign);
        }
    }
}
