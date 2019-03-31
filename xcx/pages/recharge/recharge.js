// pages/recharge/recharge.js
const app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    indicatorDots: true,
    autoplay: true,
    interval: 5000,
    duration: 1000,
    list: [],
    page: 0, //页码
    winHeight: "", //窗口高度
    currentTab: 0, //预设当前项的值
    scrollLeft: 0, //tab标题的滚动条位置
    isGet: true, //是否可以请求
    hidden: true, //加载弹框显示 
    price: 10,
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    var that = this;
    var userId = wx.getStorageSync('userId');
    if (userId != null && userId > 0 && userId != '') {
      that.getUser(userId); //读取会员
    }
  },
  getUser: function(userId) { //读取会员
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getUser',
        userId: userId,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            user: res.data,
            canIUse: false,
          })
        }
      }
    })
  },
  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function() {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function() {
    var that = this;
    //  高度自适应
    wx.getSystemInfo({
      success: function(res) {
        var clientHeight = res.windowHeight,
          clientWidth = res.windowWidth,
          rpxR = 750 / clientWidth;
        var calc = clientHeight * rpxR - 180;
        that.setData({
          winHeight: calc,
          scrollHeight: res.windowHeight,
          page: 0,
          list: [],
        });

      }
    });
    this.getList(); //列表
  },
  getList: function() { //读取列表
    var that = this;
    var page = that.data.page + 1;
    this.setData({
      hidden: false,
      isGet: false,
    });
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getUserIntegralList',
        userId: wx.getStorageSync('userId'),
        page: page,
        size: 8,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data) {
          var list = that.data.productList;
          var newList = res.data;
          if (newList.length > 0) {
            for (var i in newList) {
              list.push(newList[i]);
            }
            that.setData({
              list: list,
              isGet: true,
              hidden: true,
              page: page,
            });
          }
        } else {
          that.setData({
            isGet: false,
            hidden: true,
          })
        }

      }
    });
  },
  //页面滑动到底部
  bindDownLoad: function() {
    if (this.data.isGet) {
      this.getProductList();
    }
  },
  //打开积分兑换
  openGift: function() {
    wx.navigateTo({
      url: '/pages/gift_list/gift_list',
    })
  },
  //选择充值金额
  selectMoney: function(e) {
    var price = e.currentTarget.dataset.price;
    var that = this;
    that.setData({
      price: price,
    }, function() {

    })
  },
  //充值
  recharge: function() {
    var that = this;
    console.log(that.data.price)
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'addUserRecharge',
        userId: wx.getStorageSync('userId'),
        price: that.data.price,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data.status > 0) {
          wx.request({
            url: app.globalData.apiUrl,
            data: {
              opt: 'GetUnifiedOrderResult',
              userId: wx.getStorageSync('userId'),
              id: res.data.status,
              typeId: 2,
            },
            header: {
              'content-type': 'application/json'
            },
            success: function(resOrderResult) {
              if (resOrderResult.data != null) {
                console.log(resOrderResult.data)
                wx.requestPayment({
                  'timeStamp': resOrderResult.data.timeStamp,
                  'nonceStr': resOrderResult.data.nonceStr,
                  'package': resOrderResult.data.package,
                  'signType': 'MD5',
                  'paySign': resOrderResult.data.paySign,
                  'success': function(res) {
                    wx.redirectTo({
                      url: '/pages/bag/bag',
                    })
                  },
                  'fail': function(res) {
                    wx.redirectTo({
                      url: '/pages/recharge/recharge',
                    })
                  },
                  'complete': function(res) {
                    wx.redirectTo({
                      url: '/pages/bag/bag',
                    })
                  }
                })
              }
            }
          })
        }
      }
    })
  },
  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function() {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function() {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function() {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function() {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function() {

  }
})