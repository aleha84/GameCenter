(function () {
    console.log("conversation script start");

    $.connection.hub.logging = true;
    var hub = $.connection.conversationHub;

    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        console.log('Conversation hub initialized');

        hub.server.test();

        if (window.utils.signalr.callback)
            window.utils.signalr.callback();
    });

    

    console.log("conversation script running");
})()