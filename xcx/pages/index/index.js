//index.js
//获取应用实例
const app = getApp()
Page({
  data: {
    imgUrls: [
     
    ],
    imgBanner:[],
    hostUrl: app.globalData.hostUrl,
    word: app.globalData.word,
    indicatorDots: true,
    autoplay: true,
    interval: 3000,
    duration: 500,
  },
  onShow: function () {
    // 生命周期函数--监听页面显示
    var that = this;
    //  高度自适应
    wx.getSystemInfo({
      success: function (res) {
        var clientHeight = res.windowHeight,
          clientWidth = res.windowWidth,
          rpxR = 750 / clientWidth;
        var calc = clientHeight * rpxR - 180;
        that.setData({
          winHeight: calc,
          scrollHeight: res.windowHeight,
          page: 0,
          merchants: [],
        });
      }
    });
    that.getBanner(1);//读取首页banner
    that.getBannerType(2);//读取广告
    that.getArticlePage();//读取公告
    that.getProductIsRecommend();//读取店长推荐
    that.getProductOne();//读取产品
    that.getProductTwo();//读取产品
    that.getProductThree();//读取产品
    that.getProductFour();//读取产品
  },
  getBanner: function (typeId) {//读取首页banner
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getBanner',
        typeId: typeId,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function (res) {
        if (res.data != null) {
          if(typeId=1){
          that.setData({
            imgUrls: res.data,
          })
          }else if(typeId=2){
            that.setData({
              imgBanner: res.data,
            })
          }
        }
      }
    })
  },
  getBannerType: function (typeId) {//读取广告
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getBanner',
        typeId: typeId,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function (res) {
        if (res.data != null) {
            that.setData({
              imgBanner: res.data,
            })
        }
      }
    })
  },
  getArticlePage: function (typeId) {//读取公告
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getArticlePage',
        classId: 93,
        page:1,
        size:46,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function (res) {
        if (res.data != null) {
          that.setData({
            newList: res.data,
          })
        }
      }
    })
  },
  getProductIsRecommend: function () {//读取产品推荐
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getProductPageList',
        where: "isRecommend=1",
        page: 1,
        size: 3,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function (res) {
        if (res.data != null) {
          that.setData({
            productIsRecommend: res.data,
          })
        }
      }
    })
  },
  getProductOne: function () {//读取产品
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getProductPageList',
        where: "typeId=1",
        page: 1,
        size: 3,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function (res) {
        if (res.data != null) {
          that.setData({
            productOne: res.data,
          })
        }
      }
    })
  },
  getProductTwo: function () {//读取产品
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getProductPageList',
        where: "typeId=2",
        page: 1,
        size: 3,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function (res) {
        if (res.data != null) {
          that.setData({
            productTwo: res.data,
          })
        }
      }
    })
  },
  getProductThree: function () {//读取产品
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getProductPageList',
        where: "typeId=3",
        page: 1,
        size: 3,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function (res) {
        if (res.data != null) {
          that.setData({
            productThree: res.data,
          })
        }
      }
    })
  },
  getProductFour: function () {//读取产品
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getProductPageList',
        where: "typeId=4",
        page: 1,
        size: 3,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function (res) {
        if (res.data != null) {
          that.setData({
            productFour: res.data,
          })
        }
      }
    })
  },
  //输入内容时
  searchActiveChangeinput: function (e) {
    const val = e.detail.value;
    app.globalData.word = val;
  },
  //搜索提交
  searchSubmit: function () {
    wx.navigateTo({
      url: '/pages/goods_list/goods_list'
    })
  },
  changeIndicatorDots: function (e) {
    this.setData({
      indicatorDots: !this.data.indicatorDots
    })
  },
  changeAutoplay: function (e) {
    this.setData({
      autoplay: !this.data.autoplay
    })
  },
  intervalChange: function (e) {
    this.setData({
      interval: e.detail.value
    })
  },
  durationChange: function (e) {
    this.setData({
      duration: e.detail.value
    })
  },
  onLoad: function () {
    // 查看是否授权
    wx.getSetting({
      success: function (res) {
        if (res.authSetting['scope.userInfo']) {
          // 已经授权，可以直接调用 getUserInfo 获取头像昵称
          wx.getUserInfo({
            success: function (res) {
              // console.log(res.userInfo)
              
            }
          })
        }
      }
    })
  },
  /**
    * 用户点击右上角分享
    */
  onShareAppMessage: function () {
    if (res.from === 'button') {
      // 来自页面内转发按钮
      console.log(res.target)
    }
    return {
      title: '链鲜社区生活馆',
      path: '/pages/index/index',
      success: function (res) {
        // 转发成功
      },
      fail: function (res) {
        // 转发失败
      }
    }
  },
  
  
})
