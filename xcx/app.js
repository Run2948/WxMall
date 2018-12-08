//app.js
App({
  onLaunch: function () {
    // 展示本地存储能力
    var logs = wx.getStorageSync('logs') || []
    logs.unshift(Date.now())
    wx.setStorageSync('logs', logs)

    // 获取用户信息
    wx.getSetting({
      success: res => {
        if (res.authSetting['scope.userInfo']) {
          // 已经授权，可以直接调用 getUserInfo 获取头像昵称，不会弹框
          wx.getUserInfo({
            success: res => {
              // 可以将 res 发送给后台解码出 unionId
              this.globalData.userInfo = res.userInfo
              // 由于 getUserInfo 是网络请求，可能会在 Page.onLoad 之后才返回
              // 所以此处加入 callback 以防止这种情况
              if (this.userInfoReadyCallback) {
                this.userInfoReadyCallback(res)
              }
            }
          })
        }else{
          
        }
      }
    });
    var userId = wx.getStorageSync('userId');
    if (userId == null || userId <= 0) {
      this.getUserLogin();
    }
   
  },
  getUserLogin: function (callback) {
    var that = this;
    // 登录
    wx.login({
      success: res => {
        // 发送 res.code 到后台换取 openId, sessionKey, unionId
        if (res.code) {
          wx.getUserInfo({
            withCredentials:false,
            success: resUserInfo => {
              if (resUserInfo) {
                that.globalData.userInfo = resUserInfo.userInfo
                //发起网络请求
                wx.request({
                  url: that.globalData.apiUrl,
                  data: {
                    code: res.code,
                    opt: 'onLogin'
                  },
                  header: {
                    'content-type': 'application/json'
                  },
                  success: function (res) {
                    wx.request({
                      url: that.globalData.apiUrl,
                      data: {
                        opt: 'addUser',
                        openid: res.data.openid,
                        nickName: resUserInfo.userInfo.nickName,
                        gender: resUserInfo.userInfo.gender,
                        avatarUrl: resUserInfo.userInfo.avatarUrl,
                      },
                      header: {
                        'content-type': 'application/json'
                      },
                      success: function (resAddUser) {
                        if (resAddUser.data) {
                          console.log(JSON.stringify(resAddUser.data));
                          that.globalData.userId = resAddUser.data.userId;
                          wx.setStorage({
                            key: "userId",
                            data: resAddUser.data.userId
                          })
                          wx.setStorage({
                            key: "userInfo",
                            data: resUserInfo.userInfo
                          })
                          callback(resAddUser.data.userId)
                        }
                      }
                    });//创建会员
                  }
                })
              }
            },
          })

        } else {
          console.log('登录失败！' + res.errMsg)
        }
      }
    });
    // end登录
  },
  globalData: {
    userId: 0,
    userInfo: null,
    word: '',
    typeId:'',
    apiUrl: 'https://lxshenghuo.sulel.com/api/xcx/index.aspx',
    hostUrl: 'https://lxshenghuo.sulel.com',
  }
})