// pages/cart/cart.js
const app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    hostUrl: app.globalData.hostUrl,
    selection: 1,
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    var that = this;
    var userId = wx.getStorageSync('userId');
    if (userId != null && userId > 0 && userId != '') {
      that.getCartList(); //读取购物车
      that.dTotal(); //读取金额
      that.getCountChecked(function(data) {}); //读取全选状态
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
  getCartList: function() { //读取购物车
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getCartList',
        userId: wx.getStorageSync('userId'),
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            cartList: res.data,
          })
        }
      }
    })
  },
  dTotal: function() { //读取金额
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'dTotal',
        userId: wx.getStorageSync('userId'),
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            dTotal: res.data.dTotal,
            marketPriceTotal: res.data.marketPriceTotal,
            quantity: res.data.quantity,
          })
        }
      }
    })
  },
  jian: function(e) { //减
    var that = this;
    var id = e.currentTarget.dataset.id;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'updateCart',
        id: id,
        type: 2,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          if (res.data.status == 0) {
            that.getCartList(); //读取购物车
            that.dTotal(); //读取金额
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
  jia: function(e) { //加
    var that = this;
    var id = e.currentTarget.dataset.id;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'updateCart',
        id: id,
        type: 1,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          if (res.data.status == 0) {
            that.getCartList(); //读取购物车
            that.dTotal(); //读取金额
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
  choice: function(e) { //选择
    var that = this;
    var id = e.currentTarget.dataset.id;
    var checkId = e.currentTarget.dataset.ischecked;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'choice',
        id: id,
        checkId: checkId,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          if (res.data.status == 0) {

            that.getCountChecked(function(data) {
              that.getCartList(); //读取购物车
              that.dTotal(); //读取金额
            }); //读取全选状态
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
  selection: function(e) { //全选
    var that = this;
    var id = e.currentTarget.dataset.id;
    var checkId = e.currentTarget.dataset.id;
    var selection = 1;
    if (checkId == 1) {
      selection = 2;
    }
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'selection',
        userId: wx.getStorageSync('userId'),
        checkId: checkId,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          if (res.data.status == 0) {
            that.setData({
              selection: selection,
            }, function() {
              that.getCartList(); //读取购物车
              that.dTotal(); //读取金额
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
  getCountChecked: function(callback) { //检查是否全选
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getCountChecked',
        userId: wx.getStorageSync('userId'),
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          if (res.data.status == 2) {
            that.setData({
              selection: 2,
            }, function() {
              callback(res.data.status)
            })
          } else if (res.data.status == 1 || res.data.status == 0) {
            that.setData({
              selection: 1,
            }, function() {
              callback(res.data.status)
            })
          }
        }
      }
    })
  },
  buyNow: function() {
    var that = this;
    that.getCountChecked(function(data) {
      if (data > 0) {
        wx.navigateTo({
          url: '/pages/con_order/con_order',
        })
      } else {
        wx.showModal({
          title: '温馨提示',
          content: '请选择商品',
          success: function(res) {
            if (res.confirm) {

            } else if (res.cancel) {}
          }
        })
      }
    });
  },
  delCart: function(e) { //删除
    var that = this;
    var id = e.currentTarget.dataset.id;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'deleteCart',
        id: id,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          if (res.data.status == 0) {
            that.getCartList(); //读取购物车
            that.dTotal(); //读取金额
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