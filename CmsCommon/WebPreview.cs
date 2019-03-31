using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Cms.Common
{
    /// <summary>  
    /// 供Asp.Net直接调用的包装类  
    /// 作者：Kai.Ma http://kaima.cnblogs.com  
    /// </summary>  
    public class WebPreview
    {

        private Uri _uri = null;
        private Exception _ex = null;
        private Bitmap _bitmap = null;
        private int _timeout = 30 * 1000;//设置线程超时时长  
        private int _width = 200;//缩图宽  
        private int _height = 150;//缩图高  
        private bool _fullPage = true;

        private WebPreview(Uri uri)
            : this(uri, 30 * 1000, 200, 150, true)
        {

        }

        private WebPreview(Uri uri, int timeout, int width, int height, bool fullPage)
        {
            _uri = uri;
            _timeout = timeout;
            _width = width;
            _height = height;
            _fullPage = fullPage;
        }

        internal Bitmap GetWebPreview()
        {
            //Asp.Net引用Winform（类似ActiveX）控件，必须开单线程  
            Thread t = new Thread(new ParameterizedThreadStart(StaRun));
            t.SetApartmentState(ApartmentState.STA);
            t.Start(this);

            if (!t.Join(_timeout))
            {
                t.Abort();
                throw new TimeoutException();
            }

            if (_ex != null) throw _ex;
            if (_bitmap == null) throw new ExecutionEngineException();

            return _bitmap;
        }

        public static Bitmap GetWebPreview(Uri uri)
        {
            WebPreview wp = new WebPreview(uri);
            return wp.GetWebPreview();
        }
        public static Bitmap GetWebPreview(Uri uri, int timeout, int width, int height, bool fullPage)
        {
            WebPreview wp = new WebPreview(uri, timeout, width, height, fullPage);
            return wp.GetWebPreview();
        }

        /// <summary>  
        /// 为WebBrowser所开线程的启动入口函数，相当于Winform里面的Main()  
        /// </summary>  
        /// <param name="_wp"></param>  
        private static void StaRun(object _wp)
        {
            WebPreview wp = (WebPreview)_wp;
            try
            {
                WebPreviewBase wpb = new WebPreviewBase(wp._uri, wp._width, wp._height, wp._fullPage);
                wp._bitmap = wpb.GetWebPreview();
            }
            catch (Exception ex)
            {
                wp._ex = ex;
            }
        }
    }

    /// <summary>  
    /// 包装后的抓图基类。WebBrowser自带的BrawToBitmap不能抓到一些网站的图片，  
    /// 对于一些转向的网站会返回空白图片，所以采用原生的通过IViewObject接口  
    /// 取浏览器的图象，实现SNAP。感谢类库的作者“随飞”。  
    /// 原作者：随  飞 http://chinasf.cnblogs.com  
    /// 包装者：Kai.Ma http://kaima.cnblogs.com  
    /// </summary>  
    class WebPreviewBase : IDisposable
    {
        Uri _uri = new Uri("about:blank");//原始uri  
        int _thumbW = 1024;     //缩略图高度  
        int _thumbH = 768;      //缩略图宽度  
        WebBrowser _wb;         //浏览器对象  
        bool _fullpage = false; //是否抓取全图  


        public WebPreviewBase(Uri uri, int thumbW, int thumbH, bool fullpage)
        {
            _wb = new WebBrowser();
            _wb.ScriptErrorsSuppressed = true;
            //_wb.ScriptErrorsSuppressed = false;  
            _wb.ScrollBarsEnabled = false;
            _wb.Size = new Size(1024, 768);//浏览器分辨率为1024x768              
            _wb.NewWindow += new System.ComponentModel.CancelEventHandler(CancelEventHandler);
            _thumbW = thumbW;
            _thumbH = thumbH;
            _uri = uri;
        }
        /// <summary>  
        /// URI 地址  
        /// </summary>  
        public Uri Uri
        {
            get { return _uri; }
            set { _uri = value; }
        }
        /// <summary>  
        /// 缩略图宽度  
        /// </summary>  
        public int ThumbW
        {
            get { return _thumbW; }
            set { _thumbW = value; }
        }
        /// <summary>  
        /// 缩略图高度  
        /// </summary>  
        public int ThumbH
        {
            get { return _thumbH; }
            set { _thumbH = value; }
        }
        //防止弹窗  
        public void CancelEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
        /// <summary>  
        /// 初始化  
        /// </summary>  
        protected void InitComobject()
        {
            try
            {
                _wb.Navigate(this._uri);
                //因为没有窗体，所以必须如此  
                while (_wb.ReadyState != WebBrowserReadyState.Complete)
                {
                    //立即重绘  
                    Application.DoEvents();
                }
                //这句最好注释，不然网页上的动画都抓不到了  
                _wb.Stop();
                if (_wb.ActiveXInstance == null) throw new Exception("实例不能为空");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// 获取Web预览图  
        /// </summary>  
        /// <returns>Bitmap</returns>  
        public Bitmap GetWebPreview()
        {
            #region 调整图片高宽，并调整浏览器高宽适应图片高宽
            int w = _wb.Width;
            int h = _wb.Height;
            Size sz = _wb.Size;

            if (_fullpage)
            {
                h = _wb.Document.Body.ScrollRectangle.Height; // +SystemInformation.VerticalScrollBarWidth;  
                w = _wb.Document.Body.ScrollRectangle.Width; // +SystemInformation.HorizontalScrollBarHeight;  
            }

            // 最小宽度不能小于缩略图宽度  
            if (w < _thumbW)
                w = _thumbW;

            // 调整最小高度，充满浏览器  
            if (h < sz.Height)
                h = sz.Height;
            _wb.Size = new Size(w, h);
            #endregion

            try
            {
                InitComobject();
                //构造snapshot类，抓取浏览器ActiveX的图象  
                Snapshot snap = new Snapshot();
                Bitmap thumBitmap = snap.TakeSnapshot(_wb.ActiveXInstance, new Rectangle(0, 0, w, h));
                //调整图片大小，这里选择以宽度为标准，高度保持比例  
                thumBitmap = (Bitmap)ImageLibrary.ResizeImageToAFixedSize(thumBitmap, _thumbW, _thumbH, ImageLibrary.ScaleMode.W);
                return thumBitmap;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _wb.Dispose();
        }

    }


    #region WebPreview的类库
    /// <summary>  
    /// ActiveX 组件快照类  
    /// AcitveX 必须实现 IViewObject 接口  
    ///   
    /// 作者:随飞  
    /// http://chinasf.cnblogs.com  
    /// chinasf@hotmail.com  
    /// </summary>  
    class Snapshot
    {
        /// <summary>  
        /// 取快照  
        /// </summary>  
        /// <param name="pUnknown">Com 对象</param>  
        /// <param name="bmpRect">图象大小</param>  
        /// <returns></returns>  
        public Bitmap TakeSnapshot(object pUnknown, Rectangle bmpRect)
        {
            if (pUnknown == null)
                return null;
            //必须为com对象  
            if (!Marshal.IsComObject(pUnknown))
                return null;
            //IViewObject 接口  
            UnsafeNativeMethods.IViewObject ViewObject = null;
            IntPtr pViewObject = IntPtr.Zero;
            //内存图  
            Bitmap pPicture = new Bitmap(bmpRect.Width, bmpRect.Height);
            Graphics hDrawDC = Graphics.FromImage(pPicture);
            //获取接口  
            object hret = Marshal.QueryInterface(Marshal.GetIUnknownForObject(pUnknown),
                ref UnsafeNativeMethods.IID_IViewObject, out pViewObject);
            try
            {
                ViewObject = Marshal.GetTypedObjectForIUnknown(pViewObject, typeof(UnsafeNativeMethods.IViewObject)) as UnsafeNativeMethods.IViewObject;
                //调用Draw方法  
                ViewObject.Draw((int)DVASPECT.DVASPECT_CONTENT,
                    -1,
                    IntPtr.Zero,
                    null,
                    IntPtr.Zero,
                    hDrawDC.GetHdc(),
                    new NativeMethods.COMRECT(bmpRect),
                    null,
                    IntPtr.Zero,
                    0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            //释放  
            hDrawDC.Dispose();
            return pPicture;
        }
    }

    /// <summary>  
    /// 从 .Net 2.0 的 System.Windows.Forms.Dll 库提取  
    /// 版权所有：微软公司  
    /// </summary>  
    internal static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagDVTARGETDEVICE
        {
            [MarshalAs(UnmanagedType.U4)]
            public int tdSize;
            [MarshalAs(UnmanagedType.U2)]
            public short tdDriverNameOffset;
            [MarshalAs(UnmanagedType.U2)]
            public short tdDeviceNameOffset;
            [MarshalAs(UnmanagedType.U2)]
            public short tdPortNameOffset;
            [MarshalAs(UnmanagedType.U2)]
            public short tdExtDevmodeOffset;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class COMRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public COMRECT()
            {
            }

            public COMRECT(Rectangle r)
            {
                this.left = r.X;
                this.top = r.Y;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }

            public COMRECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public static NativeMethods.COMRECT FromXYWH(int x, int y, int width, int height)
            {
                return new NativeMethods.COMRECT(x, y, x + width, y + height);
            }

            public override string ToString()
            {
                return string.Concat(new object[] { "Left = ", this.left, " Top ", this.top, " Right = ", this.right, " Bottom = ", this.bottom });
            }

        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagLOGPALETTE
        {
            [MarshalAs(UnmanagedType.U2)]
            public short palVersion;
            [MarshalAs(UnmanagedType.U2)]
            public short palNumEntries;
        }
    }

    /// <summary>  
    /// 从 .Net 2.0 的 System.Windows.Forms.Dll 库提取  
    /// 版权所有：微软公司  
    /// </summary>  
    [SuppressUnmanagedCodeSecurity]
    internal static class UnsafeNativeMethods
    {
        public static Guid IID_IViewObject = new Guid("{0000010d-0000-0000-C000-000000000046}");

        [ComImport, Guid("0000010d-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IViewObject
        {
            [PreserveSig]
            int Draw([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [In] NativeMethods.tagDVTARGETDEVICE ptd, IntPtr hdcTargetDev, IntPtr hdcDraw, [In] NativeMethods.COMRECT lprcBounds, [In] NativeMethods.COMRECT lprcWBounds, IntPtr pfnContinue, [In] int dwContinue);
            [PreserveSig]
            int GetColorSet([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [In] NativeMethods.tagDVTARGETDEVICE ptd, IntPtr hicTargetDev, [Out] NativeMethods.tagLOGPALETTE ppColorSet);
            [PreserveSig]
            int Freeze([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [Out] IntPtr pdwFreeze);
            [PreserveSig]
            int Unfreeze([In, MarshalAs(UnmanagedType.U4)] int dwFreeze);
            void SetAdvise([In, MarshalAs(UnmanagedType.U4)] int aspects, [In, MarshalAs(UnmanagedType.U4)] int advf, [In, MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink);
            void GetAdvise([In, Out, MarshalAs(UnmanagedType.LPArray)] int[] paspects, [In, Out, MarshalAs(UnmanagedType.LPArray)] int[] advf, [In, Out, MarshalAs(UnmanagedType.LPArray)] IAdviseSink[] pAdvSink);
        }
    }
    #endregion   
}
