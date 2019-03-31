// pages/selectAddress/selectAddress.js
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
      that.getAddressList();


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
  getAddressList: function() { //读取收货地址
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getAddressList',
        userId: wx.getStorageSync('userId'),
        where: '',
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            addressList: res.data,
          })
        }
      }
    })
  },
  addAddress: function() {
    wx.redirectTo({
      url: '/pages/address/address?id=0',
    })
  },
  edit: function(e) {
    var id = e.currentTarget.dataset.id;
    wx.redirectTo({
      url: '/pages/address/address?id=' + id,
    })
  },
  delete: function(e) {
    var that = this;
    var id = e.currentTarget.dataset.id;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'deleteAddress',
        id: id,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data.status == 0) {
          wx.showToast({
            title: '成功!', //这里打印出登录成功
            icon: 'success',
            duration: 1000,
            success: function() {
              that.getAddressList();
            }
          })
        } else {
          wx.showToast({
            title: '提交失败!',
            icon: 'loading',
            duration: 1500
          })
        }
      }
    })
  },
  radio: function(e) {
    var that = this;
    var id = e.currentTarget.dataset.id;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'defaultAddress',
        id: id,
        userId: wx.getStorageSync('userId'),
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data.status == 0) {
          wx.showToast({
            title: '成功!', //这里打印出登录成功
            icon: 'success',
            duration: 1000,
            success: function() {
              wx.redirectTo({
                url: '/pages/con_order/con_order',
              })
            }
          })
        } else {
          wx.showToast({
            title: '提交失败!',
            icon: 'loading',
            duration: 1500
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