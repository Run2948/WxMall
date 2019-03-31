// pages/order/order.js
const app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    hostUrl: app.globalData.hostUrl,
    typeId: 0,
    switchTab: true,
    switchTabOne: false,
    switchTabTwo: false,
    switchTabThree: false,
    switchTabFour: false,
    keyWord: '',
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {

  },
  getOrderList: function() { //读取订单
    var that = this;
    var where = "";
    if (that.data.switchTab) {
      where = "";
    }
    if (that.data.switchTabOne) {
      where = "is_payment=0 and ";
    }
    if (that.data.switchTabTwo) {
      where = "is_payment=1 and is_transaction=0 and ";
    }
    if (that.data.switchTabThree) {
      where = "is_payment=1 and is_transaction=1 and ";
    }
    if (that.data.switchTabFour) {
      where = "order_status=1 and ";
    }
    if (that.data.keyWord.length > 0) {
      where = where + " order_num='" + that.data.keyWord + "' and ";
    }
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getOrderList',
        userId: wx.getStorageSync('userId'),
        where: where,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            orderList: res.data,
          })
        }
      }
    })
  },
  switchTab: function(e) {
    var that = this;
    if (e.currentTarget.dataset.order == 0) {
      that.setData({
        page: 0,
        orderList: [],
        switchTab: true,
        switchTabOne: false,
        switchTabTwo: false,
        switchTabThree: false,
        switchTabFour: false,
      }, function() {
        that.getOrderList();
      });
    } else if (e.currentTarget.dataset.order == 1) {
      that.setData({
        page: 0,
        orderList: [],
        switchTab: false,
        switchTabOne: true,
        switchTabTwo: false,
        switchTabThree: false,
        switchTabFour: false,
      }, function() {
        that.getOrderList();
      });

    } else if (e.currentTarget.dataset.order == 2) {
      that.setData({
        page: 0,
        orderList: [],
        switchTab: false,
        switchTabOne: false,
        switchTabTwo: true,
        switchTabThree: false,
        switchTabFour: false,
      }, function() {
        that.getOrderList();
      });

    } else if (e.currentTarget.dataset.order == 3) {
      that.setData({
        page: 0,
        orderList: [],
        switchTab: false,
        switchTabOne: false,
        switchTabTwo: false,
        switchTabThree: true,
        switchTabFour: false,
      }, function() {
        that.getOrderList();
      });

    } else if (e.currentTarget.dataset.order == 4) {
      that.setData({
        page: 0,
        orderList: [],
        switchTab: false,
        switchTabOne: false,
        switchTabTwo: false,
        switchTabThree: false,
        switchTabFour: true,
      }, function() {
        that.getOrderList();
      });

    }
  },
  //输入内容时
  searchActiveChangeinput: function(e) {
    var that = this;
    const val = e.detail.value;
    that.setData({
      keyWord: val,
    }, function() {});
  },
  //搜索提交
  searchSubmit: function() {
    this.getOrderList();
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
    var userId = wx.getStorageSync('userId');
    if (userId != null && userId > 0 && userId != '') {
      that.getOrderList(); //读取订单
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