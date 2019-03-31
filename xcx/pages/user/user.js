// pages/user/user.js
const app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    user: {
      headimgurl: '../../images/touxiang.png',
      username: '昵称昵称',
      userMoney: '',
      userscore: ''
    },
    canIUse: wx.canIUse('button.open-type.getUserInfo'),
    isPay: 0,
    isDelivery: 0,
    isReceiving: 0,
    isTransaction: 0,
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    // 生命周期函数--监听页面显示
    var that = this;
    var userId = wx.getStorageSync('userId');
    if (userId != null && userId > 0 && userId != '') {
      that.getUser(userId); //读取会员
      that.getOrderRed(userId)
      that.getOrderRedOne(userId)
      that.getOrderRedTwo(userId)
      that.getOrderRedThree(userId)
      that.getWebSite(); //读取站点信息
    }
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
  getOrderRed: function(userId) { //待支付
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getOrderRed',
        userId: userId,
        type: 1,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            isPay: res.data.status,
          })
        }
      }
    })
  },
  getOrderRedOne: function(userId) { //待支付
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getOrderRed',
        userId: userId,
        type: 2,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            isDelivery: res.data.status,
          })
        }
      }
    })
  },
  getOrderRedTwo: function(userId) { //待支付
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getOrderRed',
        userId: userId,
        type: 3,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            isReceiving: res.data.status,
          })
        }
      }
    })
  },
  getOrderRedThree: function(userId) { //待支付
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getOrderRed',
        userId: userId,
        type: 4,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            isTransaction: res.data.status,
          })
        }
      }
    })
  },
  getWebSite: function() { //读取站点信息
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getWebSite',
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            webSite: res.data,
          })
        }
      }
    })
  },
  calling: function(e) {
    var that = this;
    wx.makePhoneCall({
      phoneNumber: e.currentTarget.dataset.mobile,
      success: function() {
        console.log("拨打电话成功！")
      },
      fail: function() {
        console.log("拨打电话失败！")
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

  },
  bindGetUserInfo: function(e) {
    var that = this;
    if (e) {
      app.getUserLogin(function(data) {
        console.log(data)
        if (data) {
          that.getUser(data);
          that.setData({
            canIUse: false
          });
        }
      })
    }

  },
})