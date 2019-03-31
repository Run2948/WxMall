// pages/classification/classification.js
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
    // 生命周期函数--监听页面显示
    var that = this;
    that.getType(); //读取分类
  },
  getType: function() { //读取广告
    var that = this;
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getType',
        parentId: 0,
      },
      header: {
        'content-type': 'application/json'
      },
      success: function(res) {
        if (res.data != null) {
          that.setData({
            typeList: res.data,
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

  },
  //输入内容时
  searchActiveChangeinput: function(e) {
    const val = e.detail.value;
    app.globalData.word = val;
  },
  //搜索提交
  searchSubmit: function() {
    wx.navigateTo({
      url: '/pages/goods_list/goods_list'
    })
  },
})