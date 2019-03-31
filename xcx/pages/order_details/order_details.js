// pages/order_details/order_details.js
const app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    hostUrl: app.globalData.hostUrl,
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    var that = this;
    var userId = wx.getStorageSync('userId');
    if (userId != null && userId > 0 && userId != '') {
      that.getOrderSubList(options.id); //读取订单
      that.getOrder(options.id); //读取订单
      that.getAddressList();
      that.getOrderSate(options.id);
    } else {
      wx.showModal({
        title: '温馨提示',
        content: '先登录',
        success: function(res) {
          if (res.confirm) {
            wx.navigateTo({
              url: '/pages/mine/mine',
            })
          } else if (res.cancel) {}
        }
      })
    }
  },
  getOrder: function(id) { //读取订单
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getOrder',
        id: id,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            order: res.data,
          })
        }
      }
    })
  },
  getOrderSubList: function(id) { //读取订单
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getOrderSubList',
        userId: wx.getStorageSync('userId'),
        id: id,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            orderSubList: res.data,
          })
        }
      }
    })
  },
  getAddressList: function() { //读取收货地址
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getAddressList',
        userId: wx.getStorageSync('userId'),
        where: ' and is_default=1',
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            address: res.data[0],
          })
        }
      }
    })
  },
  getOrderSate: function(id) { //读取订单
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getOrderSate',
        userId: wx.getStorageSync('userId'),
        id: id,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            orderStatus: res.data.status,
          })
        }
      }
    })
  },
  pay: function(e) {
    var id = e.currentTarget.dataset.id;
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'GetUnifiedOrderResult',
        userId: wx.getStorageSync('userId'),
        id: id,
        typeId: 1,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          console.log(res.data)
          wx.requestPayment({
            'timeStamp': res.data.timeStamp,
            'nonceStr': res.data.nonceStr,
            'package': res.data.package,
            'signType': 'MD5',
            'paySign': res.data.paySign,
            'success': function(res) {
              wx.navigateBack({
                url: '/pages/order/order',
              })
            },
            'fail': function(res) {},
            'complete': function(res) {}
          })
        }
      }
    })
  },
  canalOrder: function(e) {
    var id = e.currentTarget.dataset.id;
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'canalOrder',
        id: id,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          if (res.data.status == 0) {
            wx.showToast({
              title: '取消成功',
              icon: 'success',
              duration: 2000
            });
            that.getOrderSubList(id); //读取订单
            that.getOrder(id); //读取订单
            that.getAddressList();
            that.getOrderSate(id);
          } else {
            wx.showToast({
              title: '取消失败',
              icon: 'error',
              duration: 2000
            })
          }

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