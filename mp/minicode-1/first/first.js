var pageObject = {
  test: function (e) {
    console.log("test")
    wx.navigateTo({
      url: '/index/index',
    })
  },

}

Page(pageObject)