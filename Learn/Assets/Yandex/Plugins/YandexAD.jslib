mergeInto(LibraryManager.library, {

    Hello: function () {
        window.alert("Hello, world!");
        console.log("Hello world");
    },

    GetPlayerData: function () {
        myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
        myGameInstance.SendMessage('Yandex', 'SetIcon', player.getPhoto('large'));
    },

    SaveExtern: function (date) {
        var dateString = UTF8ToString(date);
        var myObject = JSON.parse(dateString);
        player.setData(myObject);
    },

    LoadExtern: function () {
        player.getData().then(_date => {
            const myJSON = JSON.stringify(_date);
            myGameInstance.SendMessage("Progress", "SetPlayerInfo", myJSON);
        });
    },
});