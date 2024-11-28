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
});