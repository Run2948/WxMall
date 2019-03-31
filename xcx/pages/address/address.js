// pages/address/address.js
const app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    hostUrl: app.globalData.hostUrl,
    consignee: '',
    cellphone: '',
    address: '',
    id: 0,
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    var that = this;
    if (options.id > 0) {
      that.getAddress(options.id);
    }
  },
  getAddress: function (id) { //读取地址
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getAddress',
        userId: wx.getStorageSync('userId'),
        id: id,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function (res) {
        if (res.data != null) {
          that.setData({
            consignee: res.data.consignee,
            cellphone: res.data.cellphone,
            address: res.data.address,
            id: res.data.id,
          })
        }
      }
    })
  },
  formSubmit: function (e) { //提交
    var that = this;
    if (e.detail.value.consignee.length == 0 || e.detail.value.cellphone.length == 0) {
      wx.showToast({
        title: '不得为空!',
        icon: 'loading',
        duration: 1500
      })
    } else {
      wx.request({
        url: app.globalData.apiUrl, //接口地址
        data: {
          opt: 'addAddress',
          userId: wx.getStorageSync('userId'),
          id: e.detail.value.id,
          consignee: e.detail.value.consignee,
          cellphone: e.detail.value.cellphone,
          address: e.detail.value.address,
          is_default: 0,
        },
        header: {
          'content-type': 'application/json'
        },
        success: function (res) {
          if (res.data.status == 0) {
            wx.showToast({
              title: '提交成功!', //这里打印出登录成功
              icon: 'success',
              duration: 1000,
              success: function () {
                wx.redirectTo({
                  url: '/pages/selectAddress/selectAddress',
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
    }
  },
  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  }
})