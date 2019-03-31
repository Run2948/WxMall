// pages/details/details.js
import WxParse from '../../wxParse/wxParse.js';
import util from '../../utils/util.js';
const app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    hostUrl: app.globalData.hostUrl,
    showModel: true,
    showCeng: true,
    quantity: 1,
    stock: 0,
  },
  closeAllLayer: function() {
    this.setData({
      showModel: true,
      showCeng: true
    })
  },
  chooseModel: function() {
    this.setData({
      showCeng: false,
      showModel: false
    })
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    var that = this;
    that.setData({
      id: options.id,
    });
    that.getInfo(options); //读取详细
  },
  getInfo: function(options) { //读取详细
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getProductInfo',
        id: options.id,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            model: res.data,
            stock: res.data.stock,
            content: WxParse.wxParse('content', 'html', res.data.content, that),
            minprice: (res.data.marketPrice - res.data.price).toFixed(2),
          })
          wx.setNavigationBarTitle({
            title: res.data.name
          });
        }
      }
    })
  },
  cart: function(e) { //加入购物车
    var that = this;
    var id = e.currentTarget.dataset.id;
    var userId = wx.getStorageSync('userId');
    if (userId != null && userId > 0 && userId != '') {
      that.addCart(id, userId, that.data.quantity, 1, e.currentTarget.dataset.unit);
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
  book: function(e) { //立即购买
    var that = this;
    var id = e.currentTarget.dataset.id;
    var userId = wx.getStorageSync('userId');
    if (userId != null && userId > 0 && userId != '') {
      that.addCart(id, userId, that.data.quantity, 2, e.currentTarget.dataset.unit);
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
  addCart: function(id, userId, quantity, isChecked, unit) { //读取详细
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'addCart',
        id: id,
        userId: userId,
        quantity: quantity,
        isChecked: isChecked,
        unit: unit,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          if (res.data.status == 0 && isChecked == 1) {
            wx.showToast({
              title: '加入成功',
              icon: 'success',
              duration: 2000
            })
          } else if (res.data.status == 0 && isChecked == 2) {
            wx.navigateTo({
              url: '/pages/con_order/con_order',
            })
          } else {
            wx.showToast({
              title: '失败',
              icon: 'error',
              duration: 2000
            })
          }
        }
      }
    })
  },
  jian: function(e) { //减
    var that = this;
    if (that.data.quantity > 1) {
      that.setData({
        quantity: that.data.quantity - 1,
      })
    } else {
      wx.showToast({
        title: '数量不能为0',
        icon: 'error',
        duration: 2000
      })
    }
  },
  jia: function(e) { //加
    var that = this;
    if (that.data.quantity < that.data.stock) {
      that.setData({
        quantity: that.data.quantity + 1,
      })
    } else {
      wx.showToast({
        title: '库存不足',
        icon: 'error',
        duration: 2000
      })
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