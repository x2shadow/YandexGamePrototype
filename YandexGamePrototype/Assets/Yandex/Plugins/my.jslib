mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
    console.log("Hello World! X2");
  },

  GiveMePlayerData: function () {
    console.log("Player Name: "  + player.getName());
    console.log("Player Photo: " + player.getPhoto("medium"));

    myGameInstance.SendMessage("Yandex", "SetName",  player.getName());
    myGameInstance.SendMessage("Yandex", "SetPhoto", player.getPhoto("medium"));
  },

  RateGame: function () {
    console.log("Rate game!");

    ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
  },

  SaveExtern: function (data) {
    var dataString = UTF8ToString(data);
    var myobj = JSON.parse(dataString);
    player.setData(myobj);
  },

  LoadExtern: function () {
    player.getData().then(data => {
      const myJSON = JSON.stringify(data);
      myGameInstance.SendMessage("Progress", "SetPlayerInfo", myJSON);
    })
  },

  SetToLeaderboard : function (value) {
    ysdk.getLeaderboards()
      .then(lb => {
        lb.setLeaderboardScore("Height", value);
      })
  },

  GetLanguage : function () {
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
  },
});