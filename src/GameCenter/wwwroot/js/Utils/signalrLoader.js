(function () {
    var initSignalr = function (callback) {

        window.utils.signalr.callback = callback;

        if (!window.utils.signalr.loaded) {
            var url = '/';

            console.log('begin loading signalr libs');
            [
                //{ url: 'js/lib/jquery.min.js', check: function() { return !window.jQuery } },
                { url: 'js/lib/jquery.signalr.min.js' },
                { url: 'signalr/hubs' },
                { url: 'js/app/conversation.js?_=' + new Date().getTime() },
            ].forEach(function(item) {
                var isCss = item.isCss || false;
                if (item.check && !item.check()) {
                    return;
                }
                var element = document.createElement(isCss ? "link" : "script");
                if (isCss) {
                    element.setAttribute('href', url + item.url);
                    element.setAttribute('media', 'all');
                    element.setAttribute('rel', 'stylesheet');
                    element.setAttribute('type', 'text/css');
                } else {
                    element.type = "text/javascript";
                    element.setAttribute('src', url + item.url);
                    element.async = false;
                }
                element.onload = function() {
                    console.log(this);
                }
                var head = document.getElementsByTagName("head")[0];
                (head || document.body).appendChild(element);
            });

            window.utils.signalr.loaded = true;
            console.log('end  loading signalr libs');
        } else {
            console.log('signalr already loaded, continue to callback');
            if (callback)
                callback();
        }
        
    }

    if (window.utils)
        return;

    window.utils = {
        signalr: {
            init: initSignalr,
            loaded : false
        }
    }
})()