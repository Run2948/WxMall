// pages/goods_list/goods_list.js
const app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    hostUrl: app.globalData.hostUrl,
    indicatorDots: true,
    autoplay: true,
    interval: 5000,
    duration: 1000,
    productList: [],
    page: 0, //页码
    winHeight: "", //窗口高度
    currentTab: 0, //预设当前项的值
    scrollLeft: 0, //tab标题的滚动条位置
    isGet: true, //是否可以请求
    hidden: true, //加载弹框显示 
    typeId: '',
    switchTabOne: true,
    switchTabTwo: false,
    switchTabThree: false,
    switchTabFour: false,
    switchTabFive: false,
    word: app.globalData.word,
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    if (options.typeId) {
      app.globalData.typeId = options.typeId;
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
  onShow: function(options) {
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
          productList: [],
        });

      }
    });
    this.getProductList(); //列表
  },
  getProductList: function() { //读取列表
    var that = this;
    var page = that.data.page + 1;
    this.setData({
      hidden: false,
      isGet: false,
    });
    var where = '1=1 ';
    if (app.globalData.word != '') {
      where = where + " and name like '%" + app.globalData.word + "%'";
    }
    if (app.globalData.typeId != '') {
      where = where + "and typeId =" + app.globalData.typeId;
    }
    var order = '';
    if (that.data.switchTabOne) {
      order = ' ';
    }
    if (that.data.switchTabTwo) {
      order = '';
    }
    if (that.data.switchTabThree) {
      order = order + ' price asc,';
    }
    if (that.data.switchTabFour) {
      order = order + 'sales desc,';
    }
    if (that.data.switchTabFive) {
      order = order + 'createdTime desc,';
    }
    wx.request({
      url: app.globalData.apiUrl,
      data: {
        opt: 'getProductPageList',
        orderBy: order,
        where: where,
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
              productList: list,
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
  switchTab: function(e) {
    var that = this;
    if (e.currentTarget.dataset.order == 1) {
      that.setData({
        page: 0,
        productList: [],
        switchTabOne: true,
        switchTabTwo: false,
        switchTabThree: false,
        switchTabFour: false,
        switchTabFive: false,
      }, function() {
        that.getProductList();
      });
    } else if (e.currentTarget.dataset.order == 2) {
      that.setData({
        page: 0,
        productList: [],
        switchTabOne: false,
        switchTabTwo: true,
        switchTabThree: false,
        switchTabFour: false,
        switchTabFive: false,
      }, function() {
        that.getProductList();
      });

    } else if (e.currentTarget.dataset.order == 3) {
      that.setData({
        page: 0,
        productList: [],
        switchTabOne: false,
        switchTabTwo: false,
        switchTabThree: true,
        switchTabFour: false,
        switchTabFive: false,
      }, function() {
        that.getProductList();
      });

    } else if (e.currentTarget.dataset.order == 4) {
      that.setData({
        page: 0,
        productList: [],
        switchTabOne: false,
        switchTabTwo: false,
        switchTabThree: false,
        switchTabFour: true,
        switchTabFive: false,
      }, function() {
        that.getProductList();
      });

    } else if (e.currentTarget.dataset.order == 5) {
      that.setData({
        page: 0,
        productList: [],
        switchTabOne: false,
        switchTabTwo: false,
        switchTabThree: false,
        switchTabFour: false,
        switchTabFive: true,
      }, function() {
        that.getProductList();
      });

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